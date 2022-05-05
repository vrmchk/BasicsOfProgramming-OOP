using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Sharp
{
    internal class FormulaTree
    {
        public Node Root { get; private set; }

        public FormulaTree(object value) => Root = new Node(value);
        public FormulaTree(Node node) => Root = node;

        public void Insert(object value) => InsertHelper(value, Root);
        public void Insert(Node node) => InsertHelper(node, Root);

        public string LevelTraverse() =>
            LevelTraverseHelper(Root, new StringBuilder(Root.ToString().PadLeft(5) + "\n"));

        public string PreorderTraverse() => PreorderTraverseHelper(Root, new List<Node>());
        public string InorderTraverse() => InorderTraverseHelper(Root, new List<Node>());
        public string PostorderTraverse() => PostorderTraverseHelper(Root, new List<Node>());

        private void InsertHelper(object value, Node root)
        {
            if (root.Right == null) root.Right = new Node(value);
            else if (root.Left == null) root.Left = new Node(value);
            else InsertHelper(value, root.Left);
        }

        private void InsertHelper(Node node, Node root)
        {
            if (root.Right == null) root.Right = node;
            else if (root.Left == null) root.Left = node;
            else InsertHelper(node, root.Left);
        }

        private string LevelTraverseHelper(Node root, StringBuilder result)
        {
            if (root.Left != null) result.Append(root.Left);
            if (root.Right != null) result.Append(root.Right + "\n");
            if (root.Left != null) LevelTraverseHelper(root.Left, result);
            return result.ToString();
        }

        private string PreorderTraverseHelper(Node root, List<Node> nodes)
        {
            nodes.Add(root);
            if (root.Left != null) PreorderTraverseHelper(root.Left, nodes);
            if (root.Right != null) PreorderTraverseHelper(root.Right, nodes);
            return string.Join(' ', nodes);
        }

        private string PostorderTraverseHelper(Node root, List<Node> nodes)
        {
            if (root.Left != null) PostorderTraverseHelper(root.Left, nodes);
            if (root.Right != null) PostorderTraverseHelper(root.Right, nodes);
            nodes.Add(root);
            return string.Join(' ', nodes);
        }

        private string InorderTraverseHelper(Node root, List<Node> nodes)
        {
            if (root.Left != null) InorderTraverseHelper(root.Left, nodes);
            nodes.Add(root);
            if (root.Right != null) InorderTraverseHelper(root.Right, nodes);
            return string.Join(' ', nodes);
        }
    }
}