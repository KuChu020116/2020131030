using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience
{

    class Node
    {
        public int id;
        public HashSet<string> bucket = new HashSet<string>();

        public void AddKey(string key)
        {
            bucket.Add(key);
        }

        public void RemoveKey(string key)
        {
            if (bucket.Contains(key))
            {
                bucket.Remove(key);
            }
        }
    }
}
