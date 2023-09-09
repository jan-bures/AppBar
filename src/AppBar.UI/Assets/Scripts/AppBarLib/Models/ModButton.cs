using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace AppBarLib.Models
{
    /// <summary>
    /// Represents a button that can be added to an app bar.
    /// </summary>
    [PublicAPI]
    public class ModButton
    {
        /// <summary>
        /// Unique identifier for this button.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// List of states that this button can be in.
        /// </summary>
        public List<ButtonState> ButtonStates { get; set; }

        /// <summary>
        /// Current state of this button.
        /// </summary>
        public ButtonState CurrentState { get; set; }

        /// <summary>
        /// Set of game states that this button is allowed to be in.
        /// </summary>
        public HashSet<GameState> AllowedGameStates { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ModButton"/> class. The current state will be set to the first
        /// state in the list of button states.
        /// </summary>
        /// <param name="id">Unique identifier for this button.</param>
        /// <param name="buttonStates">List of states that this button can be in.</param>
        /// <param name="allowedGameStates">Set of game states that this button is allowed to be in.</param>
        public ModButton(string id, List<ButtonState> buttonStates, HashSet<GameState> allowedGameStates) :
            this(id, buttonStates, buttonStates[0], allowedGameStates)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ModButton"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for this button.</param>
        /// <param name="buttonStates">List of states that this button can be in.</param>
        /// <param name="currentState">Current state of this button.</param>
        /// <param name="allowedGameStates">Set of game states that this button is allowed to be in.</param>
        /// <exception cref="ArgumentException">Thrown if the current state is not in the list of button states.</exception>
        public ModButton(
            string id,
            List<ButtonState> buttonStates,
            ButtonState currentState,
            HashSet<GameState> allowedGameStates
        )
        {
            if (buttonStates == null || buttonStates.Count == 0)
            {
                throw new ArgumentException($"Button must have at least one state ({id}).");
            }

            if (currentState == null)
            {
                throw new ArgumentException($"Current state must not be null ({id}).");
            }

            if (!buttonStates.Contains(currentState))
            {
                throw new ArgumentException($"Current state must be in the list of button states ({id}).");
            }

            if (allowedGameStates == null || allowedGameStates.Count == 0)
            {
                throw new ArgumentException($"Button must be allowed in at least one game state ({id}).");
            }

            Id = id;
            ButtonStates = buttonStates;
            CurrentState = currentState;
            AllowedGameStates = allowedGameStates;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ModButton"/> class. The button will have two states: on and off.
        /// </summary>
        /// <param name="id">Unique identifier for this button.</param>
        /// <param name="label">Label to display on the button.</param>
        /// <param name="icon">Icon to display on the button.</param>
        /// <param name="toggleAction">Action to perform when the button is clicked.</param>
        /// <param name="rightToggleAction">Action to perform when the button is right-clicked.</param>
        public ModButton(string id, string label, Texture2D icon, Action toggleAction, Action rightToggleAction = null)
        {
            Id = id;

            ButtonStates = new List<ButtonState>
            {
                new ButtonState(label, icon, ButtonState.IndicatorOffColor, toggleAction, rightToggleAction),
                new ButtonState(label, icon, ButtonState.IndicatorOnColor, toggleAction, rightToggleAction)
            };

            CurrentState = ButtonStates[0];
        }
    }
}