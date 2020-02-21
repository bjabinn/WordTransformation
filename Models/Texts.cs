
using System.Collections.Generic;

namespace WordTransformation.Models
{
    public class Texts
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<WordGap> Words { get; set; }
    }
}
