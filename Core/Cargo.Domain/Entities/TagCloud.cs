﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int  BlogID  { get; set; }
        public Blog Blog  { get; set; }
    }
}
