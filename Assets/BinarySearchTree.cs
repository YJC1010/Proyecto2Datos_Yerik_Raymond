using System;
using UnityEngine; // ← Importante para usar Debug.Log

public class TreeNode
{
    public int Key;
    public TreeNode Left, Right;

    public TreeNode(int item)
    {
        Key = item;
        Left = Right = null;
    }
}

public class BinarySearchTree 
{
    private TreeNode root;

    public BinarySearchTree()
    {
        root = null;
    }

    public bool Search(int key)
    {
        return SearchRecursive(root, key);
    }

    private bool SearchRecursive(TreeNode node, int key)
    {
        if (node == null)
        {
            return false;
        }
        if (node.Key == key)
        {
            return true;
        }
        else if (key > node.Key)
        {
            return SearchRecursive(node.Right, key);
        }
        else
        {
            return SearchRecursive(node.Left, key);
        }
    }

    public void Insert(int key)
    {
        root = InsertRecursive(root, key);
    }

    private TreeNode InsertRecursive(TreeNode node, int key)
    {
        if (node == null)
        {
            return new TreeNode(key);
        }

        if (key < node.Key)
        {
            node.Left = InsertRecursive(node.Left, key);
        }
        else if (key > node.Key)
        {
            node.Right = InsertRecursive(node.Right, key);
        }

        return node;
    }

    public void Delete(int key)
    {
        root = DeleteRecursive(root, key);
    }

    private TreeNode DeleteRecursive(TreeNode node, int key)
    {
        if (node == null) return node;

        if (key < node.Key)
        {
            node.Left = DeleteRecursive(node.Left, key);
        }
        else if (key > node.Key)
        {
            node.Right = DeleteRecursive(node.Right, key);
        }
        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            node.Key = MinValue(node.Right);
            node.Right = DeleteRecursive(node.Right, node.Key);
        }
        return node;
    }

    private int MinValue(TreeNode node)
    {
        int minValue = node.Key;
        while (node.Left != null)
        {
            minValue = node.Left.Key;
            node = node.Left;
        }
        return minValue;
    }

    public string InOrder()
    {
        string result = "";
        InOrderRecursive(root, ref result);
        return result;
    }

    private void InOrderRecursive(TreeNode node, ref string result)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left, ref result);
            result += node.Key + " ";
            InOrderRecursive(node.Right, ref result);
        }
    }

    public string PreOrder()
    {
        string result = "";
        PreOrderRecursive(root, ref result);
        return result;
    }

    private void PreOrderRecursive(TreeNode node, ref string result)
    {
        if (node != null)
        {
            result += node.Key + " ";
            PreOrderRecursive(node.Left, ref result);
            PreOrderRecursive(node.Right, ref result);
        }
    }

    public string PostOrder()
    {
        string result = "";
        PostOrderRecursive(root, ref result);
        return result;
    }

    private void PostOrderRecursive(TreeNode node, ref string result)
    {
        if (node != null)
        {
            PostOrderRecursive(node.Left, ref result);
            PostOrderRecursive(node.Right, ref result);
            result += node.Key + " ";
        }
    }
}
