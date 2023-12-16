using Core.Inputs;
using Core.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        PlayerController _playerController;
        InputHandler _inputHandler;
        [SerializeField] GameObject cameraPivotGameObject;
        [SerializeField] float cameraFollowSpeed = 0.2f;
        [SerializeField] float cameraPitchSpeed = 25f;
        [SerializeField] float cameraYawSpeed = 25f;
        [SerializeField] float cameraLookSmoothTime = 1;
        Transform _targetTransform;
        Vector3 _cameraFollowVelocity = Vector3.zero;
        float _pitchAngle;
        float _yawAngle;
        float _minPitchAngle = -35;
        float _maxPitchAngle = 35;
        

        public void Init(PlayerController playerController, InputHandler inputHandler)
        {
            _playerController = playerController;
            _inputHandler = inputHandler;
            
            _targetTransform = _playerController.transform;
        }

        public void HandleAllCameraMovement()
        {
            FollowTarget();
            RotateCamera();
        }
        
        void FollowTarget()
        {
            var targetPosition = Vector3.SmoothDamp(transform.position, _targetTransform.position,
                ref _cameraFollowVelocity, cameraFollowSpeed);
            
            transform.position = targetPosition;
        }

        void RotateCamera()
        {
            _pitchAngle = Mathf.Lerp(_pitchAngle, _pitchAngle + (_inputHandler.cameraInputY * cameraPitchSpeed), cameraLookSmoothTime * Time.deltaTime);
            _yawAngle = Mathf.Lerp(_yawAngle, _yawAngle + (_inputHandler.cameraInputX * cameraYawSpeed), cameraLookSmoothTime * Time.deltaTime);
            _pitchAngle = Mathf.Clamp(_pitchAngle, _minPitchAngle, _maxPitchAngle);

            var rotation = Vector3.zero;
            rotation.y = _yawAngle;
            var targetRotation = Quaternion.Euler(rotation);
            transform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = _pitchAngle;
            targetRotation = Quaternion.Euler(rotation);
            cameraPivotGameObject.transform.localRotation = targetRotation;
        }
    }
}
