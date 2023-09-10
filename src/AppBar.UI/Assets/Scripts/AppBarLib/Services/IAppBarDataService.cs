using AppBarLib.Models;

namespace AppBarLib.Services
{
    internal interface IAppBarDataService
    {
        /// <summary>
        /// Loads the app bar data.
        /// </summary>
        /// <returns>The app bar data.</returns>
        public AppBarData Load();

        /// <summary>
        /// Saves the app bar data.
        /// </summary>
        /// <param name="data">The app bar data.</param>
        public void Save(AppBarData data);
    }
}