using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDAPI.DAL.Entity.DTO
{
    public class UpdateUserDTO
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }

    }
}
