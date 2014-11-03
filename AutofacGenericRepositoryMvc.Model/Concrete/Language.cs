using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Abstract;
using Newtonsoft.Json;

namespace AutofacGenericRepositoryMvc.Model.Concrete
{
    public class Language : Entity<int>
    {
        public Language()
        {
            Persons = new List<Person>();
        }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Language Name")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
