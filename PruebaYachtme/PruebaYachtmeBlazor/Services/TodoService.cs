using PruebaYachtmeBlazor.Models;
using System.Net.Http.Json;

namespace PruebaYachtmeBlazor.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetTodosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Item>>>("https://localhost:7020/api/Items/GetAll");
            return response?.Result ?? new List<Item>();
        }

        public async Task<bool> AddTodoAsync(AddTodoItem newItem)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Items/AddItem", newItem);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> MarkAsDoneAsync(int id)
        {
            var response = await _httpClient.PutAsJsonAsync("https://localhost:7020/api/Items/Done", id);
            return response.IsSuccessStatusCode;
        }
    }


}


