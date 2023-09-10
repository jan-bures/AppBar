using System;
using System.Collections.Generic;

namespace AppBarLib.Core.Messaging
{
    /// <summary>
    /// The central message bus of the application.
    /// </summary>
    internal class MessageCenter
    {
        #region Delegates

        /// <summary>
        /// The message handler delegate.
        /// </summary>
        /// <typeparam name="T">The type of the message.</typeparam>
        public delegate void MessageHandler<in T>(T message) where T : IMessage;

        #endregion

        #region Fields

        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static MessageCenter Instance { get; } = new MessageCenter();

        private readonly Dictionary<Type, Delegate> _messageHandlers = new Dictionary<Type, Delegate>();

        #endregion

        #region Methods

        private MessageCenter()
        {
        }

        /// <summary>
        /// Subscribes to the message of the specified type.
        /// </summary>
        /// <param name="handler">The message handler.</param>
        /// <typeparam name="T">The type of the message.</typeparam>
        public void Subscribe<T>(MessageHandler<T> handler) where T : IMessage
        {
            if (_messageHandlers.TryGetValue(typeof(T), out var handlers))
            {
                _messageHandlers[typeof(T)] = Delegate.Combine(handlers, handler);
            }
            else
            {
                _messageHandlers[typeof(T)] = handler;
            }
        }

        /// <summary>
        /// Unsubscribes from the message of the specified type.
        /// </summary>
        /// <param name="handler">The message handler.</param>
        /// <typeparam name="T">The type of the message.</typeparam>
        public void Unsubscribe<T>(MessageHandler<T> handler) where T : IMessage
        {
            if (!_messageHandlers.TryGetValue(typeof(T), out var handlers))
            {
                return;
            }

            handlers = Delegate.Remove(handlers, handler);
            if (handlers != null)
            {
                _messageHandlers[typeof(T)] = handlers;
            }
            else
            {
                _messageHandlers.Remove(typeof(T));
            }
        }

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <typeparam name="T">The type of the message.</typeparam>
        public void Publish<T>(T message) where T : IMessage
        {
            if (_messageHandlers.TryGetValue(typeof(T), out var handlers))
            {
                ((MessageHandler<T>)handlers)(message);
            }
        }

        #endregion
    }
}