using ai;
using Microsoft.Data.SqlClient;

var cs = @"Server=(localdb)\MSSQLLocalDB;Database=Author;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;";

var repo = new AuthorRepository(new SqlConnection(), cs);

//var authors = new List<Author>();

//for (int i = 1; i <= 10; i++)
//{
//    var author = new Author
//    {
//        FirstName = "Filankes",
//        LastName = "Filankesov"
//    };
//    authors.Add(author);
//}

//repo.AddAuthors(authors);

//authors.ForEach(Console.WriteLine);


int[] random_numbers = { 1,2,4};
repo.RemoveAuthors(random_numbers);

#region Read datas
//var authors = repo.GetAllAuthors().ToList();


//authors.ForEach(Console.WriteLine);

#endregion

#region Remove Data
//repo.RemoveAuthor(1);
#endregion