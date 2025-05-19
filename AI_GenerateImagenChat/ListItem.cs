using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GenerateImagenChat
{
    public class ListItem
    {
        public string SessionID { get; set; }
        public string FirstQuestion { get; set; }

        public override string ToString()
        {
            return FirstQuestion;
        }

    }
}
