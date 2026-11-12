namespace PhotoOrganizer.Services;

public class DatabaseService : IDataServices {

    private SQLiteAsyncConnection? _db;
    private bool _isInitialized;

    public async Task InitAsync() {
        if(_isInitialized)
            return;

        _db = new SQLiteAsyncConnection(DbPath.DatabasePath, DbPath.Flags);

        await _db.CreateTableAsync<Tag>();
        await _db.CreateTableAsync<Photo>();

        await SeedTagsAsync();

        _isInitialized = true;
    }

    public async Task<IEnumerable<Tag>> GetTagsAsync() {
        if(_db == null) await InitAsync();
        return await _db!.Table<Tag>().ToListAsync();
    }

    public async Task<string?> GetTagNameAsync(int tagId) {
        if(_db == null) await InitAsync();
        var tag = await _db!.Table<Tag>().Where(t => t.Id == tagId).FirstOrDefaultAsync();
        return tag?.Name;
    }

    public async Task SaveTagAsync(Tag tag) {
        if(_db == null) await InitAsync();
        await _db!.InsertAsync(tag);
    }

    public async Task<IEnumerable<Photo>> GetAllPhotosAsync() {
        if(_db == null) await InitAsync();
        return await _db!.Table<Photo>().ToListAsync();
    }

    public async Task SavePhotoAsync(Photo p) {
        if(_db == null) await InitAsync();
        await _db!.InsertAsync(p);
    }

    public async Task<IEnumerable<Tag>> SeedTagsAsync() {
        if(_db == null) await InitAsync();

        var tags = await _db!.Table<Tag>().ToListAsync();

        if(tags.Count > 0)
            return tags;

        //tags =
        //[
        //    new() { Name = "Work", IconGlyph = IconFont.Work },
        //    new() { Name = "Home", IconGlyph = IconFont.Home },
        //    new() { Name = "Personal", IconGlyph = IconFont.Person },
        //    new() { Name = "Study", IconGlyph = IconFont.School },
        //    new() { Name = "All", IconGlyph = IconFont.Notes, isSelected = true },
        //    new() { Name = "New tag", IconGlyph = IconFont.Add }
        //];

        await _db.InsertAllAsync(tags);

        return tags;
    }
}