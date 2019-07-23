using System;
using System.Collections.Generic;
using System.Text;

namespace KnightBilGraph
{
    class Node
    {
        public List<Node> Neighbours = new List<Node>();

        private static List<Node> Existing = new List<Node>();

        public Node previous;

        public int ValueX { get; set; }
        public int ValueY { get; set; }
        public bool IsVisited { get; set; }
        public bool IsChecked { get; set; }
        public int Distance { get; set; }

        private Node(int x , int y)
        {

            
            ValueX = x;
            ValueY = y;
            IsVisited = false;
            IsChecked = false;
            previous = null;
            Distance = int.MaxValue;
            
        }

        public static Node CreateNode(int x, int y)
        {
            foreach (var node in Existing)
            {
                if(node.ValueX==x && node.ValueY== y)
                {
                    return node;
                }

            }
            var auxNode = new Node(x, y);
            Existing.Add(auxNode);
            return auxNode;
        }
        //private bool Exist()
        //{
        //    foreach (var node in Existing)
        //    {
        //        if (this.Equals(node))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public void Visit()
        {
            IsVisited = true;
        }


        public void AddNeighbour(Node node)
        {
            if (!InNeighbours(node))
            {
                Neighbours.Add(node);
            }
            
        }

        //public  bool  Equals(Node node)
        //{
        //    return ((ValueX == node.ValueX) && (ValueY==node.ValueY));
        //}


        public override bool Equals(object obj)
        {
            var node = obj as Node;
            if (node == null)
                return false;
            return (ValueX == node.ValueX) && (ValueY == node.ValueY);
        }

        public bool InNeighbours(Node targetNode)
        {
            foreach (var node in Neighbours)
            {
                if (node.Equals(targetNode))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
