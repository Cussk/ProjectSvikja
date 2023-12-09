using System;
using UnityEngine;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        PlayerControls _playerControls;
        Vector2 _movementInput;

        void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new PlayerControls();
                _playerControls.PlayerMovement.Movement.performed += input => _movementInput = input.ReadValue<Vector2>();
            }

            _playerControls.Enable();  
        }

        void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}
