namespace TestApp.ArchUnitNetTests;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using Xunit;
using TestApp.Application.Services;
using TestApp.Infrastructure.Data;

using static ArchUnitNET.Fluent.ArchRuleDefinition;
using ArchUnitNET.xUnit;

public class DependencyRules
{

    // TIP: load your architecture once at the start to maximize performance of your tests
    private static readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(System.Reflection.Assembly.Load("TestApp"))
        .Build();

    private readonly IObjectProvider<IType> Applications = Types()
        .That()
        .ResideInNamespace("TestApp.Application")
        .As("Application");

    private readonly IObjectProvider<IType> Domain = Types()
        .That()
        .ResideInNamespace("TestApp.Domain")
        .As("Domain");

    private readonly IObjectProvider<IType> Infrastructure = Types()
        .That()
        .ResideInNamespace("TestApp.Infrastructure")
        .As("Infrastructure");

    private readonly IObjectProvider<Interface> ServiceInterfaces =
        Interfaces().That().HaveFullNameContaining("Service").As("Service Interfaces");

    [Fact]
    public void ApplicationLayerMustNotDependOnInfrastructure()
    {
        IArchRule exampleLayerShouldNotAccessForbiddenLayer = Types()
            .That()
            .Are(Applications)
            .Should()
            .NotDependOnAny(Infrastructure)
            .Because("it's forbidden");
        exampleLayerShouldNotAccessForbiddenLayer.Check(Architecture);
    }

    [Fact]
    public void ServiceClassesShouldHaveCorrectName()
    {
        Classes().That().AreAssignableTo(ServiceInterfaces).Should().HaveNameContaining("Service")
            .Check(Architecture);
    }

    [Fact]
    public void RepositoryInterfacesShouldHaveCorrectName()
    {
        Interfaces().That().ResideInNamespace("TestApp.Domain.Repositories").Should().HaveNameContaining("Repository")
            .Check(Architecture);
    }
}