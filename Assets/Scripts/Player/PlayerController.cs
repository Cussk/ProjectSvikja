using System;
using Inputs;
using Movement;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        InputHandler _inputHandler;
        Rigidbody _playerRigidBody;
        PlayerMovementHandler _playerMovementHandler;
        
        void Awake()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
            _inputHandler = new InputHandler();
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
