using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloVirus1
{
    class Terminator : Operation
    {
        public override void execute(Dictionary<string, string> arguments)
        {
            TerminatorService.add(arguments["program"]);
        }
    }
}
