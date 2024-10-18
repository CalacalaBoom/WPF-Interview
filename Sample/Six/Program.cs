namespace Six
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = new int[] { 10, 11, 8, 9, 6, 5, 7 };

            TreeNode tree = null;
            foreach (int value in values)
            {
                tree = AVLTree.AVLInsert(tree, value);
            }

            tree = AVLTree.AVLInsert(tree, 15);
            tree = AVLTree.AVLInsert(tree, 16);
            tree = AVLTree.AVLInsert(tree, 4);

            var result = Traversal.InOrderTraversal(tree);

            result.ForEach(x => { Console.Write(x+" "); });

            Console.ReadLine();
        }
    }
}
