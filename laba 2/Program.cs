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
        // Серіалізація у JSON строку
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
        // Десеріалізація у JSON строку
        Sentence deserializedSentence = Sentence.DeserializeFromJson(json);
        Console.WriteLine("Deserialized sentence:");
        Console.WriteLine(deserializedSentence.LineText);
        // Збереження у JSON файл
        sentence.SaveToJsonFile("sentence.json");
        Console.WriteLine("Object saved to sentence.json");
        // Завантаження з JSON файлу
        Sentence loadedSentence = Sentence.LoadFromJsonFile("sentence.json");
        Console.WriteLine("Object loaded from sentence.json:");
        Console.WriteLine(loadedSentence.LineText);
        // Додавання слова до речення
        sentence.AddWord("I");
        // Додавання іншого слова
        sentence.AddWord("Test");
        // Видалення слова
        sentence.RemoveWord("Test");
        // Вставка слова на певну позицію
        sentence.InsertWord(1, "new");
        // Отримання кількості літер
        int lettersCount = sentence.CountLetters();
        Console.WriteLine("Кiлькiсть лiтер у реченнi: " + lettersCount);
        // Отримання кількості слів
        int wordsCount = sentence.CountWord();
        Console.WriteLine("Кiлькiсть слiв у реченнi: " + wordsCount);
        // Знаходження найдовшого слова
        string longestWord = sentence.LongestWord();
        Console.WriteLine("Найдовше слово у реченнi: " + longestWord);
        // Знаходження найкоротшого слова
        string shortestWord = sentence.ShortestWord();
        Console.WriteLine("Найкоротше слово у реченнi: " + shortestWord);
        // Перевірка наявності слова
        bool containsWord = sentence.CheckWord("This");
        Console.WriteLine("Слово 'This' присутнє у реченнi: " + containsWord);
        // Отримання слова за певною позицією
        string wordAtPosition = sentence.WordAtPosition(1);
        Console.WriteLine("Слово на позицiї 1 у реченнi: " + wordAtPosition);
        // Порівняння двох речень
        bool areEqual = sentence.CheckLineText(s1);
        Console.WriteLine("Чи рiвнi два речення: " + areEqual);
    }
}

