using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Telegram.Bot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.RegularExpressions;
using System.Web;

namespace GoogleBooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleBooksApiController : ControllerBase
    {
        [HttpPut("bot_waiting_for_book/{id}")]
        public ActionResult<string> BotWaitForBook(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_book", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_book/{id}")]
        public ActionResult<bool> BotWaitForBook(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_book", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }


        [HttpPut("bot_waiting_for_genre/{id}")]
        public ActionResult<string> BotWaitForGenre(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_genre", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_genre/{id}")]
        public ActionResult<bool> BotWaitForGenre(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_genre", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_unwanted_genre/{id}")]
        public ActionResult<string> BotWaitForUnwantedGenre(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_unwanted_genre", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_unwanted_genre/{id}")]
        public ActionResult<bool> BotWaitForUnwantedGenre(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_unwanted_genre", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_book_you_have_read/{id}")]
        public ActionResult<string> BotWaitForBookYouHaveRead(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_book_you_have_read", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_book_you_have_read/{id}")]
        public ActionResult<bool> BotWaitForBookYouHaveRead(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_book_you_have_read", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_favorite_author/{id}")]
        public ActionResult<string> BotWaitForFavoriteAuthor(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_favorite_author", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_favorite_author/{id}")]
        public ActionResult<bool> BotWaitForFavoriteAuthor(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_favorite_author", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_book_to_delete/{id}")]
        public ActionResult<string> BotWaitForBookToDelete(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_book_to_delete", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_book_to_delete/{id}")]
        public ActionResult<bool> BotWaitForBookToDelete(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_book_to_delete", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_genre_to_delete/{id}")]
        public ActionResult<string> BotWaitForGenreToDelete(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_genre_to_delete", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_genre_to_delete/{id}")]
        public ActionResult<bool> BotWaitForGenreToDelete(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_genre_to_delete", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_author_to_delete/{id}")]
        public ActionResult<string> BotWaitForAuthorToDelete(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_author_to_delete", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_author_to_delete/{id}")]
        public ActionResult<bool> BotWaitForAuthorToDelete(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_author_to_delete", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpPut("bot_waiting_for_secret_book/{id}")]
        public ActionResult<string> BotWaitForSecretBook(long id, bool b)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Set("bot_waiting_for_user_secret_book", b);
            var result = Constants.collection.UpdateOne(filter, update);
            return Ok();
        }

        [HttpGet("bot_waiting_for_secret_book/{id}")]
        public ActionResult<bool> BotWaitForSecretBook(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("bot_waiting_for_user_secret_book", out BsonValue value))
            {
                return value.AsBoolean;
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetBook(string bookName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={bookName}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var items = result.items;
                if (items.Count > 0)
                {
                    dynamic bestMatch = items[0];
                    int bestMatchScore = CalculateMatchScore(bestMatch.volumeInfo.title.ToString(), bookName);

                    // Find the best matching book
                    for (int i = 1; i < items.Count; i++)
                    {
                        dynamic currentItem = items[i];
                        string currentTitle = currentItem.volumeInfo.title.ToString();
                        int currentScore = CalculateMatchScore(currentTitle, bookName);

                        if (currentScore > bestMatchScore)
                        {
                            bestMatch = currentItem;
                            bestMatchScore = currentScore;
                        }
                    }

                    var book = new Book
                    {
                        Title = bestMatch.volumeInfo.title.ToString(),
                        Authors = bestMatch.volumeInfo.authors.ToObject<string[]>(),
                        PageCount = bestMatch.volumeInfo.pageCount,
                        Publisher = bestMatch.volumeInfo.publisher
                    };

                    return Ok(book);
                }
            }

            return BadRequest("Unable to get book information");
        }

        private int CalculateMatchScore(string title, string searchQuery)
        {
            // Simple scoring based on the number of characters that match in the title and search query
            int score = 0;
            for (int i = 0; i < searchQuery.Length; i++)
            {
                if (i < title.Length && title[i] == searchQuery[i])
                {
                    score++;
                }
                else
                {
                    break;
                }
            }

            return score;
        }

        [HttpGet("genre")]
        public async Task<ActionResult<Book>> GetBookByGenre(string genre)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q=subject:{genre}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var books = new List<Book>();

                // Get all books that match the search query
                foreach (var item in result.items)
                {
                    var book = new Book
                    {
                        Title = item.volumeInfo.title,
                        Authors = item.volumeInfo.authors.ToObject<string[]>(),
                        PageCount = item.volumeInfo.pageCount,
                        Publisher = item.volumeInfo.publisher,
                        Description = item.volumeInfo.description
                    };

                    books.Add(book);
                }

                // Shuffle the list of books and take the first three
                var randomBooks = books.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

                return Ok(randomBooks);
            }

            return BadRequest("Unable to get book information");
        }

        [HttpPut("user_genres/{id}/{genre}")]
        public ActionResult<string> AddUserGenre(long id, string genre)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.AddToSet("genres", genre);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("user_already_read/{id}/{title}")]
        public ActionResult<string> AddUserAlreadyReadBook(long id, string title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.AddToSet("already_read_books", title);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("user_favorite_author/{id}/{author}")]
        public ActionResult<string> AddFavoriteAuthor(long id, string author)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.AddToSet("favorite_authors", author);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpGet("user_read_books/{id}")]
        public ActionResult<List<string>> GetUserReadBooks(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("already_read_books", out BsonValue value))
            {
                var readBooks = value.AsBsonArray;
                var bookList = new List<string>();
                foreach (var book in readBooks)
                {
                    bookList.Add(book.ToString());
                }
                return bookList;
            }

            return NotFound();
        }

        [HttpGet("user_favorite_authors/{id}")]
        public ActionResult<List<string>> GetUserFavoriteAuthors(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("favorite_authors", out BsonValue value))
            {
                var favoriteAuthors = value.AsBsonArray;
                var authorList = new List<string>();
                foreach (var author in favoriteAuthors)
                {
                    authorList.Add(author.ToString());
                }
                return authorList;
            }

            return NotFound();
        }


        [HttpGet("user_unwanted_genres/{id}")]
        public ActionResult<List<string>> GetUserUnwantedGenres(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var document = Constants.collection.Find(filter).FirstOrDefault();
            if (document != null && document.TryGetValue("genres", out BsonValue value))
            {
                var unwantedGenres = value.AsBsonArray;
                var genreList = new List<string>();
                foreach (var genre in unwantedGenres)
                {
                    genreList.Add(genre.ToString());
                }
                return genreList;
            }

            return NotFound();
        }

        [HttpDelete("delete_book_ive_read/{id}/{title}")]
        public ActionResult DeleteBookIveRead(long id, string title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Pull("already_read_books", title);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("delete_unwanted_genre/{id}/{genre}")]
        public ActionResult DeleteUnwantedGenre(long id, string genre)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Pull("genres", genre);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("delete_favorite_author/{id}/{author}")]
        public ActionResult DeleteFavoriteAuthor(long id, string author)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("user_id", id);
            var update = Builders<BsonDocument>.Update.Pull("favorite_authors", author);
            var result = Constants.collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("search_book/{id}/{description}")]
        public async Task<ActionResult<List<Book>>> SearchBook(long id, string description)
        {
            // Отримати користувача за ідентифікатором з бази даних
            var user = await Constants.collection.Find(x => x["user_id"] == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Отримати жанри, які користувач не хоче читати
            var unwantedGenres = user.GetValue("genres").AsBsonArray?.Select(x => x.ToString()) ?? Enumerable.Empty<string>();

            // Отримати прочитані книги користувача
            var readBooks = user.GetValue("already_read_books").AsBsonArray?.Select(x => x.ToString()) ?? Enumerable.Empty<string>();

            // Виконати запит до Google Books API з використанням опису
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={description}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var books = new List<Book>();

                // Проітерувати отримані книги з API
                foreach (var item in result.items)
                {
                    var book = new Book
                    {
                        Title = item.volumeInfo.title,
                        Authors = item.volumeInfo.authors.ToObject<string[]>(),
                        PageCount = item.volumeInfo.pageCount,
                        Publisher = item.volumeInfo.publisher,
                        Description = item.volumeInfo.description
                    };

                    // Перевірити, чи книга належить до небажаних жанрів або вже була прочитана
                    if (!ContainsUnwantedGenres(book, unwantedGenres) && !IsAlreadyRead(book, readBooks))
                    {
                        books.Add(book);
                    }
                }

                // Знайти книгу, анотація якої найкраще співпала з описом
                var bestMatchBook = FindBestMatchBook(books, description);

                return Ok(bestMatchBook);
            }

            return BadRequest("Unable to get book information");
        }

        private bool ContainsUnwantedGenres(Book book, IEnumerable<string> unwantedGenres)
        {
            if (book == null || unwantedGenres == null || !unwantedGenres.Any())
            {
                return false;
            }

            return unwantedGenres.Intersect(book.Genres ?? Enumerable.Empty<string>()).Any();
        }

        private bool IsAlreadyRead(Book book, IEnumerable<string> readBooks)
        {
            if (book == null || readBooks == null || !readBooks.Any())
            {
                return false;
            }

            return readBooks.Contains(book.Title);
        }

        private Book FindBestMatchBook(List<Book> books, string description)
        {
            if (books == null || !books.Any())
            {
                return null;
            }

            // Знайти книгу з найкращою співпадінням анотації з описом
            Book bestMatchBook = null;
            int bestMatchCount = 0;

            foreach (var book in books)
            {
                int matchCount = GetMatchCount(book.Description, description);
                if (matchCount > bestMatchCount)
                {
                    bestMatchBook = book;
                    bestMatchCount = matchCount;
                }
            }

            return bestMatchBook;
        }

        private int GetMatchCount(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern))
            {
                return 0;
            }

            // Підрахувати кількість співпадінь слів у тексті зі зразком
            var words = pattern.Split(' ');
            int matchCount = 0;

            foreach (var word in words)
            {
                if (text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchCount++;
                }
            }

            return matchCount;
        }
    }

}

    
        

