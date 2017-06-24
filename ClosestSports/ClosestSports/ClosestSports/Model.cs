using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

// ZipCodeAPI key: R30l6zlw02utKOfmJSgpwJk6wLOAowngzoCFXXcX0GrLuG7ezoE57YcDK1e9xCq7
namespace ClosestSports
{
    public class Model
    {
        private List<String> sports;
        private String ZipCode;
        private double radius;
        private String radiusUnits;
        private readonly String ZIP_CODE_API_KEY = "R30l6zlw02utKOfmJSgpwJk6wLOAowngzoCFXXcX0GrLuG7ezoE57YcDK1e9xCq7";

        public Model(List<String> sports, String address, double radius, String radiusUnits)
        {
            this.sports = sports;
            setAddress(address);
            this.radius = radius;
            this.radiusUnits = radiusUnits;
        }

        public void setAddress(String address)
        {
            MatchCollection mc = Regex.Matches(address,"[0-9]{5}(-[0-9]{4})?");
            foreach(Match m in mc)
            {
                ZipCode = m.ToString();
            }
            //TODO: Some Regex or something to grab the zip code and set this.zipCode
        }

        public void getSurroundingZipCodesBasedOnRadiusAsync()
        {
            string url = "https://www.zipcodeapi.com/rest/"
                          + ZIP_CODE_API_KEY + "/radius.json/" +
                          ZipCode + "/" + radius.ToString() + "/" + radiusUnits + "?minimal";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());
                Console.WriteLine(json);
            }
        }

        override public string ToString()
        {
            return "{" + sports.ToString() + "," + ZipCode.ToString() + "," + radius.ToString() + "," + radiusUnits + "}";
        }

    }

}
