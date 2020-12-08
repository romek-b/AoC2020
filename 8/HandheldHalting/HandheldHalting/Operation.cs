using System;

namespace HandheldHalting
{
    public struct Operation
    {
        public readonly Op Type;

        public readonly int Value;

        public Operation(Op type, int value)
        {
            Type = type;
            Value = value;
        }

        public Operation(string listing)
        {
            var split = listing.Split(" ");

            if (!Enum.TryParse<Op>(split[0], true, out var type))
            {
                throw new ArgumentException("Wrong operation type!");
            }

            if (!int.TryParse(split[1], out var value))
            {
                throw new ArgumentException("Unrecognized value!");
            }

            Type = type;
            Value = value;
        }
    }
}
