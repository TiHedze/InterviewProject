namespace LibraryApp.Application.Core
{
    using AutoMapper;
    using LibraryApp.Application.Responses;
    using LibraryApp.Core.Entities.Database;
    using System.Collections.Generic;

    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            this.CreateMap<Author, AuthorResponse>();
            this.CreateMap<Book, AuthorBookResponse>();
        }
    }
}