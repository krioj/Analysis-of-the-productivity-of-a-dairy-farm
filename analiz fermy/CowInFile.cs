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

            var statistic = new Statistics();

            foreach (float milk in LitresMilkInDay)
            {
                statistic.AddFeedInStatistics(milk);
            }
            foreach (float feet in KilogramsFeedInDay)
            {
                statistic.AddMilkInStatistics(feet);
            }
            return statistic;
        }
    }
}

