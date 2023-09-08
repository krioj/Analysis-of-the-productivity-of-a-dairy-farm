namespace analiz_fermy
{

    public class CowInFile : CowBase // IAnimals
    {

        public const string FeedInFile = "milk.txt";
        public const string MilkInFile = "feed.txt";

        public CowInFile(int namber) : base(namber)

        {
        }

        public override event DataAddedDelegate DataAdded;

        public void ClearFile()
        {
            File.WriteAllText(MilkInFile, string.Empty);
            File.WriteAllText(FeedInFile, string.Empty);
        }

        public override void AddFeed(float kilograms)
        {
            using (var writer = File.AppendText(FeedInFile))
            {
                writer.WriteLine(kilograms);
            }
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }
        public override void AddFeed(string kilograms)
        {
            if (float.TryParse(kilograms, out float kilogramsFl))
            {
                AddFeed(kilogramsFl);
            }
            else
            {
                throw new Exception("źle podana liczba");
            }
        }

        public override void AddMilk(float litres)
        {
            using (var writer = File.AppendText(MilkInFile))
            {
                writer.WriteLine(litres);
            }
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }
        public override void AddMilk(string litres)
        {
            if (float.TryParse(litres, out float litresFl))
            {
                AddMilk(litresFl);
            }
            else
            {
                throw new Exception("źle podana liczba");
            }
        }

        public override Statistics GetStatistics()          // pszekazuje dane do "CountStatistics" z "ReadFromFile"
        {
            return CountStatistics(ReadFromFile());

        }
        private List<object> ReadFromFile()                 // metoda dla odczytywanie danyh z pliku
        {
            List<object> lists = new List<object>();

            var LitresMilkInDay = new List<float>();
            if (File.Exists(MilkInFile))                    // sprawdza czy plik istnieje
            {
                using (var reader = File.OpenText(MilkInFile))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        LitresMilkInDay.Add(float.Parse(line));
                    }
                }
            }
            lists.Add(LitresMilkInDay);

            var KilogramsFeedInDay = new List<float>();
            if (File.Exists(FeedInFile))
            {
                using (var reader = File.OpenText(FeedInFile))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        KilogramsFeedInDay.Add(float.Parse(line));
                    }
                }
            }
            lists.Add(KilogramsFeedInDay);
            return lists;
        }
        private Statistics CountStatistics(List<object> lists)    // Metoda jaka zwruci wypelniony obiekt z statystykami
        {
            var statistic = new Statistics();
            int a = 0;
            foreach (List<float> list in lists)
            {

                if (a == 0)
                    foreach (float milk in list)
                    {
                        statistic.AddFeedInStatistics(milk);
                    }
                a++;
                if (a == 1)
                    foreach (float feet in list)
                    {
                        statistic.AddMilkInStatistics(feet);
                    }

            }
            return statistic;
        }
    }
}

