namespace Talapate.APi.Error
{
    public class ApiExcaptionResponse : ApiResponse
    {
        public string? Detailes { get; set; }

        public ApiExcaptionResponse(int statuscode, string massege=null, string detailes=null ):base(statuscode,massege)
        {
            Detailes = detailes;
             
        }
    }
}
