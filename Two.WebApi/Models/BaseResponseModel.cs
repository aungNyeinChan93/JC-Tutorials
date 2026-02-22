namespace Two.WebApi.Models
{
    public class BaseResponseModel<T>
    {
        public int ResponseCode { get; set; }

        public string? ResponseDescription { get; set; } 

        public ResponseType ResponseType { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsError { get { return !IsSuccess; } }

        public T? ResponseData { get; set; } 

        public static BaseResponseModel<T> Success(bool status,int code ,string desc,T data)
        {
            var response = new BaseResponseModel<T>()
            {
                IsSuccess = status,
                ResponseCode = code,
                ResponseDescription = desc,
                ResponseType = ResponseType.Success,
                ResponseData = data
            };

            return response;
        }

        public static BaseResponseModel<T> SysTemError(bool status, int code, string desc, T data)
        {
            var response = new BaseResponseModel<T>()
            {
                IsSuccess = status,
                ResponseCode = code,
                ResponseDescription = desc,
                ResponseType = ResponseType.SystemError,
                ResponseData = data
            };

            return response;
        }

        public static BaseResponseModel<T> ValidationError(bool status, int code, string desc, T data )
        {
            var response = new BaseResponseModel<T>()
            {
                IsSuccess = status,
                ResponseCode = code,
                ResponseDescription = desc,
                ResponseType = ResponseType.ValidationError,
                ResponseData = data
            };

            return response;
        }

    }

    public enum ResponseType
    {
        None,
        Success,
        ValidationError,
        SystemError
    }
}
