using ipma_weather_service.Models;
using System;
using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase() 
        { }

        public virtual bool ValidateUrl(string url) 
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
           
        protected abstract string GetUrlForOneCity(int city);

        protected abstract string GetUrlForAllCities();

    }
}