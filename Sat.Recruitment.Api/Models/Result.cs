namespace Sat.Recruitment.Api.Models
{
    public class Result
    {
        public Result(bool isSuccess, string errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; set; }
        public string Errors { get; set; }

    }
}
