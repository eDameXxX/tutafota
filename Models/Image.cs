using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotooo.Models
{
    public class Image
    {
        public string ImageUrl { get; set; }

        private Note note;

        public Note GetNote()
        {
            return note;
        }

        public void SetNote(Note value)
        {
            note = value;
        }
    }
}
