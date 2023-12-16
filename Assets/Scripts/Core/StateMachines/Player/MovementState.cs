using UnityEngine;

namespace Core.StateMachines.Player
{
    public class MovementState : PlayerBaseState
    {
        public MovementState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            var movement = new Vector3();
            movement.x = playerStateMachine.InputHandler.MovementValue.x;
            movement.y = 0;
            movement.z = playerStateMachine.InputHandler.MovementValue.y;

            playerStateMachine.CharacterController.Move(movement * (playerStateMachine.MovementSpeed * deltaTime));
        }

        public override void Exit()
        {
            
        }
    }
}
