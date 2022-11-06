using Quizy.Shared.DDD;
using Quizy.User.Domain.Dtos;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Exceptions;
using Quizy.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.User.Domain.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> ExecuteAsync(string name, string email)
        {
            var existingUser = await this._repository.FindByEmailAsync(email);
            if(existingUser != null)
            {
                throw new EmailAlreadyExistsException(email);
            }

            var user = new UserEntity(
                id: new Id(),
                name: name,
                email: email
            );

            await this._repository.SaveAsync(user);
            await this._repository.SaveChangesAsync();

            var dto = new UserDto(user);

            return dto;
        }
    }

}
