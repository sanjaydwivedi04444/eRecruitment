using System.Data.Common;

namespace eRecruitment.Application.FunctionalTests;
public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
