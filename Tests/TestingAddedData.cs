using analiz_fermy;

namespace Tests
{
    public class TestingAddedData
    {
        [Test]
        public void AddedFeedAndMilk()
        {
            var cow = new CowInMemory(3);

            cow.AddFeed(5);
            cow.AddFeed(3);
            cow.AddFeed(2);

            cow.AddMilk(5);
            cow.AddMilk(3);
            cow.AddMilk(2);

            var stats = cow.GetStatistics();

            Assert.AreEqual(stats.PriceForFeed, 2.25);
            Assert.AreEqual(stats.MaxFeed, 5);
            Assert.AreEqual(stats.MinFeed, 2);
            Assert.AreEqual(stats.SumLitres, 10);
            Assert.AreEqual(stats.MoneyForFeed, 22.5);

            Assert.AreEqual(stats.PriceForMilk, 4);
            Assert.AreEqual(stats.MaxMilk, 5);
            Assert.AreEqual(stats.MinMilk, 2);
            Assert.AreEqual(stats.SumLitres, 10);
            Assert.AreEqual(stats.MoneyForMilk, 40);
            Assert.AreEqual(stats.Days, 3);
        }
    }
}