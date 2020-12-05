using System;
using System.Linq;
using System.Collections.Generic;


namespace BinaryBoarding
{
    public class BoardingPass
    {
        public int Row { get; }

        public int Column { get; }

        public int SeatId { get; }

        public BoardingPass(string code)
        {
            if(code.Length != 10)
            {
                throw new ArgumentException("Scan length must be 10!");
            }

            var firstHalf = code[..7];
            var secondHalf = code[7..];
            if(firstHalf.All(c => FirstHalfAllowedCharacters.Contains(c)) &&
                secondHalf.All(c => SecondHalfAllowedCharacters.Contains(c)))
            {
                Row = Convert.ToInt32(firstHalf.Replace('B','1').Replace('F','0'), 2);
                Column = Convert.ToInt32(secondHalf.Replace('R','1').Replace('L','0'), 2);
                SeatId = 8 * Row + Column;
                return;
            }

            throw new ArgumentException("Scan doesn't match schema!");
        }

        private static IEnumerable<char> FirstHalfAllowedCharacters
            = new char[] { 'B', 'F' };
        
        private static IEnumerable<char> SecondHalfAllowedCharacters
            = new char[] { 'R', 'L' };
    }
}