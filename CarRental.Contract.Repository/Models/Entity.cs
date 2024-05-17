using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Contract.Repository.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        [NotMapped]
        public string Id { get; set; }

        public string? TrangThai { get; set; }
    }
}
