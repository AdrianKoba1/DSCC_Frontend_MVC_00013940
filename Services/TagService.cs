using Frontend_MVC_00013940.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class TagService
{
    private readonly HttpClient _httpClient;

    public TagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Tag>> GetTagsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Tag>>("tags");
    }

    public async Task<Tag> GetTagByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Tag>($"tags/{id}");
    }

    public async Task CreateTagAsync(Tag tag)
    {
        await _httpClient.PostAsJsonAsync("tags", tag);
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        await _httpClient.PutAsJsonAsync($"tags/{tag.Id}", tag);
    }

    public async Task DeleteTagAsync(int id)
    {
        await _httpClient.DeleteAsync($"tags/{id}");
    }
}
