using UnityEngine;

namespace MyCode._Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerSetting _setting;

        private CharacterController _characterController;
        private AxisInputHandler _moveInputHandler;

        private Vector2 _moveInput;

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
            _moveInputHandler = new AxisInputHandler("Horizontal", "Vertical");
            _moveInputHandler.OnAxisEvent += OnMoveInput;
        }

        private void Update()
        {
            _moveInputHandler.Update();
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
            _moveInputHandler.OnAxisEvent -= OnMoveInput;
        }
    }
}