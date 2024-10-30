using bankapp.bankapp.exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankapp.bankAppServices;

namespace bankapp
{
    internal class Program
    {
       
        static void Main(string[] args)
        {            
            BankAppService.displayMenu();

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
    }
}
