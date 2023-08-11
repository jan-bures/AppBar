using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppBar.UI
{
    public class AppBarMenu : MonoBehaviour
    {
        private const string ShowClass = "show";

        private VisualElement _root;
        private VisualElement _appBar;
        private VisualElement _appBarMenu;
        private VisualElement _appBarMenuContainer;
        private Button _appBarMenuButton;

        private bool IsVisible
        {
            get => _appBarMenu.ClassListContains(ShowClass);
            set
            {
                if (value)
                {
                    _appBarMenu.AddToClassList(ShowClass);
                    RecalculateIfNeeded();
                    _root.pickingMode = PickingMode.Position;
                }
                else
                {
                    _appBarMenu.RemoveFromClassList(ShowClass);
                    _root.pickingMode = PickingMode.Ignore;
                }
            }
        }

        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _appBar = _root.Q(className: "app-bar");

            _appBarMenu = _root.Q(className: "app-bar-menu");
            _appBarMenuContainer = _appBarMenu.Q(className: "app-bar-menu-container");
            _appBarMenuButton = _appBar.Q<Button>(className: "app-bar-menu-button");

            AddItem("Item 1", () => {});
            AddItem("Item 2", () => {});
            AddItem("Item 3", () => {});

            IsVisible = false;

            _root.RegisterCallback<MouseDownEvent>(_ => IsVisible = false);
            _appBarMenu.RegisterCallback<MouseDownEvent>(e => e.StopPropagation());

            _appBarMenuButton.clicked += () =>
            {
                IsVisible = !IsVisible;
            };
        }

        #region Menu Items

        public Button AddItem(string buttonText, Action onClick, int index)
        {
            var menuItem = new Button(onClick)
            {
                text = buttonText
            };
            menuItem.AddToClassList("app-bar-menu-item");

            _appBarMenuContainer.Insert(index, menuItem);

            RecalculateIfNeeded();

            return menuItem;
        }

        public Button AddItem(string buttonText, Action onClick)
        {
            return AddItem(buttonText, onClick, _appBarMenuContainer.childCount);
        }

        public void RemoveItem(Button menuItem)
        {
            menuItem.RemoveFromHierarchy();

            RecalculateIfNeeded();
        }

        public void RemoveItem(int index)
        {
            var container = _appBarMenu.Q(className: "app-bar-menu-container");
            container.RemoveAt(index);

            RecalculateIfNeeded();
        }

        #endregion

        #region Recalculate Menu Position

        private void RecalculateIfNeeded()
        {
            if (IsVisible)
            {
                StartCoroutine(RecalculateCoroutine());
                //_appBar.schedule.Execute(UpdateMenuPosition).StartingIn(1);
            }
        }

        private IEnumerator RecalculateCoroutine()
        {
            yield return null;
            UpdateMenuPosition();
        }

        private void UpdateMenuPosition()
        {
            // Get screen size
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            // Get menu size
            var menuWidth = _appBarMenu.resolvedStyle.width;
            var menuHeight = _appBarMenu.resolvedStyle.height;

            // Get position of app bar
            var xMin = _appBar.worldBound.xMin;
            var xMax = _appBar.worldBound.xMax;
            var yMin = _appBar.worldBound.yMin;
            var yMax = _appBar.worldBound.yMax;

            // Calculate menu position
            float x;
            float y;

            if (menuWidth <= screenWidth - xMax)
            {
                // Menu fits to the right of the app bar
                x = xMax;
                y = Math.Max(0, Math.Min(yMin, screenHeight - menuHeight));
            }
            else if (menuHeight <= screenHeight - yMax)
            {
                // Menu fits below the app bar
                x = Math.Max(0, Math.Min(xMax, screenWidth) - menuWidth);
                y = yMax;
            }
            else if (menuHeight <= yMin)
            {
                // Menu fits above the app bar
                x = Math.Max(0, Math.Min(xMax, screenWidth) - menuWidth);
                y = yMin - menuHeight;
            }
            else
            {
                // Menu fits to the left of the app bar
                x = xMin - menuWidth;
                y = Math.Max(0, Math.Min(yMin, screenHeight - menuHeight));
            }

            // Set menu position
            _appBarMenu.style.left = x - xMin;
            _appBarMenu.style.top = y - yMin;
        }

        #endregion
    }
}