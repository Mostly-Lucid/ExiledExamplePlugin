using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ExampleExiledTutorial
{
    public class Config : IConfig // This is the config class, it inherits from IConfig so it can be used as a config
    {
        [Description("Enable or disable the whole plugin")] // This is a description of the config option, it will appear above the value in the config file
        public bool IsEnabled { get; set; } = true; // This is the name of the config option, and the default value

        [Description("Get additional infomation in the console")]
        public bool Debug { get; set; } = false; //bool means it can only be a true or a false value
        
        [Description("The amount of health that players will spawn with")]
        public int SpawnHealth { get; set; } = 75; // This is an integer, so it can only be a whole number
    }
}