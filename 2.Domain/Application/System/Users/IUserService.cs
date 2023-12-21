using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.System.Users;

namespace Application.System.Users
{
    public interface IUserService
    {
        public Task<string> Authenticate(LoginRequest request);
        public Task<bool> Register(RegisterRequest request);
    }
}
