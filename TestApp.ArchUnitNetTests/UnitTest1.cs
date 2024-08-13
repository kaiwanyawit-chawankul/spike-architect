namespace TestApp.ArchUnitNetTests;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using Xunit;
using TestApp.Application.Services;
using TestApp.Infrastructure.Data;

using static ArchUnitNET.Fluent.ArchRuleDefinition;
public class DependencyRules
    {
        [Fact]
        public void ApplicationLayerMustNotDependOnInfrastructure()
        {
            var assembly = typeof(UserService).Assembly;

            var typesFromApplication = Types.Of(assembly);
            var typesFromInfrastructure = Types.Of(typeof(UserRepository).Assembly);

            typesFromApplication.ShouldNotDependOn(typesFromInfrastructure);
        }
    }