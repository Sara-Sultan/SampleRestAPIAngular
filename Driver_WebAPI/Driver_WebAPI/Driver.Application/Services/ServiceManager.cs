using Driver.Application.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDriverService> _lazyDriverService;

        public ServiceManager()
        {
            _lazyDriverService = new Lazy<IDriverService>(() => new DriverService());
        }

        public IDriverService DriverService => _lazyDriverService.Value;

    }
}
