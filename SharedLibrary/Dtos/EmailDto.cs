using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class EmailDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }

        public EmailDto() { }

        public EmailDto(string name, string email, string subject, string message)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Message = message;
        }

    }
}
