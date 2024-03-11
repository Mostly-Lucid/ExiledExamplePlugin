using System;
using Exiled.API.Features;

namespace ExampleExiledTutorial
{
    public class Plugin : Plugin<Config> // This is the main class for the plugin, it inherits from Plugin<Config> so it can access the config
    {
        public override string Name => "ExampleExiledTutorial"; // Set name of the plugin
        public override string Author => "Lucid"; // Set name of the author
        public override Version Version => new(1, 0, 0); // Set the version of the plugin

        public EventHandler EventHandler; // The first EventHandler must match the name of the class in EventHandler.cs, the second can be whatever you want
        public static Plugin Instance { get; private set; } // This is a static reference to the plugin, so you can access it from anywhere, useful for when you need to access the config

        public override void OnEnabled() //while the plugin is enabled
        {
            Instance = this; // This sets the static reference to this instance of the plugin
            Exiled.Events.Handlers.Player.Spawned += EventHandler.OnSpawned; // This tells the server to run the OnSpawned method in EventHandler.cs when a player spawns
            Exiled.Events.Handlers.Player.Died += EventHandler.OnPlayerDied; // This tells the server to run the OnPlayerDied method in EventHandler.cs when a player dies
            base.OnEnabled(); // This calls the base method, which will run the Exiled API's OnEnabled method (ALWAYS RUN THIS)
        }

        public override void OnDisabled() //when the plugin is disabled
        {
            Exiled.Events.Handlers.Player.Spawned -= EventHandler.OnSpawned; // This tells the server to stop running the OnSpawned method in EventHandler.cs when a player spawns
            Exiled.Events.Handlers.Player.Died -= EventHandler.OnPlayerDied; // This tells the server to stop running the OnPlayerDied method in EventHandler.cs when a player dies
            EventHandler = null; // This sets the EventHandler variable to null, so it can be garbage collected
            Instance = null; // This sets the static reference to null, so it can be garbage collected
            base.OnDisabled(); // This calls the base method, which will run the Exiled API's OnDisabled method (ALWAYS RUN THIS)
        }
    }
}