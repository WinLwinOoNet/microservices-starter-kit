using System.Threading.Tasks;
using Msk.WebApp.Entities;

namespace Msk.WebApp.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);
    }
}
