using System.Threading.Tasks;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services
{
    public interface IContainerStarter
    {
        Task<string> StartContainerAsync();
    }
}