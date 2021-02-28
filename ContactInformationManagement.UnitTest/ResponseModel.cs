using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInformationManagement.UnitTest
{
    public class ResponseModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("contactId")]
        public int? ContactId { get; set; }
    }
}
