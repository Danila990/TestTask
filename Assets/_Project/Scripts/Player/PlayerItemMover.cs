using MyCode.Core;
using UnityEngine;
using VContainer;

namespace MyCode._Player
{
    public class PlayerItemMover : MonoBehaviour
    {
        [SerializeField] private Transform _holdParent;

        private PlayerSetting _setting;
        private IInputService _inputService;
        private IMoveItem _moveItem;
        private CharacterController _characterController;
        private Vector3 _rotateInput;

        [Inject]
        public void Construct(IInputService inputService, IDatabase gameDatabase)
        {
            _inputService = inputService;
            _inputService.OnItemUpInput += OnItemUpInput;
            _inputService.OnCameraRotateInput += OnRotateInput;
            _setting = gameDatabase.GetSO<PlayerSetting>("PlayerSetting");
        }

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
        }

        private void OnItemUpInput()
        {
            if (_moveItem is null)
            {
                PickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        private void PickUpObject()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _setting.PickUpRange))
            {
                if (hit.transform.gameObject.TryGetComponent(out IMoveItem moveItem))
                {
                    _moveItem = moveItem;
                    _moveItem.StartMove(_holdParent);
                }
            }
        }

        private void OnRotateInput(Vector2 input)
        {
            _rotateInput = input;
        }

        private void DropObject()
        {
            if (_moveItem is not null)
            {
                _moveItem.StopMove(_characterController.velocity + _rotateInput * 3);
                _moveItem = null;
            }
        }

        private void OnDestroy()
        {
            _inputService.OnItemUpInput -= OnItemUpInput;
            _inputService.OnCameraRotateInput -= OnRotateInput;
        }
    }
}