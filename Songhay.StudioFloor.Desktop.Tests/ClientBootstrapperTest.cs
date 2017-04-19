using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using Prism.Modularity;
using Songhay.Extensions;
using System.Linq;

namespace Songhay.StudioFloor.Desktop.Tests
{
    [TestClass]
    public class ClientBootstrapperTest
    {
        [TestInitialize]
        public void InitializeTest()
        {
            this.TestContext.RemovePreviousTestResults();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ShouldConfigureModuleCatalog()
        {
            var projectsFolder = this.TestContext.ShouldGetSolutionFolder(this.GetType());
            this.TestContext.ShouldFindFolder(projectsFolder);

            var bootstrapper = new ClientBootstrapper();
            bootstrapper.Run();

            Assert.IsNotNull(bootstrapper.Container, "The expected IoC container is not here.");

            var eventAggregator = bootstrapper.Container.Resolve<IEventAggregator>();
            Assert.IsNotNull(eventAggregator, "The expected Prism Event Aggregator is not here.");

            var catalog = bootstrapper.Container.Resolve<IModuleCatalog>();
            Assert.IsNotNull(catalog, "The expected Prism Module Catalog is not here.");
            Assert.IsNotNull(catalog.Modules, "The expected Prism Module catalogs are not here.");
            Assert.IsTrue(catalog.Modules.Any(), "The expected Prism Module catalogs are not here.");

            catalog.Modules.ForEachInEnumerable(i => this.TestContext.WriteLine($"Module name: {i.ModuleName}"));
        }
    }
}
