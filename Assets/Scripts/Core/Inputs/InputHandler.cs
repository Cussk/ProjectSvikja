using System;
using Animation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Inputs
{
    public class InputHandler : PlayerControls.IPlayerWorldControlsActions
    {
        public event Action JumpEvent;
        
        PlayerControls _playerControls;

        #region Properties
        public Vector2 MovementInput { get; private set; }
        public Vector2 CameraInput { get; private set; }
        #endregion

        public void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new PlayerControls();
                _playerControls.PlayerWorldControls.SetCallbacks(this);
            }

            _playerControls.Enable();    
        }

        public void OnDisable()
        {
            _playerControls.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

        public void OnCamera(InputAction.CallbackContext context)
        {
            CameraInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            JumpEvent?.Invoke();
        }
    }
}
