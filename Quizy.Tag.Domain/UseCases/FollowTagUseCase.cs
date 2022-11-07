using Quizy.Shared.DDD;
using Quizy.Tag.Domain.Dtos;
using Quizy.Tag.Domain.Entities;
using Quizy.Tag.Domain.Exceptions;
using Quizy.Tag.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Domain.UseCases
{
    public class FollowTagUseCase
    {
        private readonly ITagRepository _repository;

        public FollowTagUseCase(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TagDto> ExecuteAsync(Id userId, string tagName)
        {
            var existingTag = await _repository.FindByUserIdAndName(userId, tagName);
            if(existingTag != null)
            {
                return new TagDto(existingTag);
            }

            if (string.IsNullOrEmpty(tagName))
            {
                throw new InvalidParameterException($"Invalig tagName ({tagName})");
            }

            var tag = new TagEntity(
                id: new Id(),
                name: tagName,
                userId: userId
            );
            await _repository.SaveAsync(tag);
            await _repository.SaveChangesAsync();

            return new TagDto(tag);
        }
    }
}
