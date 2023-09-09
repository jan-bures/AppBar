using AppBarLib.Core;

namespace Scripts.AppBarLib.Core
{
    internal abstract class BaseModel : IConcern
    {
        protected BaseModel(Context context)
        {
            Context = context;
        }

        public bool IsInitialized { get; protected set; }

        public Context Context { get; }

        public virtual void Initialize()
        {
            IsInitialized = true;
        }

        public virtual void Dispose()
        {
        }
    }
}