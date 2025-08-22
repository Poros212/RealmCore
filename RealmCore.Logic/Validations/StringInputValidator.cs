namespace RealmCore.Logic.Validations
{
    public static class StringInputValidator
    {
        private const int MaxLength = 25;

        public static ValidationResultDto<string> CheckStringInput(string? value)
        {
            if (value == null)
            {
                return new ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Input cannot be null."
                };
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return new ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Input cannot be empty or whitespace."
                };
            }
            if (value.Length > MaxLength)
            {
                return new ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = $"Input exceeds maximum length of {MaxLength} characters."
                };
            }
            return new ValidationResultDto<string>
            {
                IsOK = true,
                Value = value
            };
        }

        //public static ValidationResultDto<string> CheckIfInput(bool check)
        //{
        //    if (check)
        //    {
        //        return new ValidationResultDto<string>
        //        {
        //            IsOK = true,
        //            Value = null
        //        };
        //    }
        //}
    }
}