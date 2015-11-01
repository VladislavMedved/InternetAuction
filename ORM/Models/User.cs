using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public partial class User
    {
        public User()
        {
            SoldProducts = new HashSet<Product>();
            BoughtProducts = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Login { get; set; }

        [EmailAddress]
        public string E_mail { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; } 
        public DateTime RegistryDate { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; }

        public virtual ICollection<Product> BoughtProducts { get; set; }

        
    }
}
