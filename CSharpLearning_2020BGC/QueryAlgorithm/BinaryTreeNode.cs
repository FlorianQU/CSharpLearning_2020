using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAlgorithm
{
    public class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }
}
