using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;

namespace TepeBusApp.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(LoginDTO loginDTO);
        IResult UserExist(string email);
        bool RePassword(RegisterDTO registerDTO);
        IDataResult<User> Register(RegisterDTO registerDTO, string password);
    }
}
