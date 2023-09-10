using System;
using System.Collections.Generic;
using System.Linq;
using AppBarLib.Core.Messaging;
using AppBarLib.Messages;
using AppBarLib.Models;
using JetBrains.Annotations;

namespace AppBarLib.Services
{
    internal class ModButtonService : IModButtonService
    {
        private static MessageCenter MessageCenter => MessageCenter.Instance;

        private readonly Dictionary<string, ModButton> _buttons = new Dictionary<string, ModButton>();

        /// <summary>
        /// Register a button.
        /// </summary>
        /// <param name="button">Button to register.</param>
        public void Register(ModButton button)
        {
            if (_buttons.ContainsKey(button.Id))
            {
                throw new ArgumentException($"Button with ID '{button.Id}' already registered.");
            }

            _buttons.Add(button.Id, button);

            MessageCenter.Publish(new ModButtonRegisteredMessage(button));
        }

        /// <summary>
        /// Unregister a button.
        /// </summary>
        /// <param name="button">Button to unregister.</param>
        public void Unregister(ModButton button)
        {
            if (!_buttons.ContainsKey(button.Id))
            {
                throw new ArgumentException($"Button with ID '{button.Id}' not registered.");
            }

            _buttons.Remove(button.Id);

            MessageCenter.Publish(new ModButtonUnregisteredMessage(button));
        }

        [CanBeNull]
        public ModButton GetById(string id)
        {
            _buttons.TryGetValue(id, out var button);
            return button;
        }

        public IEnumerable<ModButton> FindByGameState(GameState state)
        {
            return _buttons.Values.Where(button => button.AllowedGameStates.Contains(state));
        }
    }
}