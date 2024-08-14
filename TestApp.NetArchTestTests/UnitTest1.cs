using NetArchTest.Rules;
using TestApp.Application.Services;

namespace TestApp.NetArchTestTests;

public class UnitTest1
{
    [Fact]
    public void ApplicationLayerMustNotDependOnInfrastructure()
    {
        var result = Types.InAssembly(typeof(UserService).Assembly)
            .That()
            .ResideInNamespace("TestApp.Application")
            .ShouldNot()
            .HaveDependencyOn("TestApp.Infrastructure")
            .GetResult();
        Assert.True(result.IsSuccessful, "Application should not depend on Interface.");

    }

    [Fact]
    public void ServiceClassesShouldHaveCorrectName()
    {
        var result = Types.InAssembly(typeof(UserService).Assembly)
            .That()
            .ResideInNamespace("TestApp.Application.Services")
            .Should()
            .HaveNameEndingWith("Service")
            .GetResult();
        Assert.True(result.IsSuccessful, "Services should have name ending with Service");

    }

    [Fact]
    public void RepositoryInterfacesShouldHaveCorrectName()
    {
        var result = Types.InAssembly(typeof(UserService).Assembly)
            .That()
            .ResideInNamespace("TestApp.Domain.Repositories")
            .Should()
            .HaveNameEndingWith("Repository")
            .GetResult();

        Assert.True(result.IsSuccessful, "Repositories should have name ending with Repository");
    }
}
