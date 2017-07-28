using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldComponent
{
    public class HelloWorldData
    {
        public HelloWorldData(string name)
        {
            this.Name = name;
        }

        public String Name { get; set; }

        public String getName()
        {
            return this.Name;
        }
    }
}
