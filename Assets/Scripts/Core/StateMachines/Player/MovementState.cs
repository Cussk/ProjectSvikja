using UnityEngine;

namespace Core.StateMachines.Player
{
    public class MovementState : PlayerBaseState
    {
        float _verticalInput;
        float _horizontalInput;
        float _cameraInputX;
        float _cameraInputY;
        
        public MovementState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            HandleMovement();
            HandleCameraMovement();
        }

        public override void FixedTick(float deltaTime)
        {
            playerStateMachine.PlayerMovementHandler.HandleAllMovement(_verticalInput, _horizontalInput);
        }

        public override void LateTick(float deltaTime)
        {
            playerStateMachine.CameraController.HandleAllCameraMovement(_cameraInputY, _cameraInputX);
        }

        public override void Exit()
        {
            
        }
        
        void HandleMovement()
        {
            _verticalInput = playerStateMachine.InputHandler.MovementInput.y;
            _horizontalInput = playerStateMachine.InputHandler.MovementInput.x;
            var moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
            playerStateMachine.AnimatorController.UpdateAnimatorValues(0, moveAmount);
        }

        void HandleCameraMovement()
        {
            _cameraInputX = playerStateMachine.InputHandler.CameraInput.x;
            _cameraInputY = playerStateMachine.InputHandler.CameraInput.y;
        }
    }
}
