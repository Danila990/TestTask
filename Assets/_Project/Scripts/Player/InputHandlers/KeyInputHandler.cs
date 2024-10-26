using System;
using UnityEngine;

namespace MyCode
{
    public class KeyInputHandler
    {
        public event Action OnDownEvent = () => { };
        public event Action OnUpEvent = () => { };

        private readonly KeyCode _key;

        public KeyInputHandler(KeyCode key)
        {
            _key = key;
        }

        public void Update()
        {
            InputEvent();
        }

        private void InputEvent()
        {
            if (Input.GetKeyDown(_key))
            {
                OnDownEvent.Invoke();
            }

            if (Input.GetKeyUp(_key))
            {
                OnUpEvent.Invoke();
            }
        }
    }
}