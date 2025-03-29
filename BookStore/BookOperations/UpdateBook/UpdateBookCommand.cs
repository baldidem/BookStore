using BookStore.Context;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id,UpdateBookModel updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                throw new InvalidOperationException("Kitap bulunamadi");

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.PublishDate != default ? updatedBook.Title : book.Title;

            _context.SaveChanges();

        }

        public class UpdateBookModel()
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
        }
    }
}
