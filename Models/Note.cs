﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotooo.Models
{
    public class Note
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }    
        
        public string ContentUrl { get; set; }
    }

}
