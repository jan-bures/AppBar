using AppBarLib.Core.Messaging;
using AppBarLib.Models;

namespace AppBarLib.Messages
{
    internal class ModButtonRegisteredMessage : IMessage
    {
        public ModButton Button { get; private set; }

        public ModButtonRegisteredMessage(ModButton button)
        {
            Button = button;
        }
    }
}