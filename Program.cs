namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FakeList<int> list = new FakeList<int>();
            FakeList<int> list2 = new FakeList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(8);
            list.Add(7);
            list.RemoveAt(6);
            list.Remove(2);
            list.Insert(4, 47);
            list2.Add(1);
            list2.Add(3);
            list2.Add(2);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            list2.Add(8);
            list2.Add(7);
            list2.RemoveAt(6);
            list2.Remove(2);
            list2.Insert(4, 47);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in list2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(list.Equals(list2));
            Console.WriteLine(list.Contains(47));
            list.Clear();
            Console.WriteLine(list.Count);
        }
    }
}
