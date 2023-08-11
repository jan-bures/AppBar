using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppBar.UI
{
    /// <summary>
    /// A simple drag manipulator for UIElements.
    /// </summary>
    internal class DragManipulator : IManipulator
    {
        public DragManipulator(bool isEnabled = false)
        {
            IsEnabled = isEnabled;
        }

        public bool IsEnabled { get; set; }

        /// <summary>
        /// The target element to drag.
        /// </summary>
        public VisualElement target
        {
            get => _target;
            set
            {
                _target = value;

                _target.RegisterCallback<PointerDownEvent>(DragBegin);
                _target.RegisterCallback<PointerUpEvent>(DragEnd);
                _target.RegisterCallback<PointerMoveEvent>(PointerMove);
            }
        }

        private VisualElement _target;
        private Vector3 _offset;
        private PickingMode _mode;

        /// <summary>
        /// Is the target currently being dragged?
        /// </summary>
        private bool _isDragging;

        private void DragBegin(PointerDownEvent evt)
        {
            if (!IsEnabled)
            {
                return;
            }

            var textFieldClass = typeof(TextField).GetNestedType("TextInput", BindingFlags.NonPublic);
            if (textFieldClass != null && textFieldClass.IsInstanceOfType(evt.target))
            {
                evt.StopPropagation();
                return;
            }

            _mode = target.pickingMode;
            target.pickingMode = PickingMode.Ignore;
            _offset = evt.localPosition;
            _isDragging = true;
            target.CapturePointer(evt.pointerId);
        }

        private void DragEnd(PointerUpEvent evt)
        {
            if (!IsEnabled)
            {
                return;
            }

            target.ReleasePointer(evt.pointerId);
            _isDragging = false;
            target.pickingMode = _mode;
        }

        private void PointerMove(PointerMoveEvent evt)
        {
            if (!IsEnabled || !_isDragging)
            {
                return;
            }

            var delta = evt.localPosition - _offset;
            var newPosition = target.transform.position + delta;
            var x = Mathf.Clamp(newPosition.x, 0, Screen.width - target.resolvedStyle.width);
            var y = Mathf.Clamp(newPosition.y, 0, Screen.height - target.resolvedStyle.height);

            target.transform.position = new Vector3(x, y);
        }
    }
}