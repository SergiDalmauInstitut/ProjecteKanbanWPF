using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanbanWPF.ApiClient.ApiObjects
{
    internal class LoginDTO
    {
        public required string Mail { get; set; }
        public required string Password { get; set; }
    }
}
