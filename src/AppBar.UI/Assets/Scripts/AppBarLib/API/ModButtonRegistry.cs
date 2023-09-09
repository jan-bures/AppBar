using System;
using System.Collections.Generic;
using System.Linq;
using AppBarLib.Core.Messaging;
using AppBarLib.Messages;
using AppBarLib.Models;
using JetBrains.Annotations;

namespace AppBarLib.API
{
    /// <summary>
    /// Place for mods to register their buttons.
    /// </summary>
    [PublicAPI]
    public class ModButtonRegistry
    {
        private MessageCenter _messageCenter;

        private readonly Dictionary<string, ModButton> _buttons = new Dictionary<string, ModButton>();

        internal ModButtonRegistry(MessageCenter messageCenter)
        {
            _messageCenter = messageCenter;
        }

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

            _messageCenter.Publish(new ModButtonRegisteredMessage(button));
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

            _messageCenter.Publish(new ModButtonUnregisteredMessage(button));
        }

        [CanBeNull]
        internal ModButton GetById(string id)
        {
            _buttons.TryGetValue(id, out var button);
            return button;
        }

        internal IEnumerable<ModButton> FindByGameState(GameState state)
        {
            return _buttons.Values.Where(button => button.AllowedGameStates.Contains(state));
        }
    }
}