// See https://aka.ms/new-console-template for more information
using Ship.Components;
using Ship.Entities;
using Ship.EventSystem;
using Ship.Modules;
using Ship.Systems;

var powerSystem = new PowerSystem();
var IsToggleableSystem = new IsToggleableSystem();

var mainBreaker = new MainBreakerModule();
var powerSource = new GenericPowerSource();

var powerDrain = new Entity();
powerDrain.AddComponent<IsToggleableComponent>(new IsToggleableComponent());
powerDrain.AddComponent<ConsumesPowerComponent>(new ConsumesPowerComponent(500));

IsToggleableSystem.setState(mainBreaker, true);
IsToggleableSystem.setState(powerSource, true);
IsToggleableSystem.setState(powerDrain, true);

