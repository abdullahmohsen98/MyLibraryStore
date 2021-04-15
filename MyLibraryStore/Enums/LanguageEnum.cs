﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Arabic language")]
        Hindi = 10,
        [Display(Name = "English language")]
        English = 11,
        [Display(Name = "German language")]
        German = 12,
        [Display(Name = "Chinese language")]
        Chinese = 13,
        [Display(Name = "Turkish language")]
        Urdu =  14
    }
}
