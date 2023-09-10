using System;
using AppBarLib.Core.Messaging;
using Scripts.AppBarLib.Core;

namespace AppBarLib.Core
{
    internal class BaseConcern : IConcern
    {
        protected MessageCenter MessageCenter => MessageCenter.Instance;

        public bool IsInitialized { get; protected set; }

        public virtual void Initialize()
        {
            if (IsInitialized)
            {
                throw new InvalidOperationException("Object already initialized.");
            }

            IsInitialized = true;
        }

        public virtual void Dispose()
        {
        }
    }
}