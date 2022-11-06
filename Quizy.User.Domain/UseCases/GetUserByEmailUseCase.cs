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
    public class GetUserByEmailUseCase
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> ExecuteAsync(string email)
        {
            var user = await this._repository.FindByEmailAsync(email);
            if(user == null)
            {
                throw new UserNotFoundException(email);
            }

            var dto = new UserDto(user);

            return dto;
        }
    }

}
