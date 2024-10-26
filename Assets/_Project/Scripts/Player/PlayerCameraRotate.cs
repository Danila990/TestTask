using MyCode.Core;
using UnityEngine;
using VContainer;

namespace MyCode._Player
{
    public class PlayerCameraRotate : MonoBehaviour
    {
        private PlayerSetting _setting;
        private CharacterController _characterController;
        private IInputService _inputService;
        private Camera _playerCamera;
        private float _rotationX = 0f;
        private Vector2 _rotateInput;

        [Inject]
        public void Construct(IInputService inputService, IDatabase gameDatabase)
        {
            _inputService = inputService;
            _inputService.OnCameraRotateInput += OnRotateInput;
            _setting = gameDatabase.GetSO<PlayerSetting>("PlayerSetting");
        }

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
            _playerCamera ??= Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
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
            _inputService.OnCameraRotateInput -= OnRotateInput;
        }
    }
}