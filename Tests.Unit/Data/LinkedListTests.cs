using OnlineShop.Data.Structures;
using Xunit;

namespace Tests.Unit.Data
{
    public class LinkedListTests
    {
        private readonly LinkedListCircular<int> _linkedList;

        public LinkedListTests()
        {
            _linkedList = new LinkedListCircular<int>();
        }

        [Fact]
        public void AddHead_OnEmptyList_HeadAndTailAreSame()
        {
            var nodeOne = 0;
            _linkedList.AddHead(value: nodeOne);

            Assert.Equal(_linkedList.Head.Value, nodeOne);
            Assert.Equal(_linkedList.Head, _linkedList.Tail);
        }

        [Fact]
        public void AddHead_OnNotEmptyList_AddsAdditionalNode()
        {
            var nodeOne = 1;
            var nodeTwo = 2;
            var nodeThree = 3;
            _linkedList.AddHead(value: nodeOne);
            _linkedList.AddHead(value: nodeTwo);
            _linkedList.AddHead(value: nodeThree);

            Assert.Equal(_linkedList.Head.Value, nodeThree);
            Assert.Equal(_linkedList.Tail.Value, nodeOne);
            Assert.Equal(_linkedList.Tail.Next.Value, nodeTwo);
            Assert.Equal(_linkedList.Head.Prev.Value, nodeTwo);

            Assert.NotEqual(_linkedList.Head, _linkedList.Tail);
            Assert.NotEqual(_linkedList.Head, _linkedList.Head.Prev);

            Assert.Equal(_linkedList.Head.Next, _linkedList.Tail);
            Assert.Equal(_linkedList.Head.Prev, _linkedList.Tail.Next);
            Assert.Equal(_linkedList.Tail.Prev, _linkedList.Head);

        }
    }
}