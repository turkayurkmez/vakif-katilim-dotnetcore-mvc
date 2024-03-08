using Microsoft.Extensions.Localization;
using System.Reflection;

namespace BookStore.MVC.Localization
{
    public class SharedResource
    {
    }

    public class LanguageService
    {
        private readonly IStringLocalizer localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(SharedResource), assemblyName.Name);
        }

        public LocalizedString GetKey(string key)
        {
            return localizer[key];
        }
    }
}
