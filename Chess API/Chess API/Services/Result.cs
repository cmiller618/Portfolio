using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chess_API.Services
{
    public class Result<T>
    {

        private List<string> messages= new List<string>();
        private ResultType type = ResultType.SUCCESS;
        private T payload;

        public ResultType getType()
        {
            return type;
        }

        public T Payload { get; set; }

        public bool isSuccess()
        {
            return type == ResultType.SUCCESS;
        }

        public List<string> getMessages()
        {
            return new List<string>(messages);
        }

        public void addMessage(string message, ResultType type)
        {
            messages.Add(message);
            this.type = type;
        }
    }
}
