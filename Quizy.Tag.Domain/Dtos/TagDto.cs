using Quizy.Tag.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Domain.Dtos
{
    public class TagDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }

        public TagDto(TagEntity tag)
        {
            Id = tag.Id.Value;
            Name = tag.Name;
            UserId = tag.UserId.Value;
        }
    }
}
