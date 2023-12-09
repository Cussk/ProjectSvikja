using System;
using Animation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inputs
{
    public class InputHandler
    {
        PlayerControls _playerControls;
        AnimatorController _animatorController;
        Vector2 _movementInput;
        float _moveAmount;
        float _verticalInput;
        float _horizontalInput;

        #region Properties
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
                _playerControls.PlayerMovement.Movement.performed += input => _movementInput = input.ReadValue<Vector2>();
            }

            _playerControls.Enable();    
        }

        public void OnDisable()
        {
            _playerControls.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
            //HandleJumpInput
            //HandleActionInput
        }

        void HandleMovementInput()
        {
            _verticalInput = _movementInput.y;
            _horizontalInput = _movementInput.x;
            _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
            _animatorController.UpdateAnimatorValues(0, _moveAmount);
        }
    }
}
