using Newtonsoft.Json;
using ExamenProg3JuanMino.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ExamenProg3JuanMino.Services
{
    public class ImageGenerator
    {
        public async Task<responseModel> GenerateImage(input input)
        {
            responseModel resp = new responseModel();
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", "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");

                var Message = await client.PostAsync("https://api.openai.com/v1/images/generations",
                    new StringContent(JsonConvert.SerializeObject(input),
                    Encoding.UTF8, "application/json"));

                if (Message.IsSuccessStatusCode)
                {
                    var content = await Message.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<responseModel>(content);
                }
            }

            return resp;
        }
    }
}
