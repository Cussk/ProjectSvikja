using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Core.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected BaseState currentState;

        void Update()
        {
            currentState?.Tick(Time.deltaTime);
        }

        void FixedUpdate()
        {
            currentState?.FixedTick(Time.deltaTime);
        }

        void LateUpdate()
        {
            currentState?.LateTick(Time.deltaTime);
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.Exit();

            currentState = newState;
            currentState?.Enter();
        }
    }
}
