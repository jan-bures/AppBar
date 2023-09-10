using System.Collections.Generic;
using System.Linq;
using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;
using UnityEngine.UIElements;

namespace AppBarLib.Presenters
{
    internal class StateContainerPresenter : BasePresenter<StateContainer, StateContainerView>
    {
        private List<AppBarPresenter> _appBarPresenters = new List<AppBarPresenter>();

        public StateContainerPresenter(StateContainer model, StateContainerView view) : base(model, view)
        {
            _appBarPresenters.AddRange(
                from appBar in Model.AppBars
                let appBarView = new AppBarView(new VisualElement())
                select new AppBarPresenter(appBar, appBarView)
            );
        }
    }
}