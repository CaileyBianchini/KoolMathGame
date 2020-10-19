using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static void AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            tempArray[_scenes.Length] = scene;
            _scenes = tempArray;
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if(tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                }
            }
            if(removed == true)
                _scenes = tempArray;

            return removed;
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index > _scenes.Length)
                return;

            _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;

            _scenes[_currentSceneIndex].Start();
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
            //creates a window for raylib
            Raylib.InitWindow(1024, 760, "Math for Games");
            Raylib.SetTargetFPS(0);
            
            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math for Games";

            //creates new scene for our actors to exsist in
            Scene scene2 = new Scene();
            Scene scene1 = new Scene();

            Entity entity = new Entity(0, 6, '>', ConsoleColor.Green);
            entity.Velocity.X = 1;
            MazeWalls();
            Player player = new Player(0, 6, Color.RED, '@', ConsoleColor.Green);
            scene2.AddEntity(player);
            scene2.AddEntity(entity);


            AddScene(scene1);
            AddScene(scene2);
        }


        //this will create entities for the maze walls
        public void MazeWalls()
        {
            Scene scene1 = new Scene();
            AddScene(scene1);

            //18 down
            //28 across
            Maze maze1 = new Maze(1, 0, '╔', ConsoleColor.Red);
            scene1.AddEntity(maze1);

            for (int i = 1; i < 5; i++)
            {
                Maze maze = new Maze(1, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            int j = 0;
            for (j = 8; j < 18; j++)
            {
                Maze maze = new Maze(1, j, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze2 = new Maze(24, 0, '╗', ConsoleColor.Red);
            scene1.AddEntity(maze2);

            for (int i = 2; i < 24; i++)
            {
                Maze maze = new Maze(i, 0, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze3 = new Maze(1, j, '╚', ConsoleColor.Red);
            scene1.AddEntity(maze3);

            for (int i = 2; i < 20; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze4 = new Maze(20, j, '╩', ConsoleColor.Red);
            scene1.AddEntity(maze4);

            for (int i = 21; i < 28; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze5 = new Maze(28, j, '╝', ConsoleColor.Red);
            scene1.AddEntity(maze5);

            for (int i = 1; i < 18; i++)
            {
                Maze maze = new Maze(28, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            for (int i = 1; i < 11; i++)
            {
                Maze maze = new Maze(24, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze6 = new Maze(24, 11, '╝', ConsoleColor.Red);
            scene1.AddEntity(maze6);

            for (int i = 4; i < 11; i++)
            {
                Maze maze = new Maze(21, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze7 = new Maze(21, 11, '╚', ConsoleColor.Red);
            scene1.AddEntity(maze7);

            Maze maze10 = new Maze(21, 4, '╗', ConsoleColor.Red);
            scene1.AddEntity(maze10);

            Maze maze8 = new Maze(22, 11, '═', ConsoleColor.Red);
            scene1.AddEntity(maze8);

            Maze maze9 = new Maze(23, 11, '═', ConsoleColor.Red);
            scene1.AddEntity(maze9);

            for (int i = 5; i < 21; i++)
            {
                Maze maze = new Maze(i, 4, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze11 = new Maze(12, 4, '╦', ConsoleColor.Red);
            scene1.AddEntity(maze11);

            for (int i = 5; i < 7; i++)
            {
                Maze maze = new Maze(12, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            j = j - 1;

            Maze maze12 = new Maze(20, j, '║', ConsoleColor.Red);
            scene1.AddEntity(maze12);

            j = j - 1;

            Maze maze13 = new Maze(20, j, '║', ConsoleColor.Red);
            scene1.AddEntity(maze13);

            j = j - 1;

            for (int i = 17; i < 24; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze14 = new Maze(16, j, '╚', ConsoleColor.Red);
            scene1.AddEntity(maze14);

            Maze maze15 = new Maze(20, j, '╦', ConsoleColor.Red);
            scene1.AddEntity(maze15);

            for (int i = 9; i < j; i++)
            {
                Maze maze = new Maze(16, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze16 = new Maze(16, 13, '╣', ConsoleColor.Red);
            scene1.AddEntity(maze16);

            for (int i = 9; i < 16; i++)
            {
                Maze maze = new Maze(i, 13, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            Maze maze17 = new Maze(9, 13, '╚', ConsoleColor.Red);
            scene1.AddEntity(maze17);

            for (int i = 9; i < 13; i++)
            {
                Maze maze = new Maze(9, i, '║', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }

            for (int i = 5; i < 13; i++)
            {
                Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                scene1.AddEntity(maze);
            }
        }

        //Called every frame.
        public void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Console.Clear();
            Raylib.ClearBackground(Color.DARKBLUE);
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose())
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
