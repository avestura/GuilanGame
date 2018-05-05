using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuilanGame.Models
{

    public enum StudentFiled
    {
        Computer, Electrics, WaterEngineering, CivilEngineering, Mechanics, Medical, Textile, Humanitism, BaseScience, Other
    }

    public class RecordItem
    {
        public int    Rank { get; set; }
        public string Name { get; set; }
        public int    Score { get; set; }
        public StudentFiled StudentFiled { get; set;}
    }
}
