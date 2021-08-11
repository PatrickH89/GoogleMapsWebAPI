using GoogleMapsWebApi.Models.Configuration;
using GoogleMapsWebAPI.Interfaces;
using GoogleMapsWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleMapsApi.Services
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

        public async Task<CoordinatesModel> GetLocation(AddressInputModel address) // Ich speichere die Dateneingabe vom HTML-Body von Postman in einem Paramater-Objekt address. Dieses Objekt ist moddelliert nach der Klasse AddressPostModel.
        {
            if(address == null)
            {
                //logger
                return null;
            }
            string requestQuery = BuildRequestQuery(address); // Dynamische Url für google api basteln und im String requestQuery speichern
            GeoCodeModel geoCodeModel = await Send(requestQuery); // Dynamische Url senden und die Rückgabe der json-Datei als Object mit dem Namen geCodeModel speichern
            return BuildCoordinatesModel(geoCodeModel); // Nimm das Objekt vom GeoCodeModel prüfe ob null und wenn nicht nimm Länge und Breite und speichere es als Objekt der Klasse CoordinatesModel als Rückgabewert
        }

        //------------------------------------------------------------------
        // Methode: Mit der Klasse AddressPostModel die dynamische Url basteln

        private string BuildRequestQuery(AddressInputModel address)
        {
            return $"?address={address.Country}+{address.PostCode}+{address.City}+{address.Street}+{address.StreetNumber}&key={Config.ApiKey}"; 
        }

        //------------------------------------------------------------------
        // Nimm den String requestQuery und sende ihn an die google api, wenn der response geklappt hat, speicher diese json als String in content, dann modelliere aus dem String ein Objekt der Klasse GeoCodeModel und gib es aus.

        private async Task<GeoCodeModel> Send(string requestQuery) // Was macht das?
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestQuery); // Hier wird _client und requestQuery zusammengeführt und aufgerufen
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GeoCodeModel>(content);
                }
                //logger
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        //------------------------------------------------------------------
        // Methode: Nimm das Objekt geoCodeModel und prüfe:
        /// Wenn Längen- und Breitengrad nicht null sind in der json Datei von der google api, dann erstelle mir ein Objekt der Klasse CoordinatesModel und füge Länge und Breite von der json ein

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
