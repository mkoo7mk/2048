using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Field
    {
        int[][] field;
        Random random = new Random();

        public Field()
        {
            field = CreateNewField();
        }

        public void Reset()
        {
            field = CreateNewField();
        }

        private int[][] CreateNewField()
        {
            var field = new int[4][];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new int[4];
                for (int j = 0; j < field[i].Length; j++) { field[i][j] = 0; }
            }

            return field;
        }

        public void PrintField()
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write($"|{field[i][j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private void SetField(Point point, int value)
        {
            field[point.row][point.col] = value;
        }

        public int[][] GetField()
        {
            return field.Select(a => a.ToArray()).ToArray();
        }

        public int GetField(int row, int column)
        {
            return field[row][column];
        }

        private List<Point> GetFreePoint()
        {
            List<Point> l = new();
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 0)
                    {
                        l.Add(new Point(i, j));
                    }
                }
            }
            return l;
        }

        public int GenerateNewCell()
        {
            var list = GetFreePoint();
            if (list.ToArray().Length == 0)
            {
                Console.WriteLine("You have lost");
                return -1;
            }
            Point p = list[random.Next(0, list.ToArray().Length)];
            SetField(p, random.Next(0, 2) == 0 ? 2 : 4);
            return 0;

        }

        public void SetField(int[][] f)
        {
            for (int i = 0; i < f.Length; i++)
            {
                for(int j = 0; j < f[i].Length; j++)
                {
                    field[i][j] = f[i][j];
                }
            }
        }

        public void Collapse(string dir)
        {
            switch (dir)
            {
                case "w":
                    CollapseW();
                    break;
                case "s":
                    CollapseS();
                    break;
                case "d":
                    CollapseD();
                    break;
                case "a":
                    CollapseA();
                    break;
            }
        }

        private void CollapseW()
        {
            List<int> l = new();
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (field[i][j] != 0)
                    {
                        l.Add(field[i][j]);
                    }
                }
                for (int i = l.ToArray().Length; i < field.Length; i++)
                {
                    l.Add(0);
                }

                for (int i = 0; i < field.Length; i++)
                {
                    field[i][j] = l[i];
                }
                l.Clear();
            }
        }

        private void CollapseS()
        {
            List<int> l = new();
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (field[i][j] != 0)
                    {
                        l.Add(field[i][j]);
                    }
                }
                for (int i = l.ToArray().Length; i < field.Length; i++)
                {
                    l.Insert(0, 0);
                }

                for (int i = 0; i < field.Length; i++)
                {
                    field[i][j] = l[i];
                }
                l.Clear();
            }
        }

        private void CollapseA()
        {
            List<int> l = new();
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (field[j][i] != 0)
                    {
                        l.Add(field[j][i]);
                    }
                }
                for (int i = l.ToArray().Length; i < field.Length; i++)
                {
                    l.Add(0);
                }

                for (int i = 0; i < field.Length; i++)
                {
                    field[j][i] = l[i];
                }
                l.Clear();
            }
        }

        private void CollapseD()
        {
            List<int> l = new();
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (field[j][i] != 0)
                    {
                        l.Add(field[j][i]);
                    }
                }
                for (int i = l.ToArray().Length; i < field.Length; i++)
                {
                    l.Insert(0, 0);
                }

                for (int i = 0; i < field.Length; i++)
                {
                    field[j][i] = l[i];
                }
                l.Clear();
            }

        }

        public void Merge(string dir)
        {
            switch (dir)
            {
                case "w":
                    MergeW();
                    break;
                case "s":
                    MergeS();
                    break;
                case "a":
                    MergeA();
                    break;
                case "d":
                    MergeD();
                    break;
            }
        }

        private void MergeW()
        {
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length - 1; i++)
                {
                    if (field[i][j] == field[i + 1][j])
                    {
                        field[i][j] = field[i + 1][j] * 2;
                        field[i + 1][j] = 0;
                    }
                }
            }
        }

        private void MergeS()
        {
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = field.Length - 1; i > 0; i--)
                {
                    if (field[i][j] == field[i - 1][j])
                    {
                        field[i][j] = field[i - 1][j] * 2;
                        field[i - 1][j] = 0;
                    }
                }
            }

        }

        private void MergeD()
        {
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = field.Length - 1; i > 0; i--)
                {
                    if (field[j][i] == field[j][i - 1])
                    {
                        field[j][i] = field[j][i - 1] * 2;
                        field[j][i - 1] = 0;
                    }
                }
            }
        }

        private void MergeA()
        {
            for (int j = 0; j < field.Length; j++)
            {
                for (int i = 0; i < field.Length - 1; i++)
                {
                    if (field[j][i] == field[j][i + 1])
                    {
                        field[j][i] = field[j][i + 1] * 2;
                        field[j][i + 1] = 0;
                    }
                }
            }

        }
    }
}
