namespace Livraria.Model
{
    public class Book
    {
        public static int IdCount = 1;
        public int Id { get; private set; }
        public string Tittle { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public BookGender Gender { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public Book(string tittle, string author, BookGender gender, double price, int amount)
        {
            Id = IdCount++;
            Tittle = tittle;
            Author = author;
            Gender = gender;
            Price = price;
            Amount = amount;
        }
        
    }
}
