using System.Collections.Generic;
using System.Linq;

namespace ReportRepair
{
    public static class Report
    {
        private static List<int> _input;
        private static int _sum;
        private static int[] _vector;
        private static int? _result;

        public static int? FindResult(int dim, int sum, IEnumerable<int> input)
        {
            _input = input.ToList();
            _sum = sum;
            _vector = null;
            _result = null;
            Iterator(0, dim);
            return _result;
        }

        private static void Iterator(int index, int dim)
        {
            if(_result != null)
            {
                return;
            }

            if(_vector is null)
            {
                _vector = new int[dim];
            }

            if(dim > 0)
            {
                for(var i = index; i < _input.Count; i++)
                {
                    _vector[dim - 1] = i;
                    Iterator(i, dim - 1);
                }
            }
            else
            {
                if(_vector.Sum(i => _input[i]) == _sum)
                {
                    _result = 1;
                    for(var v = 0; v<_vector.Length; v++)
                    {
                        _result *= _input[_vector[v]];
                    }
                }
            }
        }
    }
}
