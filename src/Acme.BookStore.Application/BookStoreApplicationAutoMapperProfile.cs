using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Shelves;
using AutoMapper;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
            CreateMap<Shelf, ShelfDto>();
            CreateMap<CreateUpdateShelfDto, Shelf>();
        }
    }
}
