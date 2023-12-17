using System;
using Animation;
using Core.Camera;
using Core.Inputs;
using Core.Movement;
using UnityEngine;

namespace Core.StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        #region Properties

        public InputHandler InputHandler { get; private set; }
        public PlayerMovementHandler PlayerMovementHandler { get; private set; }
        public CameraController CameraController { get; private set; }
        public AnimatorController AnimatorController { get; private set; }

        #endregion

        public void Init(InputHandler inputHandler, PlayerMovementHandler playerMovementHandler, CameraController cameraController, AnimatorController animatorController)
        {
            InputHandler = inputHandler;
            PlayerMovementHandler = playerMovementHandler;
            CameraController = cameraController;
            AnimatorController = animatorController;
        }

        void Start()
        {
            currentState = new MovementState(this);
            currentState?.Enter();
        }
    }
}
