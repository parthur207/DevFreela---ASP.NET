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
    public class CommentMapper
    {
        public static ProjectCommentEntity ToCommentEntity(CreateCommentModel model)
           => new(model.Content, model.IdProject, model.IdUser);
    }
}
