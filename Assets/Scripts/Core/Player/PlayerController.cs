using System;
using Animation;
using Core.Camera;
using Inputs;
using Movement;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        CameraController _cameraController;
        AnimatorController _animatorController;
        InputHandler _inputHandler;
        Rigidbody _playerRigidBody;
        PlayerMovementHandler _playerMovementHandler;
        
        void Awake()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
            _animatorController = GetComponent<AnimatorController>();
            _cameraController = FindObjectOfType<CameraController>();
            _inputHandler = new InputHandler(_animatorController);
            _inputHandler.OnEnable();
            _playerMovementHandler = new PlayerMovementHandler(_inputHandler, _playerRigidBody);
            
            _cameraController.Init(this, _inputHandler);
        }

        void OnDestroy()
        {
            _inputHandler.OnDisable();
        }

        void Update()
        {
            _inputHandler.HandleAllInputs();
        }

        void FixedUpdate()
        {
            _playerMovementHandler.HandleAllMovement();
        }

        void LateUpdate()
        {
            _cameraController.HandleAllCameraMovement();
        }
    }
}
