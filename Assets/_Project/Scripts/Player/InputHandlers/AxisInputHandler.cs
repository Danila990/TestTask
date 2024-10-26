using System;
using UnityEngine;

namespace MyCode
{
    public class AxisInputHandler
    {
        public event Action<Vector2> OnAxisEvent = (_) => { };

        private readonly string _event1;
        private readonly string _event2;
        private Vector2 _eventInput = Vector2.zero;

        public AxisInputHandler(string event1, string event2)
        {
            _event1 = event1;
            _event2 = event2;
        }

        public void Update()
        {
            InputEvent();
        }

        private void InputEvent()
        {
            _eventInput.x = Input.GetAxis(_event1);
            _eventInput.y = Input.GetAxis(_event2);
            OnAxisEvent.Invoke(_eventInput);
        }
    }
}