using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Common.DTOs
{
    public record ClickModel(string PageType, int Id);
    public record ClickModelReferens<TDto>(string PageType, TDto dto);
}
