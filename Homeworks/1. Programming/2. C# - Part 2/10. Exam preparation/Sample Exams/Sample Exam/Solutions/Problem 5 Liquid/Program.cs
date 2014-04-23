using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Liquid
{
    public class Liquid
    {
        static int width;
        static int height;
        static int depth;
        static int[, ,] cuboid;

        static Graph graph;
        static int startNode;
        static int endNode;

        static void Main()
        {
            ReadCuboid();
            BuildGraph();
            int maxFlow = FordFulkersonAlgorithm.MaxFlow(
                graph, (int)startNode, (int)endNode);
            Console.WriteLine(maxFlow);
        }

        private static void ReadCuboid()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);

            // Read the cuboid content
            cuboid = new int[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] sequences = line.Split('|');
                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = sequences[d].Split(
                        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        int cubeValue = int.Parse(numbers[w]);
                        cuboid[w, h, d] = cubeValue;
                    }
                }
            }
        }

        private static void BuildGraph()
        {
            // For each cube from the cuboid we assign two nodes in the graph
            int graphNodesCount = 2 * (width * height * depth) + 2;
            graph = new Graph(graphNodesCount);

            // Add edges from the startNode to the top side of the cuboid
            startNode = graphNodesCount - 2;
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    int topSideNode = CalcNodeNumber(w, h, 0, 0);
                    int capacity = cuboid[w, h, 0];
                    graph.AddEdge(startNode, topSideNode, capacity);
                }
            }

            // Add edges between each cube and its 5 neighbors
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        AddEdgeIfPossible(w, h, d, w + 1, h, d);
                        AddEdgeIfPossible(w, h, d, w - 1, h, d);
                        AddEdgeIfPossible(w, h, d, w, h + 1, d);
                        AddEdgeIfPossible(w, h, d, w, h - 1, d);
                        AddEdgeIfPossible(w, h, d, w, h, d + 1);
                        AddEdgeBetweenDoubledNode(w, h, d);
                    }
                }
            }

            // Add edges from the bottom side of the cuboid the the endNode
            endNode = graphNodesCount - 1;
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    int bottomSideNode = CalcNodeNumber(w, h, depth - 1, 1);
                    int capacity = cuboid[w, h, depth - 1];
                    graph.AddEdge(bottomSideNode, endNode, capacity);
                }
            }
        }

        private static void AddEdgeBetweenDoubledNode(int w, int h, int d)
        {
            int fromNode = CalcNodeNumber(w, h, d, 0);
            int toNode = CalcNodeNumber(w, h, d, 1);
            int capacity = cuboid[w, h, d];
            graph.AddEdge(fromNode, toNode, capacity);
        }

        private static void AddEdgeIfPossible(
            int fromW, int fromH, int fromD,
            int toW, int toH, int toD)
        {
            if ((toW >= 0 && toW < width) &&
                (toH >= 0 && toH < height) &&
                (toD >= 0 && toD < depth))
            {
                int fromNode = CalcNodeNumber(fromW, fromH, fromD, 1);
                int toNode = CalcNodeNumber(toW, toH, toD, 0);
                int fromCapacity = cuboid[fromW, fromH, fromD];
                int toCapacity = cuboid[toW, toH, toD];
                int edgeCapacity = Math.Min(fromCapacity, toCapacity);
                graph.AddEdge(fromNode, toNode, edgeCapacity);
            }
        }

        private static int CalcNodeNumber(int w, int h, int d, int side)
        {
            return
                side * (width * height * depth) +
                (d * width * height) +
                (h * width) + w;
        }
    }

    class Graph
    {
        public List<int>[] ChildNodes { get; private set; }
        public int[,] Capacities { get; private set; }
        public int NodesCount { get { return this.ChildNodes.Length; } }

        public Graph(int size)
        {
            this.ChildNodes = new List<int>[size];
            for (int node = 0; node < size; node++)
            {
                this.ChildNodes[node] = new List<int>();
            }
            this.Capacities = new int[size, size];
        }

        public void AddEdge(int fromNode, int toNode, int capacity)
        {
            this.ChildNodes[fromNode].Add((int)toNode);
            this.Capacities[fromNode, toNode] = capacity;
        }
    }

    class FordFulkersonAlgorithm
    {
        public static int MaxFlow(Graph g, int sourceNode, int terminalNode)
        {
            int maxFlow = 0;

            while (true)
            {
                List<int> augumentingPath = FindAugumentingPathBFS(g, sourceNode, terminalNode);
                if (augumentingPath == null)
                {
                    // No more augumenting paths --> max flow is found
                    break;
                }
                int pathCapacity = GetPathCapacity(g, augumentingPath);
                AugmentPath(g, augumentingPath, pathCapacity);
                maxFlow += pathCapacity;
            }

            return maxFlow;
        }

        private static int GetPathCapacity(Graph g, List<int> path)
        {
            int pathCapacity = int.MaxValue;
            for (int i = 0; i < path.Count - 1; i++)
            {
                int fromNode = path[i];
                int toNode = path[i + 1];
                int edgeCapacity = g.Capacities[fromNode, toNode];
                if (edgeCapacity < pathCapacity)
                {
                    pathCapacity = edgeCapacity;
                }
            }

            return pathCapacity;
        }

        private static void AugmentPath(Graph g, List<int> path, int minCapacity)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                int fromNode = path[i];
                int toNode = path[i + 1];
                g.Capacities[fromNode, toNode] -= minCapacity;
                g.Capacities[toNode, fromNode] += minCapacity;
            }
        }

        private static List<int> FindAugumentingPathBFS(Graph g, int startNode, int endNode)
        {
            int?[] prevNode = new int?[g.NodesCount];
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[g.NodesCount];
            visited[startNode] = true;
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();

                if (currentNode == endNode)
                {
                    // Build the path by using prevNode[]
                    List<int> path = new List<int>();
                    int? node = endNode;
                    while (node != null)
                    {
                        path.Add(node.Value);
                        node = prevNode[node.Value];
                    }
                    path.Reverse();
                    return path;
                }

                // Append all possible child nodes to the queue
                foreach (var childNode in g.ChildNodes[currentNode])
                {
                    var capacity = g.Capacities[currentNode, childNode];
                    if (capacity > 0 && !visited[childNode])
                    {
                        prevNode[childNode] = currentNode;
                        visited[childNode] = true;
                        queue.Enqueue(childNode);
                    }
                }
            }

            return null;
        }
    }
}
