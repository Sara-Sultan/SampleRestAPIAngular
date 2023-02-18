using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Application.DTO
{
   public class ResponseDTO
    {
    public bool success { get; set; }
    public object results { get; set; }
    public string messages { get; set; }
}
}
