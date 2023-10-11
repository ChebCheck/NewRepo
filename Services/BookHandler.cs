using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookHandler : IPostHandler
    {   
        public BookHandler() { }

        public bool IsValid(object handledBook)
        {
            Book book = handledBook as Book;
            bool result = true;

            if (book.Title == "")
                result = false;

            return result;
        }
    }
}
