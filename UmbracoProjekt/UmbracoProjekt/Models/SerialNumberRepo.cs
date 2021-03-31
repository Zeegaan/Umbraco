using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbracoProjekt.Models
{
    public class SerialNumberRepo
    {
        private List<string> serialNumbers;
        public SerialNumberRepo()
        {
            Guid newGuid;
            List<string> result = new List<string>();
            for (int i = 1; i < 101; i++)
            {
                newGuid = Guid.NewGuid();
                result.Add(newGuid.ToString());
            }
            serialNumbers = result;
        }
        public List<string> Get()
        {
            return serialNumbers;
        }
    }
}
