using System;

namespace Project_1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null) head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node = head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(4);
            list.Add(5);
            list.Add(1);
            Console.WriteLine("List:");
            list.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            list.ForEach(i =>
            {
                sum += i;
                if (i > max) max = i;
                if (i < min) min = i;
            });
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
        }
    }
}
