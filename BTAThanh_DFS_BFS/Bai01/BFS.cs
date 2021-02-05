using System;
using System.Collections.Generic;
using System.Linq;

class BFS
{
    private Graph g;
    private bool[] visited;
    private int[] mang;

    public BFS(Graph g)
    {
        visited = Enumerable.Repeat(false, g.n).ToArray();
        mang = Enumerable.Repeat(-1, g.n).ToArray();
        this.g = g;
    }


    public void startBFS(int startVertex)
    {
        visited = Enumerable.Repeat(false, g.n).ToArray();
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

    private void timDuongDi(int startVertex, int endVertex)
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(startVertex);
        visited[startVertex] = true;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            for (int v = 0; v < g.n; ++v)
                if (g[u, v] > 0 && visited[v] == false)
                {
                    visited[v] = true;
                    queue.Enqueue(v);
                    mang[v] = u;

                    if (v == endVertex)
                        return;
                }
        }
    }

    public List<int> findPath(int startVertex, int endVertex)
    {
        timDuongDi(startVertex, endVertex);

        List<int> path = new List<int>();
        path.Add(endVertex);

        while (mang[endVertex] != -1)
        {
            path.Insert(0, mang[endVertex]);
            endVertex = mang[endVertex];
        }

        return path;
    }
}