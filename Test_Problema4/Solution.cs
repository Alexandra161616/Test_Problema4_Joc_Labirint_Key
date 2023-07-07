using System;
using System.Collections.Generic;

namespace Test_Problema4
{
    public class Solution
    {
        public static int ShortestPathAllKeys(string[] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int totalKeys = 0;
            int startX = -1;
            int startY = -1;
            
            

            // Gasesti pozitia de start si numeri cheile
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        startX = i;
                        startY = j;
                    }
                    else if (char.IsLower(grid[i][j]))
                    {
                        totalKeys++;
                    }
                }
            }

            int[][] directions = new int[][] {
        new int[] { -1, 0 }, // sus
        new int[] { 1, 0 },  // jos
        new int[] { 0, -1 }, // stanga
        new int[] { 0, 1 }   // dreapta
    };

            var queue = new Queue<(int, int, int)>();  // (x, y, stare)
            var visited = new HashSet<(int, int, int)>();

            queue.Enqueue((startX, startY, 0));
            visited.Add((startX, startY, 0));

            int steps = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var (x, y, state) = queue.Dequeue();

                    if (state == (1 << totalKeys) - 1)
                    {
                        return steps;
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        int newX = x + directions[j][0];
                        int newY = y + directions[j][1];
                        int newState = state;

                        if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] != '#')
                        {
                            char c = grid[newX][newY];

                            if (char.IsLower(c))
                            {
                                newState |= (1 << (c - 'a'));
                            }

                            if (char.IsUpper(c) && ((state >> (c - 'A')) & 1) == 0)
                            {
                                continue;
                            }

                            if (!visited.Contains((newX, newY, newState)))
                            {
                                visited.Add((newX, newY, newState));
                                queue.Enqueue((newX, newY, newState));
                            }
                        }
                    }
                }

                steps++;
            }

            return -1;  // Nu s a gasit niciun drum bun
        }
    }
}