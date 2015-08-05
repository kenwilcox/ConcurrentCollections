
namespace SalesBonuses
{
    public class Trade
    {
        public SalesPerson Person { get; private set; }
        public int QuantitySold { get; private set; }

        public Trade(SalesPerson person, int quantitySold)
        {
            Person = person;
            QuantitySold = quantitySold;
        }
    }
}
