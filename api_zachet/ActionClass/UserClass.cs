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

        public List<string> AddAccount(AccountCreate account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(account.Phone))
                    return new List<string> { "Поле с номером телефона не заполнено" };

                if (account.Phone.Length < 11)
                    return new List<string> { "Номер телефона не может быть меньше или больше 11 символов" };

                Person createUser = new Person()
                {
                    
                    Name = account.Name, 
                    Surname = account.Surname, 
                    PhoneNumber = account.Phone, 
                    Email = account.Email
                };

                _context.Add(createUser);
                _context.SaveChanges();

                int personId = createUser.PersonId;

                Results.Created();
                return [$"Пользователь успешно создан Id - {personId}"];
            }
            catch(Exception)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса"});
                throw;
            }
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
            try
            {
                var data = _context.Persons.Where(u => u.Name == name).Select(x => new PersonDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    Id = x.PersonId,
                    Phone = x.PhoneNumber,
                    Surname = x.Surname,
                }
                ).ToList();
                return (List<PersonDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
