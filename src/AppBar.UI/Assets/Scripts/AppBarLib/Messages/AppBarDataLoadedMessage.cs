using AppBarLib.Core.Messaging;
using AppBarLib.Models;

namespace AppBarLib.Messages
{
    internal class AppBarDataLoadedMessage : IMessage
    {
        /// <summary>
        /// The app bar data that was loaded.
        /// </summary>
        public AppBarData Data { get; }

        /// <summary>
        /// Creates a new instance of the AppBarDataLoadedMessage class.
        /// </summary>
        /// <param name="data"></param>
        public AppBarDataLoadedMessage(AppBarData data)
        {
            Data = data;
        }
    }
}