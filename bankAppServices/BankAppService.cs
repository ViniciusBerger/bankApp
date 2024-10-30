using bankapp.bankapp.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp.bankAppServices
{
    public class BankAppService
    {
        static List<ContaCorrente> listAccounts = new List<ContaCorrente>();
        public static void displayMenu()
        {
            BankAppService.listAccounts.Add(new ContaCorrente(794, 794.00, "Joao pedro", "05262589199", "unenployed"));
            BankAppService.listAccounts.Add(new ContaCorrente(784, 124.00, "Gui", "05262589199", "unenployed"));
            BankAppService.listAccounts.Add(new ContaCorrente(774, 844.00, "Luiza", "05262589199", "unenployed"));

            int option = 0;
            while (option != 6)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("=== WELCOME TO THE CRIA'S BANK ===");
                Console.WriteLine("==================================");
                Console.WriteLine("1- Add Account");
                Console.WriteLine("2- List Accounts");
                Console.WriteLine("3- Remove Accounts");
                Console.WriteLine("4- Sort Accounts");
                Console.WriteLine("5- Search Accounts");
                Console.WriteLine("6- quit");
                Console.WriteLine("==================================");

                try
                {
                    string charOption = Console.ReadLine();
                    option = int.Parse(charOption);

                    switch (option)
                    {
                        case 1:
                            addAccount();
                            break;
                        case 2:
                            displayAccountList();
                            break;
                        case 3:
                            removeAccount();
                            break;
                        case 4:
                            sortObjects();
                            break;
                        case 5:
                            searchAccount();
                            break;
                        case 6:
                            break;
                    }
                }

                catch (bankappException exception)
                {
                    Console.WriteLine("a exception happened ==>" + exception.Message);
                    Console.ReadLine();                   
                }
            }

        }

        static void addAccount()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===== Add Account menu =====");
            Console.WriteLine("============================");

            try
            {
                ContaCorrente conta = new ContaCorrente(acctAgency(), acctBalance(), acctTitular(), titularID().ToString(), titularProfession());

                listAccounts.Add(conta);

                Console.WriteLine(conta.ToString());
                Console.WriteLine("This Account is being added");
                Console.ReadLine();

                Console.Clear();               
            }
           
            catch (Exception except)
            {
                Console.WriteLine($"===> {except.Message}");
                Console.ReadLine();
                addAccount();
            }           

        }


        #region addAccounts functions
        static string acctTitular()
        {
            Console.WriteLine("inform the titular's name: ");
            string acctTitular = Console.ReadLine().Trim();
            return acctTitular;
        }

        static int acctAgency()
        {
            Console.WriteLine("Inform Account agency");
            int acctAgency = int.Parse(Console.ReadLine().Trim());
            return acctAgency;
        }

        static double acctBalance()
        {
            Console.WriteLine("Inform your balance: ");
            double acctBalance = double.Parse(Console.ReadLine().Trim());
            return acctBalance;
        }

        static long titularID()
        {
            bool loop = true;
            long titularID = 0;
            while (loop)
            {
                Console.WriteLine("Inform titular's id: ");
                titularID = long.Parse(Console.ReadLine().Trim());
                int lenght = titularID.ToString().Length;
                if (lenght< 9)
                {
                    loop = true;
                    
                    throw new Exception("===> The informed ID is in the wrong format");
                }
                else
                {
                    loop = false;
                }
                
            }
            return titularID;
        }

        static string titularProfession()
        {
            Console.WriteLine("inform the titular's job: ");
            string titularProfession = Console.ReadLine().Trim();
            return titularProfession;
        }
        #endregion


        static void displayAccountList()
        {
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("list Accounts menu");
            Console.WriteLine("===========================");
            if (listAccounts.Count == 0)
                Console.WriteLine("There is no cadastred accounts");
            Console.WriteLine("\n");
            foreach (ContaCorrente account in listAccounts)
            {
                Console.WriteLine(account.ToString());
            }
            Console.ReadLine();
            Console.Clear();           
        }

        static void removeAccount()
        {
            Console.WriteLine("======================");
            Console.WriteLine("=== REMOVE ACCOUNT ===");
            Console.WriteLine("======================");
            Console.WriteLine("");
            Console.WriteLine("Please type the account number you want to remove =>");
            string acctNumber = Console.ReadLine().Trim();
            ContaCorrente account = null;

            account = listAccounts.Where(Account => Account.Account == acctNumber).FirstOrDefault();
            if (account != null)
            {
                listAccounts.Remove(account);
                Console.WriteLine("This account has been removed...");
            }
            else
            {
                Console.WriteLine("there is no such account in our record...");
            }
            Console.ReadLine();
            Console.Clear();            
        }

        static void sortObjects()
        {
            listAccounts.Sort();
            displayAccountList();

        }

        static void searchAccount()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("=== Search account menu ===");
            Console.WriteLine("==============================");
            Console.WriteLine("");
            Console.WriteLine("Please type the account you are looking for => ");
            string acct = Console.ReadLine().Trim();

            try
            {
                bool found = false;
                ContaCorrente account;

                account = listAccounts.Where(Account => Account.Account == acct).FirstOrDefault();
                if (account != null)
                {
                    Console.WriteLine(account.ToString());
                    found = true;
                    Console.ReadLine();
                }
                if (!found)
                {
                    Console.WriteLine("The account you are searching is not in our records");
                    Console.ReadLine();
                }
            }
            catch (Exception exception)
            {
                throw new bankappException(exception.Message);
            }

        }
    }
}
