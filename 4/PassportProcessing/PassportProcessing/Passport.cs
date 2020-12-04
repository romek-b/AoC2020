using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PassportProcessing
{
    public class Passport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }

        public Passport(IDictionary<string, string> data)
        {
            if(data.ContainsKey("byr"))
            {
                Byr = data["byr"];
            }
            if(data.ContainsKey("iyr"))
            {
                Iyr = data["iyr"];
            }
            if(data.ContainsKey("eyr"))
            {
                Eyr = data["eyr"];
            }
            if(data.ContainsKey("hgt"))
            {
                Hgt = data["hgt"];
            }
            if(data.ContainsKey("hcl"))
            {
                Hcl = data["hcl"];
            }
            if(data.ContainsKey("ecl"))
            {
                Ecl = data["ecl"];
            }
            if(data.ContainsKey("pid"))
            {
                Pid = data["pid"];
            }
            if(data.ContainsKey("cid"))
            {
                Cid = data["cid"];
            }
        }

        public bool IsValid
        {
            get 
            {
                return !string.IsNullOrWhiteSpace(Byr)
                    && !string.IsNullOrWhiteSpace(Iyr)
                    && !string.IsNullOrWhiteSpace(Eyr)
                    && !string.IsNullOrWhiteSpace(Hgt)
                    && !string.IsNullOrWhiteSpace(Hcl)
                    && !string.IsNullOrWhiteSpace(Ecl)
                    && !string.IsNullOrWhiteSpace(Pid);
            }
        }

        public bool IsStrictlyValid
        {
            get
            {
                var hgtValid = Hgt switch
                {
                    null => false,
                    _ when Hgt.Contains("cm") => int.TryParse(Hgt.Replace("cm", ""), out var ihgt)
                        && ihgt >= 150 && ihgt <= 193,
                    _ when Hgt.Contains("in") => int.TryParse(Hgt.Replace("in", ""), out var ihgt)
                        && ihgt >= 59 && ihgt <= 76,
                    _ => false
                };

                return IsValid &&
                    Byr.Length == 4 && int.TryParse(Byr, out var ibyr) &&
                        ibyr >= 1920 && ibyr <= 2002 &&
                    Iyr.Length == 4 && int.TryParse(Iyr, out var iiyr) &&
                        iiyr >= 2010 && iiyr <= 2020 &&
                    Eyr.Length == 4 && int.TryParse(Eyr, out var ieyr) &&
                        ieyr >= 2020 && ieyr <= 2030 &&
                    hgtValid &&
                    Hcl[0] == '#' && int.TryParse(Hcl[1..], NumberStyles.HexNumber, default, out var _) &&
                    PossibleEcl.Contains(Ecl) &&
                    Pid.Length == 9 && int.TryParse(Pid, out var _);
            }
        }

        private static readonly IEnumerable<string> PossibleEcl
            = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
    }
}