namespace analiz_fermy
{

    public class CowInFile : CowBase // IAnimals
    {

        private const string AmoutFeedInFile = "AmoutMilk.txt";
        private const string AmoutMilkInFile = "AmoutFeed.txt";

        public CowInFile(int namber) : base(namber)
        {
        }

        public override event DataAddedDelegate DataAdded;

        internal void ClearFile()
        {
            File.WriteAllText(AmoutMilkInFile, string.Empty);
            File.WriteAllText(AmoutFeedInFile, string.Empty);
        }

        public override void AddFeed(float kilograms)
        {
            using (var writer = File.AppendText(AmoutFeedInFile))
            {
                writer.WriteLine(kilograms);
            }
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }

        public override void AddMilk(float litres)
        {
            using (var writer = File.AppendText(AmoutMilkInFile))
            {
                writer.WriteLine(litres);
            }
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()          // pszekazuje dane do "CountStatistics" z "ReadFromFile"
        {
            var AmoutMilk = new List<float>();
            if (File.Exists(AmoutMilkInFile))                    // sprawdza czy plik istnieje
            {
                using (var reader = File.OpenText(AmoutMilkInFile))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        AmoutMilk.Add(float.Parse(line));
                    }
                }
            }

            var AmountFeed = new List<float>();
            if (File.Exists(AmoutFeedInFile))
            {
                using (var reader = File.OpenText(AmoutFeedInFile))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        AmountFeed.Add(float.Parse(line));
                    }
                }
            }

            var statistic = new Statistics();

            foreach (float milk in AmoutMilk)
            {
                statistic.AddFeedInStatistics(milk);
            }
            foreach (float feet in AmountFeed)
            {
                statistic.AddMilkInStatistics(feet);
            }
            return statistic;
        }
    }
}

