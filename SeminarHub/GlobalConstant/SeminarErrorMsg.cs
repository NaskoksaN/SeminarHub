using static SeminarHub.GlobalConstant.ValidationConst;

namespace SeminarHub.GlobalConstant
{
    public static class SeminarErrorMsg
    {
        public const string RequiredErrorMsg = "{0} is required";

        public const string LengthErrorMsg = "{0} must be between {2} and {1} symbols long";

        public const string ErrorDateFormat = $"must be in format {SeminarDateFormat}";
    }
}
