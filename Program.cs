using System;
using Raylib_cs;

namespace mIcAlArAn
{
    class Mclaren
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1920, 1100,"Ryan's Car Game (C# Ver)");
            Raylib.SetTargetFPS(60);
            Texture2D treetexture = Raylib.LoadTexture("");
            Texture2D mclarentexture = Raylib.LoadTexture("");

            Color Teal = new Color(0,128,128,255);


            decimal player_width = 302.0m;
            decimal player_height = 101.0m;
            decimal player_x = 800.0m;
            decimal player_y = 800.0m;
            decimal player_speed = 70.0m;


            decimal enemy_width = 350.0m;
            decimal enemy_height = 350.0m;
            decimal enemy_speed = 10.0m;
            decimal enemy_x = Raylib.GetRandomValue(0.0m, 1920.0m - enemy_width);
            decimal enemy_y = -enemy_height;

            int score = 0;
            decimal Health = 100.0m;
            bool game_over = false;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                if (!game_over)
                {
                    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                    {
                        if (player_y > 0.0m)
                        {
                            player_y -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                    {
                        if (player_x > 0.0m)
                        {
                            player_x -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                    {
                        if (player_y < 1200.0m - player_height)
                        {
                            player_y += player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                    {
                        if (player_x < 1920.0m - player_height)
                        {
                            player_x += player_speed;
                        }
                    }
                }
                if (!game_over)
                {
                    enemy_y += enemy_speed;

                    if (enemy_y > 1200.0m)
                    {
                        enemy_x = Raylib.GetRandomValue(0.0m, 1920.0m - enemy_width);
                        enemy_y = -enemy_height;
                        score += 1;
                    }
                    decimal position_x = player_x + (player_width / 2);
                    decimal position_y = player_y - player_height;

                }
            }    
        }
    }
}
