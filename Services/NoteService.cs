using Frontend_MVC_00013940.Models;
using System.Text.Json;

namespace Frontend_MVC_00013940.Services
{
    public class NoteService
    {
        private readonly HttpClient _httpClient;

        public NoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            try
            {
                var notes = await _httpClient.GetFromJsonAsync<IEnumerable<Note>>("notes");
                return notes ?? new List<Note>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                return new List<Note>();
            }
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Note>($"notes/{id}");
        }

        public async Task CreateNoteAsync(Note note)
        {
            await _httpClient.PostAsJsonAsync("notes", note);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            await _httpClient.PutAsJsonAsync($"notes/{note.Id}", note);
        }

        public async Task DeleteNoteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"notes/{id}");
            response.EnsureSuccessStatusCode();
        }

        // New method to fetch tags
        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            try
            {
                var tags = await _httpClient.GetFromJsonAsync<IEnumerable<Tag>>("tags");
                return tags ?? new List<Tag>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                return new List<Tag>();
            }
        }
    }
}
