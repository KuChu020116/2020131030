using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DHT01;

namespace Experience
{
    class Program
{
    static void Main(string[] args)
    {
        #region 该类的 main
        DHT dht = new DHT(100);
        // 用随机分配的键初始化 100 个节点
        for (int i = 0; i < 100; i++)
        {
            Node node = dht.nodes[i];
            for (int j = 0; j < new Random().Next(0, 10); j++)
            {
                string key = $"key_{i}_{j}";
                node.AddKey(key);
                dht.GetKeys().Add(key);
            }
        }
        // 生成 200 个随机字符串并在随机节点中设置它们的值
        List<Tuple<string, string>> keyValuePairs = new List<Tuple<string, string>>();
        for (int i = 0; i < 200; i++)
        {
            string key = $"key_{i}_random";
            string value = "";
            int length = new Random().Next(5, 21);
            for (int j = 0; j < length; j++)
            {
                char c = (char)new Random().Next(97, 123);
                value += c;
            }
            keyValuePairs.Add(new Tuple<string, string>(key, value));
            if (i == 0)
            {
                dht.SetValue(key, value);
            }
            else
            {
            int nodeIndex = new Random().Next(0, 100);
            dht.SetValue(key, value);
            dht.nodes[nodeIndex].AddKey(key);
            }
        }
        // 选择 100 个随机键并检索它们的值
        HashSet<string> selectedKeys = new HashSet<string>();
        Random random = new Random();
        while (selectedKeys.Count < 100)
        {
            string key = keyValuePairs[random.Next(0, 200)].Item1;
            if (!selectedKeys.Contains(key))
            {
                selectedKeys.Add(key);
            }
        }
        foreach (string key in selectedKeys)
        {
            Console.WriteLine(dht.GetValue(key));
        }
        Console.ReadKey();
     }
#endregion
}

        #region DHT01类
        //    // 初始化100个节点
        //    var nodes = Enumerable.Range(0, 100).Select(i => new DHT01.Node()).ToList();

        //    // 随机生成200个字符串，计算哈希值后随机选择一个节点执行SetValue操作，并记录Key
        //    var random = new Random();
        //    var keys = new List<byte[]>();
        //    for (int i = 0; i < 200; i++)
        //    {
        //        var value = Encoding.UTF8.GetBytes(RandomString(random.Next(1, 10)));
        //        var hash = GetHash(value);
        //        var nodeIndex = random.Next(0, 100);
        //        nodes[nodeIndex].SetValue(hash, value);
        //        keys.Add(hash);
        //    }

        //    // 随机选择100个Key，并在随机的节点上执行GetValue操作
        //    for (int i = 0; i < 100; i++)
        //    {
        //        var keyIndex = random.Next(0, keys.Count);
        //        var key = keys[keyIndex];
        //        var nodeIndex = random.Next(0, 100);
        //        var value = nodes[nodeIndex].GetValue(key);
        //        Console.WriteLine($"Key: {BitConverter.ToString(key)}, Value: {Encoding.UTF8.GetString(value)}");
        //    }
        //}

        //private static string RandomString(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        //}

        //private static byte[] GetHash(byte[] data)
        //{
        //    using (var sha1 = SHA1.Create())
        //    {
        //        return sha1.ComputeHash(data);
        //    }
        //}
        #endregion

    }
    }
