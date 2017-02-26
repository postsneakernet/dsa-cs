using System;
using DataStructures.Trees;

namespace Algorithms.Trees
{
    class PrettyPrintTree<T> where T : IComparable
    {
        public static string LBranch = "/";
        public static string RBranch = "\\";
        public static char BranchSep = '_';
        public static char PadChar = '.';
        public static int Padding = 3;

        public static int BranchSepLength = 0;
        public static int StartSpace = 1;
        public static int SiblingSpace = 2;
        public static int CousinSpace = 3;

        // [branch sep length, start space, sibling space, cousin space] per level
        public static int[,] LevelSpacing = {
                { 24, 30, 0, 0 },
                { 10, 16, 33, 33 },
                { 3, 9, 19, 19 },
                { 0, 5, 11, 11 },
                { 0, 0, 5, 3 }
        };

        public static void Print(INode<T> node)
        {
            var pbt = TreeOperationsIter<T>.LevelOrderTraversalAsPbt(node);

            if (pbt.Size == 0)
            {
                Console.WriteLine("*-tree is empty-*");
                return;
            }

            int maxLevel = (int)System.Math.Log(pbt.Size, 2);

            if (maxLevel > 4)
            {
                Console.WriteLine("Only levels under 5 are currently supported");
                return;
            }

            int level = 0;
            int size = 0;

            for (int i = 0; i < pbt.Size; ++i, ++size)
            {
                if (size == (int)System.Math.Pow(2, level))
                {
                    Console.WriteLine();

                    for (int j = 0; j < size * 2; ++j)
                    {
                        if (j == 0)
                        {
                            Console.Write("{0}", "".PadLeft(LevelSpacing[level, StartSpace] - 1));
                        }
                        else if (j % 2 != 0)
                        {
                            Console.Write("{0}", "".PadLeft(LevelSpacing[level, BranchSepLength] * 2 + Padding));
                        }
                        else
                        {
                            Console.Write("{0}", "".PadLeft(LevelSpacing[level, CousinSpace] - 2));
                        }

                        if (j % 2 == 0)
                        {
                            Console.Write("{0}", LBranch);
                        }
                        else
                        {
                            Console.Write("{0}", RBranch);
                        }
                    }

                    ++level;
                    size = 0;
                    Console.WriteLine();
                }

                if (size == 0)
                {
                    Console.Write("{0}", "".PadLeft(LevelSpacing[level, StartSpace]));
                }
                else if (size % 2 != 0)
                {
                    Console.Write("{0}", "".PadLeft(LevelSpacing[level, SiblingSpace]));
                }
                else
                {
                    Console.Write("{0}", "".PadLeft(LevelSpacing[level, CousinSpace]));
                }

                Console.Write("{0}", "".PadLeft(LevelSpacing[level, BranchSepLength], BranchSep));

                String s = (pbt.Get(i).CompareTo(default(T)) != 0) ? pbt.Get(i).ToString() : "x";
                Console.Write("{0}", s.PadLeft(Padding, PadChar));

                Console.Write("{0}", "".PadLeft(LevelSpacing[level, BranchSepLength], BranchSep));
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
