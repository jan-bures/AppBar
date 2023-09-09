using AppBarLib.Core;

namespace Scripts.AppBarLib.Core
{
    internal abstract class BasePresenter<TModel, TView> : IConcern
    {
        public Context Context { get; }

        protected readonly TModel Model;
        protected TView View;

        protected BasePresenter(Context context, TModel model, TView view)
        {
            Context = context;
            Model = model;
            View = view;
        }

        public bool IsInitialized { get; protected set; }

        public virtual void Initialize()
        {
            IsInitialized = true;
        }

        public virtual void Dispose()
        {
        }
    }
}