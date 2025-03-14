using Livraria.Model;

namespace Livraria.Communication.Requests
{
    public class RequestRegisterBookJson
    {
        public string Tittle { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public BookGender Gender { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
