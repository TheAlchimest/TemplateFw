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
            public const string Update = "Faq/Update";
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
            public const string Update = "Country/Update";
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
            public const string Update = "Portal/Update";
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
            public const string Update = "Language/Update";
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
            public const string Update = "Service/Update";
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
            public const string Update = "ServiceType/Update";
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
        public static class ArticleUrls
        {
            public const string Create = "Article/Create";
            public const string Update = "Article/Update";
            public const string Delete = "Article/Delete/{0}";
            public const string GetAll = "Article/getall";
            public const string GetPaged = "Article/get-paged";

            public const string GetViewAll = "Article/getallview";
            public const string GetOne = "Article/getone/{0}";
            public const string Info = "Article/info/{0}";
            public const string GetLookup = "Article/lookup?portalId={0}&serviceId{1}";
        }

        public static class AuthorUrls
        {
            public const string Create = "Author/Create";
            public const string Update = "Author/Update";
            public const string Delete = "Author/Delete/{0}";
            public const string GetAll = "Author/getall";
            public const string GetPaged = "Author/get-paged";

            public const string GetViewAll = "Author/getallview";
            public const string GetOne = "Author/getone/{0}";
            public const string Info = "Author/info/{0}";
            public const string GetLookup = "Author/lookup?portalId={0}&serviceId{1}";
        }
        public static class CategoryUrls
        {
            public const string Create = "Category/Create";
            public const string Update = "Category/Update";
            public const string Delete = "Category/Delete/{0}";
            public const string GetAll = "Category/getall";
            public const string GetPaged = "Category/get-paged";

            public const string GetViewAll = "Category/getallview";
            public const string GetOne = "Category/getone/{0}";
            public const string Info = "Category/info/{0}";
            public const string GetLookup = "Category/lookup?portalId={0}&serviceId{1}";
        }

        public static class CommentUrls
        {
            public const string Create = "Comment/Create";
            public const string Update = "Comment/Update";
            public const string Delete = "Comment/Delete/{0}";
            public const string GetAll = "Comment/getall";
            public const string GetPaged = "Comment/get-paged";

            public const string GetViewAll = "Comment/getallview";
            public const string GetOne = "Comment/getone/{0}";
            public const string Info = "Comment/info/{0}";
            public const string GetLookup = "Comment/lookup?portalId={0}&serviceId{1}";
        }

        public static class ContactUsUrls
        {
            public const string Create = "ContactUs/Create";
            public const string Update = "ContactUs/Update";
            public const string Delete = "ContactUs/Delete/{0}";
            public const string GetAll = "ContactUs/getall";
            public const string GetPaged = "ContactUs/get-paged";

            public const string GetViewAll = "ContactUs/getallview";
            public const string GetOne = "ContactUs/getone/{0}";
            public const string Info = "ContactUs/info/{0}";
            public const string GetLookup = "ContactUs/lookup?portalId={0}&serviceId{1}";
        }
        public static class PaymentUrls
        {
            public const string Create = "Payment/Create";
            public const string Update = "Payment/Update";
            public const string Delete = "Payment/Delete/{0}";
            public const string GetAll = "Payment/getall";
            public const string GetPaged = "Payment/get-paged";

            public const string GetViewAll = "Payment/getallview";
            public const string GetOne = "Payment/getone/{0}";
            public const string Info = "Payment/info/{0}";
            public const string GetLookup = "Payment/lookup?portalId={0}&serviceId{1}";
        }
        public static class SubscriptionUrls
        {
            public const string Create = "Subscription/Create";
            public const string Update = "Subscription/Update";
            public const string Delete = "Subscription/Delete/{0}";
            public const string GetAll = "Subscription/getall";
            public const string GetPaged = "Subscription/get-paged";

            public const string GetViewAll = "Subscription/getallview";
            public const string GetOne = "Subscription/getone/{0}";
            public const string Info = "Subscription/info/{0}";
            public const string GetLookup = "Subscription/lookup?portalId={0}&serviceId{1}";
        }
        public static class SubscriptionPlanUrls
        {
            public const string Create = "SubscriptionPlan/Create";
            public const string Update = "SubscriptionPlan/Update";
            public const string Delete = "SubscriptionPlan/Delete/{0}";
            public const string GetAll = "SubscriptionPlan/getall";
            public const string GetPaged = "SubscriptionPlan/get-paged";

            public const string GetViewAll = "SubscriptionPlan/getallview";
            public const string GetOne = "SubscriptionPlan/getone/{0}";
            public const string Info = "SubscriptionPlan/info/{0}";
            public const string GetLookup = "SubscriptionPlan/lookup?portalId={0}&serviceId{1}";
        }

        public static class SubscriptionStatusUrls
        {
            public const string Create = "SubscriptionStatus/Create";
            public const string Update = "SubscriptionStatus/Update";
            public const string Delete = "SubscriptionStatus/Delete/{0}";
            public const string GetAll = "SubscriptionStatus/getall";
            public const string GetPaged = "SubscriptionStatus/get-paged";

            public const string GetViewAll = "SubscriptionStatus/getallview";
            public const string GetOne = "SubscriptionStatus/getone/{0}";
            public const string Info = "SubscriptionStatus/info/{0}";
            public const string GetLookup = "SubscriptionStatus/lookup?portalId={0}&serviceId{1}";
        }

        public static class TagUrls
        {
            public const string Create = "Tag/Create";
            public const string Update = "Tag/Update";
            public const string Delete = "Tag/Delete/{0}";
            public const string GetAll = "Tag/getall";
            public const string GetPaged = "Tag/get-paged";

            public const string GetViewAll = "Tag/getallview";
            public const string GetOne = "Tag/getone/{0}";
            public const string Info = "Tag/info/{0}";
            public const string GetLookup = "Tag/lookup?portalId={0}&serviceId{1}";
        }
        public static class UsersUrls
        {
            public const string Create = "Users/Create";
            public const string Update = "Users/Update";
            public const string Delete = "Users/Delete/{0}";
            public const string GetAll = "Users/getall";
            public const string GetPaged = "Users/get-paged";

            public const string GetViewAll = "Users/getallview";
            public const string GetOne = "Users/getone/{0}";
            public const string Info = "Users/info/{0}";
            public const string GetLookup = "Users/lookup?portalId={0}&serviceId{1}";
        }
    }
}
