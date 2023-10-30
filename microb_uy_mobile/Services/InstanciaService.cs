using microb_uy_mobile.DTOs;
using microb_uy_mobile.Helpers;
using Refit;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace microb_uy_mobile.Services
{
    public class InstanciaService
    {
        //private HttpClient client;
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:44384";
        public static string API = $"{BaseAddress}/api/tenants";

        public InstanciaService()
        {
            //#if DEBUG
            //    HttpsClientHandlerService handler = new HttpsClientHandlerService();
            //    HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
            //#else
            //    this.client = new HttpClient();
            //#endif
        }

        //async Task<List<DefaultReponseDTO>> IInstanciaService.GetInstanciasAsync()
        //{
        //    var api = RestService.For<IInstanciaService>("https://localhost:44384");
        //    var todos = await api.GetInstanciasAsync();
        //    return todos;
        //}

        //public async Task<List<InstanciaDTO>> GetInstanciasAsync()
        //{
        //    #if DEBUG
        //        HttpsClientHandlerService handler = new HttpsClientHandlerService();
        //        HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
        //    #else
        //        client = new HttpClient();
        //    #endif

        //    List<InstanciaDTO> Instancias = new List<InstanciaDTO>();

        //    Uri uri = new Uri(API);
        //    try
        //    {
        //        HttpResponseMessage response = await client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            Instancias = JsonSerializer.Deserialize<List<InstanciaDTO>>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }

        //    return Instancias;
        //}

        public async Task<List<InstanciaDTO>> GetInstanciasAsyncOLD()
        {
            try
            {
#if DEBUG
                //HttpsClientHandlerService handler = new HttpsClientHandlerService();
                //HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
                HttpClient client = new HttpClient();
#else
                    client = new HttpClient();
#endif
                //client.GetFromJsonAsync
                DefaultReponseDTO response = await client.GetFromJsonAsync<DefaultReponseDTO>(API);
                Console.WriteLine("catch llamada api");
                //var responseBody = await response.Content.ReadAsStringAsync();
                //JsonNode nodos = JsonNode.Parse(responseBody);
                //JsonNode results = nodos["response"];
                //var instancias = JsonSerializer.Deserialize<List<InstanciaDTO>>(results.ToString());
                //q instancias;

                //string apiUrl = "https://localhost:44384/api/tenants";
                //var response = await client.GetStringAsync(apiUrl);
                //if (!string.IsNullOrEmpty(response))
                //{
                //    return JsonSerializer.Deserialize<List<InstanciaDTO>>(response);
                //}
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("catch llamada api");
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
