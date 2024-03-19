namespace InputSystem
{
    public class InputManager : IInputManager
    {
        public GameInput inputs { get; private set; }

        public InputManager()
        {
            inputs = new GameInput();
            inputs.Enable();
        }
    }
}

