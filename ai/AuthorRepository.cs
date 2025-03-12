using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai
{
    internal class AuthorRepository : IAuthorRepository
    {
        private IDbConnection _db;

        public AuthorRepository(IDbConnection db, string cs)
        {
            _db = db;
            _db.ConnectionString = cs;
        }

        public Author AddAuthor(Author author) {
            var sql = @"INSERT INTO Author(FirstName, LastName)
                      VALUES(@FirstName, @LastName)
                      SELECT CAST(SCOPE_IDENTITY() as INT)";

            var id = _db.Query<int>(sql, new
            {
                @FirstName = author.FirstName,
                @LastName = author.LastName
            }).FirstOrDefault();
            author.Id = id;
            return author;
}


        public void AddAuthors(IEnumerable<Author> authors)
        {
            var sql = @"INSERT INTO Author (FirstName, LastName) 
                VALUES (@FirstName, @LastName)";

            _db.Execute(sql, authors);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var sql = "SELECT * FROM Author";
            return _db.Query<Author>(sql);
        }

        public IEnumerable<Author> GetAuthorsById(int[] ids)
        {
            var sql = "SELECT * FROM Author WHERE Id IN @Ids";
            return _db.Query<Author>(sql, new { Id = ids });
        }

        public IEnumerable<Author> GetAuthorsById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuthor(int id)
        {
            var sql =  "DELETE FROM Author WHERE Id = @Id";
            _db.Execute(sql, new { @Id = id });

        }

        public void RemoveAuthors(int[] authorIds)
        {
            var sql = "DELETE FROM Author WHERE Id IN @Ids";
            _db.Execute(sql, new { Ids = authorIds });
        }
    }
}
