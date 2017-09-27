using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Sudoku
{
    public class Sudoku
    {
        /// <summary>
        /// Kollar om nuvarande spelet är löst
        /// </summary>
        public bool IsGameSolved
        {
            get
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (sudokuArray[i, j] == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public string BoardAsText { get { return GetFormatedBoard(); } }
        private int[,] sudokuArray = new int[9, 9];
        private List<int> numbers = new List<int>();

        /// <summary>
        /// Konstruktor för spelet
        /// </summary>
        /// <param name="inputNumbers">Soduko spelet i sträng format</param>
        public Sudoku(string inputNumbers)
        {
            CreateBoard(inputNumbers);
        }

        /// <summary>
        /// Lägger till siffrorna till listan
        /// </summary>
        private void AddNumbersToList()
        {
            numbers.Clear();
            numbers.AddRange(Enumerable.Range(1, 9));
        }

        /// <summary>
        /// Löser hela sudokun
        /// </summary>
        public void Solve()
        {
            bool test = true;
            bool runProgram = true;

            //Håller koll på vilken rad vi är i arrayen
            while (runProgram)
            {
                runProgram = false;
                for (int row = 0; row < 9; row++)
                {
                    //håller koll på cilken col vi är på
                    for (int col = 0; col < 9; col++)
                    {
                        int rowChecker = row;
                        int colChecker = col;
                        AddNumbersToList();

                        if (CellContainsZero(row, col))
                        {
                            test = true;
                            UpdateSolvedNumbersCurrentRow(row, col);
                            UpdateSolvedNumbersCurrentCol(row, col);

                            //kollar boxen col 
                            while (colChecker % 3 != 0)
                            {
                                colChecker--;
                            }
                            while (rowChecker % 3 != 0)
                            {
                                rowChecker--;
                            }
                            for (int j = 0; j < 3; j++)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (sudokuArray[rowChecker, colChecker] != 0)
                                    {
                                        if (numbers.Contains(sudokuArray[rowChecker, colChecker]))
                                        {
                                            numbers.Remove(sudokuArray[rowChecker, colChecker]);
                                        }
                                    }
                                    colChecker++;
                                }
                                colChecker = colChecker - 3; rowChecker++;
                               
                                //Kollar om det är en kvar i siffror för då är det den.
                                if (numbers.Count == 1)
                                {
                                    sudokuArray[row, col] = numbers[0];
                                    runProgram = true;
                                }
                                //För att skriva ut på skärmen steg för steg
                                test = false;
                            }
                        }
                    }
                }
            }
        }

        public bool CellContainsZero(int row, int col)
        {            
            if(sudokuArray[row, col] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateSolvedNumbersCurrentRow(int rowFixed, int colFixed)
        {
            for (int col = 0; col < 9; col++)
            {
                if (numbers.Contains(sudokuArray[rowFixed, col]))
                {
                    numbers.Remove(sudokuArray[rowFixed, col]);
                }
            }
        }

        public void UpdateSolvedNumbersCurrentCol(int rowFixed, int colFixed)
        {
            for (int row = 0; row < 9; row++)
            {
                if (numbers.Contains(sudokuArray[row, colFixed]))
                {
                    numbers.Remove(sudokuArray[row, colFixed]);
                }
            }
        }

        /// <summary>
        /// Formaterar brädan som en sträng
        /// </summary>
        /// <returns></returns>
        private string GetFormatedBoard()
        {
            StringBuilder sb = new StringBuilder();
            int cellCount = 0;

            foreach (var value in sudokuArray)
            {
                if ((cellCount % 27) == 0)
                {
                    sb.AppendLine(string.Concat(Enumerable.Repeat("-", 22)));
                }
                if ((cellCount % 3) == 0)
                {
                    sb.Append("|");
                }
                sb.Append($"{value} ");
                cellCount++;
                if ((cellCount % 9) == 0)
                {
                    sb.Append("|");
                    sb.AppendLine();
                }
                if (sudokuArray.Length == cellCount)
                {
                    sb.AppendLine(string.Concat(Enumerable.Repeat("-", 22)));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Skapar sudoku matrisen
        /// </summary>
        /// <param name="inputNumbers">Det råa formaten i sträng format</param>
        private void CreateBoard(string inputNumbers)
        {
            int count = 0;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {

                    sudokuArray[row, col] = (int)char.GetNumericValue(inputNumbers[count]);
                    count++;

                }
            }
        }
    }
}

