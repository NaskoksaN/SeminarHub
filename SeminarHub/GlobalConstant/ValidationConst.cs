namespace SeminarHub.GlobalConstant
{
    public static class ValidationConst
    {
        public const string SeminarDateFormat = "dd/MM/yyyy HH:mm";
        public const string RegexDateValidation 
            = "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\\d{4} (?:[01]\\d|2[0-3]):[0-5]\\d$";

        public const int DurationMinRange = 30;
        public const int DurationMaxRange = 180;

        public const int CategoryMinRange = 1;
        public const int CategoryMaxRange = int.MaxValue;

    }
}
