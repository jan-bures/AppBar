using AppBarLib.Core.Messaging;
using AppBarLib.Models;

namespace AppBarLib.Messages
{
    internal class ModButtonRegisteredMessage : IMessage
    {
        /// <summary>
        /// The button that was registered.
        /// </summary>
        public ModButton Button { get; }

        /// <summary>
        /// Creates a new instance of the ModButtonRegisteredMessage class.
        /// </summary>
        /// <param name="button">The button that was registered.</param>
        public ModButtonRegisteredMessage(ModButton button)
        {
            Button = button;
        }
    }
}