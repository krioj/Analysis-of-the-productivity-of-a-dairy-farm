
namespace analiz_fermy
{
    public abstract class CowBase : ICow
    {
        public delegate void DataAddedDelegate(object sender, EventArgs args);

        public abstract event DataAddedDelegate DataAdded;

        public CowBase(int namber)
        {
            this.Namber = namber;
        }

        public int Namber { get; private set; }

        public abstract Statistics GetStatistics();

        public abstract void AddFeed(float kilograms);

        public abstract void AddFeed(string kilograms);

        public abstract void AddMilk(float litres);

        public abstract void AddMilk(string litres);
    }
}
