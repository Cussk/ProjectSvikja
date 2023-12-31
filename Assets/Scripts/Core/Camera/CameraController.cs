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
        [SerializeField] GameObject cameraPivotGameObject;
        [SerializeField] float cameraFollowSpeed = 0.2f;
        [SerializeField] float cameraPitchSpeed = 25f;
        [SerializeField] float cameraYawSpeed = 25f;
        [SerializeField] float cameraLookSmoothTime = 1;
        [SerializeField] float minPitchAngle = -35;
        [SerializeField] float maxPitchAngle = 35;
        Transform _targetTransform;
        Vector3 _cameraFollowVelocity = Vector3.zero;
        float _pitchAngle;
        float _yawAngle;

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
            _targetTransform = _playerController.transform;
        }

        // public void HandleAllCameraMovement(float cameraInputY, float cameraInputX)
        // {
        //     FollowTarget();
        //     RotateCamera(cameraInputY, cameraInputX);
        // }
        
        public void FollowTarget()
        {
            var targetPosition = Vector3.SmoothDamp(transform.position, _targetTransform.position,
                ref _cameraFollowVelocity, cameraFollowSpeed);
            
            transform.position = targetPosition;
        }

        public  void RotateCamera(float cameraInputY, float cameraInputX)
        {
            _pitchAngle = Mathf.Lerp(_pitchAngle, _pitchAngle + (cameraInputY * cameraPitchSpeed), cameraLookSmoothTime * Time.deltaTime);
            _yawAngle = Mathf.Lerp(_yawAngle, _yawAngle + (cameraInputX * cameraYawSpeed), cameraLookSmoothTime * Time.deltaTime);
            _pitchAngle = Mathf.Clamp(_pitchAngle, minPitchAngle, maxPitchAngle);

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
