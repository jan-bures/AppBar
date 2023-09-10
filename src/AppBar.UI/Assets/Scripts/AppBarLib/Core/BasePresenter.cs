using AppBarLib.Core;

namespace Scripts.AppBarLib.Core
{
    internal abstract class BasePresenter<TModel, TView> : BaseConcern
    {
        protected readonly TModel Model;
        protected TView View;

        protected BasePresenter(TModel model, TView view)
        {
            Model = model;
            View = view;
        }
    }
}