using Microsoft.Extensions.Localization;

namespace TemplateFw.Resources
{
    public interface ISharedResource
    {
    }

    public class SharedResource
    {
        private static IStringLocalizer _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer) => _localizer = localizer;

        public string this[string index] => _localizer[index];

        public static string LocalizeString(string name) => _localizer[name];
    }

    public class UIResource
    {
        private static IStringLocalizer _localizer;

        public UIResource(IStringLocalizer<UIResource> localizer) => _localizer = localizer;

        public string this[string index] => _localizer[index];

        public static string LocalizeString(string name) => _localizer[name];
    }

    public class ModulesResource
    {
        private static IStringLocalizer _localizer;

        public ModulesResource(IStringLocalizer<ModulesResource> localizer) => _localizer = localizer;

        public string this[string index] => _localizer[index];

        public static string LocalizeString(string name) => _localizer[name];
    }
    public class OperationsResource
    {
        private static IStringLocalizer _localizer;

        public OperationsResource(IStringLocalizer<OperationsResource> localizer) => _localizer = localizer;

        public string this[string index] => _localizer[index];

        public static string LocalizeString(string name) => _localizer[name];
    }
}
