using Supabase;

namespace PhotoOrganizer.Services;

class SupabaseDataService(Client client) : ISupabaseDataService {


    public async Task<PhotoDto> InsertPhotoAsync(PhotoDto photoDto) {

        var response = await client
             .From<PhotoDto>()
             .Insert(photoDto);

        return response?.Model!;
    }
    public async Task<IEnumerable<PhotoDto>> GetPhotosAsync() {

        var response = await client
            .From<PhotoDto>()
            .Get();

        return response.Models;
    }

    public async Task<IEnumerable<PhotoDto>> GetPhotosByTagAsync(long tagId) {

        var response = await client
            .From<PhotoDto>()
            .Where(photo => photo.TagId == tagId)
            .Get();

        return response.Models;
    }

}