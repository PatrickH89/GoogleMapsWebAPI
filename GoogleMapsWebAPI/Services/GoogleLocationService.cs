using GoogleMapsWebAPI.Models.Configuration;
using GoogleMapsWebAPI.Interfaces;
using GoogleMapsWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleMapsWebAPI.Services
{
    public class GoogleLocationService : IGoogleLocationService
    {
        //------------------------------------------------------------------
        // config + http-client
        GoogleConfiguration Config { get; }

        private readonly HttpClient _client;

        //------------------------------------------------------------------
        // gate to the outside -> will be called in Send method -> contains with _client the BaseAddress of Config.ApiUrl
        public GoogleLocationService(HttpClient httpClient, GoogleConfiguration googleConfiguration)
        {
            Config = googleConfiguration;
            httpClient.BaseAddress = new Uri(Config.ApiUrl);
            _client = httpClient;
        }

        //------------------------------------------------------------------
        // get longitude and latitude by Geocoding API
        public async Task<CoordinatesModel> GetLocation(AddressInputModel address)
        {
            if(address == null)
            {
                //logger
                return null;
            }
            string requestQuery = BuildRequestQuery(address); // method 1
            GeoCodeModel geoCodeModel = await Send(requestQuery); // method 2
            return BuildCoordinatesModel(geoCodeModel);  // method 3
        }

        //------------------------------------------------------------------
        // method 1: create a dynamic url for GeoCoding API
        private string BuildRequestQuery(AddressInputModel address)
        {
            return $"?address={address.Country}+{address.PostCode}+{address.City}+{address.Street}+{address.StreetNumber}&key={Config.ApiKey}"; 
        }

        //------------------------------------------------------------------
        // method 2: send requestQuery to GeoCoding API and wait for successful response which you deserialize as GeocodeModel object and return it
        private async Task<GeoCodeModel> Send(string requestQuery)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestQuery);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GeoCodeModel>(content);
                }
                return null;
                //logger
            }
            catch (Exception)
            {
                return null;
            }
        }

        //------------------------------------------------------------------
        // method 3: put longitude and latitude in CoordinatesModel object and return it
        private CoordinatesModel BuildCoordinatesModel(GeoCodeModel geoCodeModel)
        {
            if (geoCodeModel?.results[0]?.geometry?.location?.lat == null || geoCodeModel?.results[0]?.geometry?.location?.lng == null) 
            {
                return null; 
            }
            return new CoordinatesModel() 
            {
                Latitude = geoCodeModel.results[0].geometry?.location?.lat ?? 0,
                Longitude = geoCodeModel.results[0].geometry?.location?.lng ?? 0
            };
        }
    }
}
