using System;

namespace TestTaskFrom1CGS
{
    public struct Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public Cell(int x, int y, int[][] cells)
        {
            X = x;
            Y = y;
            Value = cells[y][x];
        }
    }
}
