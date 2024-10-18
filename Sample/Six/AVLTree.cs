using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    public static class AVLTree
    {
        //获取节点高度
        private static int GetHeight(TreeNode node)
        {
            return node?.Height ?? 0;
        }

        //获取平衡因子
        private static int GetBalanceFactor(TreeNode node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        //二叉树插入
        public static TreeNode Insert(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);

            if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }
            else if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                return node;
            }

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return node;
        }

        //AVL树插入
        public static TreeNode AVLInsert(TreeNode node, int value)
        {
            var oldTree = Insert(node, value);

            int balance = GetBalanceFactor(oldTree);

            //LL
            if (balance > 1 && GetBalanceFactor(oldTree.Left) > 0)
            {
                return RotateRight(oldTree);
            }

            //LR
            if (balance > 1 && GetBalanceFactor(oldTree.Left) < 0)
            {
                oldTree.Left = RotateLeft(oldTree.Left);
                return RotateRight(oldTree);
            }

            //RR
            if (balance < -1 && GetBalanceFactor(oldTree.Right) < 0)
            {
                return RotateLeft(oldTree);
            }
            //RL
            if (balance < -1 && GetBalanceFactor(oldTree.Right) > 0)
            {
                oldTree.Right = RotateRight(oldTree.Right);
                return RotateLeft(oldTree);
            }

            return oldTree;
        }

        //右旋
        public static TreeNode RotateRight(TreeNode node)
        {
            var LeftNode = node.Left;
            var LeftsRightChildNode = LeftNode.Right;

            LeftNode.Right = node;
            node.Left = LeftsRightChildNode;

            node.Height = Math.Max(GetHeight(node.Right), GetHeight(node.Left)) + 1;
            LeftNode.Height = Math.Max(GetHeight(LeftNode.Left), GetHeight(LeftNode.Right)) + 1;

            return LeftNode;
        }

        //左旋
        public static TreeNode RotateLeft(TreeNode node)
        {
            var RightNode = node.Right;
            var RightsLeftChildNode = RightNode.Left;

            RightNode.Left = node;
            node.Right = RightsLeftChildNode;

            node.Height = Math.Max(GetHeight(node.Right), GetHeight(node.Left)) + 1;
            RightNode.Height = Math.Max(GetHeight(RightNode.Left), GetHeight(RightNode.Right)) + 1;

            return RightNode;
        }
    }
}
