namespace PhotoOrganizer.Mappers;

public static class PhotoMapper {

    public static PhotoDto ToDto(this Photo photo) {

        return new PhotoDto {
            Title = photo.Title,
            Description = photo.Description,
            LocationDescription = photo.LocationDescription,
            TagId = photo.TagId,
            FilePath = photo.FilePath
        };
    }

    public static Photo ToModel(this PhotoDto dto) {

        return new Photo {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            LocationDescription = dto.LocationDescription,
            TagId = dto.Id,
            FilePath = dto.FilePath
        };
    }
}