using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class TagModelService : ITagModelService
    {
        public TagEntity ModelToEntity(Tag tag)
        {
            TagEntity tagEntity = null;
            if (tag.Isdeleted == 0)
                tagEntity = new TagEntity(tag);
            return tagEntity;
        }
    }
}
