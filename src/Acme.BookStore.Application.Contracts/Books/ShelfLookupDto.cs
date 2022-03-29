using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books
{
    public class ShelfLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
