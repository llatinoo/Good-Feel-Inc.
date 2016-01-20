using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Controls
    {
        //Punkt an dem sich die Maus zurzeit befindet
        private Point cursorPos;

        public Point CursorPos
        {
            get { return cursorPos; }
        }

        private Vector2 vecCursorPos;

        public Vector2 VecCursorPos
        {
            get { return vecCursorPos; }
        }

        //Tastatur Status
        KeyboardState previousKeyboardState;
        KeyboardState currentKeyboardState;

        public KeyboardState CurrentKeyboardState
        {
            get { return currentKeyboardState; }
        }

        public KeyboardState PreviousKeyboardState
        {
            get { return previousKeyboardState; }
        }


        public void Update()
        {
            vecCursorPos = new Vector2(Mouse.GetState().Position.X - 10, Mouse.GetState().Position.Y - 10);
            cursorPos = new Point(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
    }
}