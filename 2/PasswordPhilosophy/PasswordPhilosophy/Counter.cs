using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordPhilosophy
{
    public static class Counter
    {
        public static int CountUsedToBeValidPasswords(IEnumerable<string> lines)
        {
            return CountValidPassswords(lines, pwd => pwd.WasValid);
        }

        public static int CountCurrentlyValidPasswords(IEnumerable<string> lines)
        {
            return CountValidPassswords(lines, pwd => pwd.IsValid);
        }

        private static int CountValidPassswords(IEnumerable<string> lines, Func<PasswordWithPolicy, bool> rule)
        {
            return lines.Select(c => (PasswordWithPolicy)c).Count(rule);
        }
    }
}
