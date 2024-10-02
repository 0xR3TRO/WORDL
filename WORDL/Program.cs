using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Witaj w grze Wordl!");

        Console.Write("Podaj swoje imię: ");
        string imie = Console.ReadLine();

        Console.WriteLine($"Cześć, {imie}! Zaczynamy grę!");

        List<string> listaSlow = new List<string> {
            "cloud",
            "apple",
            "brave",
            "house",
            "light",
            "train",
            "water",
            "bread",
            "plane",
            "heart"
        };

        while (true)
        {
            Random rand = new Random();
            string wylosowaneSlowo = listaSlow[rand.Next(listaSlow.Count)];

            int pozostaleProby = 5;
            bool odgadniete = false;

            while (pozostaleProby > 0 && !odgadniete)
            {
                Console.Write($"Podaj swoje słowo (5 liter) - pozostało prób: {pozostaleProby}: ");
                string slowoGracza = Console.ReadLine().ToLower();

                if (slowoGracza.Length != 5)
                {
                    Console.WriteLine("Słowo musi mieć dokładnie 5 liter. Spróbuj ponownie.");
                    continue;
                }

                if (!listaSlow.Contains(slowoGracza))
                {
                    Console.WriteLine("Słowo nie znajduje się na liście. Spróbuj ponownie.");
                    continue;
                }

                if (slowoGracza == wylosowaneSlowo)
                {
                    Console.WriteLine("Gratulacje! Odgadłeś słowo!");
                    odgadniete = true;
                }
                else
                {
                    string podpowiedz = "";

                    for (int i = 0; i < 5; i++)
                    {
                        if (slowoGracza[i] == wylosowaneSlowo[i])
                        {
                            podpowiedz += "+ ";
                        }
                        else if (wylosowaneSlowo.Contains(slowoGracza[i]))
                        {
                            podpowiedz += "* ";
                        }
                        else
                        {
                            podpowiedz += "_ ";
                        }
                    }

                    Console.WriteLine("Podpowiedź: " + podpowiedz);
                    pozostaleProby--;
                }
            }

            if (!odgadniete)
            {
                Console.WriteLine($"Niestety, nie udało się odgadnąć słowa. Poprawne słowo to: {wylosowaneSlowo}");
            }

            S Console.Write("Czy chcesz zagrać ponownie? (tak/nie): ");
            string odpowiedz = Console.ReadLine().ToLower();

            if (odpowiedz != "tak")
            {
                Console.WriteLine("Dziękujemy za grę! Do zobaczenia!");
                break;
            }
        }
    }
}