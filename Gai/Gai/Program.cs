using System;

namespace Gai
{
    public class Program
    {
        public static void Main()
        {
            database bd = new database();

            bd.Add(9999, "Нарушение А");
            bd.Add(9999, "Нарушение В");
            bd.Add(9999, "Нарушение С");
            bd.Add(2099, "Нарушение А");
            bd.Add(1000, "Нарушение С");
            bd.Add(9333, "Нарушение С");
            bd.Add(9055, "Нарушение А");
            bd.Add(9055, "Нарушение В");

            bd.PrintNumber(1000);
            bd.PrintRangeNumber(10, 10000);
        }
    }

    sealed class ListViolations
    {
        public string violat;
        public ListViolations next;
    }

    sealed class TreeNode
    {
        public TreeNode parent;
        public TreeNode left;
        public TreeNode right;

        public int number;
        public ListViolations list;
    }

    sealed class database
    {
        private TreeNode root;

        public void Add(int value, string str)
        {
            Add(ref root, null, value, str);
        }

        public void Add(ref TreeNode head, TreeNode parent, int value, string str)
        {
            TreeNode temp = new TreeNode();
            temp.number = value;
            temp.list = null;
            temp.left = temp.right = temp.parent = null;

            if (head == null)
            {
                head = temp;
                Push(ref head.list, str);
            }
            else
            {
                if (value == head.number)
                    Push(ref head.list, str);
                else if (value < head.number)
                    Add(ref head.left, head, value, str);
                else
                    Add(ref head.right, head, value, str);
            }
        }

        public void PrintAll(TreeNode temp)
        {
            if (temp != null)
            {
                PrintAll(temp.left);
                Console.WriteLine($"Номер машины: {temp.number}");
                Console.WriteLine("Нарушения: ");
                PrintList(temp.list);
                PrintAll(temp.right);
            }
        }
        public void PrintNumber(int input)
        {
            TreeNode node = PrintNumber(root, input);
            if (node == null)
            {
                Console.WriteLine("Not found.");
            }
            else
            {
                Console.WriteLine($"Номер машины: {node.number}");
                Console.WriteLine("Нарушения: ");
                PrintList(node.list);
            }
        }

        public TreeNode PrintNumber(TreeNode node, int input)
        {
            if (node == null)
            {
                return null;
            }

            if (input == node.number)
            {
                return node;
            }
            else if (input < node.number)
            {
                return PrintNumber(node.left, input);
            }
            else
            {
                return PrintNumber(node.right, input);
            }
        }

        public void PrintRangeNumber(TreeNode node, int min, int max)
        {
            if (node == null)
            {
                return;
            }
            if (node.number > min)
            {
                PrintRangeNumber(node.left, min, max);
            }
            if (node.number >= min && node.number <= max)
            {
                Console.WriteLine($"Номер машины: {node.number}");
                Console.WriteLine("Нарушения: ");
                PrintList(node.list);
            }
            if (node.number < max)
            {
                PrintRangeNumber(node.right, min, max);
            }
        }

        public void PrintRangeNumber(int min, int max)
        {
            PrintRangeNumber(root, min, max);
        }

        public TreeNode ReturnRoot()
        {
            return root;
        }

        private static void PrintList(ListViolations Head)
        {
            ListViolations curr = Head;
            while (curr != null)
            {
                Console.WriteLine(curr.violat);
                curr = curr.next;
            }
        }

        private static void Push(ref ListViolations node, string newStr)
        {
            ListViolations tmp = new ListViolations();
            tmp.violat = newStr;
            tmp.next = null;

            if (node == null)
            {
                node = tmp;
            }
            else
            {
                tmp.next = node;
                node = tmp;
            }
        }
    }
}