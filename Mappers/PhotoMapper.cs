using PhotoOrganizer.Models.Dtos;

namespace PhotoOrganizer.Mappers;

public static class PhotoMapper {

    public static PhotoDto ToDto(this Photo photo) {

        return new PhotoDto {
            Title = photo.Title,
            Description = photo.Description,
            LocationDescription = photo.LocationDescription,
            TagId = photo.TagId,
            DeviceId = photo.DeviceId,
            filePath = photo.FilePath
        };
    }

    public static Photo ToModel(this PhotoDto dto) {

        return new Photo {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            LocationDescription = dto.LocationDescription,
            TagId = dto.TagId,
            DeviceId = dto.DeviceId,
            FilePath = dto.filePath
        };
    }
}