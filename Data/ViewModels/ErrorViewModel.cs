using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BooksStore.Data.ViewModels
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string Message {  get;set; }

        public string Path { get;set; }



        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
