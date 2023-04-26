using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserAddDto RegisterUser(UserAddDto payload)
        {
            if (payload == null) return null;

            var existingRole = unitOfWork.Classes.GetById(payload.RoleId);
            if (existingRole == null) return null;

            var newUser = new User
            {
                Username = payload.Username,
                Password = payload.Password,

                RoleId = existingRole.Id
            };

            if (unitOfWork.Users.Any(q => q.Username == newUser.Username))
                return null;

            unitOfWork.Users.Insert(newUser);
            unitOfWork.SaveChanges();

            return payload;
        }

        public bool LoginUser(UserLoginDto payload)
        {
            if (payload == null) return false;

            var targetUser = new User
            {
                Username = payload.Username,
                Password = payload.Password
            };

            var exists = unitOfWork.Users.Any(q => q.Username == targetUser.Username && q.Password == targetUser.Password);

            return exists;
        }
    }
}
