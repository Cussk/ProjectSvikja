using System;
using Animation;
using Core.Camera;
using Core.Inputs;
using Core.Movement;
using Core.StateMachines.Player;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerStateMachine playerStateMachine;
        CameraController _cameraController;
        AnimatorController _animatorController;
        InputHandler _inputHandler;
        Rigidbody _rigidbody;
        PlayerMovementHandler _playerMovementHandler;
        
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animatorController = GetComponent<AnimatorController>();
            _cameraController = FindObjectOfType<CameraController>();
            _inputHandler = new InputHandler();
            _inputHandler.OnEnable();
            _playerMovementHandler = new PlayerMovementHandler(_rigidbody);
            _cameraController.Init(this);
            playerStateMachine.Init(_inputHandler, _playerMovementHandler, _cameraController, _animatorController);
        }

        void OnDestroy()
        {
            _inputHandler.OnDisable();
        }
    }
}
