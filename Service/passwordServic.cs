using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class passwordServic : IpasswordServic
    {

        public password PasswordHardness(string password)
        {
            password password1 = new password();
            password1.Name = password;
            password1.Level = Zxcvbn.Core.EvaluatePassword(password).Score;
            return password1;
        }
    }
}
