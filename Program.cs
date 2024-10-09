using System;
using System.Collections.Generic;
using System.Linq;

class Export
{
    public string ProductName { get; set; }
    public string Country { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public Export(string productName, string country, int quantity, int price)
    {
        ProductName = productName;
        Country = country;
        Quantity = quantity;
        Price = price;
    }

    // Метод для виведення рядка зі значеннями полів
    public override string ToString()
    {
        return $"Товар: {ProductName}, Країна: {Country}, Кiлькiсть: {Quantity}, Цiна: {Price}";
    }
}

class Program
{
    static void Main()
    {
        // Введення даних
        List<Export> exports = new List<Export>
        {
            new Export("Товар1", "Країна1", 30, 500),
            new Export("Товар1", "Країна2", 25, 450),
            new Export("Товар2", "Країна1", 40, 200),
            new Export("Товар2", "Країна2", 50, 150),
            new Export("Товар2", "Країна1", 10, 180)
        };

        // Вивести список всіх товарів
        Console.WriteLine("Список всiх товарiв:");
        foreach (var export in exports)
        {
            Console.WriteLine(export);
        }

        // Введення назви країни з клавіатури
        Console.Write("\nВведiть назву країни: ");
        string country = Console.ReadLine();

        // Обчислення загального обсягу експорту для країни
        var totalExport = exports
            .Where(e => e.Country == country)
            .Sum(e => e.Quantity * e.Price);

        Console.WriteLine($"Загальний обсяг експорту для {country}: {totalExport}");

        // Знаходження найдешевшого товару для країни
        var cheapestExport = exports
            .Where(e => e.Country == country)
            .OrderBy(e => e.Price)
            .FirstOrDefault();

        if (cheapestExport != null)
        {
            Console.WriteLine($"Найдешевший товар для країни {country}: {cheapestExport}");
        }
        else
        {
            Console.WriteLine($"Товарiв для країни {country} не знайдено.");
        }
    }
}