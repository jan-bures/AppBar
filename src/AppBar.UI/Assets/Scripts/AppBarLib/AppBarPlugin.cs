#if UNITY_EDITOR

using AppBarLib.API;
using AppBarLib.Core;
using UnityEngine;

namespace AppBarLib
{
    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class AppBarPlugin : MonoBehaviour
    {
        #region MVC

        /// <summary>
        /// The context of the MVC framework.
        /// </summary>
        private readonly Context _context = new Context();

        /// <summary>
        /// The registry of all mod buttons.
        /// </summary>
        public ModButtonRegistry ModButtonRegistry => _context.ModButtonRegistry;

        #endregion

        #region Plugin

        /// <summary>
        /// The path to the plugin folder.
        /// </summary>
        public string PluginFolderPath { get; } = typeof(AppBarPlugin).Assembly.Location;

        /// <summary>
        /// The instance of the plugin.
        /// </summary>
        public static AppBarPlugin Instance { get; private set; }

        #endregion

        /// <summary>
        /// The constructor of the plugin.
        /// </summary>
        public AppBarPlugin()
        {
            Instance = this;
        }
    }
}

#endif