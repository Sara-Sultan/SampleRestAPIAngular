using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Application.IServices
{
    public interface IServiceManager
    {
        IDriverService DriverService { get; }
    }
}
