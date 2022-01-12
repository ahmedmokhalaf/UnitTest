using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class AccessLayer
    {
        private readonly WeightContext weightContext;

        public AccessLayer(WeightContext weightContext)
        {
            this.weightContext = weightContext;
        }

        public void AddUser(User user)
        {
            weightContext.Users.Add(user);
            weightContext.SaveChanges();
        }

        public User GetUser(string name)
        {
            return weightContext.Users.SingleOrDefault(user => user.Name == name);
        }

    }
}
