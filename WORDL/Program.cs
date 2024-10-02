using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wyjasni znakow:");
        Console.WriteLine("_ -> litera nie wystepuje w wybranym słowie");
        Console.WriteLine("+ -> litera jest na poprawnym miejscu");
        Console.WriteLine("* -> litera jest w słowie, ale w złym miejscu");

        List<string> list = new List<string>();

        list.Add("apple");
        list.Add("feld");
        list.Add("coud");
        list.Add("p__p_");
        list.Add("pp_p_");

        Random random = new Random();
        int id_slowa = random.Next(list.Count);

        string losowane_slowo = list[id_slowa];
        Console.WriteLine("Podaj słowo 5-literowe:");

        string odpowiedz = Console.ReadLine();
        List<string> podpowiedz = new List<string>() { "-", "-", "-", "-", "-" };

        if (odpowiedz.Length == 5)
        {
            if (list.Contains(odpowiedz))
            {
                if (losowane_slowo == odpowiedz)
                {
                    Console.WriteLine("Gratulacje!!! Podałeś poprawne słowo.");
                }
                else
                {
                    // Sprawdź poprawne litery na właściwych miejscach
                    for (int i = 0; i < 5; i++)
                    {
                        if (odpowiedz[i] == losowane_slowo[i])
                        {
                            podpowiedz[i] = "+";
                        }
                    }

                    // Sprawdź litery występujące w słowie, ale na złych pozycjach
                    for (int i = 0; i < 5; i++)
                    {
                        if (odpowiedz[i] != losowane_slowo[i] && losowane_slowo.Contains(odpowiedz[i]))
                        {
                            podpowiedz[i] = "*";
                        }
                    }

                    // Sprawdź litery, które nie występują w losowanym słowie
                    for (int i = 0; i < 5; i++)
                    {
                        if (!losowane_slowo.Contains(odpowiedz[i]))
                        {
                            podpowiedz[i] = "_";
                        }
                    }

                    Console.WriteLine("Podpowiedź: " + string.Join(" ", podpowiedz));
                }
            }
            else
            {
                Console.WriteLine("Słowo nieznane.");
            }
        }
        else
        {
            Console.WriteLine("Zła długość słowa. Powinno mieć 5 liter.");
        }
    }
}