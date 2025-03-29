using BookStore.Common;
using BookStore.Context;
using BookStore.Entities;

namespace BookStore.BookOperations.GetBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _context;

        public GetByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BookModel Handle(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadi");
            }
            BookModel model = new()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                Genre = ((GenreEnum)book.GenreId).ToString(),
            };
            return model;
        }

        public class BookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }

    }
}
