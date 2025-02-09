using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tries
{
    public class Trie
    {
        TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            TrieNode it = root;
            foreach (char ch in word)
            {
                if (!it.Children.ContainsKey(ch))
                {
                    it.Children[ch] = new TrieNode();
                }
                it = it.Children[ch];
            }
            it.IsEndOfWord = true;
        }

        public void Delete(string word)// this just unmarks the isEndOFtheWord, You might have to delete the nodes created, ensuring there's no any other node on the path!
        {
            TrieNode it = root;
            foreach (char ch in word)
            {
                if (it.Children.ContainsKey(ch))
                {
                    it = it.Children[ch];
                }
            }
            it.IsEndOfWord = false;
        }
        public bool Seach(string word)
        {
            TrieNode it = root;
            foreach (char ch in word)
            {
                if (it.Children.ContainsKey(ch))
                {
                    it = it.Children[ch];
                }
            }
            return it.IsEndOfWord;
        }
        public List<string> StartWith(string prefix)
        {
            TrieNode it = root;
            foreach (char ch in prefix)
            {
                if (it.Children.ContainsKey(ch))
                {
                    it = it.Children[ch];
                }
            }
            //it is standing on the last char of the prefix here , car
            List<string> searchResults = new List<string>();
            StartWithHelper(it, prefix, searchResults);
            return searchResults;
        }
        public void StartWithHelper(TrieNode it, string prefixedWord, List<string> searchResults)
        {
            if (it.IsEndOfWord)
            {
                searchResults.Add(prefixedWord);
                //return;//can't do return here as there's possibility that there might be a another word ahead on this same path!
            }
            foreach (var child in it.Children)
            {
                StartWithHelper(child.Value, prefixedWord + child.Key, searchResults);
            }
        }
    }
}
