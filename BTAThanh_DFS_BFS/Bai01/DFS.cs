using System;
using System.Collections.Generic;
using System.Linq;

class DFS
{
    private Graph g;
    private bool[] visited;
    private int endVertex, startVertex;

    public DFS(Graph g)
    {
        visited = Enumerable.Repeat(false, g.n).ToArray();
        this.g = g;
    }

    public void startDFS(int startVertex)
    {
        dfs(startVertex);
    }

    private void dfs(int startVertex)
    {
        visited[startVertex] = true;
        Console.WriteLine(startVertex);

        for (int v = 0; v < g.n; ++v)
            if (g[startVertex, v] > 0 && visited[v] == false)
            {
                dfs(v);
            }
    }

    private List<int> duongDi = new List<int>();
    private List<int> ketqua;
    private bool flag = false;

    private void timDuongDi(int startVertex)
    {
        duongDi.Add(startVertex);
        visited[startVertex] = true;

        if (startVertex == endVertex)
        {
            flag = true;
            ketqua = new List<int>(duongDi);
        }
        else
        {
            for (int v = 0; v < g.n; ++v)
            {
                if (g[startVertex, v] > 0 && visited[v] == false && flag == false)
                    timDuongDi(v);
            }
        }

        visited[startVertex] = false;
        duongDi.RemoveAt(duongDi.Count - 1);
    }

    public List<int> findPath(int startVertex, int endVertex)
    {
        this.startVertex = startVertex;
        this.endVertex = endVertex;

        timDuongDi(startVertex);

        return ketqua;
    }
}