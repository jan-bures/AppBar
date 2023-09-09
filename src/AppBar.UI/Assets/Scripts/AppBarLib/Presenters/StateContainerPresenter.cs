using System.Collections.Generic;
using System.Linq;
using AppBarLib.Core;
using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;
using UnityEngine.UIElements;

namespace AppBarLib.Controllers
{
    internal class StateContainerPresenter : BasePresenter<StateContainer, StateContainerView>
    {
        private List<AppBarPresenter> _appBarControllers = new List<AppBarPresenter>();

        public StateContainerPresenter(Context context, StateContainer model, StateContainerView view)
            : base(context, model, view)
        {
        }

        public override void Initialize()
        {
            _appBarControllers.AddRange(
                from appBar in Model.AppBars
                let appBarView = new AppBarView(new VisualElement())
                select new AppBarPresenter(Context, appBar, appBarView)
            );

            base.Initialize();
        }
    }
}