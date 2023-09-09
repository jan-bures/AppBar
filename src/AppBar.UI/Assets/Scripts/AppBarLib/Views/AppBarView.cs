using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AppBarLib.Views
{
    internal class AppBarView
    {
        public VisualElement RootElement { get; private set; }

        public List<ModButtonView> ModButtonViews { get; set; } = new List<ModButtonView>();

        public AppBarView(VisualElement rootElement)
        {
            RootElement = rootElement;
        }
    }
}