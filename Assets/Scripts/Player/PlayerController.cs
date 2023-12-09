using System;
using Animation;
using Inputs;
using Movement;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        AnimatorController _animatorController;
        InputHandler _inputHandler;
        Rigidbody _playerRigidBody;
        PlayerMovementHandler _playerMovementHandler;
        
        void Awake()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
            _animatorController = GetComponent<AnimatorController>();
            _inputHandler = new InputHandler(_animatorController);
            _inputHandler.OnEnable();
            _playerMovementHandler = new PlayerMovementHandler(_inputHandler, _playerRigidBody);
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
    }
}
