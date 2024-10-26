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
                if(_rigidbody.angularVelocity.sqrMagnitude > 0)
                {
                    _rigidbody.angularVelocity = Vector3.Lerp(_rigidbody.angularVelocity, Vector3.zero, 2 * Time.deltaTime);
                }
            }
        }

        public void StartMove(Transform pointMove)
        {
            _rigidbody.velocity = Vector3.zero;
            _target = pointMove;
        }

        public void StopMove(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
            _target = null;
        }
    }
}