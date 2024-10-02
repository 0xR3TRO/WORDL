using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main()
    {
        // Powitanie gracza
        Console.WriteLine("Witaj w grze Wordl!");

        // Pobranie imienia gracza
        Console.Write("Podaj swoje imię: ");
        string imie = Console.ReadLine();

        // Przywitanie gracza
        Console.WriteLine($"Cześć, {imie}! Zaczynamy grę!");

        // Lista słów do wylosowania
        List<string> listaSlow = new List<string> { "cloud", "apple", "brave", "house", "light", "train", "water", "bread", "plane", "heart" };

        // Pętla główna gry
        while (true)
        {
            // Wylosowanie słowa z listy
            Random rand = new Random();
            string wylosowaneSlowo = listaSlow[rand.Next(listaSlow.Count)];

            // Gracz ma 5 prób
            int pozostaleProby = 5;
            bool odgadniete = false;

            while (pozostaleProby > 0 && !odgadniete)
            {
                // Pobranie słowa od gracza
                Console.Write($"Podaj swoje słowo (5 liter) - pozostało prób: {pozostaleProby}: ");
                string slowoGracza = Console.ReadLine().ToLower();

                // Sprawdzenie, czy słowo ma 5 liter
                if (slowoGracza.Length != 5)
                {
                    Console.WriteLine("Słowo musi mieć dokładnie 5 liter. Spróbuj ponownie.");
                    continue;
                }

                // Sprawdzenie, czy słowo jest w liście
                if (!listaSlow.Contains(slowoGracza))
                {
                    Console.WriteLine("Słowo nie znajduje się na liście. Spróbuj ponownie.");
                    continue;
                }

                // Sprawdzenie, czy gracz odgadł słowo
                if (slowoGracza == wylosowaneSlowo)
                {
                    Console.WriteLine("Gratulacje! Odgadłeś słowo!");
                    odgadniete = true;
                }
                else
                {
                    // Podanie podpowiedzi
                    char[] podpowiedz = new char[5];
                    bool[] trafioneLitery = new bool[5]; // Tablica, aby śledzić, które litery zostały już użyte jako `+`

                    // Ustawienie domyślnej podpowiedzi na `_`
                    for (int i = 0; i < 5; i++)
                    {
                        podpowiedz[i] = '_';
                    }

                    // Pierwsza pętla: sprawdzanie liter we właściwej pozycji (`+`)
                    for (int i = 0; i < 5; i++)
                    {
                        if (slowoGracza[i] == wylosowaneSlowo[i])
                        {
                            podpowiedz[i] = '+';
                            trafioneLitery[i] = true;
                        }
                    }

                    // Druga pętla: sprawdzanie liter w złej pozycji (`*`)
                    for (int i = 0; i < 5; i++)
                    {
                        if (podpowiedz[i] == '_') // Jeśli litera nie została już oznaczona jako `+`
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (!trafioneLitery[j] && slowoGracza[i] == wylosowaneSlowo[j] && slowoGracza[j] != wylosowaneSlowo[j])
                                {
                                    podpowiedz[i] = '*';
                                    trafioneLitery[j] = true; // Zaznaczenie, że litera została użyta
                                    break;
                                }
                            }
                        }
                    }

                    // Wyświetlenie podpowiedzi
                    Console.WriteLine("Podpowiedź: " + new string(podpowiedz));
                }

                pozostaleProby--;
            }

            if (!odgadniete)
            {
                Console.WriteLine($"Niestety, nie odgadłeś słowa. Prawidłowe słowo to: {wylosowaneSlowo}");
            }

            // Pytanie, czy gracz chce kontynuować
            Console.Write("Czy chcesz zagrać ponownie? (tak/nie): ");
            string odpowiedz = Console.ReadLine().ToLower();

            // Sprawdzenie odpowiedzi
            if (odpowiedz != "tak")
            {
                Console.WriteLine("Dziękujemy za grę! Do zobaczenia!");
                break; // Zakończenie gry
            }
        }
    }
}