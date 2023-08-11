using System;
using System.Collections;
using System.Linq;
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

        private bool _isLocked = true;
        private bool _isRenaming = false;

        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _appBar = _root.Q(className: "app-bar");

            _appBarMenu = _root.Q(className: "app-bar-menu");
            _appBarMenuContainer = _appBarMenu.Q(className: "app-bar-menu-container");

            var appBarLabel = _appBar.Q<Label>(className: "app-bar-label");
            var appBarTextField = _appBar.Q<TextField>(className: "app-bar-text-field");
            appBarTextField.value = appBarLabel.text;
            appBarTextField.RegisterValueChangedCallback(evt =>
            {
                appBarLabel.text = evt.newValue;
            });

            _appBar.Q<Button>(className: "app-bar-menu-button").clicked += () =>
            {
                IsVisible = !IsVisible;
            };

            AddItem("Unlock position", button =>
            {
                _isLocked = !_isLocked;
                GetComponent<MockupButtons>().Manipulator.IsEnabled = !_isLocked;

                button.text = _isLocked ? "Unlock position" : "Lock position";
                _appBar.ToggleInClassList("unlocked");
            });

            AddItem("Rename", button =>
            {
                _isRenaming = !_isRenaming;

                _appBar.ToggleInClassList("rename");
                button.text = _isRenaming ? "Save name" : "Rename";

                if (_isRenaming)
                {
                    appBarTextField.Focus();
                }
                else
                {
                    appBarTextField.Blur();
                }
            });

            IsVisible = false;

            _root.RegisterCallback<MouseDownEvent>(_ => IsVisible = false);
            _appBarMenu.RegisterCallback<MouseDownEvent>(e => e.StopPropagation());


        }

        #region Menu Items

        public Button AddItem(string buttonText, Action<Button> onClick, int index)
        {
            var menuItem = new Button
            {
                text = buttonText
            };

            menuItem.clickable = new Clickable(() =>
            {
                try
                {
                    onClick(menuItem);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

                IsVisible = false;
            });
            menuItem.AddToClassList("app-bar-menu-item");

            _appBarMenuContainer.Insert(index, menuItem);

            RecalculateIfNeeded();

            return menuItem;
        }

        public Button AddItem(string buttonText, Action<Button> onClick)
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
                StartCoroutine(UpdateGeometry());
            }
        }

        private IEnumerator UpdateGeometry()
        {
            // Wait for next frame to ensure that the menu has been rendered
            yield return null;

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
            _appBarMenu.style.top = y - yMax;
        }

        #endregion
    }
}