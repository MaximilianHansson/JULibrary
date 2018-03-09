using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RepositoryLayer;
using ServiceLayer.Models;


namespace ServiceLayer.Configuration
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new toBookProfile());
                cfg.AddProfile(new fromBookProfile());

                cfg.AddProfile(new toAuthorProfile());
                cfg.AddProfile(new fromAuthorProfile());

                cfg.AddProfile(new toClassificationProfile());
                cfg.AddProfile(new fromClassificationProfile());
            });
        }
        
    }
    public class toBookProfile : Profile
    {
        public toBookProfile()
        {
            CreateMap<BOOK, Book>();
        }
    }
    public class fromBookProfile : Profile
    {
        public fromBookProfile()
        {
            CreateMap<Book, BOOK> ();
        }
    }

    public class toAuthorProfile : Profile
    {
        public toAuthorProfile()
        {
            CreateMap<AUTHOR, Author>();
        }
    }
    public class fromAuthorProfile : Profile
    {
        public fromAuthorProfile()
        {
            CreateMap<Author, AUTHOR>();
        }
    }

    public class toClassificationProfile : Profile
    {
        public toClassificationProfile()
        {
            CreateMap<CLASSIFICATION, Classification>();
        }
    }
    public class fromClassificationProfile : Profile
    {
        public fromClassificationProfile()
        {
            CreateMap<Classification, CLASSIFICATION>();
        }
    }
}
