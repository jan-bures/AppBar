using System;

namespace AppBarLib.Core.Messaging
{
    /// <summary>
    /// A generic observable value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class Observable<T>
    {
        private T _value;

        /// <summary>
        /// The value of the observable.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                OnChange?.Invoke(_value, value);
                _value = value;
            }
        }

        /// <summary>
        /// Called when the value of the observable changes.
        /// The first parameter is the old value, the second parameter is the new value.
        /// </summary>
        public event Action<T, T> OnChange;

        /// <summary>
        /// Creates a new observable with the given value.
        /// </summary>
        /// <param name="value">The value of the observable.</param>
        public Observable(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the observable to its value.
        /// </summary>
        /// <param name="observable">The observable to convert.</param>
        /// <returns>The value of the observable.</returns>
        public static implicit operator T(Observable<T> observable)
        {
            return observable.Value;
        }
    }
}