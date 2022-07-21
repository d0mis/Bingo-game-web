using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_game_web.Classes
{
    //Class used to store game board
    public class Card
    {
        BingNumb[,] board;
        
        int rows;
        int columns;
        int max;

        public Card()
        { }
        //Creates a board filled by random numbers
        public Card(int  rows, int columns, int max)
        {
            this.columns = columns;
            this.rows = rows;
            this.max = max;
            board = new BingNumb[rows,columns];
            Rand numbers = new Rand(max);
            numbers.Suffle();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    BingNumb number = new BingNumb(numbers.draw(), false);
                    board[i, j] = number;                 
                }
        }

        //Checks if a row is marked
        public bool CheckRow(int row)
        {
            if (row <= rows)
            {
                for (int i = 0; i < columns; i++)
                    if (!board[row, i].marked)
                        return false;
            }
            return true;
        }

        //Checks if all cells are marked
        public bool CheckBingo()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    if (!board[i, j].marked)
                        return false;

            return true;   
        }

        //Marks a specific cell
        public void Mark(int row, int column)
        {
            BingNumb number = new BingNumb(board[row,column].number, true);
            board[row, column] = number;

        }

        //Marks a cell with a number d
        public void Mark(int d)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j].number == d)
                    {
                        BingNumb number = new BingNumb(d, true);
                        board[i, j] = number;
                    }
                }
        }

        //Returns cell data
        public BingNumb ReturnN(int row, int column)
        {
            return board[row, column];
        }
    }
   

}
