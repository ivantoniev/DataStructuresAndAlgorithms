﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AlphabeticalOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> elements = new SortedDictionary<string, SortedSet<string>>();

            List<string[]> input = GetInputText();

            foreach (var item in input)
            {
                if (elements.ContainsKey(item[1]))
                {
                    elements[item[1]].Add(item[0]);
                }
                else
                {
                    SortedSet<string> sortedNames = new SortedSet<string>();
                    sortedNames.Add(item[0]);
                    elements.Add(item[1], sortedNames);
                }
            }

            foreach (var element in elements)
            {
                Console.Write("{0}: ", element.Key);
                foreach (var name in element.Value)
                {
                    Console.Write("{0}  ", name);
                }
                Console.WriteLine();
            }

        }

        static List<string[]> GetInputText()
        {
            StreamReader reader = new StreamReader("..\\..\\text.txt");
            string inputLine;
            List<string[]> entries = new List<string[]>();

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    inputLine = reader.ReadLine();
                    string[] rawEntries = inputLine.Split('|');

                    for (int i = 0; i < rawEntries.Length; i++)
                    {
                        rawEntries[i] = rawEntries[i].Trim();
                    }
                    entries.Add(new string[] { rawEntries[0] + " " + rawEntries[1], rawEntries[2] });
                }
            }

            return entries;
        }
    }
}
