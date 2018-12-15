using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiLibrary
{
    public class VisionService
    {
        const string subscriptionKey = "7946bfa1f1fc4d17b2b0b2a7962e05ac";
        const string uriBase =
            "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze?";

        static HttpClient client = new HttpClient();

        public static async Task<AnalyzeImageResponse> AnalyzeImage(string imagePath)
        {
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            string requestParameters = "visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";
            string uri = uriBase + "&" + requestParameters;

            HttpResponseMessage response;
            byte[] byteData = GetImageAsByteArray(imagePath);
            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json"
                // and "multipart/form-data".
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                // Make the REST API call.
                response = await client.PostAsync(uri, content);
            }

            // Get the JSON response.
            var result = await response.Content.ReadAsStringAsync();

            AnalyzeImageResponse imageResponse = null;
            if (response.IsSuccessStatusCode)
            {
                imageResponse = AnalyzeImageResponse.FromJson(result);
            }
            return imageResponse;

        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
