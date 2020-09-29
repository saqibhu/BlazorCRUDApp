using System.ComponentModel.DataAnnotations;

namespace BlazerCRUDApp.Shared.Models {
    public class Person {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}