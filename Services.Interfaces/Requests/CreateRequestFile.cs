using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class CreateRequestFile
    {
        public string Source { get; set; }
        public string FileName { get; set; }
        public int RequestId { get; set; }
        public CreateRequestFile(String Source,String FileName, int RequestId)
        {
            this.Source = Source;
            this.FileName = FileName;
            this.RequestId = RequestId;
        }
    }
}
