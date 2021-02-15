using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Business.Constant;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Core.Utilities.Security;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;

namespace TepeBusApp.Business.Concreate
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var userCheck = _userService.GetByMail(loginDTO.Email);
            if (userCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!Hashing.VerifyPasswordHash(loginDTO.Password, userCheck.Data.PasswordHash, userCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userCheck.Data);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO, string password)
        {
            byte[] passwordHash, passwordSalt;
            Hashing.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                isAdmin = false,
                isDelete = false,
                CreatedDate = DateTime.Now
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegisterd);
        }

        public bool RePassword(RegisterDTO registerDTO)
        {
            if (registerDTO.Password != registerDTO.RePassword)
            {
                return false;
            }
            return true;
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
