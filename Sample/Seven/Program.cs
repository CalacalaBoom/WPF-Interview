

namespace Seven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 逆波兰表示法
            //string infix = "A - ( ( C + D ) * B )";
            //string postfix = InfixToPostfix(infix);
            //Console.WriteLine(postfix);
            #endregion

            #region 回溯算法
            int[,] maze = {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
            };

            (int, int) start = (0, 0);
            (int, int) end = (4, 4);

            List<(int, int)> path = FindPath(maze, start, end);

            // 输出结果
            if (path != null)
            {
                Console.WriteLine("找到路径:");
                foreach (var point in path)
                {
                    Console.WriteLine($"({point.Item1}, {point.Item2})");
                }
            }
            else
            {
                Console.WriteLine("没有找到路径");
            }
            #endregion

            Console.ReadLine();
        }
        //上、右、下、左
        private static readonly int[] dx = new int[] { -1, 0, 1, 0 };
        private static readonly int[] dy = new int[] { 0, 1, 0, -1 };
        private static List<(int, int)> FindPath(int[,] maze, (int, int) start, (int, int) end)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            Stack<(int, int)> stack = new Stack<(int, int)>();
            bool[,] visited = new bool[rows, cols];

            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int x = current.Item1;
                int y = current.Item2;

                //如果已经访问过，跳过
                if (visited[x, y])
                    continue;
                //标记为已访问
                visited[x, y] = true;

                //如果已经到达终点
                if (current == end)
                {
                    var result = new List<(int, int)>(stack);
                    result.Add(current);
                    return result;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dx[i];
                    int newY = y + dy[i];

                    if (IsValidMove(maze, visited, newX, newY))
                    {
                        stack.Push(current);  // 回溯需要，先存储当前点
                        stack.Push((newX, newY));  // 移动到新位置
                        break;
                    }
                }
            }

            return null;
        }

        private static bool IsValidMove(int[,] maze, bool[,] visited, int newX, int newY)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);


            return newX >= 0 && newY >= 0 && newX < rows && newY < cols && maze[newX, newY] == 0 && !visited[newX, newY];
        }

        static string InfixToPostfix(string infix)
        {
            var output = new List<string>();
            var stack = new Stack<string>();
            var tokens = infix.Split(' '); // 假设用空格分隔

            foreach (var token in tokens)
            {
                if (IsOperand(token))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Pop(); // 弹出左括号
                }
                else // 运算符
                {
                    while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(token))
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return string.Join(" ", output);
        }

        static bool IsOperand(string token)
        {
            // 假设操作数为单个字母
            return char.IsLetter(token[0]);
        }

        static int Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
