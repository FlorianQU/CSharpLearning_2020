using System;
using System.Collections.Generic;
using System.Text;

namespace SockPairs
{
    public class SockPairFinder
    {
        private Dictionary<char, int> dict = new Dictionary<char, int>();
        public void CountSocks(string input)
        {
            dict.Clear();
            foreach (char c in input)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict.Add(c,1);
                }
            }
            Console.WriteLine(dict.Count);
        }
        public int CountPairs()
        {
            int pairs = 0;
            foreach (var key in dict.Keys)
            {
                pairs += dict[key] / 2;
            }
            return pairs;
        }

    }
}
