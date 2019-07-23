using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightBilGraph
{
    class Algo
    {
        //public Func<Node, IEnumerable<Node>> ShortestPathFunction(Graph graph, Node source)
        //{

        //    var previous = new Dictionary<Node, Node>();

        //    var queue = new Queue<Node>();
        //    queue.Enqueue(source);

        //    while (queue.Count > 0)
        //    {
        //        var vertex = queue.Dequeue();
        //        foreach (var neighbor in vertex.Neighbours)
        //        {
        //            if (previous.ContainsKey(neighbor))
        //                continue;

        //            previous[neighbor] = vertex;
        //            queue.Enqueue(neighbor);
        //        }
        //    }

        //    Func<Node, IEnumerable<Node>> shortestPath = v =>
        //    {
        //        var path = new List<Node> { };

        //        Node current = v;
        //        while (!current.Equals(source))
        //        {
        //            path.Add(current);
        //            current = previous[current];
        //        };

        //        path.Add(source);
        //        path.Reverse();

        //        return path;
        //    };

        //    return shortestPath;

        //}

        public bool BFS(ref Node src, ref Node dest)
        {
            var queue = new List<Node>();
            src.IsChecked = true;
            queue.Add(src);
            // standard BFS algorithm 
            while (queue.Count != 0)
            {
                //queue = queue.OrderBy(p => p.Distance).ToList();
                var current = queue.First();
                queue.RemoveAt(0);


                current.IsChecked = true;

                foreach (var neighbour in current.Neighbours)
                {
                    if (!neighbour.IsChecked)
                    {
                        //neighbour.IsChecked = true;
                        queue.Add(neighbour);
                        if (neighbour.Distance > current.Distance + 1)
                        {
                            neighbour.previous = current;
                            neighbour.Distance = current.Distance + 1;
                        }


                    }

                }
            }

            if (dest.previous == null)

                return false;
            else return true;
        }


        public List<Node> ShortestDistance(ref Node src, ref Node dest)
        {


            //int dist[v];

            if (BFS(ref src, ref dest) == false)
            {
                Console.WriteLine("Given source and destination  are not connected");
                return null;
            }

            // vector path stores the shortest path 
            List<Node> path = new List<Node>();
            Node current = dest;
            path.Add(current);
            while (current.previous != null)
            {
                path.Add(current.previous);
                current = current.previous;
            }
            return path;
            // distance from source is in distance array 


            // printing path from source to destination 
            //Console.WriteLine( "\nPath is::\n");
            //for (int i = path.Count - 1; i >= 0; i--)
            //     Console.Write("( "+path[i].ValueX+" , "+path[i].ValueX+" )   ");
        }








        //public List<Node> GetBestPath(List<Node> last, Node target)
        //{
        //    List<Node> best = null;

        //    foreach (var next in last[last.Count-1].Neighbours)
        //    {
        //        if (!next.IsChecked)
        //        {
        //            next.IsChecked = true;
        //            last.Add(next);
        //            List<Node> e = GetBestPath(last, target);

        //            if( e.Count > best.Count || best == null )
        //            {
        //                best = e;
        //            }

        //        }
        //        if (next.ValueX == target.ValueX && next.ValueX == target.ValueX) { break; }
        //    }
        //    return best;
        //}


    }
}
