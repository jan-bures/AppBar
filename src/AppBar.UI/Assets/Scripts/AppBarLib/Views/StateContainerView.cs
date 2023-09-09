using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppBarLib.Views
{
    internal class StateContainerView : MonoBehaviour
    {
        public VisualElement RootElement { get; private set; }

        public List<AppBarView> AppBarViews { get; set; } = new List<AppBarView>();

        private void Awake()
        {
            RootElement = GetComponent<UIDocument>().rootVisualElement;
        }
    }
}