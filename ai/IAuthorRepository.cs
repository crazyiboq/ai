using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai
{
    internal interface IAuthorRepository
    {
        Author AddAuthor (Author author);

        void AddAuthors(IEnumerable<Author> authors);

        void RemoveAuthor(int id);

        void RemoveAuthors(int[] authorIds);

        IEnumerable<Author> GetAllAuthors();

        IEnumerable<Author> GetAuthorsById(int id);
    }
}
