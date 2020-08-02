using System;
using System.Collections.Generic;
using System.Text;

namespace ListsExercise
{
     
    public sealed class TreesOperation
    {
        public static TreesOperation Instance { get; private set; } = new TreesOperation();
        public Node Root { get; set; }
        public TreesOperation() {  }

        public Node FindNode(int key, Node node)
        {
            if (node == null || node.Key == key) return node;
            if (key <= node.Left?.Key) return FindNode(key, node.Left);
            if (key >= node.Right?.Key) return FindNode(key, node.Right);

            return node;
        }

        public Node InsertNode(Node node, int key, int value)
        {
            if (node == null) return new Node(null, key, value, null);
            if (node.Key == key) return new Node(node.Left, key, value, node.Right);
            if (node.Key > key) return new Node(InsertNode(node.Left, key, value), node.Key, node.Data, node.Right);
            return new Node(node.Left, node.Key, node.Data, InsertNode(node.Right, key, value));
        }

        public int BinarySearch(int[] collection, int target)
        {
            var length = collection.Length;
            var leftSideIndex = 0;
            var rightSideIndex = length - 1;

            while (leftSideIndex != rightSideIndex)
            {
                var middleValue = Convert.ToInt32(Math.Ceiling((rightSideIndex + leftSideIndex) / 2m));
                if(collection[middleValue] > target)
                {
                    rightSideIndex = middleValue - 1;
                }
                else
                {
                    leftSideIndex = middleValue;
                }

                if (collection[leftSideIndex] == target)
                    return leftSideIndex;
            }
            return -1;
        }

        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
        }

        public int MinDepth(Node root)
        {
            return 1 + Math.Min(MinDepth(root.Left), MinDepth(root.Right));

        }

        public bool IsBalanced (Node root)
        {
            return (MaxDepth(root) - MinDepth(root) <= 1);
        }
    }
    public class Node
    {
        public Node(Node left, int key, int data, Node right)
        {
            Key = key;
            Data = data;
            Left = left;
            Right = right;
        }

        public int Key { get; set; }
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
    
}
