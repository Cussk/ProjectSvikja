using System;
using UnityEngine;

namespace Animation
{
    public class AnimatorController : MonoBehaviour
    {
        const string HORIZONTAL = "Horizontal";
        const string VERTICAL = "Vertical";
        
        Animator _animator;
        int _horizontal;
        int _vertical;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _horizontal = Animator.StringToHash(HORIZONTAL);
            _vertical = Animator.StringToHash(VERTICAL);
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            var snappedHorizontal = SnapMovementValue(0.55f, 0.5f, 1f, horizontalMovement);
            var snappedVertical = SnapMovementValue(0.55f, 0.5f, 1f, verticalMovement);
            
            _animator.SetFloat(_horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
            _animator.SetFloat(_vertical, snappedVertical, 0.1f, Time.deltaTime);
        }


        float SnapMovementValue(float threshold, float snapValue1, float snapValue2, float movementValue)
        {
            if(movementValue > 0 && movementValue < threshold)
            {
                return snapValue1;
            }

            if(movementValue > threshold)
            {
                return snapValue2;
            }

            if(movementValue < 0 && movementValue > -threshold)
            {
                return -snapValue1;
            }

            if(movementValue < -threshold)
            {
                return -snapValue2;
            }

            return 0f;
        }
    }
}
