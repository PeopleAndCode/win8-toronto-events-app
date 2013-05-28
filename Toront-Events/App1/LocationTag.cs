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
        public String eventName, area, presentedByOrgName, image, dateBeginShow, timeBegin, dateEndShow, timeEnd, admissionFee, longDesc, 
            orgContactPhone, locationName, mapAddress, ttc, eventURL, orgContactEmail, accessibleFully, parkingFee, publicWashrooms, accessiblePartially,
            parkingPaid, foodBeverage, shopping, exhibit, performance, kidFriendly, history, green, newThisYear, reservations, officialGreenSite, 
            bikeRacks, roadClose, organicFood;
        public String[] categoryList;
        public Location location;

        public LocationTag()
        {
            eventName = "unavailable";
            area = "unavailable";
            presentedByOrgName = "unknown";
            image = "unavailable";
            dateBeginShow = "TBA";
            timeBegin = "TBA";
            dateEndShow = "TBA";
            timeEnd = "TBA";
            admissionFee = "unavailable";
            longDesc = "No further description available.";
            orgContactPhone = "unavailable";
            locationName = "unknown";
            mapAddress = "unavailable";
            ttc = "unavailable";
            eventURL = "unavailable";
            orgContactEmail = "unavailable";
            accessibleFully = "unknown";
            parkingFee = "unknown";
            publicWashrooms = "Number and locations unknown";
            accessiblePartially = "unknown";
            parkingPaid = "not sure";
            foodBeverage = "unsure";
            shopping = "unsure";
            exhibit = "unknown";
            performance = "unknown";
            kidFriendly = "unknown";
            history = "Not available at this moment.";
            green = "unsure";
            newThisYear = "unknown";
            reservations = "unavailable";
            officialGreenSite = "unsure";
            bikeRacks = "unsure";
            roadClose = "unsure";
            organicFood = "unsure";
        }

        public override String ToString()
        {
            return eventName;
        }
    }
}
