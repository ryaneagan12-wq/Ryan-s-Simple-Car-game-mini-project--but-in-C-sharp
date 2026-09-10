    using Raylib_cs;
    using System;

    namespace bUGatata
    {
        class Buggati
        {
            static void Main(string[] args)
            {
                Raylib.InitWindow(1920,1100,"Speedy Mclaren");
                Raylib.SetTargetFPS(240);
                Texture2D roadtexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\TestTest\\TestTest\\Road.png");
                Texture2D buggatitexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\TestTest\\TestTest\\Buggati.png");
                Texture2D stoptexture = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\TestTest\\TestTest\\Stop.png");

                Color skyBlue = new Color(224,247,250,255);
                Color textblack = new Color(0,0,0,255);


                int Player_width = 282;
                int Player_height = 93;
                int Player_x = 800;
                int Player_y = 800;
                int Player_speed = 35;

                int Enemy_width = 133;
                int Enemy_height = 379;
                int Enemy_speed = 10;
                int Enemy_x = Raylib.GetRandomValue(0,1920 - Enemy_width);
                int Enemy_y = -Enemy_height;

                int Score = 0;
                bool game_over = false;

                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(skyBlue);

                    if (!game_over)
                    {
                        if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                        {
                            if (Player_y > 0)
                            {
                                Player_y -= Player_speed;
                            }
                        }
                        if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                        {
                            if (Player_x > 0)
                            {
                                Player_x -= Player_speed;
                            }
                        }
                        if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                        {
                            if (Player_y < 1200 - Player_height)
                            {
                                Player_y += Player_speed;
                            }
                        }
                        if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                        {
                            if (Player_x < 1920 - Player_height)
                            {
                                Player_x += Player_speed;
                            }
                        }
                    }
                    if (!game_over)
                    {
                        Enemy_y += Enemy_speed;
                        if (Enemy_y > 1200)
                        {
                            Enemy_x = Raylib.GetRandomValue(0, 1920 - Enemy_width);
                            Enemy_y = -Enemy_height;
                            Score += 1;
                        }
                        int position_x = Player_x + (Player_width / 2);
                        int position_y = Player_y + Player_height;
                        if (position_x < Enemy_x + Enemy_width && position_x + Enemy_width > Enemy_x && position_y < Enemy_y + Enemy_height && position_y + Enemy_height > Enemy_y)
                        {
                            game_over = true;
                        }
                    }
                    Raylib.DrawTexture(roadtexture, 0, 0, Color.White);
                    Raylib.DrawTexture(buggatitexture, Player_x, Player_y, Color.White);
                    Raylib.DrawTexture(stoptexture, Enemy_x, Enemy_y, Color.White);

                    if (!game_over)
                    {
                        Raylib.DrawText($"Score {Score}", 325, 200, 30, textblack);
                    }
                    else
                    {
                        Raylib.DrawText($"Final Score: {Score}", 325, 200, 30, textblack);
                        Raylib.DrawText($"Press 'R' to Restart again.", 860, 650, 30, textblack);
                        Raylib.DrawText($"OR", 950, 695, 30, textblack);
                        Raylib.DrawText($"Press Alt + F4 to Quit Game.", 840, 750, 30, textblack);


                        if (Raylib.IsKeyDown(KeyboardKey.R))
                        {
                            Enemy_x = Raylib.GetRandomValue(0, 1920 - Enemy_width);
                            Enemy_y = -Enemy_height;
                            Player_x = 800;
                            Player_y = 800;
                            Score = 0;
                            game_over = false;
                        }
                    }

                    Raylib.EndDrawing();
                }
            }
        }
    }
