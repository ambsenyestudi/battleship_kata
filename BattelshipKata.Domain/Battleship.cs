using System;

namespace BattelshipKata.Domain
{
    public class Battelship
    {
        public int Size { get; set; }
        public Battelship(int size = 10)
        {
            this.Size = size;
        }
    }
}
