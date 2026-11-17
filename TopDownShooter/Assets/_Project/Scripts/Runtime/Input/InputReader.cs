using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Input
{
    /// <summary>
    /// InputReader is a ScriptableObject that reads input from the PlayerControls input actions and raises events for other systems to subscribe to.
    /// </summary>
    [CreateAssetMenu(fileName = "InputReader", menuName = "TopDown/Input Reader")]
    public sealed class InputReader : ScriptableObject, PlayerControls.IGameplayActions
    {
        private PlayerControls playerControls;
        /// <summary>
        /// The current aim position from the player. This is a Vector2 that represents the position of the aim input.
        /// </summary>
        public Vector2 AimPosition { get; private set; }

        #region Input Events
        /// <summary>
        /// Raised when the player changes the move input. This event passes a Vector2 that represents the new move input.
        /// </summary>
        public event Action<Vector2> MoveChanged;
        /// <summary>
        /// Raised when the player presses the fire input.
        /// </summary>
        public event Action FirePressed;
        /// <summary>
        /// Raised when the player releases the fire input.
        /// </summary>
        public event Action FireReleased;
        #endregion

        /// <summary>
        /// Called when the player changes the aim input. This method is called by the PlayerControls input actions and raises the AimChanged event with the new aim position.
        /// </summary>
        /// <param name="context">The callback context for the aim input.</param>
        public void OnAim(InputAction.CallbackContext context)
        {
            AimPosition = context.ReadValue<Vector2>();
        }

        /// <summary>
        /// Called when the player presses or releases the fire input. This method is called by the PlayerControls input actions and raises the FirePressed or FireReleased events depending on the input phase.
        /// </summary>
        /// <param name="context">The callback context for the fire input.</param>
        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                FirePressed?.Invoke();
            }
            else if (context.canceled)
            {
                FireReleased?.Invoke();
            }
        }

        /// <summary>
        /// Called when the player changes the move input. This method is called by the PlayerControls input actions and raises the MoveChanged event with the new move input.
        /// </summary>
        /// <param name="context">The callback context for the move input.</param>
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveChanged?.Invoke(context.ReadValue<Vector2>());
        }

        #region Unity Callbacks
        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.Gameplay.AddCallbacks(this);
            }
            playerControls.Enable();
        }
        private void OnDisable()
        {
            playerControls?.Disable();
            playerControls?.Gameplay.RemoveCallbacks(this);
            playerControls?.Dispose();
            playerControls = null;
        }
        #endregion
    }
}
