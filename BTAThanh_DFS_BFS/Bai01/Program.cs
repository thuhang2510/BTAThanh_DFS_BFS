using System;
using System.Collections.Generic;

namespace Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            Graph g = fileIO.docFile("bai01.txt");

            Console.WriteLine("Ma tran ke: ");
            g.display(" ");

            Console.WriteLine("Danh sach ke: ");
            g.displayDSKe(" ");

            Console.WriteLine("Danh sach canh: ");
            g.displayDSCanh(" ");

            Console.WriteLine("Duyet do thi theo DFS");
            DFS dfs = new DFS(g);
            dfs.startDFS(2);
            Console.WriteLine();

            Console.WriteLine("Duyet do thi theo BFS");
            BFS bfs = new BFS(g);
            bfs.startBFS(2);
            Console.WriteLine();

            Console.WriteLine("Tim duong di DFS");
            List<int> ketqua = dfs.findPath(3, 2);

            if (ketqua != null)
                Console.WriteLine(string.Join(" --> ", ketqua));
            else
                Console.WriteLine("Khong co duong di");

            Console.WriteLine();

            Console.WriteLine("Tim duong di BFS");
            ketqua = bfs.findPath(3, 2);

            if (ketqua.Count > 1)
                Console.WriteLine(string.Join(" --> ", ketqua));
            else
                Console.WriteLine("Khong co duong di");
        }
    }
}

