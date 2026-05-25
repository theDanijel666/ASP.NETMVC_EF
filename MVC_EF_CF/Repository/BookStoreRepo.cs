using MVC_EF_CF.Data;
using MVC_EF_CF.Models;

namespace MVC_EF_CF.Repository
{
    public class BookStoreRepo : IBookStoreRepo
    {
        private readonly BookStoreContext _context;
        public BookStoreRepo(BookStoreContext context) 
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Author.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.FirstOrDefault(a=>a.Id==id);
        }

        public Author AddAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return author;
        }
        
        public Author UpdateAuthor(int id, Author author)
        {
            var authorToUpdate = _context.Author.FirstOrDefault(a => a.Id == id);
            if (authorToUpdate == null) 
            {
                throw new ArgumentException("Author with Id " + id.ToString() + " not found!");
            }
            if (author.Id != id) throw new ArgumentException("The Id's of Author don't match!");
            authorToUpdate.Ime= author.Ime;
            authorToUpdate.Prezime= author.Prezime;
            authorToUpdate.IAN= author.IAN;
            authorToUpdate.DatumRodjenja = author.DatumRodjenja;
            authorToUpdate.CV = author.CV;
            authorToUpdate.Rating= author.Rating;
            _context.Update(authorToUpdate);
            _context.SaveChanges();
            return authorToUpdate;
        }

        public Author DeleteAuthor(int id)
        {
            var author = _context.Author.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                throw new ArgumentException("Author with Id " + id.ToString() + " not found!");
            }
            _context.Author.Remove(author);
            _context.SaveChanges();
            return author;
        }

        
    }
}
