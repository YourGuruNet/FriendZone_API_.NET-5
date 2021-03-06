namespace Application.Core
{
    public class Result<Activity>
    {
        public bool IsSuccess { get; set; }

        public Activity Value { get; set; }

        public string Error { get; set; }

        // Cheking activity value
        public static Result<Activity> Success(Activity value) => new Result<Activity> { IsSuccess = true, Value = value };
        // Checking if not error
        public static Result<Activity> Failure(string error) => new Result<Activity> { IsSuccess = false, Error = error };
    }
}