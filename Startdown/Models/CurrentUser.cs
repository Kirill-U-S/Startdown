﻿namespace Startdown.Models
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public CurrentUser() { }

        public CurrentUser(int Id, string Login)
        {
            this.Id = Id;
            this.Login = Login;
        }
    }
}
