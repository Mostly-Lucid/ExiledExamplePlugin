using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace ExampleExiledTutorial
{
    public class EventHandler
    {
        //public means this can be accessed anywhere, void means it doesn't return anything, OnSpawned is the name of the method, SpawnedEventArgs much match the event in Plugin.cs, ev is the name of the variable that will be used to access the event
        public void OnSpawned(SpawnedEventArgs ev) 
        {
            // Code that you want to run when a player spawns goes inside these brackets
            Log.Info($"Player:{ev.Player.Nickname} has joined the server"); // This will log the player's name and the server's name to the console
            ev.Player.Health = Plugin.Instance.Config.SpawnHealth; // This will set the player's health to the value in the config, you can access the config from anywhere using Plugin.Instance.Config
        }
        
        public void OnPlayerDied(DiedEventArgs ev)
        {
            Log.Info($"Player:{ev.Player.Nickname} has died");
        }
    }
}