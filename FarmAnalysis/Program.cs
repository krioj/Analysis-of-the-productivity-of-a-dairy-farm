using analiz_fermy;

void CowDataAdded(object sender, EventArgs args)
{
    Console.WriteLine("dane dodano");
}

Console.WriteLine("witam w programie dla oceny rentowości crów na farmie");
while (true)
{
    Console.WriteLine("na czym będziemy operować? (q == exid)");
    Console.WriteLine("1. na pamięci");
    Console.WriteLine("2. na plikach");

    string read = Console.ReadLine();
    if (read == "q")
        break;
    if (read == "1")
    {
        var cowM = new CowInMemory(1);
        cowM.DataAdded += CowDataAdded;
        do
        {
            Console.Clear();
            Console.WriteLine("1. dodać kolejny dzień/dni (musicie wprowadzić spożywania karmy i produkowanie mleka)");
            Console.WriteLine("2. pokazać tabelę z danymi");
            Console.WriteLine("wybierz \"q\" zeby wrucic do meni głównego");

            string reader = Console.ReadLine();

            if (reader == "q")
                break;
            try
            {
                switch (reader)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("wybierz \"q\" dla wyjścia z meni dodawania");
                        Console.WriteLine("ile dniw chcesz dodać?");

                        for (int i = int.Parse(Console.ReadLine()), a = 1; a <= i; a++)
                        {
                            Console.WriteLine($"dzień {a}");
                            Console.WriteLine($"dodaj ilość spożywania karmy (kilogramów dziennie)");
                            cowM.AddFeed(Console.ReadLine());

                            Console.WriteLine($"dodaj ilość produkowanego mleka (litrów dziennie):");
                            cowM.AddMilk(Console.ReadLine());
                        }

                        break;

                    case "2":
                        Console.Clear();

                        var statsM = cowM.GetStatistics();

                        Console.WriteLine($"cena za kilogram karmy: {statsM.PriceForFeed},         cena za sprzedaż litru mleka: {statsM.PriceForMilk}");
                        Console.WriteLine($"za {statsM.Days} dni było zjedzone {statsM.SumKilograms} kilogramów karmy i wypompowano {statsM.SumLitres} litry mleka");
                        Console.WriteLine($"cena za wyprodukowane mleko: {statsM.MoneyForMilk:N2} zł");
                        Console.WriteLine($"cena zjedzonej karmy: {statsM.MoneyForFeed:N2} zł");
                        Console.WriteLine($"krówa zarobila dla ciebie: {statsM.Earnings:N2} zł");
                        Console.WriteLine($"średni dochód na krowę: {statsM.AverageEarnings:N2} zł");
                        Console.WriteLine($"min zjedzonej karmy: {statsM.MinFeed} kg");
                        Console.WriteLine($"max zjedzonej karmy: {statsM.MaxFeed} kg");
                        Console.WriteLine($"min wypompowanego mleka {statsM.MinMilk} l");
                        Console.WriteLine($"max wypompowanego mleka {statsM.MaxMilk} l");

                        Console.ReadKey();
                        break;
                    default:
                        throw new Exception("coś żle wpisałeś(-aś)");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("źle podana liczba");
            }
        } while (true);
    }
    if (read == "2")
    {
        var cowF = new CowInFile(1);
        cowF.DataAdded += CowDataAdded;
        do
        {
            Console.Clear();
            Console.WriteLine("1. dodać kolejny dzień/dni (musisz wprowadzić spożywania karmy i produkowanie mleka)");
            Console.WriteLine("2. pokazać tabelę z danymi");
            Console.WriteLine("3. usunąć dane z plików");
            Console.WriteLine("wybierz \"q\" zeby wrucic do meni głównego");

            string reader = Console.ReadLine();

            if (reader == "q")
                break;
            try
            {
                switch (reader)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("wybierz \"q\" dla wyjścia z meni dodawania");
                        Console.WriteLine("ile chcesz dniw dodać?");

                        for (int i = int.Parse(Console.ReadLine()), a = 1; a <= i; a++)
                        {
                            Console.WriteLine($"dzień {a}");
                            Console.WriteLine($"dodaj ilość spożywania karmy (kilogramów dziennie)");
                            cowF.AddFeed(Console.ReadLine());

                            Console.WriteLine($"dodaj ilość produkowanego mleka (litrów dziennie):");
                            cowF.AddMilk(Console.ReadLine());
                        }

                        break;

                    case "2":
                        Console.Clear();

                        var statsf = cowF.GetStatistics();

                        Console.WriteLine($"cena za kilogram karmy: {statsf.PriceForFeed},         cena za sprzedaż litru mleka: {statsf.PriceForMilk}");
                        Console.WriteLine($"za {statsf.Days} dni było zjedzone {statsf.SumKilograms} kilogramów karmy i wypompowano {statsf.SumLitres} litry mleka");
                        Console.WriteLine($"cena za wyprodukowane mleko: {statsf.MoneyForMilk:N2} zł");
                        Console.WriteLine($"cena zjedzonej karmy: {statsf.MoneyForFeed:N2} zł");
                        Console.WriteLine($"krówa zarobila dla ciebie: {statsf.Earnings:N2}  zł");
                        Console.WriteLine($"średni dochód na krowę: {statsf.AverageEarnings:N2} zł");
                        Console.WriteLine($"min zjedzonej karmy: {statsf.MinFeed} kg");
                        Console.WriteLine($"max zjedzonej karmy: {statsf.MaxFeed} kg");
                        Console.WriteLine($"min wypompowanego mleka {statsf.MinMilk} l");
                        Console.WriteLine($"max wypompowanego mleka {statsf.MaxMilk} l");

                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("wszystkie dane w plikach zostaną usunięte, jesteś pewien(a)? (y == yes)");

                        string clear = Console.ReadLine();

                        if (clear == "y")
                            cowF.ClearFile();

                        break;
                    default:
                        throw new Exception("coś żle wpisałeś(-aś)");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("źle podana liczba");
            }
        } while (true);
    }
}