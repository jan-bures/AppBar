using AppBarLib.Core.Messaging;
using AppBarLib.Models;

namespace AppBarLib.Messages
{
    internal class ModButtonUnregisteredMessage : IMessage
    {
        public ModButton Button { get; private set; }

        public ModButtonUnregisteredMessage(ModButton button)
        {
            Button = button;
        }
    }
}