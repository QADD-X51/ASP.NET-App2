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

            if (unitOfWork.Users.GetUserByCredentials(newUser.Username, newUser.Password) == null)
                return null;

            unitOfWork.Users.Insert(newUser);
            unitOfWork.SaveChanges();

            return payload;
        }

        public User LoginUser(UserLoginDto payload)
        {
            if (payload == null) return null;

            var exists = unitOfWork.Users.GetUserByCredentials(payload.Username,payload.Password);

            return exists;
        }
    }
}
