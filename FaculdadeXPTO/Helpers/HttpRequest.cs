using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FaculdadeXPTO.Helpers
{
    public class HttpRequest
    {
        public T Get<T>(string requestUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    var response = client.GetAsync(requestUrl).Result.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(response);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        //public string Get(string requestUrl, string token)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Add("X-Token", token);

        //            if (requestUrl.ToLower().Contains("https"))
        //                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        //            var response = client.GetAsync(requestUrl).Result;

        //            return response.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //}

        public T Get<T>(string requestUrl, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Token", token);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    client.Timeout = TimeSpan.FromMilliseconds(480000);

                    var response = client.GetAsync(requestUrl).Result.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(response);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetAsync(string requestUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    var response = await client.GetAsync(requestUrl);

                    var content = response.Content;

                    return content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetAsync(string requestUrl, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Token", token);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    var response = await client.GetAsync(requestUrl);

                    var content = response.Content;

                    return content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }

        public T Post<T>(string requestUrl, string token, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", token);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


                    string SerializedModel = JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(480000);

                    //var JsonResponse = httpClient.PostAsync(requestUrl, httpContent).Result.Content.ReadAsStringAsync().Result;

                    var JsonResponse = Task.Run(() => httpClient.PostAsync(requestUrl, httpContent).Result.Content.ReadAsStringAsync().Result).Result;

                    //Task.Run(() => Client.PostAsync()).Result;

                    var Response = JsonConvert.DeserializeObject<T>(JsonResponse);

                    return Response;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<T> PostAsync<T>(string requestUrl, string token, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", token);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


                    string SerializedModel = JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    var JsonResponse = await httpClient.PostAsync(requestUrl, httpContent);
                    var jsonString = await JsonResponse.Content.ReadAsStringAsync();

                    var Response = JsonConvert.DeserializeObject<T>(jsonString);

                    return Response;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public void Post(string requestUrl, string token, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", token);
                    httpClient.Timeout = TimeSpan.FromMilliseconds(480000);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


                    string SerializedModel = JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    var JsonResponse = httpClient.PostAsync(requestUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public T Post<T>(string requestUrl, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    httpClient.Timeout = TimeSpan.FromMilliseconds(480000);

                    string SerializedModel = Newtonsoft.Json.JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync(requestUrl, httpContent).Result;

                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public string Post(string requestUrl, List<KeyValuePair<string, string>> ParameterPairs)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    httpClient.Timeout = TimeSpan.FromMilliseconds(480000);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    //FINISH IMPLEMENTING POST

                    var httpcontent = new FormUrlEncodedContent(ParameterPairs);

                    HttpResponseMessage response = httpClient.PostAsync(requestUrl, httpcontent).Result;

                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                //TODO: MAKE A LOG FUNCTIONALITY
                return ex.Message;
            }
        }

        public T Delete<T>(string requestUrl, string Token)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", Token);

                    HttpResponseMessage response = httpClient.DeleteAsync(requestUrl).Result;

                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


        public void Delete(string requestUrl, string Token)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", Token);

                    httpClient.DeleteAsync(requestUrl);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public T Put<T>(string requestUrl, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    string SerializedModel = JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PutAsync(requestUrl, httpContent).Result;

                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public T Put<T>(string requestUrl, string token, object DeserializedModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("X-Token", token);

                    if (requestUrl.ToLower().Contains("https"))
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    string SerializedModel = JsonConvert.SerializeObject(DeserializedModel);

                    HttpContent httpContent = new StringContent(SerializedModel, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PutAsync(requestUrl, httpContent).Result;

                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}