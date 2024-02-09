
namespace analiz_fermy
{
    public abstract class CowBase : ICow
    {
        public delegate void DataAddedDelegate(object sender, EventArgs args);
        public abstract event DataAddedDelegate DataAdded;

        public CowBase(int namber)
        {
            Namber = namber;
        }

        public int Namber { get; private set; }

        public abstract Statistics GetStatistics();

        public abstract void AddFeed(float kilograms);

        public abstract void AddMilk(float litres);

        public void AddFeed(string kilograms)
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

        public void AddMilk(string litres)
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
    }
}
