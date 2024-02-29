using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BooksStore.Exceptions
{
    [Serializable]
    public class PublisherNameException:Exception
    {

        //prop

        public string PublisherName { get; set; }

        public PublisherNameException()
        {

        }
        public PublisherNameException(string Message):base(Message)
        {
            
        }
        public PublisherNameException(string Message,Exception inner):base(Message,inner)
        {
            
        }
        //

        //our own messgae not from base
        public PublisherNameException(string Message,string PublisherName):this(Message)
        {
            PublisherName = PublisherName;
        }
       
    }
}
