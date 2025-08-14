namespace RealmCore.Logic.Validations
{
    public sealed record ValidationResultDto<T>
    {
        public bool IsOK { get; init; }
        public string? ErrorMessage { get; init; }
        public T? Value { get; init; }
    }  

}