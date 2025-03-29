using BookStore.Context;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book == null)
                throw new InvalidOperationException("Kitap Bulunamadi");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
