using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    //decided not to write this task, too difficult at the moment, better try the exam preparation :)
    struct BinarySearchTree<T> : IEnumerable<TreeNode<T>>, ICloneable
        where T : IComparable<T>
    {
        private TreeNode<T> root;
    }
}
