using System;
using UnityEngine;
using VContainer.Unity;

namespace MyCode._Player
{
    public class PcInputService : IInputService, ITickable
    {
        public event Action<Vector2> OnMoveInput = (_) => { };
        public event Action<Vector2> OnCameraRotateInput = (_) => { };
        public event Action OnItemUpInput;

        public void Tick()
        {
            AxisEvent("Horizontal", "Vertical", OnMoveInput);
            AxisEvent("Mouse X", "Mouse Y", OnCameraRotateInput);
            ItemUpEvent();
        }

        private void AxisEvent(string event1, string event2, Action<Vector2> action)
        {
            Vector2 input;
            input.x = Input.GetAxis(event1);
            input.y = Input.GetAxis(event2);
            action.Invoke(input);
        }

        private void ItemUpEvent()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnItemUpInput.Invoke();
            }
        }
    }
}