using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience
{
    class DHT
    {
        public List<Node> nodes = new List<Node>();
        private HashSet<string> keys = new HashSet<string>();

        public DHT(int numNodes)
        {
            for (int i = 0; i < numNodes; i++)
            {
                Node node = new Node();
                node.id = i;
                nodes.Add(node);
            }
        }

        public int GetNodeIndex(int keyHash)
        {
            keyHash = Math.Abs(keyHash);
            return keyHash % nodes.Count;
        }

        public void SetValue(string key, string value)
        {
            int keyHash = key.GetHashCode();
            int nodeIndex = GetNodeIndex(keyHash);
            Node node = nodes[nodeIndex];
            node.AddKey(key);
            keys.Add(key);
        }

        public string GetValue(string key)
        {
            int keyHash = key.GetHashCode();
            int nodeIndex = GetNodeIndex(keyHash);
            Node node = nodes[nodeIndex];
           if (node.bucket.Contains(key))
            {
                return $"Value for key '{key}' found at node {node.id}.";
            }
            else
            {
                return $"Value for key '{key}' not found.";
            }
        }

        public HashSet<string> GetKeys()
        {
            return keys;
        }
    }
}
