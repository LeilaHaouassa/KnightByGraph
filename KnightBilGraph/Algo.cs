using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightBilGraph
{
    class Algo
    {
        

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
           
        }








       


    }
}
