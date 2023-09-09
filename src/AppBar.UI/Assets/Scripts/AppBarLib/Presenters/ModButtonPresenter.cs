using AppBarLib.Core;
using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;

namespace AppBarLib.Controllers
{
    internal class ModButtonPresenter : BasePresenter<ModButton, ModButtonView>
    {
        public ModButtonPresenter(Context context, ModButton model, ModButtonView view)
            : base(context, model, view)
        {
        }
    }
}