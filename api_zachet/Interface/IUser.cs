using api_zachet.ActionClass.HelperClass.DTO;
using api_zachet.ActionClass.Account;
using Microsoft.Identity.Client;

namespace api_zachet.Interface
{
    public interface IUser
    {
        public List<PersonDTO> GetPersons();

        public List<PersonDTO> GetPerson(string name);

        public bool AddAccount(AccountCreate account);

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<PersonDTO> UpdatePersons(string name, PersonDTO person);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> DeletePerson(int id);
    }
}
