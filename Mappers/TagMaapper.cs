namespace PhotoOrganizer.Mappers;

public static class TagMaapper {

    public static Tag ToModel(this TagDto dto) {

        return new Tag {
            Id = dto.Id,
            Name = dto.Name,
            Color = dto.Color
        };
    }
}
