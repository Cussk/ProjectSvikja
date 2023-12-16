using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Core.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        BaseState _currentState;

        void Update()
        {
            _currentState?.Tick(Time.deltaTime);
        }

        public void ChangeState(BaseState newState)
        {
            _currentState?.Exit();

            _currentState = newState;
            _currentState?.Enter();
        }
    }
}
