﻿namespace AdminDashBoard.ViewModel.Admin
{
    public class UserDetailsViewModel
    {

        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserDetailsViewModel() { }
        public UserDetailsViewModel(int id,string firstName, string lastName, string userName, string email)
        {
            Id= id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
    }
}
