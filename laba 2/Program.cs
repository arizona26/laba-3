using laba_2;
using System.Diagnostics.Metrics;
class Program
{
    static void Main()
    {

        Sentence s1 = new Sentence();
        s1.AddWord("a");
        Sentence sentence = new Sentence { LineText = "This is a" };
        string json = sentence.SerializeToJson();
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
        Sentence deserializedSentence = Sentence.DeserializeFromJson(json);
        Console.WriteLine("Deserialized sentence:");
        Console.WriteLine(deserializedSentence.LineText);
        sentence.SaveToJsonFile("sentence.json");
        Console.WriteLine("Object saved to sentence.json");
        Sentence loadedSentence = Sentence.LoadFromJsonFile("sentence.json");
        Console.WriteLine("Object loaded from sentence.json:");
        Console.WriteLine(loadedSentence.LineText);
        sentence.AddWord("I");
        sentence.AddWord("Test");
        sentence.RemoveWord("Test");
        sentence.InsertWord(1, "new");
        int lettersCount = sentence.CountLetters();
        Console.WriteLine("Кiлькiсть лiтер у реченнi: " + lettersCount);
        int wordsCount = sentence.CountWord();
        Console.WriteLine("Кiлькiсть слiв у реченнi: " + wordsCount);
        string longestWord = sentence.LongestWord();
        Console.WriteLine("Найдовше слово у реченнi: " + longestWord);
        string shortestWord = sentence.ShortestWord();
        Console.WriteLine("Найкоротше слово у реченнi: " + shortestWord);
        bool containsWord = sentence.CheckWord("This");
        Console.WriteLine("Слово 'This' присутнє у реченнi: " + containsWord);
        string wordAtPosition = sentence.WordAtPosition(1);
        Console.WriteLine("Слово на позицiї 1 у реченнi: " + wordAtPosition);
        bool areEqual = sentence.CheckLineText(s1);
        Console.WriteLine("Чи рiвнi два речення: " + areEqual);
    }
}

