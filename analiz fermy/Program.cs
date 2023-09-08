using analiz_fermy;

void CowDataAdded(object sender, EventArgs args)
{
    Console.WriteLine("dane dodano");
}
Console.WriteLine("witam w ptogramie dla oceny rentowności crow na farmie");
while (true)
{
    Console.Clear();
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
            Console.WriteLine("wybierz \"q\" dla wyjścia z programu");

            string reader = Console.ReadLine();

            if (reader == "q")
                break;
            try
            {
                switch (reader)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("wybierz \"q\" dla wyjścia z dodawaniu");
                        Console.WriteLine("ile dniw dodać?");

                        for (int i = int.Parse(Console.ReadLine()), a = 0; a < i; a++)
                        {

                            Console.WriteLine($"dodaj ilość spożywania karmy (Kg/dziennie)");
                            cowM.AddFeed(Console.ReadLine());

                            Console.WriteLine($"dodaj ilość produkowanego mleka (L/dziennie):");
                            cowM.AddMilk(Console.ReadLine());
                        }

                        break;

                    case "2":
                        Console.Clear();

                        var statsM = cowM.GetStatistics();

                        Console.WriteLine($"cena za kilogram karmy: {statsM.PriceForFeed},         cena za sprzedaż litru mleka: {statsM.PriceForMilk}");
                        Console.WriteLine($"za {statsM.Days} dni było zjedzone {statsM.SumKilograms} kilogramów karmy i wypompowano {statsM.SumLitres} litry mleka\n");
                        Console.WriteLine($"cena za wyprodukowane mleko: {statsM.MoneyForMilk:N2} zł\n");
                        Console.WriteLine($"cena zjedzonej karmy: {statsM.MoneyForFeed:N2} zł\n");
                        Console.WriteLine($"zarobki na krowie: {statsM.Earnings:N2}  zł\n");
                        Console.WriteLine($"średni dochód na krowę: {statsM.AverageEarnings:N2} zł\n");
                        Console.WriteLine($"min zjedzonej karmy: {statsM.MinFeed} kg");
                        Console.WriteLine($"max zjedzonej karmy: {statsM.MaxFeed} kg\n");
                        Console.WriteLine($"min wypompowanego mleka {statsM.MinMilk} l");
                        Console.WriteLine($"max wypompowanego mleka {statsM.MaxMilk} l");

                        Console.ReadKey();
                        break;
                    default:
                        throw new Exception("coś żle wpisałeś/wpisałaś");
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
        var cowf = new CowInFile(1);
        cowf.DataAdded += CowDataAdded;
        do
        {
            Console.Clear();
            Console.WriteLine("1. dodać kolejny dzień/dni (musicie wprowadzić spożywania karmy i produkowanie mleka)");
            Console.WriteLine("2. pokazać tabelę z danymi");
            Console.WriteLine("3. usunąć dane z plików");
            Console.WriteLine("wybierz \"q\" dla wyjścia z programu");

            string reader = Console.ReadLine();

            if (reader == "q")
                break;
            try
            {
                switch (reader)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("wybierz \"q\" dla wyjścia z dodawaniu");
                        Console.WriteLine("ile dniw dodać?");

                        for (int i = int.Parse(Console.ReadLine()), a = 0; a < i; a++)
                        {

                            Console.WriteLine($"dodaj ilość spożywania karmy (Kg/dziennie)");
                            cowf.AddFeed(Console.ReadLine());

                            Console.WriteLine($"dodaj ilość produkowanego mleka (L/dziennie):");
                            cowf.AddMilk(Console.ReadLine());
                        }

                        break;

                    case "2":
                        Console.Clear();

                        var statsf = cowf.GetStatistics();

                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("wszystkie dane w plikach zostaną usunięte, jesteś pewien/pewna? (y == yes)");

                        string clear = Console.ReadLine();

                        if (clear == "y")
                            cowf.ClearFile();

                        break;
                    default:
                        throw new Exception("coś żle wpisałeś/wpisałaś");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("źle podana liczba");
            }
        } while (true);
    }
}