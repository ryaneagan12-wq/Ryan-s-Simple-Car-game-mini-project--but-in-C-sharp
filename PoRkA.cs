using System;
using Raylib_cs;

namespace PoRkA
{
    class Porsche
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1920,1100, "Ryan's Car Game (c# Ver)");
            Raylib.SetTargetFPS(60);
            Texture2D roadtexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\PoRkA\\PoRkA\\Road.png");
            Texture2D porschetexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\PoRkA\\PoRkA\\Porsche.png");
            Texture2D stoptexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\PoRkA\\PoRkA\\Stop.png");

            Color textblack = new Color(0, 0, 0, 255);


            int player_width = 302;
            int player_height = 101;
            int player_x = 800;
            int player_y = 800;
            int player_speed = 20;


            int enemy_width = 133;
            int enemy_height = 379;
            int enemy_speed = 5;
            int enemy_x = Raylib.GetRandomValue(0, 1920 - enemy_width);
            int enemy_y = -enemy_height;

            int score = 0;
            int Health = 100;
            bool game_over = false;

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();

                if (!game_over)
                {
                    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                    {
                        if (player_y > 0)
                        {
                            player_y -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                    {
                        if (player_x > 0)
                        {
                            player_x -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                    {
                        if (player_y < 1200 - player_height)
                        {
                            player_y += player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                    {
                        if (player_x < 1920 - player_height)
                        {
                            player_x += player_speed;
                        }
                    }
                }
                if (!game_over)
                {
                    enemy_y += enemy_speed;

                    if (enemy_y > 1200)
                    {
                        enemy_x = Raylib.GetRandomValue(0,1920 - enemy_width);
                        enemy_y = -enemy_height;
                        score += 1;
                    }
                    int position_x = player_x + (player_width / 2);
                    int position_y = player_y - player_height;
                    if (position_x < enemy_x + enemy_width && position_x + enemy_width > enemy_x && position_y < enemy_y + enemy_height && position_y + enemy_height > enemy_y)
                    {
                        Health -= 1;
                    }
                    else if (Health <= 0)
                    {
                        game_over = true;
                    }

                }

                Raylib.DrawTexture(roadtexture, 0, 0, Color.White);
                Raylib.DrawTexture(porschetexture, player_x, player_y, Color.White);
                Raylib.DrawTexture(stoptexture, enemy_x,enemy_y, Color.White);

                if (!game_over)
                {
                    Raylib.DrawText($"Score:{score}", 50, 35, 30, textblack);
                    Raylib.DrawText($"Health:{Health}", 1750, 35, 30, textblack);
                }
                else
                {
                    Raylib.DrawText($"Final Score:{score}",50,35,30,textblack);
                    Raylib.DrawText($"Health:{Health}", 1750, 35, 30, textblack);
                    Raylib.DrawText($"You Have Crashed, Press 'R' to Restart the game again.", 860, 650, 30, textblack);
                    Raylib.DrawText($"OR", 950, 695, 30, textblack);
                    Raylib.DrawText($"Press Alt + F4 to Quit the game.", 840, 750, 30, textblack);

                    if (Raylib.IsKeyDown(KeyboardKey.R))
                    {
                        enemy_x = Raylib.GetRandomValue(0, 1920 - enemy_width);
                        enemy_y = -enemy_height;
                        player_x = 800;
                        player_y = 800;
                        score = 0;
                        Health = 100;
                        game_over = false;
                    }
                }
                Raylib.EndDrawing();
            }

        }
    }
}

