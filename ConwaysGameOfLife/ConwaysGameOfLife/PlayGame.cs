using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConwaysGameOfLife
{
    class PlayGame
    {
        private bool[,] myGrid;
        private int myRows, myColumns, myCellWidth;
        private Brush myCellColor;

        public PlayGame(Brush cellColor, int rows, int columns, int cellWidth)
        {

            myCellColor = cellColor;
            myRows = rows;
            myColumns = columns;
            myCellWidth = cellWidth;

            myGrid = new bool[myRows, myColumns];


            Random randomGenerator = new Random();
            for (int i = 0; i < myGrid.GetLength(0); i++)
            {
                for (int j = 0; j < myGrid.GetLength(1); j++)
                {
                    int randomNumber = randomGenerator.Next(8);

                    if (randomNumber == 0)
                    {
                        myGrid[i, j] = true;
                    }
                }
            }
        }

        private int CheckStatus(int row, int column)
        {
            int count = 0;

            if ((row - 1 >= 0 && column - 1 > 0) && myGrid[row - 1, column - 1] == true)
            {
                count++;
            }

            if ((row - 1 >= 0) && myGrid[row - 1, column] == true)
            { 
                count++; 
            }
            if ((row - 1 >= 0 && column + 1 < myColumns) && myGrid[row - 1, column + 1] == true)
            { 
                count++; 
            }
            if ((column - 1 >= 0) && myGrid[row, column - 1] == true)
            { 
                count++; 
            }
            if ((column + 1 < myColumns) && myGrid[row, column + 1] == true)
            { 
                count++; 
            }
            if ((row + 1 < myRows && column - 1 >= 0) && myGrid[row + 1, column - 1] == true)
            { 
                count++; 
            }
            if ((row + 1 < myRows) && myGrid[row + 1, column] == true)
            { 
                count++; 
            }
            if ((row + 1 < myRows && column + 1 < myColumns) && myGrid[row + 1, column + 1] == true)
            { 
                count++; 
            }

            return count;
        }

        public void NewGeneration()
        {
            Form1 temp = new Form1();

            bool[,] newGrid = new bool[myRows, myColumns];

            for (int i = 0; i < myGrid.GetLength(0); i++)
            {
                for (int j = 0; j < myGrid.GetLength(1); j++)
                {
                    int count = CheckStatus(i, j);

                    if(myGrid[i, j])
                    {
                        if(count == 2 || count == 3)
                        {
                            newGrid[i, j] = true;
                        }
                        if(count < 2 || count > 3)
                        {
                            newGrid[i, j] = false;
                        }
                    }
                    else
                    {
                        if(count == 3)
                        {
                            newGrid[i, j] = true;
                        }
                    }
                }
            }
            myGrid = newGrid;
        }

        public void Paint(Graphics g)
        {
            for (int i = 0; i < myGrid.GetLength(0); i++)
            {
                for (int j = 0; j < myGrid.GetLength(1); j++)
                {
                    if (myGrid[i, j])
                    {
                        g.FillRectangle(myCellColor, j * myCellWidth, i * myCellWidth, myCellWidth, myCellWidth);
                    }
                }
            }
        }

        public bool[,] GetGrid()
        {
            return myGrid;
        }

        public bool Equals(bool[,] g)
        {
            for (int i = 0; i < myGrid.GetUpperBound(0); i++)
            {
                for (int j = 0; j < myGrid.GetUpperBound(1); j++)
                {
                    if (myGrid[i, j] != g[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetCellColor(Color c)
        {
            myCellColor = new SolidBrush(c);
        }
    }
}
