using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndLINQ
{
    public delegate bool CompareDelegate(User user);
    public class UserServices
    {
        internal List<User> _users = [];
        public User? Find(CompareDelegate compare)
        {
            foreach (User user in _users)
            {
                if (compare(user))
                {
                    return user;
                }
            }
            return null;
        }
        public List<User> FindAll(CompareDelegate compare)
        {
            List<User> temp = [];
            foreach (User user in _users)
            {
                if (compare(user))
                {
                    temp.Add(user);
                }
            }
            return temp;
        }
    }
}
