using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;
        private Entity _entity;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }


        public static ConsoleKey GetNextKey()
        {
            //if the player hasn't pressed a key it will return
            if(!Console.KeyAvailable)
            {
                return 0;
            }
            //returns the key that was pressed
            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            _scene = new Scene();
            Entity entity = new Entity();
            _scene.AddEntity(entity);
        }


        //Called every frame.
        public void Update()
        {

            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable) Console.ReadKey(true);
                Thread.Sleep(250);
            }

            End();
        }
    }
}
