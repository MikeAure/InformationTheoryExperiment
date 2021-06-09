using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HuffmanCoding
{
    public class Huffman
    {
        public class Node:IComparable
        {
            /// <summary>
            /// 左子树
            /// </summary>
            public Node LChild { get; set; }
            /// <summary>
            /// 右子树
            /// </summary>
            public Node RChild { get; set; }
            /// <summary>
            /// 权重
            /// </summary>
            public int Weight { get; set; }
            /// <summary>
            /// 原字符
            /// </summary>
            public char Key { get; set; }

            public int CompareTo(object obj)
            {
                int result = 0;
                Node tmp = obj as Node;

                if (tmp.Weight > this.Weight)
                    result = 1;

                else if (tmp.Weight < this.Weight)
                    result = -1;

                return result;
            }

            public Node()
            {

            }

            public Node(int _weight, char _key)
            {
                Weight = _weight;
                Key = _key;
            }
        }

        public class HuffmanTree:IComparable
        {
            public char Key { get; set; }
            public string Code { get; set; }

            public HuffmanTree(char _key, string _code)
            {
                Key = _key;
                Code = _code;
            }

            
            public int CompareTo(object obj)
            {
                int result = 0;
                HuffmanTree tmp = obj as HuffmanTree;
                if (this.Code.Length < tmp.Code.Length)
                    result = 1;
                if (this.Code.Length > tmp.Code.Length)
                    result = -1;
                return result;
            }
        }

        public Node[] GetWeightArray(string str)
        {
            List<Node> result = new List<Node>();

            char[] charArr = str.ToCharArray();

            while (charArr.Length > 0)
            {
                char[] cntChars = null;
                var tmp = charArr.Where(m => m == charArr[0]);
                cntChars = new char[tmp.Count()];
                tmp.ToArray().CopyTo(cntChars, 0);
                charArr = charArr.Where(m => m != tmp.First()).ToArray();

                result.Add(new Node(cntChars.Length, cntChars[0]));
            }

            return result.ToArray();
        }

        public Node CreateHuffmanTree(Node[] sources )
        {
            Node result = null;
            Node[] nodes = sources;
            bool isNext = true;

            while (isNext)
            {
                if (nodes.Length == 2)
                {
                    result = new Node();
                    result.LChild = nodes[0];
                    result.RChild = nodes[1];
                    isNext = false;
                }

                Array.Sort(nodes);
                Node n1 = nodes[nodes.Length - 1];
                Node n2 = nodes[nodes.Length - 2];
                Node tmp = new Node();
                tmp.Weight = n1.Weight + n2.Weight;
                tmp.LChild = n1;
                tmp.RChild = n2;

                Node[] tmpnds = new Node[nodes.Length - 1];
                Array.Copy(nodes, 0, tmpnds, 0, nodes.Length - 1);
                tmpnds[tmpnds.Length - 1] = tmp;
                nodes = tmpnds;

            }

            return result;
        }

        public string StringToHuffmanCode(out Dictionary<char, string>key, string str)
        {
            string result = "";

            var tmps = GetWeightArray(str);

            var tree = CreateHuffmanTree(tmps);
            var dict = CreateHuffmanDict(tree);

            foreach(var item in dict)
            {
                Console.WriteLine(item);

            }

            result = ToHuffmanCode(str, dict);

            key = dict;
            return result;

        }

        public Dictionary<char,string> CreateHuffmanDict(Node hTree)
        {
            return CreateHuffmanDict("", hTree);
        }

        public Dictionary<char, string> CreateHuffmanDict(string code, Node hTree)
        {
            Dictionary<char, string> results = new Dictionary<char, string>();

            if(hTree.LChild ==null && hTree.RChild == null)
            {
                results.Add(hTree.Key, code);
            }
            else
            {
                var dictL = CreateHuffmanDict(code + '0', hTree.LChild);
                var dictR = CreateHuffmanDict(code + '1', hTree.RChild);
                foreach(var item in dictL)
                {
                    results.Add(item.Key, item.Value);
                }

                foreach(var item in dictR)
                {
                    results.Add(item.Key, item.Value);
                }
            }

            return results;
        }

        public string ToHuffmanCode(string source, Dictionary<char,string> hfdict)
        {
            string result = "";

            for(int i=0;i<source.Length;i++)
            {
                result += hfdict.First(m => m.Key == source[i]).Value;
            }
            return result;
        }

        public string ToText(string code, Dictionary<char, string> hfdict)
        {
            string result = "";
            for(int i=0;i<code.Length;i++)
            {
                foreach(var item in hfdict)
                {
                    if(code[i]==item.Value[0] && item.Value.Length + i <= code.Length)
                    {
                        char[] tempArr = new char[item.Value.Length];

                        Array.Copy(code.ToCharArray(), i, tempArr, 0, item.Value.Length);

                        if(new String(tempArr) == item.Value)
                        {
                            i += item.Value.Length;
                            result += item.Key;
                            break;
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// </summary>
    }
}
