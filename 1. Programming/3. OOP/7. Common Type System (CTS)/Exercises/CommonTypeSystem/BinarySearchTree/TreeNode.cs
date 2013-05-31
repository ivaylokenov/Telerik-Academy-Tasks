using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class TreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
            this.Parent = null;
        }

        public int CompareTo(T other)
        {
            return this.Value.CompareTo(other);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object otherObject)
        {
            TreeNode<T> other = (TreeNode<T>)otherObject;
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
