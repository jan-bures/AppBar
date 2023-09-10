using AppBarLib.Core.Messaging;
using AppBarLib.Models;

namespace AppBarLib.Messages
{
    internal class ModButtonUnregisteredMessage : IMessage
    {
        /// <summary>
        /// The button that was unregistered.
        /// </summary>
        public ModButton Button { get; }

        /// <summary>
        /// Creates a new instance of the ModButtonUnregisteredMessage class.
        /// </summary>
        /// <param name="button">The button that was unregistered.</param>
        public ModButtonUnregisteredMessage(ModButton button)
        {
            Button = button;
        }
    }
}