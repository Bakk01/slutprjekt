using System;
using Raylib_cs;

namespace TicTacToe
{
    class Program
    {
        static int[,] board = new int[3, 3]; 
        static int Aktivspelare = 1; 
        static bool GameOver = false; 
        static void Main(string[] args)
        {
            // Skapa ett nytt Raylib-fönsterr
            Raylib.InitWindow(300, 300, "Tictactoe");

            while (!Raylib.WindowShouldClose())
            {

                UpdateBoard();

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                DrawBoard();

        
                if (GameOver)
                {
                    string winnerText = "Vinnare: " + (Aktivspelare == 1 ? "Spelare 2" : "Spelare 1");
                    Raylib.DrawText(winnerText, 10, 220, 20, Color.RED);
                    Raylib.DrawText("Tryck R för att starta om", 10, 260, 20, Color.RED);

                
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        ResetGame();
                    }
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        static void UpdateBoard()
        {
    
            if (GameOver)
            {
                return;
            }

        
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
            
                int x = Raylib.GetMouseX() / 100;
                int y = Raylib.GetMouseY() / 100;

                if (board[x, y] == 0)
                {
                
                    board[x, y] = Aktivspelare;


                    if (CheckWin(Aktivspelare))
                    {
                        GameOver = true;
                    }
                    else
                    {
                    
                        if (Aktivspelare == 1)
                        {
                            Aktivspelare = 2;
                        }
                        else
                        {
                            Aktivspelare = 1;
                        }
                    }
                }
            }
        }

    
        static void DrawBoard()
        {
        
            Raylib.DrawLine(100, 0, 100, 300, Color.BLACK);
            Raylib.DrawLine(200, 0, 200, 300, Color.BLACK);
            Raylib.DrawLine(0, 100, 300, 100, Color.BLACK);
            Raylib.DrawLine(0, 200, 300, 200, Color.BLACK);

            // Rita ut markörerna på spelplanen
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x, y] == 1)
                    {
                        Raylib.DrawText("X", x * 100 + 30, y * 100 + 30, 80, Color.BLACK);
                    }
                    else if (board[x, y] == 2)
                    {
                        Raylib.DrawText("O", x * 100 + 30, y * 100 + 30, 80, Color.BLACK);
                    }
                }
            }
        }

    
        static bool CheckWin(int player)
        {
            // Kolla rader
            for (int x = 0; x < 3; x++)
            {
                if (board[x, 0] == player && board[x, 1] == player && board[x, 2] == player)
                {
                    return true;
                }
            }

            // Kolla kolumner
            for (int y = 0; y < 3; y++)
            {
                if (board[0, y] == player && board[1, y] == player && board[2, y] == player)
                {
                    return true;
                }
            }

            // Kolla diagonal
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }

            // Kolla anti-diagonal
            if (board[2, 0] == player && board[1, 1] == player && board[0, 2] == player)
            {
                return true;
            }

            return false;
        }

        static void ResetGame()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board[x, y] = 0;
                }
            }

            Aktivspelare = 1;
            GameOver = false;
        }
    }
}
         

  