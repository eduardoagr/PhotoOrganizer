namespace PhotoOrganizer.Services {
    //class SupabaseDataService(Client client) : ISupabaseDataService {
    //    public async Task<IReadOnlyList<PhotoDto>> GetAllPhotosAsync() {

    //        var user = await userService.GetCurrentUserAsync();

    //        var response = await client
    //            .From<PhotoDto>()
    //            .Where(p => p.DeviceId == user.DeviceId)
    //            .Get();

    //        return response.Models;
    //    }


    //    public Task<PhotoDto?> GetPhotoByIdAsync(long id) {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<IReadOnlyList<PhotoDto>> GetPhotosByTagAsync(int tagId) {
    //        var response = await client
    //            .From<PhotoDto>()
    //            .Where(p => p.TagId == tagId)
    //            .Get();

    //        return response.Models;
    //    }

    //    public async Task<PhotoDto> InsertPhotoAsync(PhotoDto dto) {
    //        var response = await client.From<PhotoDto>().Insert(dto);
    //        return response?.Models?.FirstOrDefault()!;

    //    }

    //    public async Task<TagDto> InsertTagAsync(TagDto tagDto) {
    //        var response = await client.From<TagDto>().Insert(tagDto);

    //        return response?.Models?.FirstOrDefault()!;
    //    }

    //    public async Task<IReadOnlyList<TagDto>> UploadInitialTagsAsync(IUserService userService) {

    //        var user = await userService.GetCurrentUserAsync();

    //        var existing = await GetAllTagsAsync(user.Id);

    //        foreach(var tag in InitialTagsService.InitialTags) {

    //            if(existing.Any(x => x.TagName == tag.TagName))
    //                continue;

    //            var dto = new TagDto {
    //                TagName = tag.TagName,
    //                Color = tag.Color,
    //                UserId = user.Id,
    //                CreatedAt = DateTime.UtcNow
    //            };

    //            await InsertTagAsync(dto);
    //        }

    //        return await GetAllTagsAsync(user.Id);
    //    }

    //    public async Task<IReadOnlyList<TagDto>> GetAllTagsAsync() {
    //        var response = await client
    //            .From<TagDto>()
    //            .Select("*")
    //            .Get();

    //        return response.Models;
    //    }

    //    public async Task<IReadOnlyList<TagDto>> GetAllTagsAsync(Guid userId) {

    //        var response = await client
    //            .From<TagDto>()
    //            .Select("*")
    //            .Filter("user_id", Operator.Equals, userId.ToString())
    //            .Get();

    //        return response.Models;
    //    }
    //}
}
