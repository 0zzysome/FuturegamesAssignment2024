using UnityEngine;

namespace Mechadroids {
    /// <summary>
    /// Handles input state from the Input System
    /// </summary>
    public class InputHandler {
        private InputActions inputActions;

        public Vector2 MovementInput { get; private set; }
        public Vector2 MouseDelta { get; private set; }
        public InputActions InputActions => inputActions;

        public void Initialize() {
            // initialize input here
            inputActions = new InputActions();
            inputActions.Player.Enable();
            //move if the player is using movement
            inputActions.Player.Move.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
            //stop if not
            inputActions.Player.Move.canceled += ctx => MovementInput = Vector2.zero;

            inputActions.Player.Look.performed += ctx => MouseDelta = ctx.ReadValue<Vector2>();
            inputActions.Player.Look.canceled += ctx => MouseDelta = Vector2.zero;
            inputActions.UI.Enable();

        }

        public void SetCursorState(bool visibility, CursorLockMode lockMode) {
            Cursor.visible = visibility;
            Cursor.lockState = lockMode;
        }

        public void Dispose() {
            SetCursorState(true, CursorLockMode.None);
            inputActions.Disable();
        }
    }
}
