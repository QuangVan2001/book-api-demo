using DataAccess.Models;
using DataAccess.RequestModels;
using DataAccess.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    public interface IBookService
    {
        List<BookResponseModel> GetAllBooks();
        BookResponseModel GetBook(int id);
        BookResponseModel UpdateBook(int id, BookRequestModel bookRequestModel);
        BookResponseModel DeleteBook(int id);
        BookResponseModel CreateBook(BookRequestModel bookRequestModel);
    }

    public class BookService : IBookService
    {
        private readonly BookDemoContext _context;

        public BookService(BookDemoContext context)
        {
            _context = context;
        }
        public BookResponseModel CreateBook(BookRequestModel bookRequestModel)
        {
            Book book = new Book();
            book.Price = bookRequestModel.Price;
            book.CreatedAt = DateTime.Now;
            book.Name = bookRequestModel.Name;
            book.IsActive = true;
            _context.Books.Add(book);
            _context.SaveChanges();

            BookResponseModel bookResponse = new BookResponseModel();
            bookResponse.Id = book.Id;
            bookResponse.Price = book.Price;
            bookResponse.Name = book.Name;
            bookResponse.CreatedAt = book.CreatedAt;
            return bookResponse;
        }

        public BookResponseModel DeleteBook(int id)
        {
            var bookExit = _context.Books.FirstOrDefault(x => x.Id == id);
            if(bookExit != null)
            {
                bookExit.IsActive = false;
                _context.Books.Update(bookExit);
                _context.SaveChanges();
            }
            BookResponseModel bookResponse = new BookResponseModel();
            bookResponse.Id = bookExit.Id;
            bookResponse.Price = bookExit.Price;
            bookResponse.Name = bookExit.Name;
            bookResponse.CreatedAt = bookExit.CreatedAt;
            return bookResponse;
        }

        public List<BookResponseModel> GetAllBooks()
        {
            List<BookResponseModel> listBook = new List<BookResponseModel>();
            var books = _context.Books.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            foreach (var book in books)
            {
                BookResponseModel bookResponseModel = new BookResponseModel();
                bookResponseModel.Id = book.Id;
                bookResponseModel.Name = book.Name;
                bookResponseModel.Price = book.Price;
                bookResponseModel.CreatedAt = book.CreatedAt;
                listBook.Add(bookResponseModel);
            }
            return listBook;
        }

        public BookResponseModel GetBook(int id)
        {
            var bookExit = _context.Books.FirstOrDefault(x => x.Id == id);
            BookResponseModel bookResponseModel = new BookResponseModel();
            if (bookExit != null)
            {
                bookResponseModel.Id = bookExit.Id;
                bookResponseModel.Name = bookExit.Name;
                bookResponseModel.Price = bookExit.Price;
                bookResponseModel.CreatedAt = bookExit.CreatedAt;
            }
            return bookResponseModel;
        }

        public BookResponseModel UpdateBook(int id, BookRequestModel bookRequestModel)
        {
            var bookExit = _context.Books.FirstOrDefault(x => x.Id == id);
            if (bookExit != null)
            {
                bookExit.Name = bookRequestModel.Name;
                bookExit.Price = bookRequestModel.Price;
                bookExit.UpdatedAt = DateTime.Now;
                _context.Books.Update(bookExit);
                _context.SaveChanges();
            }
            BookResponseModel bookResponse = new BookResponseModel();
            bookResponse.Id = bookExit.Id;
            bookResponse.Price = bookExit.Price;
            bookResponse.Name = bookExit.Name;
            bookResponse.CreatedAt = bookExit.CreatedAt;
            return bookResponse;
        }
    }
}
