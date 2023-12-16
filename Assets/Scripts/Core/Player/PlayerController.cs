using System;
using Animation;
using Core.Camera;
using Core.Inputs;
using Core.StateMachines.Player;
using Movement;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerStateMachine playerStateMachine;
        CameraController _cameraController;
        AnimatorController _animatorController;
        InputHandler _inputHandler;
        CharacterController _characterController;
        PlayerMovementHandler _playerMovementHandler;
        
        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animatorController = GetComponent<AnimatorController>();
            _cameraController = FindObjectOfType<CameraController>();
            _inputHandler = new InputHandler(_animatorController);
            _inputHandler.OnEnable();
            playerStateMachine.Init(_inputHandler, _characterController);
            
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
           
        }

        void LateUpdate()
        {
           
        }
    }
}
