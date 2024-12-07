using System.ComponentModel.DataAnnotations;

namespace api_zachet.ActionClass.HelperClass.DTO
{
    public class AccountUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
