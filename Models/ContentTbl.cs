using System;
using System.Collections.Generic;

namespace PublisherSubscriber.Models
{
    public partial class ContentTbl
    {
        public int ContentId { get; set; }
        public string? ContentType { get; set; }
        public string? ContentName { get; set; }
        public string? PersonName { get; set; }
        public string? PersonGender { get; set; }
        public string? PersonCity { get; set; }
        public string? PersonQualification { get; set; }
        public string? Subscribe { get; set; }
        public string? UnSubscribe { get; set; }
    }
}
