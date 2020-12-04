using System.Collections.Generic;
using System.Linq;

namespace PassportProcessing
{
    public static class Processing
    {
        public static int CheckValidPassportsFromData(string data)
        {
            return CheckValidPassports(Convert(data));
        }

        public static int CheckStrictlyValidPassportsFromData(string data)
        {
            return CheckStrictlyValidPassports(Convert(data));
        }

        private static int CheckValidPassports(IEnumerable<Passport> passports)
        {
            return passports.Count(p => p.IsValid);
        }

        private static int CheckStrictlyValidPassports(IEnumerable<Passport> passports)
        {
            return passports.Count(p => p.IsStrictlyValid);
        }

        private static IEnumerable<Passport> Convert(string data)
        {
            var result = new List<Passport>();
            var entries = data.Split("\n\n");
            foreach(var entry in entries)
            {
                var hashtable = new Dictionary<string, string>();
                var kvs = entry.Split(new[] { ' ','\n'});
                foreach(var kv in kvs)
                {
                    if(!string.IsNullOrWhiteSpace(kv))
                    {
                        var akv = kv.Split(':');
                        hashtable.Add(akv[0], akv[1]);
                    }
                }
                result.Add(new Passport(hashtable));
            }
            return result;
        }
    }
}