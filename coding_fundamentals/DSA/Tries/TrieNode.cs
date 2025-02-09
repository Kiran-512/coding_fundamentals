using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tries
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public bool IsEndOfWord;
        public TrieNode()
        {
            this.IsEndOfWord = false;
        }
    }
}
