using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace laba_2
{
    public class Sentence
    {
        public string LineText { get; set; }
        public void AddWord(string Word)
        {
            LineText += Word;
        }
        public void RemoveWord(string Word)
        {
            LineText = LineText.Replace(Word, " ");
        }
        public void InsertWord(int position, string word)
        {
            var words = LineText.Split(' ');
            var list = new List<string>(words);
            list.Insert(position, word);
            LineText = string.Join(" ", list);
        }
        public int CountLetters() 
        {
            return LineText.Length;
        }
        private string[] SplitLineText()

        {
            return LineText.Split(' ');
        }
        public int CountWord()
        {
            return SplitLineText().Length;
        }
        public string LongestWord()
        {
            var words = LineText.Split(' ');
            string longest = string.Empty;
            foreach (var word in words)
            {
                if (word.Length > longest.Length)
                    longest = word;
            }
            return longest;
        }
        public string ShortestWord()
        {
            var words = LineText.Split(' ');
            string shortest = string.Empty;
            if (words.Length > 0)
                shortest = words[0];
            foreach (var word in words)
            {
                if (word.Length < shortest.Length)
                    shortest = word;
            }
            return shortest;
        }
        public bool CheckWord(string Word)
        {
            return LineText.Contains(Word);
        }
        public string WordAtPosition(int position)
        {
            var words = LineText.Split(' ');
            if (position >= 0 && position < words.Length)
                return words[position];
            else
                return null;
        }
        public bool CheckLineText(Sentence sentence) 
        {
            if (LineText == sentence.LineText)
            {
                return true;
            }
            return false;
        }
        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static Sentence DeserializeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Sentence>(json);
        }
        public void SaveToJsonFile(string filename)
        {
            string jsonData = SerializeToJson();
            File.WriteAllText(filename, jsonData);
        }
        public static Sentence LoadFromJsonFile(string filename)
        {
            string jsonData = File.ReadAllText(filename);
            return DeserializeFromJson(jsonData);
        }
    }
}

