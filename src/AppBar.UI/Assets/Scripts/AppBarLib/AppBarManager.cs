using System;
using AppBarLib.API;
using AppBarLib.Services;
using Scripts.AppBarLib.Core;

namespace AppBarLib
{
    internal class AppBarManager : IInitializable
    {
        #region Services

        private IAppBarDataService _appBarDataService;
        private IModButtonService _modButtonService;

        #endregion

        #region API

        public ModButtons ModButtonsAPI { get; }

        #endregion

        public AppBarManager(string rootPath)
        {
            _appBarDataService = new FileAppBarDataService(rootPath);
            _modButtonService = new ModButtonService();

            ModButtonsAPI = new ModButtons(_modButtonService);
        }

        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            if (IsInitialized)
            {
                throw new InvalidOperationException("Manager already initialized.");
            }

            IsInitialized = true;
        }
    }
}