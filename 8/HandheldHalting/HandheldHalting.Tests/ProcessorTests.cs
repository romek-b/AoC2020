using System.Collections.Generic;
using Xunit;

namespace HandheldHalting.Tests
{
    public class ProcessorTests
    {
        [Fact]
        public void Execute_Works()
        {
            // arrange

            // act
            _processor.Execute();

            // assert
            Assert.Equal(5, _processor.Acc);
        }

        private readonly Processor _processor;

        public ProcessorTests()
        {
            var input = new List<string>()
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            _processor = new Processor(input);
        }
    }
}
