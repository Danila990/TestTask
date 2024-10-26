using MyCode.Core;
using UnityEngine;
using VContainer;

namespace MyCode._Player
{
    public class PlayerMover : MonoBehaviour
    {
        private PlayerSetting _setting;
        private CharacterController _characterController;
        private IInputService _inputService;
        private Vector2 _moveInput;
        
        [Inject]
        public void Construct(IInputService inputService, IDatabase gameDatabase)
        {
            _inputService = inputService;
            _inputService.OnMoveInput += OnMoveInput;
            _setting = gameDatabase.GetSO<PlayerSetting>("PlayerSetting");
        }

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            _characterController.Move(move * _setting.MoveSpeed * Time.deltaTime);
        }

        private void OnMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        private void OnDestroy()
        {
            _inputService.OnMoveInput -= OnMoveInput;
        }
    }
}