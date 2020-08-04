using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MusicWebAPIClient
{

    class Song
    {
        public string lyrics {get; set;}

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            //take song from user
            Console.WriteLine("Enter a song");
            var title = Console.ReadLine();

            //take artist from user
            Console.WriteLine("Enter an artist");
            var artist = Console.ReadLine();
 
            //http client object that can make calls to an API endpoint
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            //adding the ability to accept json headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var req = await client.GetStreamAsync($"https://api.lyrics.ovh/v1/{artist}/{title}");
            var song = await JsonSerializer.DeserializeAsync<Song>(req);

            Console.WriteLine(song.lyrics);
        }
    }
}
