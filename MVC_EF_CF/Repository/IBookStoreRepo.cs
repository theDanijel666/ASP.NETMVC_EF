using MVC_EF_CF.Models;

namespace MVC_EF_CF.Repository
{
    public interface IBookStoreRepo
    {
        public IEnumerable<Author> GetAuthors();
        public Author GetAuthor(int id);
        public Author UpdateAuthor(int id, Author author);
        public Author AddAuthor(Author author);
        public Author DeleteAuthor(int id);
    }
}
