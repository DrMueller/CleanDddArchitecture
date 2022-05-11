using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Data.SqlClient;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services.Implementation
{
    [UsedImplicitly]
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Simple check to see if DB is ready")]
    public class ContainerAwaiter : IContainerAwaiter
    {
        public async Task WaitUntilDataseAvailableAsync()
        {
            var start = DateTime.UtcNow;
            const int MaxWaitTimeSeconds = 60;
            var connectionEstablised = false;

            while (!connectionEstablised && start.AddSeconds(MaxWaitTimeSeconds) > DateTime.UtcNow)
            {
                try
                {
                    await using var sqlConnection = new SqlConnection(DockerConstants.ConnectionString);
                    await sqlConnection.OpenAsync();
                    connectionEstablised = true;
                }
                catch
                {
                    // If opening the SQL connection fails, SQL Server is not ready yet
                    await Task.Delay(500);
                }
            }

            if (!connectionEstablised)
            {
                throw new Exception("Connection to the SQL docker database could not be established within 60 seconds.");
            }
        }
    }
}