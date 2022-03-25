using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enlistment_netcore.Models.CustomModels
{
    public class StatusMessage
    {
        private string message;
        private int status;
        private string data;
        private string redirectUrl;
        private string errorType;
        public string Message { get => message; set => message = value; }
        public int Status { get => status; set => status = value; }
        public string Data { get => data; set => data = value; }
        public string RedirectUrl { get => redirectUrl; set => redirectUrl = value; }
        public string ErrorType { get => errorType; set => errorType = value; }
    }
}
