using System;
using Livraria.Communication.Requests;
using Livraria.Model;

namespace Livraria.Repository;

public static class BookRepository
{
    public static List<Book> books = new List<Book>();

    public static void AddBook(Book book)
    {
        books.Add(book);
    }

    public static List<Book> GetBooks()
    {
        return books;
    }

    public static int BookCount()
    {
        return books.Count();
    }

    public static Book ReturnBook(int id)
    {
        Book bookFinded = null;
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                bookFinded = book;
            }
        }
        return bookFinded;
    }

    public static Boolean RemoveBook(int id)
    {
        Book bookToRemove = books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            return true;
        }
        return false;

    }

    public static String UpdateBook(int id, RequestRegisterBookJson book)
    {
        if (books[id] == null)
        {
            return "Cannot add book if it is not registred";
        }

        books[id].Author = book.Author;
        books[id].Tittle = book.Tittle;
        books[id].Amount = book.Amount;
        books[id].Gender = book.Gender;
        books[id].Price = book.Price;

        return "Book updated!";
    }

}
