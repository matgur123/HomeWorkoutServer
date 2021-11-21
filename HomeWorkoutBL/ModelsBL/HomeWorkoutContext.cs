
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HomeWorkoutBL.Models;
namespace HomeWorkoutBL.Models
{       
        public partial class HomeWorkoutContext : DbContext
        {

        //scaffold-dbcontext "Server=localhost\sqlexpress;Database=HomeWorkoutDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
        //Server=localhost\sqlexpress;Database=HomeWorkoutDB;Trusted_Connection=True;

        public User Login(string email, string pswd)
        {
            User user = this.Users
            .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;

        }
    }
}
