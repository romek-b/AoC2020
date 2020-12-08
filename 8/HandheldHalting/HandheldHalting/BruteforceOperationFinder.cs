using System.Collections.Generic;
using System.Linq;

namespace HandheldHalting
{
    public class BruteforceOperationFinder
    {
        private readonly IList<Operation> operations;

        public BruteforceOperationFinder(IEnumerable<string> listings)
        {
            operations = listings.Select(l => new Operation(l)).ToList();
        }

        public int Find()
        {
            var index = 0;
            var processor = new Processor(operations);
            processor.Execute();
            while (!processor.Completed)
            {
                switch (operations[index].Type)
                {
                    case Op.Nop:
                    case Op.Jmp:
                        var currOp = operations[index];
                        var newOps = new List<Operation>(operations);
                        newOps[index] = new Operation((currOp.Type == Op.Jmp ? Op.Nop : Op.Jmp), currOp.Value);
                        processor = new Processor(newOps);
                        processor.Execute();
                        break;
                    default:
                        break;
                }
                    
                index++;
            }

            return processor.Acc;
        }
    }
}
