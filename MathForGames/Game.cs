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

        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

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

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
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
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();


            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            bool testBool = true;
            int test = Convert.ToInt32(testBool);
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }


        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //creates a window for raylib
            Raylib.InitWindow(1024, 760, "Math for Games");
            Raylib.SetTargetFPS(20);
            
            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math for Games";

            //creates new scene for our actors to exsist in
            Scene scene1 = new Scene();

            Entity entity = new Entity(0, 6, '>', ConsoleColor.Green);
            entity.Velocity.X = 1;

            Enemy enemy = new Enemy(10, 10, Color.GREEN, 'm', ConsoleColor.Green);

            Player player = new Player(0, 6, Color.RED, '@', ConsoleColor.Green);
            scene1.AddEntity(player);
            player.Speed = 5;
            scene1.AddEntity(entity);
            scene1.AddEntity(enemy);
            enemy.Target = player;

            for(int ii = 0; ii < 1; ii++)
            {
                //18 down
                //28 across
                Maze maze1 = new Maze(1, 0, '╔', ConsoleColor.Red);
                scene1.AddEntity(maze1);
                maze1.Target = player;

                for (int i = 1; i < 5; i++)
                {
                    Maze maze = new Maze(1, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                int j = 0;
                for (j = 8; j < 18; j++)
                {
                    Maze maze = new Maze(1, j, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze2 = new Maze(24, 0, '╗', ConsoleColor.Red);
                scene1.AddEntity(maze2);
                maze2.Target = player;

                for (int i = 2; i < 24; i++)
                {
                    Maze maze = new Maze(i, 0, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze3 = new Maze(1, j, '╚', ConsoleColor.Red);
                scene1.AddEntity(maze3);
                maze3.Target = player;

                for (int i = 2; i < 20; i++)
                {
                    Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze4 = new Maze(20, j, '╩', ConsoleColor.Red);
                scene1.AddEntity(maze4);
                maze4.Target = player;

                for (int i = 21; i < 28; i++)
                {
                    Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze5 = new Maze(28, j, '╝', ConsoleColor.Red);
                scene1.AddEntity(maze5);
                maze5.Target = player;

                for (int i = 1; i < 18; i++)
                {
                    Maze maze = new Maze(28, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                for (int i = 1; i < 11; i++)
                {
                    Maze maze = new Maze(24, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze6 = new Maze(24, 11, '╝', ConsoleColor.Red);
                scene1.AddEntity(maze6);
                maze6.Target = player;

                for (int i = 4; i < 11; i++)
                {
                    Maze maze = new Maze(21, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze7 = new Maze(21, 11, '╚', ConsoleColor.Red);
                scene1.AddEntity(maze7);
                maze7.Target = player;

                Maze maze10 = new Maze(21, 4, '╗', ConsoleColor.Red);
                scene1.AddEntity(maze10);
                maze10.Target = player;

                Maze maze8 = new Maze(22, 11, '═', ConsoleColor.Red);
                scene1.AddEntity(maze8);
                maze8.Target = player;

                Maze maze9 = new Maze(23, 11, '═', ConsoleColor.Red);
                scene1.AddEntity(maze9);
                maze9.Target = player;

                for (int i = 5; i < 21; i++)
                {
                    Maze maze = new Maze(i, 4, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze11 = new Maze(12, 4, '╦', ConsoleColor.Red);
                scene1.AddEntity(maze11);
                maze11.Target = player;

                for (int i = 5; i < 7; i++)
                {
                    Maze maze = new Maze(12, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                j = j - 1;

                Maze maze12 = new Maze(20, j, '║', ConsoleColor.Red);
                scene1.AddEntity(maze12);
                maze12.Target = player;

                j = j - 1;

                Maze maze13 = new Maze(20, j, '║', ConsoleColor.Red);
                scene1.AddEntity(maze13);
                maze13.Target = player;

                j = j - 1;

                for (int i = 17; i < 24; i++)
                {
                    Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze14 = new Maze(16, j, '╚', ConsoleColor.Red);
                scene1.AddEntity(maze14);
                maze14.Target = player;

                Maze maze15 = new Maze(20, j, '╦', ConsoleColor.Red);
                scene1.AddEntity(maze15);
                maze15.Target = player;

                for (int i = 9; i < j; i++)
                {
                    Maze maze = new Maze(16, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze16 = new Maze(16, 13, '╣', ConsoleColor.Red);
                scene1.AddEntity(maze16);
                maze16.Target = player;

                for (int i = 9; i < 16; i++)
                {
                    Maze maze = new Maze(i, 13, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                Maze maze17 = new Maze(9, 13, '╚', ConsoleColor.Red);
                scene1.AddEntity(maze17);
                maze17.Target = player;

                for (int i = 9; i < 13; i++)
                {
                    Maze maze = new Maze(9, i, '║', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }

                for (int i = 5; i < 13; i++)
                {
                    Maze maze = new Maze(i, j, '═', ConsoleColor.Red);
                    scene1.AddEntity(maze);
                    maze.Target = player;
                }
            }

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);

            SetCurrentScene(startingSceneIndex);
        }


        //this will create entities for the maze walls
        public void MazeWalls()
        {
            Scene scene1 = new Scene();

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
        public void Update(float deltaTime)
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
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
            if(_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
