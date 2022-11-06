using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.User.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string idOrEmail) : base($"User not found ({idOrEmail})")
        {

        }
    }
}
