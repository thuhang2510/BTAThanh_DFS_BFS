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
        visited = new bool[g.n];
        this.g = g;
    }

    public void startDFS(int u)
    {
        visited = new bool[g.n];
        dfs(u);
    }

    private void dfs(int u)
    {
        visited[u] = true;
        Console.WriteLine(u);

        for (int v = 0; v < g.n; ++v)
            if (g[u, v] > 0 && visited[v] == false)
            {
                dfs(v);
            }
    }

    private List<int> duongDi = new List<int>();
    private List<int> ketqua;
    private bool flag;

    private void timDuongDi(int uBD)//tên tham số không được trùng tên với biến trong class
    {
        duongDi.Add(uBD);
        visited[uBD] = true;

        if (uBD == endVertex)
        {
            flag = true;
            ketqua = new List<int>(duongDi);
        }
        else
        {
            for (int v = 0; v < g.n; ++v)
            {
                if (g[uBD, v] > 0 && visited[v] == false && flag == false)
                    timDuongDi(v);
            }
        }

        visited[uBD] = false;
        duongDi.RemoveAt(duongDi.Count - 1);
    }

    public List<int> findPath(int uBD, int uKT)
    {
        visited = new bool[g.n];
        flag = false;
        startVertex = uBD;
        endVertex = uKT;

        timDuongDi(startVertex);

        return ketqua;
    }
}