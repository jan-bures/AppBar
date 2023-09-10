using AppBarLib.Models;
using AppBarLib.Views;
using Scripts.AppBarLib.Core;

namespace AppBarLib.Presenters
{
    internal class ModButtonPresenter : BasePresenter<ModButton, ModButtonView>
    {
        public ModButtonPresenter(ModButton model, ModButtonView view) : base(model, view)
        {
        }
    }
}