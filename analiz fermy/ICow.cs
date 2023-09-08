using static analiz_fermy.CowBase;

namespace analiz_fermy
{
    public interface ICow
    {
        int Namber { get; }

        event DataAddedDelegate DataAdded;

        Statistics GetStatistics();

        void AddFeed(float kilograms);

        void AddFeed(string kilograms);

        void AddMilk(float litres);

        void AddMilk(string litres);
    }
}
