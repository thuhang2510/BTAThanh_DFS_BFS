using System;
using System.Collections.Generic;
using System.Linq;

class BFS
{
    private Graph g;
    private int[] trace;

    public BFS(Graph g)
    {
        trace = Enumerable.Repeat(-1, g.n).ToArray();
        this.g = g;
    }

    public void startBFS(int startVertex)
    {
        bool[] visited = new bool[g.n]; //phải để cục bộ
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(startVertex);
        visited[startVertex] = true;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            Console.WriteLine(u);

            for (int v = 0; v < g.n; ++v)
                if (g[u, v] > 0 && visited[v] == false)
                {
                    visited[v] = true;
                    queue.Enqueue(v);
                }
        }
    }

    private void timDuongDi(int uBD, int uKT)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[g.n];

        queue.Enqueue(uBD);
        visited[uBD] = true;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            for (int v = 0; v < g.n; ++v)
                if (g[u, v] > 0 && visited[v] == false)
                {
                    visited[v] = true;
                    queue.Enqueue(v);
                    trace[v] = u;

                    if (v == uKT)
                        return;
                }
        }
    }

    //findPath phải trả về đường đi không bị đảo ngược
    public List<int> findPath(int startVertex, int endVertex)//các input tuyệt đối không thay đổi giá trị
    {
        trace = Enumerable.Repeat(-1, g.n).ToArray();

        timDuongDi(startVertex, endVertex);

        List<int> path = new List<int>();
        int u = endVertex;

        if (trace[u] == -1)
            return path;

        path.Add(u);

        while (trace[u] != -1)
        {
            path.Add(trace[u]);
            u = trace[u];
        }

        path.Reverse();

        return path;
    }
}