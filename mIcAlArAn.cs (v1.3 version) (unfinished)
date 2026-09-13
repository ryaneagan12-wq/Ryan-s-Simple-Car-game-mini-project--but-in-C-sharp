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

            Color Teal = new Color(0, 128, 128, 255);
            Color textblack = new Color(0, 0, 0, 255);

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
                    if (position_x < enemy_x + enemy_width && position_x + enemy_width > enemy_x && position_y < enemy_y + enemy_height && position_y + enemy_height > enemy_y)
                    {
                        Health -= 0.1m;
                    }
                    else if (Health <= 0.0m)
                    {
                        game_over = true;
                    }
                }

                Raylib.DrawTexture(treetexture, enemy_x, enemy_y, Color.White);
                Raylib.DrawTexture(mclarentexture, player_x, player_y, Color.White);

                if (!game_over)
                {
                    Raylib.DrawText($"Score:{score}", 50, 35, 30, textblack);
                    Raylib.DrawText($"Health:{Health}", 1750, 35, 30, textblack); // needs to be rounded
                }
                else
                {
                    Raylib.DrawText($"Final Score:{score}", 50, 35, 30, textblack);
                    Raylib.DrawText($"Health:{Health}", 1750, 35, 30, textblack); // needs to be rounded 
                    Raylib.DrawText($"You Have Crashed, Press 'R' to Restart the game again.", 860, 650, 30, textblack);
                    Raylib.DrawText($"OR", 950, 695, 30, textblack);
                    Raylib.DrawText($"Press Alt + F4 to Quit the game.", 840, 750, 30, textblack);

                    if (Raylib.IsKeyDown(KeyboardKey.R))
                    {
                        enemy_x = Raylib.GetRandomValue(0.0m, 1920.0m - enemy_width);
                        enemy_y = -enemy_height;
                        player_x = 800.0m;
                        player_y = 800.0m;
                        score = 0;
                        Health = 100.0m;
                        game_over = false;
                    }
                }
                Raylib.EndDrawing();
            }    
        }
    }
}
