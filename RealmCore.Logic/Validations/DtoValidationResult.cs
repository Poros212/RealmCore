namespace RealmCore.Logic.Validations
{
    public sealed record DtoValidationResult<T>
    {
        public bool IsOK { get; init; }
        public string? ErrorMessage { get; init; }
        public T? Value { get; init; }
    }
}