using System.Threading.Tasks;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services.Servants
{
    public interface IDockerContainerFinder
    {
        Task<Maybe<string>> TryFindingIdByNameAsync(string namepart);
    }
}