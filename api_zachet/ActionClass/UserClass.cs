using api_zachet.ActionClass.Account;
using api_zachet.ActionClass.HelperClass.DTO;
using api_zachet.Interface;
using api_zachet.Models;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<string> DeletePerson(int id)
        {
            try
            {
                var person = _context.Persons.Find(id);
                if (person == null) 
                {
                    Results.NotFound(new List<string> { "Пользователь не найден" });
                }

                var personSigns = _context.Signs.Where(ks => ks.PersonId == id).ToList();

                if (personSigns.Any())
                {
                    _context.RemoveRange(personSigns);
                    _context.SaveChanges();
                }
                _context.Persons.Remove(person);
                _context.SaveChanges();

                Results.NoContent();
                return new List<string> { "Пользователь успешно удален" };

            }
            catch
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }

        //public List<PersonDTO> GetPerson(string name)
        //{
        //    try
        //    {
        //        var person = _context.Persons.Find(name);
        //        if (_context.Persons.Contains(name))
        //        {
        //            Results.NotFound(new List<string> { "Пользователь не найден" });
        //        }
        //    }
        //    catch
        //    {
        //        Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
        //        throw;
        //    }
        //}

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

        public List<PersonDTO> GetPerson(string name)
        {
            throw new NotImplementedException();
        }
    }
}
