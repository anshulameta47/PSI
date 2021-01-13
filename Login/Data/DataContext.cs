/*
*Login Controller
* Aditya and Anshul
*15 sept 2020
* Creating the DbContext
*/
using Com.Sapient.Models;
using Com.Sapient.Utility;
using Microsoft.EntityFrameworkCore;

namespace Com.Sapient.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<User_Role_Mapping> User_Role_Mappings { get; set; }
        public DbSet<User_SecurityQuestion_Mapping> User_SecurityQuestion_Mappings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityQuestion>().HasData(new SecurityQuestion {Id = 1, Question = "What is your pet name?"},new SecurityQuestion {Id = 2, Question = "What is your favourite dish?"} );
            modelBuilder.Entity<User_SecurityQuestion_Mapping>().HasData(new User_SecurityQuestion_Mapping {UserAccountId = 1, SecurityQuestionId = 1, Answer = "Fluffy"},new User_SecurityQuestion_Mapping {UserAccountId = 2, SecurityQuestionId = 2, Answer = "chicken"} );

            modelBuilder.Entity<User_Role_Mapping>().HasKey(ur => new { ur.UserAccountId, ur.RoleId });
            modelBuilder.Entity<User_SecurityQuestion_Mapping>().HasKey(ur => new { ur.UserAccountId, ur.SecurityQuestionId });

            modelBuilder.Entity<UserAccount>().HasData(new UserAccount { Id=1,Email = "test1@gmail.com", Password = PasswordUtility.Encrypt("test1"),IsActive=false,FirstName="raj",LastName="kapoor",Gender='m'},
                                                                        new UserAccount { Id=2, Email = "test2@gmail.com", Password = PasswordUtility.Encrypt("test2"),IsActive=true,FirstName="manroop",LastName="singh",Gender='m'},
                                                                        new UserAccount { Id = 3, Email = "adityakhanna2009@gmail.com", Password = PasswordUtility.Encrypt("test3"),IsActive=true,FirstName="vin",LastName="diesel",Gender='m'},
                                                                        new UserAccount { Id = 4, Email = "anshulameta@gmail.com", Password = PasswordUtility.Encrypt("test4"), IsActive = true, FirstName = "charles", LastName = "arthur", Gender = 'm' },
                                                                        new UserAccount { Id = 5, Email = "soni.nikhilkumar@gmail.com", Password = PasswordUtility.Encrypt("test5"), IsActive = true, FirstName = "nikhil", LastName = "soni", Gender = 'm' },
                                                                        new UserAccount { Id = 6, Email = "amrithkhanna2010@gmail.com", Password = PasswordUtility.Encrypt("test6"), IsActive = true, FirstName = "pariwesh", LastName = "gupta", Gender = 'm' },
                                                                        new UserAccount { Id = 7, Email = "test4@gmail.com", Password = PasswordUtility.Encrypt("test7"), IsActive = true, FirstName = "megha", LastName = "gupta", Gender = 'f'},
                                                                        new UserAccount { Id = 8, Email = "test5@gmail.com", Password = PasswordUtility.Encrypt("test8"), IsActive = true, FirstName = "arnab", LastName = "ari", Gender = 'm' },
                                                                        new UserAccount { Id = 9, Email = "test6@gmail.com", Password = PasswordUtility.Encrypt("test9"), IsActive = true, FirstName = "vijay", LastName = "pandey", Gender = 'm' }
                                                                        

                                                                        );
            
        }
        
    }
}