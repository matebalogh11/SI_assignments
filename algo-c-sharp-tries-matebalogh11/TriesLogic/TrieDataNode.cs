using System;
using System.Collections.Generic;

namespace TriesLogic
{
    public class TrieDataNode
    {
        /// <summary>
        /// Stores the Data id this instance
        /// </summary>
        public char Data
        {
            get; private set;
        }
        public Dictionary<char, TrieDataNode> children { get; set; } = new Dictionary<char, TrieDataNode>();
        public bool isCompleted { get; set; }
        public TrieDataNode parent { get; set; }
        public bool root { get; set; } = false;
        /// <summary>
        /// Initializes a TrieDataNode with its data
        /// </summary>
        /// <param name="data">The data in this node</param>
        public TrieDataNode(char data)
        {
            Data = data;
        }

        /// <summary>
        /// Converts the value of this instance to its string representation of its Data property. 
        /// </summary>
        /// <returns>The string representation of the Data property of this instance.</returns>
        public override String ToString()
        {
            return Data.ToString();
        }
    }
}
