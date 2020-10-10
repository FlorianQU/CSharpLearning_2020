using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QueryAlgorithm
{
    public class BinaryTreeSearching
    {
        public int[] InputArray { get; set; }
        private BinaryTreeNode rootNode;
        public BinaryTreeSearching(int[] inputArray)
        {
            InputArray = inputArray;
            rootNode = null;
        }
        public BinaryTreeNode Insert(int value, BinaryTreeNode rootNode)
        {
            if (rootNode == null)
            {
                return new BinaryTreeNode(value);
            }
            else if (rootNode.Value > value)
            {
                rootNode.Left = Insert(value, rootNode.Left);
            }
            else if (rootNode.Value < value)
            {
                rootNode.Right = Insert(value, rootNode.Right);
            }
            return rootNode;
        }
        public void BuildBinaryTree()
        {
            foreach (int element in InputArray)
            {
                rootNode = Insert(element, rootNode);
            }
        }
        public bool Search(int value)
        {
            BinaryTreeNode newNode = rootNode;
            while (newNode != null)
            {
                if (newNode.Value == value)
                {
                    return true;
                }
                else if (newNode.Value > value)
                {
                    newNode = newNode.Left;
                }
                else if (newNode.Value < value)
                {
                    newNode = newNode.Right;
                }
            }
            return false;
        }
        public void ShowBinaryTree()
        {
            ShowBinaryTree(rootNode);
        }
        public void ShowBinaryTree(BinaryTreeNode startNode)
        {
            if (startNode != null)
            {
                ShowBinaryTree(startNode.Left);
                Console.Write($"{startNode.Value} ");
                ShowBinaryTree(startNode.Right);
            }
        }
    }
}
