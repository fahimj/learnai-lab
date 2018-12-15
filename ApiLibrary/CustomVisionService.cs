using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiLibrary
{
    public class CustomVisionService
    {
        const string subscriptionKey = "218ab0f6949c4e50af3ad243c9999a75";
        const string uriBase =
            "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/b3f3b85f-81a8-47b6-9248-09b4fd78d295/image?iterationId=8b64f25b-9626-460d-8eda-b1a0645945b7";

        static HttpClient client = new HttpClient();

        public static async Task<CustomImageResponse> AnalyzeImage(string imagePath)
        {
            client.DefaultRequestHeaders.Add("Prediction-Key", subscriptionKey);
            string uri = uriBase;

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

            CustomImageResponse imageResponse = null;
            if (response.IsSuccessStatusCode)
            {
                imageResponse = CustomImageResponse.FromJson(result);
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
