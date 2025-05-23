using DevFreela.Domain.Entities;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    internal class CommentMapper
    {
        public ProjectCommentEntity ToCommentEntity(CreateCommentModel model)
           => new(Content, IdProject, IdUser);
    }
}
