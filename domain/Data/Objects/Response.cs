using cm.backend.domain.Data.Enums;

namespace cm.backend.domain.Data.Objects
{
    public class Response
    {
        public Response()
        {
            ResultCode = ResultCodes.Success;
            Message = "Success";
            Item = null;
        }

        public ResultCodes ResultCode { get; set; }

        public string Message { get; set; }

        public object Item { get; set; }
    }
}
