using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Улица</summary>
    public class Street
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название улицы не может быть пустым.")]
        [StringLength(100, ErrorMessage = "Название улицы не может содержать более 100 символов.")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        public List<House> Houses { get; set; }
    }
}
