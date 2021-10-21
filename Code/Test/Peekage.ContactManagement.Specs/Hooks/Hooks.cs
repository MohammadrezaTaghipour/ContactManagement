using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Peekage.ContactManagement.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container,
            ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
            RegisterConfiguration(container);
        }

        [BeforeScenario(Order = 0)]
        public void SetupStage()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility>
            {
                CallAnApi.At("localhost:5000/api")
            });

            var stage = new Stage(cast);
            stage.ShineSpotlightOn("Bob");
            _container.RegisterInstanceAs(stage);
        }


        private void RegisterConfiguration(IObjectContainer container)
        {
            var configuration = SettingsHelper.GetConfiguration();

            container.RegisterInstanceAs(configuration);
        }

    }
}
