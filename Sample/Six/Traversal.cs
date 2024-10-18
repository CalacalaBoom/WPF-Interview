using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    public static class Traversal
    {
        public static List<int> InOrderTraversal(TreeNode? node)
        {
            List<int> result = new List<int>();
            InOrderTraversalHelper(node, result);
            return result;
        }

        //中序遍历
        private static void InOrderTraversalHelper(TreeNode? node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            // 递归遍历左子树
            InOrderTraversalHelper(node.Left, result);

            // 添加当前节点的值到结果列表中
            result.Add(node.Value);

            // 递归遍历右子树
            InOrderTraversalHelper(node.Right, result);
        }
    }
}
