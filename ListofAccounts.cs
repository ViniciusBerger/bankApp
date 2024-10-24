using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp
{
    internal class ListofAccounts
    {
        private ContaCorrente[] _item = null;
        private int _nextPosition = 0;

        public ListofAccounts(int initialSize = 3)
        {
            _item = new ContaCorrente[initialSize];


        }

        //INDEXADOR, USING THIS IS POSSIBLE NOW TO CALL THE ARRAY BY INDEX
        public ContaCorrente this[int index]
        {
            get { return RecoverAccountByIndex(index); }
        }
        public void add(ContaCorrente Account)
        {
            verifySize(_nextPosition + 1);
            _item[_nextPosition] = Account;
            _nextPosition++;         
        }
        public void displayAccounts()
        {
            for (int i = 0; i < _nextPosition; i++)
            {
                Console.WriteLine($"account {i + Environment.NewLine} Account: {_item[i].Account + Environment.NewLine} Agency: {_item[i].Agency + Environment.NewLine} Balance: {_item[i].Balance + Environment.NewLine}");
            }
        }
        private void verifySize(int necessarySize)
        {
            if (_item.Length >= necessarySize)
                return;
            else
            {
                ContaCorrente[] newAccountList = new ContaCorrente[necessarySize];

                for (int i = 0; i < _item.Length; i++)
                {
                    newAccountList[i] = _item[i];
                }
                _item = newAccountList;
            }
        }
        public void maxBalance()
        {
            double maxValue = 0;
            foreach (var item in _item)
            {
                if (maxValue <= item.Balance)
                    maxValue = item.Balance;                    
            }
            Console.WriteLine($"the highest balance between these accounts is {maxValue}");
            
        }
        public void removeAccount(ContaCorrente Account)
        {
            for (int i = getIndex(Account); i < _nextPosition - 1; i++)
            {
                _item[i] = _item[i+1];
                _nextPosition--;
                _item[_nextPosition] = null;
            }
            Console.WriteLine($"removing account {Account.Account}");
            
        }
        private int getIndex(ContaCorrente Account)
        {
            int itemIndex = 0;
            for (int i = 0; i < _nextPosition; i++)
            {
                ContaCorrente currentAccount = _item[i];
                if (currentAccount == Account)
                    itemIndex = i;
            }

            return itemIndex;
        }
        private ContaCorrente RecoverAccountByIndex(int index)
        {
            if (index <0 | index > _nextPosition)
                throw new ArgumentOutOfRangeException(index.ToString());
            else
                return _item[index];
        }
        public int Size
        { get { return _nextPosition; } }
    }
}
