using AppBarLib.API;
using AppBarLib.Core.Messaging;

namespace AppBarLib.Core
{
    /// <summary>
    /// The context of the application.
    /// </summary>
    internal class Context
    {
        /// <summary>
        /// The central message bus of the application.
        /// </summary>
        public MessageCenter MessageCenter { get; } = new MessageCenter();

        /// <summary>
        /// The registry of mod buttons.
        /// </summary>
        public ModButtonRegistry ModButtonRegistry { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context()
        {
            ModButtonRegistry = new ModButtonRegistry(MessageCenter);
        }
    }
}