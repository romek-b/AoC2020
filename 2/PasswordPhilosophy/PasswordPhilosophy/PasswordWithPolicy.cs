using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordPhilosophy
{
    public class PasswordWithPolicy
    {
        private readonly int _low;
        private readonly int _high;
        private readonly char _letter;
        private readonly char[] _password;

        private static Regex _pattern = new Regex(@"^(\d+)-(\d+)\s(\w):\s(\w+)$");

        public PasswordWithPolicy(int low, int high, char letter, string password)
        {
            _low = low;
            _high = high;
            _letter = letter;
            _password = password.ToCharArray();
        }

        public bool WasValid
        {
            get
            {
                var count = _password.Count(c => c == _letter);
                return count >= _low && count <= _high;
            }
        }

        public bool IsValid
        {
            get
            {
                return _password[_low - 1] == _letter
                    ^ _password[_high - 1] == _letter;
            }
        }

        public static explicit operator PasswordWithPolicy(string entry)
        {
            var match = _pattern.Match(entry);
            if (!match.Success)
            {
                throw new InvalidCastException($"'{entry}' does not match password with policy pattern!");
            }

            return new PasswordWithPolicy(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                char.Parse(match.Groups[3].Value),
                match.Groups[4].Value
            );
        }
    }
}
