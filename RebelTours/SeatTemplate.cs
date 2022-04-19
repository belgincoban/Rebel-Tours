using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours
{
    public class SeatTemplate
    {
        private readonly bool?[,] _seatSpaces;

        public SeatTemplate(int rowCount, int colCount, int activeRowCount, params int[] disabledSpaces)
        {
            _seatSpaces = new bool?[rowCount, colCount];

            if (disabledSpaces == null)
            {
                disabledSpaces = new int[0];
            }

            for (int rowIndex = 0; rowIndex < _seatSpaces.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < _seatSpaces.GetLength(1); colIndex++)
                {
                    var spaceIndex = colIndex + rowIndex * _seatSpaces.GetLength(1);

                    if (disabledSpaces.Contains(spaceIndex))
                    {
                        _seatSpaces[rowIndex, colIndex] = null;
                    }
                    else if (rowIndex < activeRowCount)
                    {
                        _seatSpaces[rowIndex, colIndex] = true;
                    }
                    else
                    {
                        _seatSpaces[rowIndex, colIndex] = false;
                    }
                }
            }
        }

        public int GetSeatCount(SeatingType type)
        {
            var seatCount = 0;

            for (int rowIndex = 0; rowIndex < _seatSpaces.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < _seatSpaces.GetLength(1); colIndex++)
                {
                    if (
                        colIndex == 1 && (type == SeatingType.Deluxe || type == SeatingType.Premium)
                        ||
                        colIndex == 2 && type == SeatingType.Premium
                        )
                    {
                        continue;
                    }

                    if (_seatSpaces[rowIndex, colIndex].HasValue &&_seatSpaces[rowIndex,colIndex].Value)
                    {
                        seatCount++;
                    }
                }
            }

            return seatCount;
        }
    }
}
