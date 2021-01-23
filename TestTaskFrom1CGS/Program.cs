using System;
using System.Collections.Generic;

namespace TestTaskFrom1CGS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] cells_1 = new int[3][];
            cells_1[0] = new int[3] { 0, 0, 1 };
            cells_1[1] = new int[3] { 0, 1, 0 };
            cells_1[2] = new int[3] { 0, 1, 1 };

            int[][] cells_2 = new int[1][];
            cells_2[0] = new int[1] { 0 };

            int[][] cells_3 = new int[3][];
            cells_3[0] = new int[3] { 0, 0, 1 };
            cells_3[1] = new int[3] { 1, 0, 0 };
            cells_3[2] = new int[3] { 1, 1, 0 };

            int[][] cells_4 = new int[5][];
            cells_4[0] = new int[5] { 0, 0, 0, 0, 1 };
            cells_4[1] = new int[5] { 1, 1, 1, 0, 1 };
            cells_4[2] = new int[5] { 1, 0, 0, 0, 1 };
            cells_4[3] = new int[5] { 1, 0, 1, 1, 1 };
            cells_4[4] = new int[5] { 1, 0, 0, 0, 1 };
            
            Console.WriteLine(GetMinTravelPrice(cells_4));
            Console.ReadKey();
        }

        private static int GetMinTravelPrice(int[][] cells)
        {
            var frontier = new PriorityQueue<int, Cell>();
            var costSoFar = new Dictionary<Cell, int>();

            Cell startCell = new Cell(0, 0, cells);

            frontier.Enqueue(0, startCell);
            costSoFar[startCell] = 0;

            while (!frontier.IsEmpty)
            {
                var currentCell = frontier.Dequeue();
                if (IsFinishCell(currentCell, cells))
                    return costSoFar[currentCell];
                
                foreach (Cell cell in GetNeighbors(currentCell, cells))
                {
                    int newCost = costSoFar[currentCell] + GetTransitionСost(currentCell, cell);

                    if (!costSoFar.ContainsKey(cell) || newCost < costSoFar[cell])
                    {
                        costSoFar[cell] = newCost;
                        frontier.Enqueue(newCost, cell);
                    }
                }
            }

            return -1;
        }

        private static List<Cell> GetNeighbors(Cell cell, int[][] cells)
        {
            List<Cell> neighbors = new List<Cell>();

            int y = cell.Y;
            int x = cell.X;

            if (IsCoordsCorrect(y - 1, x, cells))
                neighbors.Add(new Cell(x, y - 1, cells));

            if (IsCoordsCorrect(y + 1, x, cells))
                neighbors.Add(new Cell(x, y + 1, cells));

            if (IsCoordsCorrect(y, x - 1, cells))
                neighbors.Add(new Cell(x - 1, y, cells));

            if (IsCoordsCorrect(y, x + 1, cells))
                neighbors.Add(new Cell(x + 1, y, cells));

            return neighbors;
        }

        private static bool IsCoordsCorrect(int y, int x, int[][] cells)
        {
            return (y >= 0 && y < cells.Length &&
                    x >= 0 && x < cells[0].Length);
        }

        private static int GetTransitionСost(Cell cell, Cell otherCell)
        {
            if (cell.Value == otherCell.Value)
                return 0;
            else
                return 1;
        }

        private static bool IsFinishCell(Cell cell, int[][] cells)
        {
            return cell.Y == cells.Length - 1 && cell.X == cells[0].Length - 1;
        }
    }
}
