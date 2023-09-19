namespace analiz_fermy
{
    public class Statistics
    {
        public float PriceForMilk = 4f;
        public float PriceForFeed = 2.25f;

        public float MaxFeed { get; private set; }
        public float MinFeed { get; private set; }

        public float MaxMilk { get; private set; }
        public float MinMilk { get; private set; }

        public int Days { get; private set; }

        public float SumLitres { get; private set; }
        public float SumKilograms { get; private set; }

        public float MoneyForFeed
        {
            get
            {
                return SumKilograms * PriceForFeed;
            }
        }
        public float MoneyForMilk
        {
            get
            {
                return SumLitres * PriceForMilk;
            }
        }

        public float Earnings
        {
            get
            {
                return MoneyForMilk - MoneyForFeed;
            }
        }
        public float AverageEarnings
        {
            get
            {
                return Earnings / Days;
            }
        }

        public Statistics()
        {
            Days = 0;
            SumLitres = 0;
            SumKilograms = 0;
            MaxMilk = float.MinValue;
            MinMilk = float.MaxValue;
            MaxFeed = float.MinValue;
            MinFeed = float.MaxValue;
        }

        public void AddFeedInStatistics(float kilograms)
        {
            SumKilograms += kilograms;
            MaxFeed = Math.Max(MaxFeed, kilograms);
            MinFeed = Math.Min(MinFeed, kilograms);
        }
        public void AddMilkInStatistics(float litres)
        {
            SumLitres += litres;
            MaxMilk = Math.Max(MaxMilk, litres);
            MinMilk = Math.Min(MinMilk, litres);
            Days++;
        }
    }
}
