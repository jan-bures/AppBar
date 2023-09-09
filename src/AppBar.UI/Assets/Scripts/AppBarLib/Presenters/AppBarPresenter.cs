using AppBarLib.Core;
using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;

namespace AppBarLib.Controllers
{
    internal class AppBarPresenter : BasePresenter<AppBar, AppBarView>
    {
        public AppBarPresenter(Context context, AppBar model, AppBarView view)
            : base(context, model, view)
        {
        }
    }
}