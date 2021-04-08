using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UmbracoProjekt.Models
{
    public class SerialNumberRepo
    {
        private List<string> serialNumbers = new List<string>();
        public SerialNumberRepo()
        {
            Load();
        }
        public List<string> Get()
        {
            return serialNumbers;
        }
        public void Create(int count)
        {
            Guid newGuid;
            for (int i = 0; i < count; i++)
            {
                newGuid = Guid.NewGuid();
                serialNumbers.Add(newGuid.ToString());
            }
            SaveChanges();
        }
        public void Delete(string serialNumber)
        {
            serialNumbers.Remove(serialNumber);
        }
        public void SaveChanges()
        {
            File.WriteAllLines("text.txt", serialNumbers.Select(x => string.Join(",", x)));
        }
        private void Load()
        {
            var lines = System.IO.File.ReadAllLines("text.txt").Select(x => x.Split(','));
            foreach (var line in lines)
            {
                serialNumbers.Add(line[0]);
            }
        }
    }
}
