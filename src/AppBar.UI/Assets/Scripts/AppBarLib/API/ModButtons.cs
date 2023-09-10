using AppBarLib.Models;
using AppBarLib.Services;
using JetBrains.Annotations;

namespace AppBarLib.API
{
    /// <summary>
    /// Place for mods to register their buttons.
    /// </summary>
    [PublicAPI]
    public class ModButtons
    {
        private readonly IModButtonService _service;

        internal ModButtons(IModButtonService service)
        {
            _service = service;
        }

        /// <summary>
        /// Register a mod button.
        /// </summary>
        /// <param name="button">The button to register.</param>
        public void Register(ModButton button)
        {
            _service.Register(button);
        }

        /// <summary>
        /// Unregister a mod button.
        /// </summary>
        /// <param name="button">The button to unregister.</param>
        public void Unregister(ModButton button)
        {
            _service.Unregister(button);
        }
    }
}