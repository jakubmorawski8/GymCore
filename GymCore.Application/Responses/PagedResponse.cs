using System;
namespace GymCore.Application.Responses
{
    public class PagedResponse : BaseResponse
    {
        public int TotalCount { get; set; }

        public PagedResponse() : base()
        {
        }
    }
}

