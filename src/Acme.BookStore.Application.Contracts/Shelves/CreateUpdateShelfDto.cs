using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Shelves
{
    public class CreateUpdateShelfDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
