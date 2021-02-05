using System;
using System.IO;

class FileIO
{
    public Graph docFile(string tenFile)
    {
        char[] sep = { ' ', '\t' };
        string[] lines = File.ReadAllLines(tenFile);

        int n = int.Parse(lines[0]);
        Graph g = new Graph(n);

        for (int i = 1; i < lines.Length; ++i)
        {
            string[] content = lines[i].Split(sep, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < content.Length; ++j)
                g[i - 1, j] = int.Parse(content[j]);
        }

        return g;
    }
}