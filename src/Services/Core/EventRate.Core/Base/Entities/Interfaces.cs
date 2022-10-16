namespace EventRate.Core.Base.Entities
{

    public interface IHardDelete { }

    /// <summary>
    /// IUniqueEmail interface ile işaretlediğimiz modelimizde Email alanı olmasını zorluyor ve bu alanı unique tutmamız gerektiğini anlıyoruz.
    /// </summary>
    public interface IUniqueEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    /// <summary>
    /// IUniqueName interface ile işaretlediğimiz modelimizde Name alanı olmasını zorluyor ve bu alanı unique tutmamız gerektiğini anlıyoruz.
    /// </summary>
    public interface IUniqueName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// IFile interface ile işaretlediğimiz modelimizde Dosya ile ilgili alanların olmasını zorluyoruz ve burada bir dosya işlemi olduğunu anlıyoruz.
    /// </summary>
    public interface IFile
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
    }
}
