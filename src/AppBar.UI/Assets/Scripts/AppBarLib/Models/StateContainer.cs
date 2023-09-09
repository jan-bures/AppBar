using System.Collections.Generic;
using AppBarLib.Core.Messaging;
using Newtonsoft.Json;

namespace AppBarLib.Models
{
    /// <summary>
    /// The container for all app bars in one game state.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class StateContainer
    {
        /// <summary>
        /// The game state.
        /// </summary>
        [JsonProperty("state")]
        public Observable<GameState> State { get; set; }

        /// <summary>
        /// The list of app bars.
        /// </summary>
        public List<AppBar> AppBars { get; set; }
    }
}