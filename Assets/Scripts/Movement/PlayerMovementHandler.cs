using System;
using Inputs;
using UnityEngine;

namespace Movement
{
    public class PlayerMovementHandler
    {
        float _movementSpeed = 7f;
        float _rotationSpeed = 15f;
        
        InputHandler _inputHandler;
        Rigidbody _playerRigidBody;
        Vector3 _moveDirection;
        Transform _cameraObject;

        public PlayerMovementHandler(InputHandler inputHandler, Rigidbody playerRigidBody)
        {
            _inputHandler = inputHandler;
            _playerRigidBody = playerRigidBody;
            if (Camera.main != null) _cameraObject = Camera.main.transform;
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        void HandleMovement()
        {
            _moveDirection = _cameraObject.forward * _inputHandler.VerticalInput;
            _moveDirection += _cameraObject.right * _inputHandler.HorizontalInput;
            _moveDirection.Normalize();
            _moveDirection.y = 0;
            _moveDirection *= _movementSpeed;
            
            var movementVelocity = _moveDirection;
            _playerRigidBody.velocity = movementVelocity;
        }

        void HandleRotation()
        {
            var targetDirection = Vector3.zero;
            targetDirection = _cameraObject.forward * _inputHandler.VerticalInput;
            targetDirection += _cameraObject.right * _inputHandler.HorizontalInput;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
                targetDirection = _playerRigidBody.transform.forward;

            var targetRotation = Quaternion.LookRotation(targetDirection);
            var playerRotation = Quaternion.Slerp(_playerRigidBody.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _playerRigidBody.transform.rotation = playerRotation;
        }
    }
}
