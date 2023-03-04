using System;
using System.Collections.Generic;

namespace KnightsTour
{
    public class Solver
    {
        private readonly int rows;
        private readonly int columns;

        public Solver(int rows, int columns)
        {
            if (rows <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows));
            }

            if (columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columns));
            }

            this.rows = rows;
            this.columns = columns;
        }

        public (int row, int column)[] Solve(int startRow, int startCol)
        {
            if (startRow < 0 || startRow >= this.rows)
            {
                throw new ArgumentOutOfRangeException(nameof(startRow));
            }

            if (startCol < 0 || startCol >= this.columns)
            {
                throw new ArgumentOutOfRangeException(nameof(startCol));
            }

            var node = Solve(new Node(startRow, startCol, null));

            Stack<(int row, int column)> result = new Stack<(int row, int column)>();
            while (node is not null)
            {
                result.Push((node.Row, node.Column));
                node = node.Parent;
            }

            return result.ToArray();

            Node Solve(Node current)
            {
                int nextRow, nextCol;

                nextRow = current.Row - 2;
                nextCol = current.Column - 1;
                if (nextRow >= 0 && nextCol >= 0 && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row - 2;
                nextCol = current.Column + 1;
                if (nextRow >= 0 && nextCol < this.columns && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row - 1;
                nextCol = current.Column + 2;
                if (nextRow >= 0 && nextCol < this.columns && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row + 1;
                nextCol = current.Column + 2;
                if (nextRow < this.rows && nextCol < this.columns && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row + 2;
                nextCol = current.Column + 1;
                if (nextRow < this.rows && nextCol < this.columns && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row + 2;
                nextCol = current.Column - 1;
                if (nextRow < this.rows && nextCol >= 0 && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row - 1;
                nextCol = current.Column - 2;
                if (nextRow >= 0 && nextCol >= 0 && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                nextRow = current.Row + 1;
                nextCol = current.Column - 2;
                if (nextRow < this.rows && nextCol >= 0 && Validate(nextRow, nextCol, current))
                {
                    Node result = Solve(new Node(nextRow, nextCol, current));
                    if (result is not null)
                    {
                        return result;
                    }
                }

                if (IsSolved(current))
                {
                    return current;
                }
                else
                {
                    return null;
                }
            }

            bool Validate(int row, int col, Node current)
            {
                while (current is not null)
                {
                    if (current.Row == row && current.Column == col)
                    {
                        return false;
                    }

                    current = current.Parent;
                }

                return true;
            }

            bool IsSolved(Node node)
            {
                int counter = 0;
                while (node is not null)
                {
                    node = node.Parent;
                    counter++;
                }

                return counter == this.rows * this.columns;
            }
        }

        private class Node
        {
            public Node(int row, int column, Node parent)
            {
                this.Row = row;
                this.Column = column;
                this.Parent = parent;
            }

            public int Row { get; }

            public int Column { get; }

            public Node Parent { get; }
        }
    }
}
