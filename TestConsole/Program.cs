// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Начало запроса (client.BaseAddress) автоматически присоединяется к остальной строке запроса
var response = client.GetAsync($"api/Buffet/get_prod_categories/{vendor}").Result;
var responseString = response.Content.ReadAsStringAsync().Result;

// BuffetException - логическая ошибка; Exception - серверная ошибка 
if (response.IsSuccessStatusCode)
{
    return JsonConvert.DeserializeObject<List<CategoryProd>>(responseString);
}
else if (response.StatusCode == HttpStatusCode.BadRequest)
{
    var error = JsonConvert.DeserializeObject<ErrorModel>(responseString);
    throw new BuffetException(error.Message);
}
else
{
    if (!string.IsNullOrEmpty(responseString))
    {
        var error = JsonConvert.DeserializeObject<ErrorModel>(responseString);
        logger.Error("", error.Message);
        throw new Exception(error.Message);
    }
    else throw new Exception("Ошибка авторизации (ошибка с пустым телом)");
}
