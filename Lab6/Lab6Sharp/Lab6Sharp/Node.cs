namespace Lab6Sharp
{
    internal class Node
    {
        public Node(object value)
        {
            Value = value;
            Left = Right = null;
        }

        public object Value { get; private set; }

        public Node? Left { get; set; }

        public Node? Right { get; set; }

        public override string ToString() => $"[{Value}]";
    }
}