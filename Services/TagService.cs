using Supabase.Postgrest;

using Client = Supabase.Client;

namespace PhotoOrganizer.Services;

public class TagService(Client client, IShellService shellService) : ITagService {

    public async Task<Tag> CreateTagAsync(string name, string color) {

        var userId = client.Auth.CurrentUser?.Id;

        if(userId is null)
            await shellService.DisplayAlertAsync("Error", "User not logged in. Please log in to create a tag.", "OK");

        var dto = new TagDto {
            UserId = Guid.Parse(userId!),
            Name = name,
            Color = color,
            CreatedAt = DateTime.UtcNow
        };

        var response = await client
            .From<TagDto>()
            .Insert(dto, new QueryOptions {
                Returning = QueryOptions.ReturnType.Representation
            });

        var inserted = response.Models.First();

        return new Tag {
            Id = inserted.Id,
            Name = inserted.Name,
            Color = inserted.Color
        };
    }

    public async Task<IEnumerable<Tag>> GetTagsAsync() {

        var response = await client
            .From<TagDto>()
            .Get();

        return response.Models.Select(dto => new Tag {
            Id = dto.Id,
            Name = dto.Name,
            Color = dto.Color
        });
    }
}
