using System;
using System.Collections.Generic;
using System.Linq;

namespace HandheldHalting
{
    public class Processor
    {
        private readonly IList<Operation> operations;

        private readonly IList<int> performedIndices;

        private int index;

        public int Acc { get; private set; }

        public bool Completed { get => index == operations.Count; }

        private Processor()
        {
            Acc = 0;
            index = 0;
            performedIndices = new List<int>();
        }

        public Processor(IEnumerable<Operation> operations) : this()
        {
            this.operations = operations.ToList();
        }

        public Processor(IEnumerable<string> listings) : this()
        {
            operations = listings.Select(l => new Operation(l)).ToList();
        }

        public void Execute()
        {
            while(index < operations.Count && !performedIndices.Contains(index))
            {
                performedIndices.Add(index);

                switch (operations[index].Type)
                {
                    case Op.Nop:
                        index++;
                        break;
                    case Op.Acc:
                        Acc += operations[index].Value;
                        index++;
                        break;
                    case Op.Jmp:
                        index += operations[index].Value;
                        break;
                    default:
                        throw new NotImplementedException("Cannot perform operation");
                }
            }
        }
    }
}
