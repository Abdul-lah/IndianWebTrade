using System;
using System.Collections.Generic;
using System.Text;

namespace INFASTRUCTURE.GernalResult
{
    public interface IGernalResult
    {
        public string Message { get; set; }
        public bool Succsefully { get; set; }
        public object value { get; set; }
    }
    public class GernalResult: IGernalResult
    {
        public string Message { get; set; }
        public bool Succsefully { get; set; }
        public object value { get; set; }
    }
}
