using System;
using Core.Inputs;
using UnityEngine;

namespace Core.Movement
{
    public class PlayerMovementHandler
    {
        float _movementSpeed = 7f;
        float _rotationSpeed = 15f;
        
        Rigidbody _rigidbody;
        Vector3 _moveDirection;
        Transform _cameraObject;

        public PlayerMovementHandler(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            if (UnityEngine.Camera.main != null) _cameraObject = UnityEngine.Camera.main.transform;
        }

        public void HandleAllMovement(float verticalInput, float horizontalInput)
        {
            HandleMovement(verticalInput, horizontalInput);
            HandleRotation(verticalInput, horizontalInput);
        }

        void HandleMovement(float verticalInput, float horizontalInput)
        {
            _moveDirection = _cameraObject.forward * verticalInput;
            _moveDirection += _cameraObject.right * horizontalInput;
            _moveDirection.Normalize();
            _moveDirection.y = 0;
            _moveDirection *= _movementSpeed;
            
            var movementVelocity = _moveDirection;
            _rigidbody.velocity = movementVelocity;
        }

        void HandleRotation(float verticalInput, float horizontalInput)
        {
            var targetDirection = Vector3.zero;
            targetDirection = _cameraObject.forward * verticalInput;
            targetDirection += _cameraObject.right * horizontalInput;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
                targetDirection = _rigidbody.transform.forward;

            var targetRotation = Quaternion.LookRotation(targetDirection);
            var playerRotation = Quaternion.Slerp(_rigidbody.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.transform.rotation = playerRotation;
        }
    }
}
