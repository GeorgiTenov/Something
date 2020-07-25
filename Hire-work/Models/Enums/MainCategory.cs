using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models.Enums
{
    public enum MainCategory
    {
        [Display(Name ="Строителство")]
        Construction,

        [Display(Name = "Дизайн")]
        Design,

        [Display(Name ="IT Developers")]
        ITSpecialists,

        [Display(Name ="Фотография")]
        Photographers,

        [Display(Name ="Музика")]
        Music,

        [Display(Name ="Актьорско майсторство")]
        Actors,

        [Display(Name = "Други")]
        Others
    }
}
