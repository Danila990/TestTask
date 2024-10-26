using System;
using UnityEngine;

namespace MyCode._Player
{
    public interface IInputService
    {
        public event Action<Vector2> OnMoveInput;
        public event Action<Vector2> OnCameraRotateInput;
        public event Action OnItemUpInput;
    }
}