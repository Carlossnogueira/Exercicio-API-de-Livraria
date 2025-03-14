using System;
using Livraria.Model;

namespace Livraria.Repository;

public static class BookRepository
{
    public  static List<Book> books = new List<Book>();

    public static void AddBook(Book book)
    {
        books.Add(book);
    }

    public static List<Book> GetBooks(){
        return books;
    }

    public static int BookCount(){
        return books.Count();
    }

}
