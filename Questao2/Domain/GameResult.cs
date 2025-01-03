using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Domain
{
    public class GameResult
    {
        public string? competition {  get; set; }
        public int year { get; set; }
        public string? round {  get; set; }
        public string? team1 { get; set; }
        public string? team2 { get; set; }
        public int team1goals { get; set; }
        public int team2goals { get; set; }
    }
}
