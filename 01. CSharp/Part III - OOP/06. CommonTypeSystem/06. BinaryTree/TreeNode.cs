using System;
using System.Text;

namespace _06.BinaryTree
{
    public class TreeNode<T>
    {
        // Fields
        public T Element { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        // Constructors
        public TreeNode(T element)
        {
            this.Element = element;
        }

        // Methods
        public override string ToString()
        {
            return this.ToString(1);
        }

        private string ToString(int tabs)
        {
            StringBuilder nodeString = new StringBuilder();

            if (tabs == 1)
            {
                nodeString.Append("Roof > ");
            }

            nodeString.Append(this.Element);

            // Leaf node
            if (this.Left == null && this.Right == null)
            {
                nodeString.Append(" - Leaf!");
            }

            if (this.Left != null)
            {
                nodeString.Append("\n");
                nodeString.Append(new string('\t', tabs));
                nodeString.Append("Left <--- ");
                nodeString.Append(this.Left.ToString(tabs + 1));
            }

            if (this.Right != null)
            {
                nodeString.Append("\n");
                nodeString.Append(new string('\t', tabs));
                nodeString.Append("Right ---> ");
                nodeString.Append(this.Right.ToString(tabs + 1));
            }

            return nodeString.ToString();
        }
    }
}
