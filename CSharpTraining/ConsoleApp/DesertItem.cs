namespace ConsoleApp
{
    abstract class DesertItem
    {
        public string Name { get; protected set; }

        public DesertItem()
        {

        }

        public DesertItem(string name)
        {
            Name = name;
        }

        public abstract float GetCost();
    }

    class Candy : DesertItem
    {
        public float Weight { get; set; }
        public float CostPerPound { get; set; }

        public Candy(string name, float weight, float cost) : base(name)
        {
            Weight = weight;
            CostPerPound = cost;
        }
        public override float GetCost()
        {
            return Weight * CostPerPound;
        }
    }

    class Cookie : DesertItem
    {
        public int NumberOfCookies { get; set; }
        public float PricePerDozen { get; set; }

        public Cookie(string name, int numberOfCookies, float pricePerDozen) : base(name)
        {
            NumberOfCookies = numberOfCookies;
            PricePerDozen = pricePerDozen;
        }
        public override float GetCost()
        {
            return NumberOfCookies*(PricePerDozen/12);
        }
    }

    class IceCream : DesertItem
    {
        public float Cost { get; set; }

        public IceCream(string name, float cost) : base(name)
        {
            Cost = cost;
        }
        public override float GetCost()
        {
            return Cost;
        }
    }

    class Sundae : IceCream
    {
        public float CostOfTopping { get; set; }

        public Sundae(string name,float iceCreamCost, float costOfTopping) : base(name, iceCreamCost)
        {
            CostOfTopping = costOfTopping;
        }
        public override float GetCost()
        {
            return Cost + CostOfTopping;
        }
    }

    class Checkout
    {
        private DesertItem[] register = new DesertItem[10];
        private int i = 0;
        private DessertShoppe ds;

        void CreateShoppe()
        {
            ds = new DessertShoppe();
        }

        public void AddToCart(DesertItem item)
        {
            register[i] = item;
            i++;
        }

        public void ClearRegister()
        {
            register = new DesertItem[10];
            i = 0;
        }

        public int GetNumberOfItems()
        {
            return i;
        }

        public float GetTotalCost()
        {
            float total = 0;
            foreach(DesertItem item in register)
            {
                total += item.GetCost();
            }
            return total;
        }

        public float GetTotalTax()
        {
            return ds.TaxRate * GetTotalCost();
        }

        public void main()
        {
            //Enter Shopname
            //Enter tax rate
            //List of DesertItems
            //Details of dessertitem
            //Do you wanna continue?
            //yes? repeat
            //no? diplay Bill Details
        }
    }

    class DessertShoppe
    {
        public readonly float TaxRate = 18.0f;
        public readonly string ShopName = "BB Store";

        private readonly int maxSizeForName = 30;
        private readonly int widthOfCost = 30;

        string centsToDollarandCents(int cents)
        {
            return (cents / 100).ToString();
        }
    }
}

/*
 class x{
 
    public int cost {get; set;}

}

class y{
    {
        X obj = new x();
       // obj.cost = 567;
        Console.WriteLine(obj.cost);
    }
}
 */ 

