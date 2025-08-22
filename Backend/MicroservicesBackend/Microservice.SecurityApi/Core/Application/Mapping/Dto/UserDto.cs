﻿namespace Microservice.Security.Core.Application.Mapping.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
