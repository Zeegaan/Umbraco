using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class DrawRules
    {
        private List<string> serialNumbers;
        private List<Form> forms;
        public DrawRules(List<string> serialNumbers, List<Form> forms)
        {
            this.serialNumbers = serialNumbers;
            this.forms = forms;
        }

        public bool CheckRules(string serialNumber)
        {
            if(CheckIfUsedTwice(serialNumber) && CheckIfValid(serialNumber))
            {
                return true;
            }
            return false;
        }

        private bool CheckIfValid(string serialNumber)
        {
            foreach (var number in serialNumbers)
            {
                if (number == serialNumber)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfUsedTwice(string serialNumber)
        {
            //making new empty list of string
            List<string> usedNumbers = new List<string>();

            foreach (var form in forms)
            {
                //check if the serial numbers match, if they do, add them to the UsedNumbers list
                if (form.SerialNumber == serialNumber)
                {
                    usedNumbers.Add(form.SerialNumber);
                }
                //Check if we already have 2 numbers in the database, if yes, return false.
                if (usedNumbers.Count == 2)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
