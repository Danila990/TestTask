using UnityEngine;

namespace MyCode._Player
{
    public class PlayerCameraRotate : MonoBehaviour
    {
        [SerializeField] private PlayerSetting _setting;

        private CharacterController _characterController;
        private AxisInputHandler _rotateInputHandler;
        private Camera _playerCamera;
        private float _rotationX = 0f;
        private Vector2 _rotateInput;

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
            _playerCamera ??= Camera.main;
            _rotateInputHandler = new AxisInputHandler("Mouse X", "Mouse Y");
            Cursor.lockState = CursorLockMode.Locked;
            _rotateInputHandler.OnAxisEvent += OnRotateInput;
        }

        private void Update()
        {
            _rotateInputHandler.Update();
            RotateCamera();
        }

        private void RotateCamera()
        {
            _rotationX -= _rotateInput.y * _setting.LookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -_setting.LookXLimit, _setting.LookXLimit);
            _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * _rotateInput.x * _setting.LookSpeed);
        }

        private void OnRotateInput(Vector2 input)
        {
            _rotateInput = input;
        }

        private void OnDestroy()
        {
            _rotateInputHandler.OnAxisEvent -= OnRotateInput;
        }
    }
}