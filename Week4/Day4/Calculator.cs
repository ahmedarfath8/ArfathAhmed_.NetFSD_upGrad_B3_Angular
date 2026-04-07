namespace Practice
{
    internal class Program
    {
        class Product
        {
            private int _productId;
            private String _productName;
            private int _price;
            private int _quantity;

            public Product(int productId) { 
                _productId = productId; 
            }
            public string Name{
                get {  return _productName; }
                set { _productName = value; }
            }
            public int Price{
                get { return _price; }
                set { _price = value; }
            }
            public int Quantity{
                get { return _quantity; }
                set { _quantity = value; }
            }
            public int Id{
                get { return _productId; }
            }
            public void ShowDetails(){
                Console.WriteLine("Id : "+this.Id);
                Console.WriteLine("Name : "+this.Name);
                Console.WriteLine("Unit Price : "+this.Price);
                Console.WriteLine("Quantity : "+this.Quantity);
                Console.WriteLine("Total : "+(this.Quantity*this.Price));

            }
        }
        static void Main(string[] args)
        {
            Product p1 = new Product(001);
            p1.Name = "iPhone";
            p1.Price = 120000;
            p1.Quantity = 2;
            p1.ShowDetails();
        }
    }
}
