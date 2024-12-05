using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace api_zachet.ActionClass.HelperClass.DTO
{
    public class PersonDTO
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; internal set; } = null;
        public string Surname { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Email { get; set; } = null;
    }
}
