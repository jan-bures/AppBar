using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;

namespace AppBarLib.Presenters
{
    internal class AppBarPresenter : BasePresenter<AppBar, AppBarView>
    {
        public AppBarPresenter(AppBar model, AppBarView view) : base(model, view)
        {
        }
    }
}