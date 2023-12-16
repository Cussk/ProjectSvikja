using System;
using Animation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Inputs
{
    public class InputHandler : PlayerControls.IPlayerWorldControlsActions
    {
        public event Action jumpEvent;
        
        PlayerControls _playerControls;
        AnimatorController _animatorController;
        Vector2 _movementValue;
        Vector2 _cameraInput;
        float _moveAmount;
        float _verticalInput;
        float _horizontalInput;
        public float cameraInputX;
        public float cameraInputY;

        #region Properties

        public Vector2 MovementValue => _movementValue;
        public float VerticalInput => _verticalInput;
        public float HorizontalInput => _horizontalInput;
        #endregion

        public InputHandler(AnimatorController animatorController)
        {
            _animatorController = animatorController;
        }

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

        public void HandleAllInputs()
        {
            
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            _movementValue = context.ReadValue<Vector2>();
        }

        public void OnCamera(InputAction.CallbackContext context)
        {
            
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            jumpEvent?.Invoke();
        }
    }
}
