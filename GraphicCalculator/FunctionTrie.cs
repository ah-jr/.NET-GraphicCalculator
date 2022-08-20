using System;
      
public class FunctionTrie
{
    static readonly int CHAR_SET_SIZE = 27;

    private class TrieNode
    {
        public TrieNode[] children = new TrieNode[CHAR_SET_SIZE];
        public int otFun;

        public TrieNode()
        {
            otFun = -1;
            for (int i = 0; i < CHAR_SET_SIZE; i++)
                children[i] = null;
        }
    };

    private TrieNode root;

    public FunctionTrie()
    {
        root = new TrieNode();
    }

    public void Insert(String key, int otFun)
    {
        int level;
        int length = key.Length;
        int index;

        TrieNode pCrawl = root;

        for (level = 0; level < length; level++)
        {
            index = GetIndex(key[level]);

            if (pCrawl.children[index] == null)
                pCrawl.children[index] = new TrieNode();

            pCrawl = pCrawl.children[index];
        }

        pCrawl.otFun = otFun;
    }

    public bool Search(String key, ref int otFun, ref int size)
    {
        int level;
        int length = key.Length;
        int index;
        TrieNode pCrawl = root;
        otFun = -1;
        size = 0;

        for (level = 0; level < length; level++)
        {
            index = GetIndex(key[level]);

            if (index < 0 || index >= CHAR_SET_SIZE)
                return false;

            if (pCrawl.children[index] == null)
                return false;

            pCrawl = pCrawl.children[index];

            if (pCrawl.otFun >= 0)
            {
                size = level + 1;
                otFun = pCrawl.otFun;
                return pCrawl.otFun >= 0;
            }
        }
        return false;
    }

    private static int GetIndex(char c)
    {
        if (c == '(')
            return CHAR_SET_SIZE - 1;
        else
            return c - 'a';
    }
}