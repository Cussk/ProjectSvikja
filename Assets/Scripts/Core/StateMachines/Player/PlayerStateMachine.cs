using Core.Inputs;
using UnityEngine;

namespace Core.StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        #region Properties

        public InputHandler InputHandler { get; private set; }
        public CharacterController CharacterController { get; private set; }
        
        [field: SerializeField] public float MovementSpeed { get; private set; }

        #endregion

        public void Init(InputHandler inputHandler, CharacterController characterController)
        {
            InputHandler = inputHandler;
            CharacterController = characterController;
        }
    }
}
