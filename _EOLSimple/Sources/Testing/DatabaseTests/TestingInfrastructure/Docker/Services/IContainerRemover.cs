using System.Threading.Tasks;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services
{
    public interface IContainerRemover
    {
        Task RemoveContainerAsync(string containerId);
    }
}