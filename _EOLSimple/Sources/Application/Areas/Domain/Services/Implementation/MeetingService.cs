using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Areas.Domain.Repositories;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors.Implementation;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;

namespace Mmu.CleanDddSimple.Areas.Domain.Services.Implementation
{
    [UsedImplicitly]
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public MeetingService(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Either<ServerError, IMeeting>> TryCreatingMeetingAsync(string name, string description, MeetingType type)
        {
            using var uow = _uowFactory.Create();

            var meetingRepo = uow.GetRepository<IMeetingRepository>();

            var meetingExists = await meetingRepo.ContainsAnyAsync(name);

            if (meetingExists)
            {
                return new GenericError($"Meeting with the name {name} already exists.");
            }

            var meeting = new Meeting(
                name,
                description,
                type);

            await meetingRepo.InsertAsync(meeting);
            await uow.SaveAsync();

            return meeting;
        }
    }
}