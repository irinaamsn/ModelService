using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitModelBl.Model
{
    public class EnumServices
    {
        public enum AllServices
        {
            стрижка=1,//+мытье и сушка
            бритье,
            покраска_волос,//+мытье и сушка
            укладка,//+мытье и сушка
            уход_за_волосами//+мытье и сушка
        }
    }
}
