using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;

namespace StockManagementSystemApplication.BLL
{
    class RegisterManager
    {

        RegisterRepository registerRepository = new RegisterRepository();
        public static Regex regex=new Regex(@"[A-Za-z]");
        public static Regex reg2 = new Regex(@"[ ]");
        public static Regex reg = new Regex(@"[@]");
        public bool Add(RegistrationInformation registrationInformation)
        {
           
           
           
           

            bool isAdded = registerRepository.Add(registrationInformation);
            return isAdded;
        }

        public bool ValidateName(string Name)
        {
            if (Name == String.Empty)
            {
                return false;
            }
            if (regex.IsMatch(Name) == false)
            {
                return false;
            } 
            return true;
        }

        public bool ValidateUserName(string userName)
        {
            if (userName == String.Empty)
            {
                return false;
            }
            if (reg2.IsMatch(userName))
            {
                return false;
            }
            if (!registerRepository.Check(userName))
            {
                return false;
            }
            return true;
        }

        public bool ValidatEmail(string email)
        {

            if (email == String.Empty)
            {
                return false;
            }
            if (reg.IsMatch(email) == false)
            {
                return false;
            }
            return true;
        }

    }
}
