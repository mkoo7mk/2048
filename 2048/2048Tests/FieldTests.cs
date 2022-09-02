using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2048;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Tests
{
    [TestClass()]
    public class FieldTests
    {
        [TestMethod()]
        public void CollapseUp()
        {
            var field = new int[4][]
            {
                new int[] {16, 4, 0, 0},
                new int[] {16, 8, 2, 0},
                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 2, 0},
            };

            var expected_field = new int[4][]
            {

                new int[] {16, 4, 2, 0},
                new int[] {16, 8, 2, 0},
                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 0, 0},
            };

            Field f = new();
            f.SetField(field);
            f.Collapse("w");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(expected_field[i][j], f.GetField(i, j));
                }
            }
        }

        [TestMethod()]
        public void CollapseDown()
        {
            var field = new int[4][]
            {
                new int[] {16, 4, 0, 0},
                new int[] {16, 8, 2, 0},
                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 2, 0},
            };

            var expected_field = new int[4][]
            {

                new int[] {0, 0, 0, 0},
                new int[] {0, 0, 0, 0},
                new int[] {16, 4, 2, 0},
                new int[] {16, 8, 2, 0},
            };

            Field f = new();
            f.SetField(field);
            f.Collapse("s");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(expected_field[i][j], f.GetField(i, j));
                }
            }
        }

        [TestMethod()]
        public void CollapseLeft()
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

                new int[] {16, 4, 0, 0},
                new int[] {16, 8, 2, 0},
                new int[] {4, 4, 0, 0},
                new int[] {2, 0, 0, 0},
            };

            Field f = new();
            f.SetField(field);
            f.Collapse("a");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(expected_field[i][j], f.GetField(i, j));
                }
            }
        }
        [TestMethod()]
        public void CollapseRight()
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

                new int[] {0, 0, 16, 4},
                new int[] {0, 16, 8, 2},
                new int[] {0, 0, 4, 4},
                new int[] {0, 0, 0, 2},
            };

            Field f = new();
            f.SetField(field);
            f.Collapse("d");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(expected_field[i][j], f.GetField(i, j));
                }
            }
        }

        [TestMethod()]
        public void MergeUp()
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

                new int[] {32, 8, 8, 4},
                new int[] {0, 4, 0, 0},
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
                    Assert.AreEqual(expected_field[i][j], f.GetField(i, j));
                }
            }
        }


    }
}