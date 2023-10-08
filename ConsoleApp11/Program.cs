using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, Dictionary<string, int>> topics = new Dictionary<string, Dictionary<string, int>>();

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу для голосования!");

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Создать новую тему голосования");
            Console.WriteLine("2. Проголосовать");
            Console.WriteLine("3. Показать результаты");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTopic();
                    break;
                case "2":
                    Vote();
                    break;
                case "3":
                    ShowResults();
                    break;
                case "4":
                    Console.WriteLine("Спасибо за использование программы!");
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие из списка.");
                    break;
            }
        }
    }

    static void CreateTopic()
    {
        Console.Write("Введите название темы голосования: ");
        string topic = Console.ReadLine();

        if (!topics.ContainsKey(topic))
        {
            topics[topic] = new Dictionary<string, int>();
            Console.WriteLine("Введите варианты ответов (введите 'готово' для завершения):");

            while (true)
            {
                Console.Write("Вариант ответа: ");
                string option = Console.ReadLine();

                if (option.ToLower() == "готово")
                    break;

                topics[topic][option] = 0;
            }

            Console.WriteLine("Тема голосования успешно создана!");
        }
        else
        {
            Console.WriteLine("Тема голосования с таким названием уже существует.");
        }
    }

    static void Vote()
    {
        Console.Write("Введите название темы голосования, за которую хотите проголосовать: ");
        string topic = Console.ReadLine();

        if (topics.ContainsKey(topic))
        {
            Console.WriteLine("Доступные варианты ответов:");

            foreach (var option in topics[topic].Keys)
            {
                Console.WriteLine(option);
            }

            Console.Write("Введите вариант ответа: ");
            string selectedOption = Console.ReadLine();

            if (topics[topic].ContainsKey(selectedOption))
            {
                topics[topic][selectedOption]++;
                Console.WriteLine("Ваш голос учтен!");
            }
            else
            {
                Console.WriteLine("Неверный вариант ответа. Пожалуйста, выберите из списка.");
            }
        }
        else
        {
            Console.WriteLine("Тема голосования не найдена.");
        }
    }

    static void ShowResults()
    {
        Console.WriteLine("Результаты голосования:");
        foreach (var topic in topics)
        {
            Console.WriteLine($"Тема: {topic.Key}");
            foreach (var option in topic.Value)
            {
                Console.WriteLine($"{option.Key}: {option.Value} голосов");
            }
            Console.WriteLine();
        }
    }
}
