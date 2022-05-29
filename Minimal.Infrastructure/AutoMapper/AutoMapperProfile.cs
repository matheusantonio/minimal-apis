using AutoMapper;
using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDomain>();
            CreateMap<PaginatedList<Post>, PaginatedList<PostDomain>>();

            CreateMap<PostDomain, Post>();
        }
    }
}
