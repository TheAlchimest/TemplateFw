namespace Dashboard.Common.WebClientHelpers
{
    public class InternalApiDictionary
    {
        
        public static class ArticleUrls
        {
            public const string Create = "article/Create";
            public const string Update = "article/Update";
            public const string Delete = "article/Delete/{0}";
            public const string GetAll = "article/getall";
            public const string GetPaged = "article/get-paged";

            public const string GetViewAll = "article/getallview";
            public const string GetOne = "article/getone/{0}";
            public const string Info = "article/info/{0}";
            public const string GetLookup = "article/lookup?authorId={0}&categoryId={1}";
        }
	public static class AuthorUrls
        {
            public const string Create = "author/Create";
            public const string Update = "author/Update";
            public const string Delete = "author/Delete/{0}";
            public const string GetAll = "author/getall";
            public const string GetPaged = "author/get-paged";

            public const string GetViewAll = "author/getallview";
            public const string GetOne = "author/getone/{0}";
            public const string Info = "author/info/{0}";
            public const string GetLookup = "author/lookup?countryId={0}";
        }
	public static class CategoryUrls
        {
            public const string Create = "category/Create";
            public const string Update = "category/Update";
            public const string Delete = "category/Delete/{0}";
            public const string GetAll = "category/getall";
            public const string GetPaged = "category/get-paged";

            public const string GetViewAll = "category/getallview";
            public const string GetOne = "category/getone/{0}";
            public const string Info = "category/info/{0}";
            public const string GetLookup = "category/lookup";
        }
	public static class CommentUrls
        {
            public const string Create = "comment/Create";
            public const string Update = "comment/Update";
            public const string Delete = "comment/Delete/{0}";
            public const string GetAll = "comment/getall";
            public const string GetPaged = "comment/get-paged";

            public const string GetViewAll = "comment/getallview";
            public const string GetOne = "comment/getone/{0}";
            public const string Info = "comment/info/{0}";
            public const string GetLookup = "comment/lookup?articleId={0}&userId={1}";
        }
	public static class ContactUsUrls
        {
            public const string Create = "contactus/Create";
            public const string Update = "contactus/Update";
            public const string Delete = "contactus/Delete/{0}";
            public const string GetAll = "contactus/getall";
            public const string GetPaged = "contactus/get-paged";

            public const string GetViewAll = "contactus/getallview";
            public const string GetOne = "contactus/getone/{0}";
            public const string Info = "contactus/info/{0}";
            public const string GetLookup = "contactus/lookup";
        }
	public static class CountryUrls
        {
            public const string Create = "country/Create";
            public const string Update = "country/Update";
            public const string Delete = "country/Delete/{0}";
            public const string GetAll = "country/getall";
            public const string GetPaged = "country/get-paged";

            public const string GetViewAll = "country/getallview";
            public const string GetOne = "country/getone/{0}";
            public const string Info = "country/info/{0}";
            public const string GetLookup = "country/lookup";
        }
	public static class FaqUrls
        {
            public const string Create = "faq/Create";
            public const string Update = "faq/Update";
            public const string Delete = "faq/Delete/{0}";
            public const string GetAll = "faq/getall";
            public const string GetPaged = "faq/get-paged";

            public const string GetViewAll = "faq/getallview";
            public const string GetOne = "faq/getone/{0}";
            public const string Info = "faq/info/{0}";
            public const string GetLookup = "faq/lookup?portalId={0}&serviceId={1}";
        }
	public static class LanguageUrls
        {
            public const string Create = "language/Create";
            public const string Update = "language/Update";
            public const string Delete = "language/Delete/{0}";
            public const string GetAll = "language/getall";
            public const string GetPaged = "language/get-paged";

            public const string GetViewAll = "language/getallview";
            public const string GetOne = "language/getone/{0}";
            public const string Info = "language/info/{0}";
            public const string GetLookup = "language/lookup";
        }
	public static class ModelUrls
        {
            public const string Create = "model/Create";
            public const string Update = "model/Update";
            public const string Delete = "model/Delete/{0}";
            public const string GetAll = "model/getall";
            public const string GetPaged = "model/get-paged";

            public const string GetViewAll = "model/getallview";
            public const string GetOne = "model/getone/{0}";
            public const string Info = "model/info/{0}";
            public const string GetLookup = "model/lookup?countryId={0}&categoryId={1}&portalId={2}&serviceId={3}&modelStatusId={4}";
        }
	public static class ModelStatusUrls
        {
            public const string Create = "modelstatus/Create";
            public const string Update = "modelstatus/Update";
            public const string Delete = "modelstatus/Delete/{0}";
            public const string GetAll = "modelstatus/getall";
            public const string GetPaged = "modelstatus/get-paged";

            public const string GetViewAll = "modelstatus/getallview";
            public const string GetOne = "modelstatus/getone/{0}";
            public const string Info = "modelstatus/info/{0}";
            public const string GetLookup = "modelstatus/lookup";
        }
	public static class PaymentUrls
        {
            public const string Create = "payment/Create";
            public const string Update = "payment/Update";
            public const string Delete = "payment/Delete/{0}";
            public const string GetAll = "payment/getall";
            public const string GetPaged = "payment/get-paged";

            public const string GetViewAll = "payment/getallview";
            public const string GetOne = "payment/getone/{0}";
            public const string Info = "payment/info/{0}";
            public const string GetLookup = "payment/lookup?subscriptionId={0}";
        }
	public static class PortalUrls
        {
            public const string Create = "portal/Create";
            public const string Update = "portal/Update";
            public const string Delete = "portal/Delete/{0}";
            public const string GetAll = "portal/getall";
            public const string GetPaged = "portal/get-paged";

            public const string GetViewAll = "portal/getallview";
            public const string GetOne = "portal/getone/{0}";
            public const string Info = "portal/info/{0}";
            public const string GetLookup = "portal/lookup";
        }
	public static class ServiceUrls
        {
            public const string Create = "service/Create";
            public const string Update = "service/Update";
            public const string Delete = "service/Delete/{0}";
            public const string GetAll = "service/getall";
            public const string GetPaged = "service/get-paged";

            public const string GetViewAll = "service/getallview";
            public const string GetOne = "service/getone/{0}";
            public const string Info = "service/info/{0}";
            public const string GetLookup = "service/lookup?serviceTypeId={0}&portalId={1}";
        }
	public static class ServiceTypeUrls
        {
            public const string Create = "servicetype/Create";
            public const string Update = "servicetype/Update";
            public const string Delete = "servicetype/Delete/{0}";
            public const string GetAll = "servicetype/getall";
            public const string GetPaged = "servicetype/get-paged";

            public const string GetViewAll = "servicetype/getallview";
            public const string GetOne = "servicetype/getone/{0}";
            public const string Info = "servicetype/info/{0}";
            public const string GetLookup = "servicetype/lookup";
        }
	public static class SubscriptionUrls
        {
            public const string Create = "subscription/Create";
            public const string Update = "subscription/Update";
            public const string Delete = "subscription/Delete/{0}";
            public const string GetAll = "subscription/getall";
            public const string GetPaged = "subscription/get-paged";

            public const string GetViewAll = "subscription/getallview";
            public const string GetOne = "subscription/getone/{0}";
            public const string Info = "subscription/info/{0}";
            public const string GetLookup = "subscription/lookup?userId={0}&subscriptionPlanId={1}&subscriptionStatusId={2}";
        }
	public static class SubscriptionPlanUrls
        {
            public const string Create = "subscriptionplan/Create";
            public const string Update = "subscriptionplan/Update";
            public const string Delete = "subscriptionplan/Delete/{0}";
            public const string GetAll = "subscriptionplan/getall";
            public const string GetPaged = "subscriptionplan/get-paged";

            public const string GetViewAll = "subscriptionplan/getallview";
            public const string GetOne = "subscriptionplan/getone/{0}";
            public const string Info = "subscriptionplan/info/{0}";
            public const string GetLookup = "subscriptionplan/lookup";
        }
	public static class SubscriptionStatusUrls
        {
            public const string Create = "subscriptionstatus/Create";
            public const string Update = "subscriptionstatus/Update";
            public const string Delete = "subscriptionstatus/Delete/{0}";
            public const string GetAll = "subscriptionstatus/getall";
            public const string GetPaged = "subscriptionstatus/get-paged";

            public const string GetViewAll = "subscriptionstatus/getallview";
            public const string GetOne = "subscriptionstatus/getone/{0}";
            public const string Info = "subscriptionstatus/info/{0}";
            public const string GetLookup = "subscriptionstatus/lookup";
        }
	public static class TagUrls
        {
            public const string Create = "tag/Create";
            public const string Update = "tag/Update";
            public const string Delete = "tag/Delete/{0}";
            public const string GetAll = "tag/getall";
            public const string GetPaged = "tag/get-paged";

            public const string GetViewAll = "tag/getallview";
            public const string GetOne = "tag/getone/{0}";
            public const string Info = "tag/info/{0}";
            public const string GetLookup = "tag/lookup";
        }
	public static class UsersUrls
        {
            public const string Create = "users/Create";
            public const string Update = "users/Update";
            public const string Delete = "users/Delete/{0}";
            public const string GetAll = "users/getall";
            public const string GetPaged = "users/get-paged";

            public const string GetViewAll = "users/getallview";
            public const string GetOne = "users/getone/{0}";
            public const string Info = "users/info/{0}";
            public const string GetLookup = "users/lookup";
        }


        public static class IdentityUrls
        {
            public const string Login = "Account/Login";
            public const string UserData = "Account/GetUserData";
        }
        public static class LoggingSystemUrls
        {
            public const string LogData = "LoggingSystem/log_data";
        }

        public static class AttachmentsUrls
        {
            public const string Download = "Attachment/Download";
            public const string Save = "Attachment/Save";
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
