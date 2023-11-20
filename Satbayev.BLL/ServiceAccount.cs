using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL
{
    class ServiceAccount : Service<Account>
    {
        public ServiceAccount(string Path) :base(Path)
        {
            
        }

        public bool CreateAccount(Account account) 
        {
            return repo.Create(account);
        }

        public List<Account> GetAllAccounts(int id)
        {
            return repo.GetAll().Where(w => w.ClientId == id).ToList();
        }

        public bool CashInAccount(int id, int sum)
        {
            Account schet = repo.GetAll().FirstOrDefault(w => w.ClientId == id);
            schet.Balance += sum;
            return repo.Update(schet);
            
        }

        public bool CashOutAccount(int id, int sum)
        {
            Account schet = repo.GetAll().FirstOrDefault(w => w.ClientId == id);
            schet.Balance -= sum;  
            if (schet.Balance < sum)
            {
                throw new Exception("Aqhsa jetpeidi");
            }
            else
            {
                schet.Balance -= sum;
            }
            return repo.Update(schet);
        }
    }
}
