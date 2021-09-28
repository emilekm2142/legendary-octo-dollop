using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;

namespace tagi
{
    public class TagDataRequestResponse
    {
        public List<TagData> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }
}