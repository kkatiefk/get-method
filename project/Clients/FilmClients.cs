using Newtonsoft.Json;
using project.Model;

namespace project.Clients
{
    public class FilmClients
    {
        private static string _address;
        private static string _apikey;
        private static string _apiHost;

        public FilmClients()
        {
            _address = Constants.Address;
            _apikey = Constants.ApiKey;
            _apiHost = Constants.ApiHost;
        }
        //public async Task<Find> GetFilmDetails(string filmName)
        //{

        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(_address),
        //        Headers =
        //    {
        //        { "X-RapidAPI-Key", _apikey },
        //        { "X-RapidAPI-Host", _apiHost},
        //    },
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();

        //        var result = JsonConvert.DeserializeObject<Find>(body);
        //        return result;

        //    }
        //}
        public async Task<Find> GetFilmDetails(string filmName)
        {
            var client = new HttpClient();
            var requestUri = $"{_address}&query={filmName}"; 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
        {
            { "X-RapidAPI-Key", _apikey },
            { "X-RapidAPI-Host", _apiHost},
        },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Find>(body);
                return result;
            }
        }
    }
}
