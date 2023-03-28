namespace Dashboard.Common.WebClientHelpers
{
    public class InternalApiDictionary
    {
        public static class LoggingSystemUrls
        {
            public const string LogData = "LoggingSystem/log_data";
        }

        public static class LookupsUrls
        {
            public const string Portals = "lookup/portals";
            public const string Services = "lookup/services/{0}";
            public const string ServicesWithLanguage = "lookup/ServicesWithLanguage/{0}/{1}";
            public const string Languages = "lookup/languages";
            public const string ServiceCategories = "lookup/serviceCategory";
            public const string ServiceSectors = "lookup/serviceSector";
            public const string ServiceBases = "lookup/serviceBase";
            public const string CommunicationType = "lookup/communicationtype";
            public const string FoundationCategories = "lookup/get-foundations-categories";

            //public const string GetAllCategories        = "lookup/get-all-category";
            //public const string GetAllMassageType       = "lookup/get-all-MassageType";
            //public const string GetAllPaymentOptions    = "lookup/get-all-PaymentOptions";
            //public const string GetAllServiceUsers      = "lookup/get-all-ServiceUsers";
        }
        public static class FaqUrls
        {
            public const string Create = "Faq/Create";
            public const string Save = "Faq/Save";
            public const string Delete = "Faq/Delete/{0}";
            public const string GetAll = "Faq/getall";
            public const string GetPaged = "Faq/get-paged";

            public const string GetViewAll = "Faq/getallview";
            public const string GetOne = "Faq/getone/{0}";
            public const string Info = "Faq/info/{0}";
            public const string GetLookup = "Faq/lookup?portalId={0}&serviceId{1}";
        }
        public static class CountryUrls
        {
            public const string Create = "Country/Create";
            public const string Save = "Country/Save";
            public const string Delete = "Country/Delete/{0}";
            public const string GetAll = "Country/getall";
            public const string GetPaged = "Country/get-paged";

            public const string GetViewAll = "Country/getallview";
            public const string GetOne = "Country/getone/{0}";
            public const string Info = "Country/info/{0}";
            public const string GetLookup = "Country/lookup";
        }
        public static class PortalUrls
        {
            public const string Create = "Portal/Create";
            public const string Save = "Portal/Save";
            public const string Delete = "Portal/Delete/{0}";
            public const string GetAll = "Portal/getall";
            public const string GetPaged = "Portal/get-paged";

            public const string GetViewAll = "Portal/getallview";
            public const string GetOne = "Portal/getone/{0}";
            public const string Info = "Portal/info/{0}";
            public const string GetLookup = "Portal/lookup";
        }
        public static class LanguageUrls
        {
            public const string Create = "Language/Create";
            public const string Save = "Language/Save";
            public const string Delete = "Language/Delete/{0}";
            public const string GetAll = "Language/getall";
            public const string GetPaged = "Language/get-paged";

            public const string GetViewAll = "Language/getallview";
            public const string GetOne = "Language/getone/{0}";
            public const string Info = "Language/info/{0}";
            public const string GetLookup = "Language/lookup";
        }
        public static class ServiceUrls
        {
            public const string Create = "Service/Create";
            public const string Save = "Service/Save";
            public const string Delete = "Service/Delete/{0}";
            public const string GetAll = "Service/getall";
            public const string GetPaged = "Service/get-paged";

            public const string GetViewAll = "Service/getallview";
            public const string GetOne = "Service/getone/{0}";
            public const string Info = "Service/info/{0}";
            public const string GetLookup = "Service/lookup?serviceTypeId={0}&portalId={1}";
        }
        public static class ServiceTypeUrls
        {
            public const string Create = "ServiceType/Create";
            public const string Save = "ServiceType/Save";
            public const string Delete = "ServiceType/Delete/{0}";
            public const string GetAll = "ServiceType/getall";
            public const string GetPaged = "ServiceType/get-paged";

            public const string GetViewAll = "ServiceType/getallview";
            public const string GetOne = "ServiceType/getone/{0}";
            public const string Info = "ServiceType/info/{0}";
            public const string GetLookup = "ServiceType/lookup";
        }
        public static class SourceUIApplicationUrls
        {
            public const string GetSourceUIApplication = "SourceUIApplication/GetSourceUIApplication/{0}";
        }



        public static class AdminUrls
        {
            public const string Save = "Identity/Save";
            public const string Delete = "Identity/Delete/{0}";
            public const string GetAll = "Identity/getall";
            public const string GetAllAdmins = "Identity/get-all-admins";
            public const string GetOne = "Identity/getone/{0}";
            public const string Getfullname = "Identity/getfullname/{0}";
        }

        public static class IdentityUrls
        {
            public const string Login = "Account/Login";
            public const string UserData = "Account/GetUserData";
        }

        public static class AttachmentsUrls
        {
            public const string Download = "Attachment/Download";
            public const string Save = "Attachment/Save";
        }

        
        
        public static class IdentityAdminUrls
        {
            public const string SendAdminNotificationForFoundationCreated = "IdentityAdmin/send-foundation-notification/{0}";
        }

        

        public static class NotificationsUrls
        {
            public const string GetAll = "Notifications/getall";
            public const string GetOne = "Notifications/getone/{0}";
            public const string GetCount = "Notifications/get-count";
            public const string UpdateSeen = "Notifications/update-seen";
            public const string RegisterWebToken = "Notifications/register-web-token/{0}";
        }

    }
}
