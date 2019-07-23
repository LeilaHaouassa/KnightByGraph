using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightBilGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Give me the size of the board : ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <=0 )
            {
                Console.WriteLine("Wrong Input Try Again! ");
                Console.WriteLine("Give me the size of the board : ");

            }
            //try { n = int.Parse(Console.ReadLine()); }
            //catch (Exception e) { Console.WriteLine("invalid input for board size"); }
            
            string[][] board = new string[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new string[n];
            }
            
            int x1 = 0;
            
            int y1 = 0;
            Console.WriteLine("Destination Coord : ");
            Console.WriteLine("x2 = ");
            int x2;
            while ((!int.TryParse(Console.ReadLine(), out x2)) || (x2 < 0) || (x2 >= n))
            {
                Console.WriteLine("Wrong Input Try Again! ");
                Console.WriteLine("x2 = ");

            }
            //try {  x2 = int.Parse(Console.ReadLine()); }
            //catch (Exception e) { Console.WriteLine("invalid input for board size"); }
            //int x2 = int.Parse(Console.ReadLine());

            Console.WriteLine("y2 = ");
            int y2;
            while ((!int.TryParse(Console.ReadLine(), out y2)) || (y2 < 0) || (y2 >= n))
            {
                Console.WriteLine("Wrong Input Try Again! ");
                Console.WriteLine("y2 = ");

            }
            //try { y2 = int.Parse(Console.ReadLine()); }
            //catch (Exception e) { Console.WriteLine("invalid input for board size"); }
            //int y2 = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = "O";
                }
            }

            board[x1][y1] = "A";
            if (x1 == x2 && y1 ==y2 )
            {
                Console.WriteLine("Wrong input : A and B are identical");
                goto exit;
            }

            
            board[x2][y2] = "B";
            
            var source = Node.CreateNode(x1,y1);
            source.Distance = 0;
            
            var destination = Node.CreateNode(x2, y2);
            Graph graph = new Graph(ref source, n * n);
            



            void checkAndAdd(ref Node node, int addX, int addY)
            {
                int auxX = node.ValueX + addX; int auxY = node.ValueY + addY;
                
                if (auxX >= 0 && auxX < n && auxY >= 0 && auxY < n )
                {
                    var auxNode = Node.CreateNode(auxX, auxY);
                    //if((node.Distance)+1 < auxNode.Distance)
                    //auxNode.Distance = node.Distance + 1;
                    
                    node.AddNeighbour(auxNode);
                    graph.AddNode(auxNode);
                    
                    
                    
                }
            }

            while (!graph.FullVisited())
            {


                for (int i = 0; i < graph.Nodes.Count; i++)
                {
                    var currentNode = graph.Nodes[i];
                    if (currentNode.IsVisited)
                        continue;
                    checkAndAdd(ref currentNode, 2, 1);
                    checkAndAdd(ref currentNode, 1, 2);
                    checkAndAdd(ref currentNode, 1, -2);
                    checkAndAdd(ref currentNode, 2, -1);
                    checkAndAdd(ref currentNode, -1, -2);
                    checkAndAdd(ref currentNode, -2, -1);
                    checkAndAdd(ref currentNode, -1, 2);
                    checkAndAdd(ref currentNode, -2, 1);
                    currentNode.Visit();

                }
            }

            var algo = new Algo();

            //var shortestPathFunction = algo.ShortestPathFunction(graph, source);
            //var shortestPath = shortestPathFunction(destination);
            //foreach (var node in shortestpath)
            //{
            //    if (node == source || node == destination)
            //        continue;
            //    board[node.valuex][node.valuey] = "x";
            //}



            List<Node> shortestPath = algo.ShortestDistance(ref source, ref destination);
            if (shortestPath == null)
            {
                goto exit;
            }

            //List<Node> aux = new List<Node>();
            //aux.Add(source);
            //var shortestPath = algo.GetBestPath(aux, destination);
            //if (shortestPath == null)
            //{
            //    Console.WriteLine("Given source and destination  are not connected");
            //    goto exit;
            //}

            foreach (var node in shortestPath)
            {
                if (node == source || node == destination)
                    continue;
                board[node.ValueX][node.ValueY] = "x";
            }


           exit:
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i][j] + "  ");
                }
                Console.WriteLine();
            }

           


        }
    }
}
