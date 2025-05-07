using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateBannerCommand
    {
        
        public string Title { get; set; }
        public String Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
