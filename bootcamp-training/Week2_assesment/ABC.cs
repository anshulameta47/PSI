using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2_assesment;

namespace Assesment_Week2
{
    class ABC : Account
    {
        //private string accountnumber;
        private string ownername = "";
        private float balance;
        private static int NumberofAccount = 0;
        public string Addaccount()
        {
            Console.WriteLine("Enter account holder name");
            ownername = Console.ReadLine();

            Console.WriteLine("Enter amount you are debiting to create your account");
            balance = (float)Convert.ToInt32(Console.ReadLine());

            using (Week2_assesment_DBEntities DBEntities = new Week2_assesment_DBEntities())
            {
                Account newaccount = new Account() {
                    Account_Number = NumberofAccount++,
                Owner_Name = ownername,
                Balance = balance,
                CreationDate = DateTime.Now};

                DBEntities.Accounts.Add(newaccount);
                DBEntities.SaveChanges();
            }
            return "Account is added";

        }

        private void UpdateBalanceAfterWithdraw(float amount, int my_account_number)
        {
            using (Week2_assesment_DBEntities DBEntities = new Week2_assesment_DBEntities())
            {

                float Updatedbalance = CurrentBalance(my_account_number) - amount;

                List<Account> accounts = DBEntities.Accounts.ToList();
                foreach (var myaccount in accounts)
                {
                    if (myaccount.Account_Number == My_Account_number)
                    {
                        DBEntities.Accounts.Remove(myaccount);
                        myaccount.Balance = Updatedbalance;
                        DBEntities.Accounts.Add(myaccount);
                        DBEntities.SaveChanges();
                    }
                }

            }
        }
        private string UpdateBalanceAfterDebit(float amount)
        {
            using (Week2_assesment_DBEntities DBEntities = new Week2_assesment_DBEntities())
            {

                float Updatedbalance = CurrentBalance(my_account_number) + amount;

                List<Account> accounts = DBEntities.Accounts.ToList();
                foreach (var myaccount in accounts)
                {
                    if (myaccount.Account_Number == My_Account_number)
                    {
                        DBEntities.Accounts.Remove(myaccount);
                        myaccount.Balance = Updatedbalance;
                        DBEntities.Accounts.Add(myaccount);
                        DBEntities.SaveChanges();
                    }
                }

            }
        }
        private float CurrentBalance(int My_Account_number)
        {
            using (Week2_assesment_DBEntities DBEntities = new Week2_assesment_DBEntities())
            {
                List<Account> accounts = DBEntities.Accounts.ToList();
                foreach (var myaccount in accounts)
                {
                    if (myaccount.Account_Number == My_Account_number)
                    {
                        return myaccount.Balance;
                    }
                }
            }
        }
    }
}
