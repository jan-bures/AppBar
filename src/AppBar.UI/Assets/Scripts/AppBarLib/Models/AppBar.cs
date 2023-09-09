using System.Collections.Generic;
using AppBarLib.Core;
using Newtonsoft.Json;
using Scripts.AppBarLib.Core;
using UnityEngine;

namespace AppBarLib.Models
{
    /// <summary>
    /// Represents a single app bar.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AppBar : BaseModel
    {
        /// <summary>
        /// Default name of a new app bar.
        /// </summary>
        public const string DefaultName = "APP.BAR";

        /// <summary>
        /// Name of the app bar.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = DefaultName;

        /// <summary>
        /// List of button IDs in the app bar.
        /// </summary>
        [JsonProperty("buttonIds")]
        public List<string> ButtonIds { get; set; } = new List<string>();

        /// <summary>
        /// Position of the app bar.
        /// </summary>
        [JsonProperty("position")]
        public Vector2 Position { get; set; } = new Vector2(Screen.width / 2f, Screen.height / 2f);

        /// <summary>
        /// Scale of the app bar.
        /// </summary>
        [JsonProperty("scale")]
        public float Scale { get; set; } = 1;

        /// <summary>
        /// Number of rows in the app bar.
        /// </summary>
        [JsonProperty("rowCount")]
        public int RowCount { get; set; } = 1;

        /// <summary>
        /// Whether the app bar automatically hides when positioned at the edge of the screen.
        /// </summary>
        [JsonProperty("autoHideAtEdge")]
        public bool AutoHideAtEdge { get; set; } = false;

        /// <summary>
        /// App bar constructor.
        /// </summary>
        /// <param name="context">MVC context.</param>
        public AppBar(Context context) : base(context)
        {
        }
    }
}