public class Directory
{
    public string Name { get; set; }
    public List<Directory> Directories { get; set; }
    public List<File> Files { get; set; }
    public Directory ParentDirectory { get; set; }
    public long Size { get; set; }

    public Directory(string name, Directory parentDirectory)
    {
        this.Name = name;
        this.Directories = new List<Directory>();
        this.Files = new List<File>();
        this.ParentDirectory = parentDirectory;
        this.Size = 0;
    }

    public void IncreaseSize(long size) 
    {
        this.Size += size;
        if (this.ParentDirectory != null)
            this.ParentDirectory.IncreaseSize(this.Size);
    }
}