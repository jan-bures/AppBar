using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppBarLib.Models
{
    /// <summary>
    /// Represents all the app bar data.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AppBarData
    {
        /// <summary>
        /// List of app bar containers for each game state.
        /// </summary>
        [JsonProperty("gameStates")]
        public List<StateContainer> GameStates { get; set; } = new List<StateContainer>();
    }
}