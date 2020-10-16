using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static ConsoleKey GetNextKey()
        {
            //If the user hasn't pressed a key return
            if (!Console.KeyAvailable)
            {
                return 0;
            }
            //Return the key that was pressed
            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;
            _scene = new Scene();
            //Entity entity = new Entity(0, 0, '>', ConsoleColor.Green);
            //entity.Velocity.X = 1;
            Player player = new Player(0, 6, '@', ConsoleColor.Green);
            _scene.AddEntity(player);
            //_scene.AddEntity(entity);
            MazeWalls();

        }


        //this will create entities for the maze walls
        public void MazeWalls()
        {
            //18 down
            //28 across
            Maze maze1 = new Maze(1, 0, '╔', ConsoleColor.Red);
            _scene.AddEntity(maze1);

            for (int i = 1; i < 5; i++)
            {
                Maze maze = new Maze(1, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            int j = 0;
            for (j = 8; j < 18; j++)
            {
                Maze maze = new Maze(1, j, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze2 = new Maze(24, 0, '╗', ConsoleColor.Red);
            _scene.AddEntity(maze2);

            for (int i = 2; i < 24; i++)
            {
                Maze maze = new Maze(i, 0, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze3 = new Maze(1, j, '╚', ConsoleColor.Red);
            _scene.AddEntity(maze3);

            for (int i = 2; i < 20; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze4 = new Maze(20, j, '╩', ConsoleColor.Red);
            _scene.AddEntity(maze4);

            for (int i = 21; i < 28; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze5 = new Maze(28, j, '╝', ConsoleColor.Red);
            _scene.AddEntity(maze5);

            for (int i = 1; i < 18; i++)
            {
                Maze maze = new Maze(28, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            for (int i = 1; i < 11; i++)
            {
                Maze maze = new Maze(24, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze6 = new Maze(24, 11, '╝', ConsoleColor.Red);
            _scene.AddEntity(maze6);

            for (int i = 4; i < 11; i++)
            {
                Maze maze = new Maze(21, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze7 = new Maze(21, 11, '╚', ConsoleColor.Red);
            _scene.AddEntity(maze7);

            Maze maze10 = new Maze(21, 4, '╗', ConsoleColor.Red);
            _scene.AddEntity(maze10);

            Maze maze8 = new Maze(22, 11, '═', ConsoleColor.Red);
            _scene.AddEntity(maze8);

            Maze maze9 = new Maze(23, 11, '═', ConsoleColor.Red);
            _scene.AddEntity(maze9);

            for (int i = 5; i < 21; i++)
            {
                Maze maze = new Maze(i, 4, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze11 = new Maze(12, 4, '╦', ConsoleColor.Red);
            _scene.AddEntity(maze11);

            for (int i = 5; i < 7; i++)
            {
                Maze maze = new Maze(12, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            j = j - 1;

            Maze maze12 = new Maze(20, j, '║', ConsoleColor.Red);
            _scene.AddEntity(maze12);

            j = j - 1;

            Maze maze13 = new Maze(20, j, '║', ConsoleColor.Red);
            _scene.AddEntity(maze13);

            j = j - 1;

            for (int i = 17; i < 24; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze14 = new Maze(16, j, '╚', ConsoleColor.Red);
            _scene.AddEntity(maze14);

            Maze maze15 = new Maze(20, j, '╦', ConsoleColor.Red);
            _scene.AddEntity(maze15);

            for (int i = 9; i < j; i++)
            {
                Maze maze = new Maze(16, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze16 = new Maze(16, 13, '╣', ConsoleColor.Red);
            _scene.AddEntity(maze16);

            for (int i = 9; i < 16; i++)
            {
                Maze maze = new Maze(i, 13, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            Maze maze17 = new Maze(9, 13, '╚', ConsoleColor.Red);
            _scene.AddEntity(maze17);

            for (int i = 9; i < 13; i++)
            {
                Maze maze = new Maze(9, i, '║', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }

            for (int i = 5; i < 13; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                _scene.AddEntity(maze);
            }
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

            while (!_gameOver)
            {

                Update();
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                Thread.Sleep(150);
            }

            End();
        }
    }
}
