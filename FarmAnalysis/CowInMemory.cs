namespace analiz_fermy
{
    public class CowInMemory : CowBase // IAnimals
    {
        public override event DataAddedDelegate DataAdded;
        public CowInMemory(int namber) : base(namber)
        {
        }

        private List<float> AmoutFeed = new List<float>();
        private List<float> AmoutMilk = new List<float>();

        public override void AddFeed(float kilograms)
        {
            AmoutFeed.Add(kilograms);
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }

        public override void AddMilk(float litres)
        {
            AmoutMilk.Add(litres);
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var litres in AmoutMilk)
            {
                statistics.AddMilkInStatistics(litres);
            }
            foreach (var kilograms in AmoutFeed)
            {
                statistics.AddFeedInStatistics(kilograms);
            }

            return statistics;
        }
    }
}
