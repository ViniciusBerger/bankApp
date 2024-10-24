using bankapp.bankapp.exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp
{
    internal class Program
    {
        static List<ContaCorrente> listAccounts = new List<ContaCorrente>();
        static void Main(string[] args)
        {
            listAccounts.Add(new ContaCorrente(794, "000001", 794.00, "Joao pedro", "05262589199", "unenployed"));
            listAccounts.Add(new ContaCorrente(784, "000002", 124.00, "Gui", "05262589199", "unenployed"));
            listAccounts.Add(new ContaCorrente(774, "000003", 844.00, "Luiza", "05262589199", "unenployed"));
            displayMenu();

        }
        //#region test of basic tools
        //void testTools()
        //{
        //    ListofAccounts listAccounts = new ListofAccounts();

        //    listAccounts.add(new ContaCorrente(874, "000001-A", 10000));
        //    listAccounts.add(new ContaCorrente(874, "000002-A", 8750));
        //    listAccounts.add(new ContaCorrente(874, "000003-b", 7461.47));
        //    var contaGui = new ContaCorrente(874, "000006-c", 78.45);
        //    listAccounts.add(contaGui);
        //    listAccounts.add(new ContaCorrente(874, "000004-b", 89.760));
        //    listAccounts.add(new ContaCorrente(874, "000005-c", 2789.50));

        //    for (int i = 0; i < listAccounts.Size; i++)
        //    {
        //        ContaCorrente currentAccount = listAccounts[i];
        //        Console.WriteLine(currentAccount.ToString());

        //    }
        //    Console.ReadLine();
        //}
        //#endregion

        static void displayMenu()
        {
            try
            {
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

                    }
                    catch (Exception exception)
                    {
                        throw new bankappException(exception.Message);
                    }

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
            }
            catch (bankappException exception)
            {
                Console.WriteLine("a exception happened ==>" + exception.Message);
                Console.ReadLine();
                displayMenu();
            }
            
            
        }

        static void addAccount()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Add Account menu");
            Console.WriteLine("============================");


            Console.WriteLine("Inform Account number: ");
            string acctNumber = Console.ReadLine().Trim();

            Console.WriteLine("Inform Account agency");
            int acctAgency = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Inform your balance: ");
            double acctBalance = double.Parse(Console.ReadLine().Trim());

            Console.WriteLine("inform the titular's name: ");
            string acctTitular = Console.ReadLine().Trim();

            Console.WriteLine("Inform titular's id: ");
            string titularID = Console.ReadLine().Trim();

            Console.WriteLine("inform the titular's job: ");
            string titularProfession = Console.ReadLine().Trim();

            ContaCorrente conta = new ContaCorrente(acctAgency, acctNumber, acctBalance, acctTitular, titularID, titularProfession);

            listAccounts.Add(conta);

            Console.WriteLine(conta.ToString());
            Console.WriteLine("This Account is being added");
            Console.ReadLine();

            Console.Clear();
            displayMenu();

        }

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
            displayMenu();
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
            displayMenu();
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
