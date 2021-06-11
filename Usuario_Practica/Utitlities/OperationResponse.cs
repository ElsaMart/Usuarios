using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usuario_Practica.Utitlities
{
    public class OperationResponse<T>
    {
        public ResponseType Result { get; set; }
        public string ErrorMessage { get; set; }
        public int HTTPCode { get; set; }
        public T Data { get; set; }
        public OperationResponse()
        {
            Result = ResponseType.Error;
            ErrorMessage = string.Empty;
        }
    }
}