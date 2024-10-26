using UnityEngine;

namespace MyCode._Player
{
    public class MoveItem : MonoBehaviour, IMoveItem
    {
        private Rigidbody _rigidbody;
        private Transform _target;

        private void Start()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_target is not null)
            {
                transform.position = _target.position;
            }
        }

        public void StartMove(Transform pointMove)
        {
            _rigidbody.isKinematic = true;
            _target = pointMove;
        }

        public void StopMove(Vector3 velocity)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = velocity;
            _target = null;
        }
    }
}