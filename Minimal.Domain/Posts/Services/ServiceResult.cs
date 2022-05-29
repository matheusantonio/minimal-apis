using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Domain.Posts.Services
{
    public record ServiceResult(bool Valid, string Message);
    public record ServiceResult<T>(bool Valid,string Message, T Data);

    public record InvalidResult(string Message) : ServiceResult(false, Message);
    public record ValidResult(string Message) : ServiceResult(true, Message);

    public record InvalidResult<T>(string Message) : ServiceResult<T>(false, Message, default(T));
    public record ValidResult<T>(T Data) : ServiceResult<T>(true, "", Data);
}
