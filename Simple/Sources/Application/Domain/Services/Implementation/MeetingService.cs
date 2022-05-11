using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.Errors.Implementation;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.Domain.Services.Implementation
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