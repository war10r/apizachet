using api_zachet.ActionClass.Account;
using api_zachet.ActionClass.HelperClass.DTO;
using api_zachet.Interface;
using api_zachet.Models;

namespace api_zachet.ActionClass
{
    public class UserClass : IUser
    {
        private readonly EremeevZachetContext _context;
        public UserClass(EremeevZachetContext context) => _context = context;

        public bool AddAccount(AccountCreate account)
        {
            throw new NotImplementedException();
        }

        public List<string> DeletePerson(long id)
        {
            throw new NotImplementedException();
        }

        public List<PersonDTO> GetPerson(string name)
        {
            throw new NotImplementedException();
        }

        public List<PersonDTO> GetPersons()
        {
            try
            {
                var data = _context.Persons.Select(
                    x => new PersonDTO()
                    {
                        Name = x.Name, Email = x.Email, Id = x.PersonId, Phone = x.PhoneNumber, Surname = x.Surname,
                    }).ToList();

                return (List<PersonDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<PersonDTO> UpdatePersons(string name, PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
