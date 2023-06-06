using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexmapGame
{
    internal class Dijkstra
    {
        public class Pair
        {
            public int vertexNumber;
            public int cost;

            public Pair(int vertexNumber, int cost)
            {
                this.vertexNumber = vertexNumber;
                this.cost = cost;
            }
        }

        public class Node
        {
            public int vertexNumber;

            //Adjacency list that shows the vertexNumber of child vertex and the weight of the edge (cost)
            public List<Pair> children;

            public Node(int vertexNumber)
            {
                this.vertexNumber = vertexNumber;
                children = new List<Pair>();
            }

            //Function to add the child for the given node
            public void Add_child(int vertexNumber, int cost)
            {
                Pair p = new Pair(vertexNumber, cost);
                children.Add(p);
            }
        }

        //Function to find the shortest path in a directed graph from source vertex to other vertices
        public static int[] Dist(List<Node> graph, int sourceVertex)
        {
            int[] path = new int[graph.Count];  //previous vertex for 'i' vertex
            int[] dist = new int[graph.Count];  //distance of each vertex from source vertex
            bool[] visited = new bool[graph.Count]; //vertex 'i' is visited or not

            for (int i = 0; i < graph.Count; i++)
            {
                visited[i] = false;
                path[i] = -1;
                dist[i] = Int32.MaxValue;
            }
            dist[sourceVertex] = 0;
            path[sourceVertex] = -1;
            int current = sourceVertex;

            
            HashSet<int> hSet = new HashSet<int>(); //set containing unvisited, reachable atm vertices

            while (true)
            {
                visited[current] = true; //mark current vertex as visited

                for (int i = 0; i < graph[current].children.Count; i++)
                {
                    int v = graph[current].children[i].vertexNumber;
                    if (visited[v]) continue;

                    hSet.Add(v);

                    //Relaxation
                    int newDist = dist[current] + graph[current].children[i].cost;
                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        path[v] = current;
                    }
                }

                hSet.Remove(current);
                if (hSet.Count == 0) break;

                //Loop to choose the next visited vertex
                int minDist = Int32.MaxValue;
                int index = 0;
                foreach (int vertex in hSet)
                {
                    if (dist[vertex] < minDist)
                    {
                        minDist = dist[vertex];
                        index = vertex;
                    }
                }
                current = index;
            }

            return path;
        }

        //Function to get the path from the source vertex to the target vertex
        public static List<int> GetPath(int[] path, int targetVertex)
        {
            List<int> verticeList = new List<int>();

            while (path[targetVertex] != -1)
            {
                targetVertex = path[targetVertex];
                verticeList.Add(targetVertex);
            } 
            verticeList.Reverse();
                
            return verticeList;
        }
    }
}