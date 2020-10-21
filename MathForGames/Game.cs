using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
<<<<<<< Updated upstream
using Raylib_cs;
=======
>>>>>>> Stashed changes

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
<<<<<<< Updated upstream
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
=======
        private Scene _scene;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
            //creates a window for raylib
            Raylib.InitWindow(1024, 760, "Math for Games");
            Raylib.SetTargetFPS(0);
            
            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math for Games";

            //creates new scene for our actors to exsist in
            Scene scene2 = new Scene();
            Scene scene1 = new Scene();

            //Entity entity = new Entity(0, 6, '>', ConsoleColor.Green);
            //entity.Velocity.X = 1;
            MazeWalls();
            Player player = new Player(0, 6, Color.RED, '@', ConsoleColor.Green);
            scene2.AddEntity(player);
            //scene2.AddEntity(entity);

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene2);
            AddScene(scene1);

            SetCurrentScene(startingSceneIndex);

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
=======
            Console.CursorVisible = false;
            _scene = new Scene();
            //Entity entity = new Entity(0,0,'©',ConsoleColor.DarkMagenta);
            //entity.Velocity.X = 1;
            Player player = new Player(0,14, '■', ConsoleColor.White);
            _scene.AddEntity(player);
            //_scene.AddEntity(entity);
            Maze();
            
            
        }


        /// <summary>
        /// - This is the first version of the maze, very ineficiant yet has all the points plotted out
        /// - all the lines that draw somthing on one x axsis will all be on one line of code, so codes with x = 1 will be on one line
        /// - although its messy the huge gaps represent the spaces the player can pass through
        /// </summary>
        public void Maze()
        {
            Scenery scenery1 = new Scenery(0, 1, '╔', ConsoleColor.Red); Scenery scenery1a = new Scenery(1, 1, '═', ConsoleColor.Red); Scenery scenery1b = new Scenery(2, 1, '═', ConsoleColor.Red); Scenery scenery1c = new Scenery(3, 1, '═', ConsoleColor.Red);
            Scenery scenery2 = new Scenery(0, 2, '║', ConsoleColor.Red);
            Scenery scenery3 = new Scenery(0, 3, '║', ConsoleColor.Red);
            Scenery scenery4 = new Scenery(0, 4, '║', ConsoleColor.Red);
            Scenery scenery5 = new Scenery(0, 5, '║', ConsoleColor.Red); Scenery scenery5d = new Scenery(4, 5, '╔', ConsoleColor.Red);
            Scenery scenery6 = new Scenery(0, 6, '║', ConsoleColor.Red);
            Scenery scenery7 = new Scenery(0, 7, '║', ConsoleColor.Red);
            Scenery scenery8 = new Scenery(0, 8, '║', ConsoleColor.Red);
            Scenery scenery9 = new Scenery(0, 9, '║', ConsoleColor.Red);
            Scenery scenery10 = new Scenery(0, 10, '║', ConsoleColor.Red);
            Scenery scenery11 = new Scenery(0, 11, '║', ConsoleColor.Red);
            Scenery scenery12 = new Scenery(0, 12, '║', ConsoleColor.Red);
            Scenery scenery13 = new Scenery(0, 13, '╚', ConsoleColor.Red); Scenery scenery13a = new Scenery(1, 13, '═', ConsoleColor.Red); Scenery scenery13b = new Scenery(2, 13, '═', ConsoleColor.Red); Scenery scenery13c = new Scenery(3, 13, '═', ConsoleColor.Red);

            _scene.AddEntity(scenery1); _scene.AddEntity(scenery1a); _scene.AddEntity(scenery1b); _scene.AddEntity(scenery1c);
            _scene.AddEntity(scenery2);
            _scene.AddEntity(scenery3);
            _scene.AddEntity(scenery4);
            _scene.AddEntity(scenery5);
            _scene.AddEntity(scenery6);
            _scene.AddEntity(scenery7);
            _scene.AddEntity(scenery8);
            _scene.AddEntity(scenery9);
            _scene.AddEntity(scenery10);
            _scene.AddEntity(scenery11);
            _scene.AddEntity(scenery12);
            _scene.AddEntity(scenery13); _scene.AddEntity(scenery13a); _scene.AddEntity(scenery13b); _scene.AddEntity(scenery13c);
>>>>>>> Stashed changes
        }

        //Called every frame.
        public void Update()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

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
            if(_scenes[_currentSceneIndex].Started)
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
