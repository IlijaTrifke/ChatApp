using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class Message
    {
        public Operation Operation { get; set; }
        public string MessageText { get; set; }
        public string Username { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorText { get; set; }
        public List<string> Clients { get; set; }
    }
}
