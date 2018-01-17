using System;
using System.Collections.Generic;

namespace TriesLogic
{
    public class AutoComplete
    {
        private TrieDataNode rootNode;

        /// <summary>
        /// Starts a new Trie with dummy root data "-"
        /// </summary>
        public AutoComplete()
        {
            rootNode = new TrieDataNode('-');
            rootNode.root = true;
        }

        /// <summary>
        /// Adds a word to the Trie.
        /// </summary>
        /// <param name="wordToAdd"></param>
        public void AddWord(String wordToAdd)
        {
            char[] letters = wordToAdd.ToCharArray();
            PlaceWord(rootNode, letters, 0);
        }
        void PlaceWord(TrieDataNode node, char[] word, int index)
        {
            if (word.Length == index)
            {
                node.isCompleted = true;
                return;
            }
            if (node.children.ContainsKey(word[index]))
            {
                TrieDataNode foundNode = node.children[word[index]];
                PlaceWord(foundNode, word, ++index);
            }
            else
            {
                TrieDataNode newNode = new TrieDataNode(word[index]);
                newNode.parent = node;
                node.children.Add(word[index], newNode);
                PlaceWord(newNode, word, ++index);
            }
        }

        /// <summary>
        /// Returns the possible completions of baseChars String from the Trie.
        /// </summary>
        /// <param name="baseChars">The String to autocomplete.</param>
        /// <returns>Possible completions.An empty list if there are none.</returns>
        public List<String> GetCompletions(String baseChars)
        {
            List<String> words = new List<string>();
            char[] letters = baseChars.ToCharArray();
            getWords(rootNode, letters, 0, words);
            return words;
        }

        void getWords(TrieDataNode node, char[] word, int index, List<String> words)
        {
            if (word.Length == index)
            {
                findLastLetter(node, words);
                return;
            }
            if (node.children.ContainsKey(Char.ToLower(word[index]))
                || node.children.ContainsKey(Char.ToUpper(word[index])))
            {
                TrieDataNode foundNode;
                node.children.TryGetValue(Char.ToLower(word[index]), out foundNode);
                if (foundNode == null) foundNode = node.children[Char.ToUpper(word[index])];
                getWords(foundNode, word, ++index, words);
            }
        }

        void findLastLetter(TrieDataNode baseNode, List<String> words)
        {
            if (words.Count >= 10) return;
            if (baseNode.isCompleted)
            {
                List<char> foundWord = new List<char>();
                rollBack(baseNode, foundWord);
                foundWord.Reverse();
                words.Add(string.Join("", foundWord));
            }
            foreach(TrieDataNode node in baseNode.children.Values)
            {
                findLastLetter(node, words);
            }
        }

        void rollBack(TrieDataNode node, List<char> result)
        {
            if (node.root == true) return;
            result.Add(node.Data);
            rollBack(node.parent, result);
        }

        /// <summary>
        /// Removes a word from the Trie
        /// </summary>
        /// <param name="wordToRemove">Word to remove from the possible words.</param>
        /// <returns>true if the removal was successful</returns>
        public bool RemoveWord(String wordToRemove)
        {
            char[] letters = wordToRemove.ToCharArray();
            return findWord(rootNode, letters, 0);
        }

        bool findWord(TrieDataNode node, char[] word, int index)
        {
            if (word.Length == index)
            {
                if (!node.isCompleted) return false;
                removeWord(node);
                return true;
            }
            if (node.children.ContainsKey(Char.ToLower(word[index]))
                || node.children.ContainsKey(Char.ToUpper(word[index])))
            {
                TrieDataNode foundNode;
                node.children.TryGetValue(Char.ToLower(word[index]), out foundNode);
                if (foundNode == null) foundNode = node.children[Char.ToUpper(word[index])];
                return findWord(foundNode, word, ++index);
            }
            return false;
        }

        void removeWord(TrieDataNode node)
        {
            if (node.root) return;
            if (node.children.Keys.Count > 0)
            {
                node.isCompleted = false;
                return;
            } else
            {
                node.parent.children.Remove(node.Data);
                removeWord(node.parent);
            }
        }
    }
}

