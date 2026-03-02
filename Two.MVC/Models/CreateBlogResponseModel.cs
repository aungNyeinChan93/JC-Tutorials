namespace Two.MVC.Models
{
    public class CreateBlogResponseModel
    {
        public CreateBlogResponseModel() { } 

        public CreateBlogResponseModel(bool isSuccess, string message)
        {
            this.isSuccess = isSuccess;
            this.message = message;
        }

        public bool isSuccess { get; set; }

        public string message { get; set; }

         
    }

    public class CreateBlogResponseModel<T>
    {
        public CreateBlogResponseModel() { }

        public CreateBlogResponseModel(bool isSuccess, string message, T? data  )
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.data = data;
        }

        public bool isSuccess { get; set; }

        public string message { get; set; }

        public T? data { get; set; }

    }
}
