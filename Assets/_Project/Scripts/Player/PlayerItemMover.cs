using UnityEngine;

namespace MyCode._Player
{
    public class PlayerItemMover : MonoBehaviour
    {
        [SerializeField] private PlayerSetting _setting;
        [SerializeField] private Transform _holdParent;

        private KeyInputHandler _keyInputHandler;
        private IMoveItem _moveItem;
        private CharacterController _characterController;
        private AxisInputHandler _rotateInputHandler;
        private Vector3 _rotateInput;

        private void Start()
        {
            _characterController ??= GetComponent<CharacterController>();
            _keyInputHandler = new KeyInputHandler(KeyCode.E);
            _rotateInputHandler = new AxisInputHandler("Mouse X", "Mouse Y");
            _keyInputHandler.OnDownEvent += OnKeyEvent;
            _rotateInputHandler.OnAxisEvent += OnRotateInput;
        }

        private void Update()
        {
            _keyInputHandler.Update();
            _rotateInputHandler.Update();
        }

        private void OnKeyEvent()
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
            _keyInputHandler.OnDownEvent -= PickUpObject;
            _rotateInputHandler.OnAxisEvent -= OnRotateInput;
        }
    }
}