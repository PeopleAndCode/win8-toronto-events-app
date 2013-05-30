using Bing.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{

    public class LocationTag
    {
        public String name, description, address, phoneNumber;
        public Location location;

        public LocationTag()
        {
            name = "unavailable";
            description = "unavailable";
            address = "somewhere over the rainbow";
            phoneNumber = "not yours";
            location = null;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
