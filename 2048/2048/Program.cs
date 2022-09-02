using _2048;
using System;

namespace A2048
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field field = new();
            var n = 5;
            var direction = " ";
            Test();
            for (int i = 0; i <= n; i++)
            {
                field.GenerateNewCell();
            }
            while (true)
            {
                field.PrintField();
                direction = PlayerMove();
                if ("wasd".Contains(direction))
                {
                    field.Collapse(direction);
                    field.Merge(direction);
                    field.Collapse(direction);
                    if (field.GenerateNewCell() == -1)
                    {
                        break;
                    }
                }
            }
        }

        private static string PlayerMove()
        {
            Console.Write("Make a move: ");
            var playerInput = Console.ReadLine();
            return playerInput;
        }
        public static void Test()
        {
            var field = new int[4][]
            {
                new int[] {16, 0, 4, 0},
                new int[] {16, 8, 2, 0},
                new int[] {0, 4, 0, 4},
                new int[] {0, 0, 2, 0},
            };

            var expected_field = new int[4][]
            {

                new int[] {32, 8, 4, 4},
                new int[] {0, 4, 4, 0},
                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 0, 0},
            };

            Field f = new();
            f.SetField(field);
            f.Collapse("w");
            f.Merge("w");
            f.Collapse("w");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(f.GetField(i, j));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(expected_field[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}