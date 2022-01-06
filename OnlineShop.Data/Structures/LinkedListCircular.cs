namespace OnlineShop.Data.Structures
{
    public class LinkedListCircular<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public void AddHead(T value)
        {
            Node<T> newHead = new Node<T>(value);

            if (Head == null)
            {
                Head = newHead;
                Head.Next = newHead;
                Head.Prev = newHead;
                Tail = newHead;

                return;
            }

            newHead.Next = Head.Next;
            newHead.Prev = Head;
            Head.Next = newHead;
            Tail.Prev = newHead;

            Head = newHead;
        }
    }
}
