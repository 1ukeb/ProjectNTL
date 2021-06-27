using UnityEngine;

namespace NTL.Input
{
    public class InputManager : MonoBehaviour
    {
        //valid keys scriptableobject
        public InputMapSO inputMapSO;

        public delegate void InputEvent(string input);
        public static InputEvent OnInput;

        private void OnGUI()
        {
            if (UnityEngine.Input.anyKeyDown && Event.current.type == EventType.KeyDown)
            {
                // get character pressed
                char c = Event.current.keyCode.ToString().ToLower()[0];

                // if not valid character, return
                if (!inputMapSO.IsValidInput(c))
                    return;

                // invoke input event
                OnInput?.Invoke(c.ToString());
            }
        }
    }
}
