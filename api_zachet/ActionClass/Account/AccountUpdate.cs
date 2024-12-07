﻿using System.ComponentModel.DataAnnotations;

namespace api_zachet.ActionClass.Account
{
    public class AccountUpdate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
