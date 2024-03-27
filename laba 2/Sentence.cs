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
        public void AddWord(string Word)// додати слово
        {
            LineText += Word;
        }
        public void RemoveWord(string Word)//видалити слово
        {
            LineText = LineText.Replace(Word, " ");
        }
        public void InsertWord(int position, string word)//вставити слово
        {
            var words = LineText.Split(' ');
            var list = new List<string>(words);
            list.Insert(position, word);
            LineText = string.Join(" ", list);
        }
        public int CountLetters() //кількість літер
        {
            return LineText.Length;
        }
        private string[] SplitLineText()//розділ по рядкам

        {
            return LineText.Split(' ');
        }
        public int CountWord()//кількість слів
        {
            return SplitLineText().Length;
        }
        // Метод для знаходження найдовшого слова у реченні
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
        public string ShortestWord()// Метод для знаходження найкоротшого слова у реченні
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
        public bool CheckWord(string Word)//чи є в реченні задане слово
        {
            return LineText.Contains(Word);
        }
        public string WordAtPosition(int position) // Метод для отримання слова за певною позицією у реченні
        {
            var words = LineText.Split(' ');
            if (position >= 0 && position < words.Length)
                return words[position];
            else
                return null;
        }
        public bool CheckLineText(Sentence sentence) // Метод для порівняння двох речень
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

        // Статичний метод для десеріалізації JSON строки у об'єкт Sentence
        public static Sentence DeserializeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Sentence>(json);
        }

        // Метод для збереження об'єкта у JSON файл
        public void SaveToJsonFile(string filename)
        {
            string jsonData = SerializeToJson();
            File.WriteAllText(filename, jsonData);
        }

        // Статичний метод для завантаження об'єкта з JSON файлу
        public static Sentence LoadFromJsonFile(string filename)
        {
            string jsonData = File.ReadAllText(filename);
            return DeserializeFromJson(jsonData);
        }
    }
}

