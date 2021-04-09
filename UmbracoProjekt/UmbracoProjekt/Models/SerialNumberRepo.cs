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
            //Looping through 'count' amount of times, instantiating a new Guid, calling newGuid.ToString() and adding it to serialNumbers list
            Guid newGuid;
            for (int i = 0; i < count; i++)
            {
                newGuid = Guid.NewGuid();
                serialNumbers.Add(newGuid.ToString());
            }
            //After we have created all the new serial numbers, save the changes
            SaveChanges();
        }
        public void Delete(string serialNumber)
        {
            serialNumbers.Remove(serialNumber);
            SaveChanges();
        }
        public void SaveChanges()
        {
            //Write to the text.txt file with all the serial numbers in the list
            File.WriteAllLines("text.txt", serialNumbers.Select(x => string.Join(",", x)));
        }
        private void Load()
        {
            //Read all the Lines in text.txt file, split it if theres a ","
            var lines = System.IO.File.ReadAllLines("text.txt").Select(x => x.Split(','));
            foreach (var line in lines)
            {
                // as we don't have a "," we just need the first string in the array to get our serial number, add it to the serialNumbers list.
                serialNumbers.Add(line[0]);
            }
        }
    }
}
