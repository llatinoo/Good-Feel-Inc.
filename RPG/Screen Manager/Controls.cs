using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG.Screen_Manager
{
    class Controls
    {
        //Punkt an dem sich die Maus zurzeit befindet
        private Point cursorPos;

        public Point CursorPos
        {
            get { return this.cursorPos; }
        }

        private Vector2 vecCursorPos;

        public Vector2 VecCursorPos
        {
            get { return this.vecCursorPos; }
        }

        //Tastatur Status
        KeyboardState previousKeyboardState;
        KeyboardState currentKeyboardState;

        public KeyboardState CurrentKeyboardState
        {
            get { return this.currentKeyboardState; }
        }

        public KeyboardState PreviousKeyboardState
        {
            get { return this.previousKeyboardState; }
        }


        public void Update()
        {
            this.vecCursorPos = new Vector2(Mouse.GetState().Position.X - 10, Mouse.GetState().Position.Y - 10);
            this.cursorPos = new Point(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();
        }
    }
}