using UnityEngine.UIElements;

namespace AppBarLib.Views
{
    internal class ModButtonView
    {
        public VisualElement RootElement { get; private set; }

        public ModButtonView(VisualElement rootElement)
        {
            RootElement = rootElement;
        }
    }
}