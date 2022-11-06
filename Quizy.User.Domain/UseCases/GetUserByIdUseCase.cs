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
    public class GetUserByIdUseCase
    {
        private readonly IUserRepository _repository;

        public GetUserByIdUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> ExecuteAsync(string id)
        {
            var user = await this._repository.FindByIdAsync(new Id(id));
            if(user == null)
            {
                throw new UserNotFoundException(id);
            }

            var dto = new UserDto(user);

            return dto;
        }
    }

}
