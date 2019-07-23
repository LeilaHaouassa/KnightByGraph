using System;
using System.Collections.Generic;
using System.Text;

namespace KnightBilGraph
{
    class Graph
    {
        public long NodeNumber { get; set; }
        public List<Node> Nodes { get; set; }
        

        

        public void AddNode(Node node)
        {
            if (!Contains(node))
            {
                Nodes.Add(node);
            }
             
        }

       
        //corrdinates of the source plus the size
        public Graph(ref Node node , int size)
        {
            
            Nodes = new List<Node>();
            
            AddNode(node);
            NodeNumber = size;
        }

        public bool Contains(Node targetNode)
        {
            foreach (var node in Nodes)
            {
                if (node.Equals(targetNode))
                {
                    return true;
                }
            }
            return false;
        }

        public bool FullVisited()
        {
            foreach (var node in Nodes)
            {
                if (!node.IsVisited)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
