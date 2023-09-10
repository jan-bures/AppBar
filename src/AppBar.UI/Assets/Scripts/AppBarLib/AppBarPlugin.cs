#if UNITY_EDITOR

using System;
using AppBarLib.API;
using AppBarLib.Models;
using AppBarLib.Services;
using JetBrains.Annotations;
using UnityEngine;

namespace AppBarLib
{
    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class AppBarPlugin : MonoBehaviour
    {
        private readonly AppBarManager _manager;

        /// <summary>
        /// The path to the plugin folder.
        /// </summary>
        [UsedImplicitly]
        public string PluginFolderPath { get; } = typeof(AppBarPlugin).Assembly.Location;

        /// <summary>
        /// The instance of the plugin.
        /// </summary>
        [PublicAPI]
        public static AppBarPlugin Instance { get; private set; }

        /// <summary>
        /// The public API for registering mod buttons.
        /// </summary>
        [PublicAPI]
        public ModButtons ModButtons { get; }

        /// <summary>
        /// The constructor of the plugin.
        /// </summary>
        public AppBarPlugin()
        {
            Instance = this;

            _manager = new AppBarManager(PluginFolderPath);
            ModButtons = _manager.ModButtonsAPI;
        }

        private void Awake()
        {
            _manager.Initialize();
        }
    }
}

#endif