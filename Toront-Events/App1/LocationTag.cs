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
        public String name, info;
        public Location location;

        public LocationTag(String name, double longitude, double latitude, String info)
        {
            this.name = name;
            this.location = new Location(longitude, latitude);
            this.info = info;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
