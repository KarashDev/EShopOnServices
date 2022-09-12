using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WpfApp1
{
    public interface IQueryServiceClient
    {
        void GetData();
    }

    public class QueryServiceClient : IQueryServiceClient
    {
        HttpClient client;

        public QueryServiceClient(HttpClient client)
        {
            this.client = client;
        }

        public void GetData()
        {
            // Начало запроса (client.BaseAddress) автоматически присоединяется к остальной строке запроса
            var response = client.GetAsync($"api/Catalog/get_catalog").Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            //// BuffetException - логическая ошибка; Exception - серверная ошибка 
            //if (response.IsSuccessStatusCode)
            //{
            //    return JsonConvert.DeserializeObject<List<CategoryProd>>(responseString);
            //}
            //else if (response.StatusCode == HttpStatusCode.BadRequest)
            //{
            //    var error = JsonConvert.DeserializeObject<ErrorModel>(responseString);
            //    throw new BuffetException(error.Message);
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(responseString))
            //    {
            //        var error = JsonConvert.DeserializeObject<ErrorModel>(responseString);
            //        logger.Error("", error.Message);
            //        throw new Exception(error.Message);
            //    }
            //    else throw new Exception("Ошибка авторизации (ошибка с пустым телом)");
            //}
        }
    }


}
