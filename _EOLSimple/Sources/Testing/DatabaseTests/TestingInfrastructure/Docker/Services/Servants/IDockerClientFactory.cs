using Docker.DotNet;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services.Servants
{
    public interface IDockerClientFactory
    {
        IDockerClient Create();
    }
}