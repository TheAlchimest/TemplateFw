using Microsoft.Extensions.Localization;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Resources
{
    public interface ISharedResource
    {
    }

    public class SharedResource
    {
        private static IStringLocalizer _localizer;

        public SharedResource(IStringLocalizer<TemplateFw.Resources.Resources.SharedResource> localizer) => _localizer = localizer;

        public string this[string index] => _localizer[index];

        public static string LocalizeString(string name) => _localizer[name];
    }

    public class UIResource
    {
        private static IStringLocalizer _localizer;

        public UIResource(IStringLocalizer<UIResources> localizer) => _localizer = localizer;

        public string this[string name] => _localizer[name];

        public static string LocalizeString(string name) => _localizer[name];
    }

    public class ModulesResource
    {
        private static IStringLocalizer<ModulesResources> _localizer;

        public ModulesResource(IStringLocalizer<ModulesResources> localizer) { 
            _localizer = localizer; }

        public string this[string name] => _localizer[name];

        public static string LocalizeString(string name) => _localizer[name];
    }
    public class OperationsResource2
    {
        private static IStringLocalizer _localizer;

        public OperationsResource2(IStringLocalizer<OperationsResources> localizer) => _localizer = localizer;

        public string this[string name] => _localizer[name];

        public static string LocalizeString(string name) => _localizer[name];
    }
}
