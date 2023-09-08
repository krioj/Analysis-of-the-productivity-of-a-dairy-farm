namespace analiz_fermy
{
    public class CowInMemory : CowBase // IAnimals
    {
        public override event DataAddedDelegate DataAdded;
        public CowInMemory(int namber) : base(namber)
        {
        }
        internal List<float> KilogramsFeedInDay = new List<float>();
        internal List<float> LitresMilkInDay = new List<float>();
        public override void AddFeed(float kilograms)
        {
            KilogramsFeedInDay.Add(kilograms);
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
            LitresMilkInDay.Add(litres);
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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var litres in LitresMilkInDay)
            {
                statistics.AddMilkInStatistics(litres);
            }
            foreach (var kilograms in KilogramsFeedInDay)
            {
                statistics.AddFeedInStatistics(kilograms);
            }

            return statistics;
        }
    }
}
