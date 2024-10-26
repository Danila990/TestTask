using UnityEngine;

namespace MyCode._Player
{
    public interface IMoveItem
    {
        public void StartMove(Transform pointMove);
        public void StopMove(Vector3 velocity);
    }
}