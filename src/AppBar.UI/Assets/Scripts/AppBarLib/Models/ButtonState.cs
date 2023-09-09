using System;
using JetBrains.Annotations;
using UnityEngine;

namespace AppBarLib.Models
{
    /// <summary>
    /// Represents a state for a button in the app bar.
    /// </summary>
    [PublicAPI]
    public class ButtonState
    {
        #region Default values

        /// <summary>
        /// Default color for the indicator when the state is "off".
        /// </summary>
        public static readonly Color IndicatorOffColor = new Color(42 / 255f, 42 / 255f, 50 / 255f);

        /// <summary>
        /// Default color for the indicator when the state is "on".
        /// </summary>
        public static readonly Color IndicatorOnColor = new Color(0 / 255f, 255 / 255f, 102 / 255f);

        /// <summary>
        /// Default color for the indicator for when an action is running or otherwise busy.
        /// </summary>
        public static readonly Color IndicatorBusyColor = new Color(255 / 255f, 255 / 255f, 102 / 255f);

        /// <summary>
        /// Default color for the indicator for when an action has errored.
        /// </summary>
        public static readonly Color IndicatorErrorColor = new Color(255 / 255f, 102 / 255f, 102 / 255f);

        #endregion

        /// <summary>
        /// Label for the button in this state.
        /// </summary>
        public string Label { get; internal set; }

        /// <summary>
        /// Icon for the button in this state.
        /// </summary>
        public Texture2D Icon { get; internal set; }

        /// <summary>
        /// Color for the indicator in this state.
        /// </summary>
        public Color IndicatorColor { get; internal set; }

        /// <summary>
        /// Action to perform when the button is clicked in this state.
        /// </summary>
        public Action OnClick { get; internal set; }

        /// <summary>
        /// Action to perform when the button is right-clicked in this state.
        /// </summary>
        public Action OnRightClick { get; internal set; }

        public ButtonState(string label, Texture2D icon, Color indicatorColor, Action onClick, Action onRightClick)
        {
            Label = label;
            Icon = icon;
            IndicatorColor = indicatorColor;
            OnClick = onClick;
            OnRightClick = onRightClick;
        }
    }
}