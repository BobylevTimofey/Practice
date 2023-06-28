namespace Practice.Interfaces
{
    public interface IValidator<T>
    {
        public string? ErrorMessage { get; set; }
        public bool Validate(T value);
    }
}
