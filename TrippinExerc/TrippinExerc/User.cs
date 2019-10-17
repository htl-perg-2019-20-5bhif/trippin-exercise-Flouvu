using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrippinExerc
{
    public class User
    {

        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("CityName")]
        public string CityName { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

    }

    public class NewUser
    {

        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Emails")]
        public IEnumerable<string> Emails { get; set; }

        [JsonPropertyName("AddressInfo")]
        public IEnumerable<AddressInfo> AddressInfo { get; set; }

        public NewUser(User user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Emails = new List<string>() { user.Email };

            this.AddressInfo = new List<AddressInfo>(){ new AddressInfo(user.Address, new City(user.CityName, user.Country, "")) };
        }

    }

    public class AddressInfo
    {

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("City")]
        public City City { get; set; }

        public AddressInfo(string Address, City City)
        {
            this.Address = Address;
            this.City = City;
        }

    }

    public class City
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("CountryRegion")]
        public string CountryRegion { get; set; }

        [JsonPropertyName("Region")]
        public string Region { get; set; }

        public City(string Name, string CountryRegion, string Region)
        {
            this.Name = Name;
            this.CountryRegion = CountryRegion;
            this.Region = Region;
        }

    }
}