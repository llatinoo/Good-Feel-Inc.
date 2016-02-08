﻿using Microsoft.Xna.Framework;
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
            vecCursorPos = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            cursorPos = new Point(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
    }
}