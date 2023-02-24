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
        public static class FaqsUrls
        {
            public const string Create = "Faq/Create";
            public const string Save = "Faq/Save";
            public const string Delete = "Faq/Delete/{0}";
            public const string GetAll = "Faq/getall";
            public const string GetViewAll = "Faq/getallview";
            public const string GetOne = "Faq/getone/{0}";
            public const string Info = "Faq/info/{0}";
        }

        public static class SourceUIApplicationUrls
        {
            public const string GetSourceUIApplication = "SourceUIApplication/GetSourceUIApplication/{0}";
        }

        public static class PollsUrls
        {
            public const string Create = "Poll/create";
            public const string Save = "Poll/save";
            public const string Delete = "Poll/delete/{0}";
            public const string GetAll = "Poll/getall";
            public const string GetOne = "Poll/getone/{0}";
            public const string Info = "Poll/info/{0}";
            public const string GetActiveForClient = "Poll/GetActiveForClient/{0}";
            public const string IsThereActiveForClient = "Poll/IsThereActiveForClient/{0}"; 
            public const string SaveAnswer = "Poll/SaveAnswer";
            public const string GetResults = "Poll/Results/{0}";
            public const string GetResultDetails = "Poll/Results/Details/{0}";
            public const string GetResultResponse = "Poll/Results/Response/{0}";

            public const string Activate = "Poll/Activate/{0}";
            public const string Deactivate = "Poll/deactivate/{0}";
        }

        public static class ProfileUrls
        {
            public const string Get = "Profile/Get/{0}";
            public const string GetUserFullData = "Profile/GetUserFullData"; 
            public const string Save = "Profile/Save";
            public const string SendOTP = "Profile/SendOTP";
            public const string SaveProfileImage = "Profile/SaveImage";
            public const string GetProfileImage = "Profile/GetImage/{0}";
            public const string RemoveProfileImage = "Profile/RemoveProfileImage"; 
        }



        public static class VotesUrls
        {
            public const string Create = "Vote/create";
            public const string Save = "Vote/save";
            public const string Delete = "Vote/delete/{0}";
            public const string GetAll = "Vote/getall";
            public const string GetOne = "Vote/getone/{0}";
            public const string Info = "Vote/info/{0}";

            public const string Activate = "Vote/Activate/{0}";
            public const string Deactivate = "Vote/deactivate/{0}";
            public const string GetActiveForClient = "Vote/GetActiveForClient/{0}";
            public const string SaveAnswer = "Vote/SaveAnswer";

            public const string GetResults = "Vote/Results/{0}";
            public const string GetResultDetails = "Vote/Results/Details/{0}";
            public const string GetResponse = "Vote/Response/{0}";


        }

        public static class AnnouncesUrls
        {
            public const string Create = "Announce/create";
            public const string Save = "Announce/save";
            public const string Delete = "Announce/delete/{0}";
            public const string GetAll = "Announce/getall";
            public const string GetOne = "Announce/getone/{0}";

            public const string Activate = "Announce/Activate/{0}";
            public const string Deactivate = "Announce/deactivate/{0}";

            public const string ClientPortalAnnounce = "Announce/ClientPortalAnnounce/{0}";
            public const string PreventViewAgain = "Announce/PreventViewAgain/{0}";
        }

        public static class ServiceCategoriesUrls
        {
            public const string Lookup = "ServiceCategory/lookup/{0}";
            public const string Create = "ServiceCategory/create";
            public const string Save = "ServiceCategory/save";
            public const string Delete = "ServiceCategory/delete/{0}";
            public const string GetAll = "ServiceCategory/getall";
            public const string ListAllForClient = "ServiceCategory/listallForClient/{0}";
            public const string GetOne = "ServiceCategory/getone/{0}";
            public const string GetAllWithServices = "ServiceCategory/GetAllWithServices";
            public const string GetLookupsBySector = "ServiceCategory/GetLookupsBySector/{0}/{1}"; 
        }

        public static class ServiceSectorsUrls
        {
            public const string Save = "ServiceSector/save";
            public const string Delete = "ServiceSector/delete/{0}";
            public const string GetAll = "ServiceSector/getall";
            public const string ListAllForClient = "ServiceSector/listallForClient/{0}";
            public const string GetOne = "ServiceSector/getone/{0}";
        }

        public static class ServiceBasesUrls
        {
            public const string Lookup = "ServiceBase/lookup/{0}";
            public const string Create = "ServiceBase/create";
            public const string Save = "ServiceBase/save";
            public const string Delete = "ServiceBase/delete/{0}";
            public const string GetAll = "ServiceBase/getall";
            public const string GetOne = "ServiceBase/getone/{0}";
        }


        public static class ComplaintsUrls
        {
            public const string Create = "Complaint/create";
            public const string Reply = "Complaint/reply";
            //public const string Delete = "Complaint/delete/{0}";
            public const string GetAll = "Complaint/getall";
            public const string GetOne = "Complaint/getone/{0}";
        }

        public static class DashoardHomeUrls
        {
            public const string Statistics = "Dashoard/Statistics";
        }

        public static class PollQuestionsUrls
        {
            public const string Create = "PollQuestion/create";
            public const string Save = "PollQuestion/save";
            public const string Delete = "PollQuestion/delete/{0}";
            public const string GetAll = "PollQuestion/getall/{0}";
            public const string GetOne = "PollQuestion/getone/{0}";
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

        public static class ServicesUrls
        {
            public const string Create = "Service/create";
            public const string Save = "Service/save";
            public const string Delete = "Service/delete/{0}";
            public const string GetPaging = "Service/getPaging";
            public const string GetOne = "Service/getone/{0}";
            public const string GetAll = "Service/getall";
            public const string GetTopServices = "Service/GetTopServices/{0}"; 
            public const string GetForCount = "Service/getforcount";
            public const string GetOneView = "Service/getoneview/{0}";
            public const string GetOneViewByServiceCode = "Service/getoneviewByServiceCode/{0}";
            public const string Rate = "Service/Rate";

            public const string Publish = "Service/Publish/{0}";
            public const string UnPublish = "Service/UnPublish/{0}";

            public const string SaveUserRelatedServices = "Service/SaveUserRelatedServices/{0}";

            public const string GetAllLookup = "Service/lookup/{0}";

            public const string GetDelegateAccountSevices = "Service/GetDelegateAccountSevices";

            public const string GetSeviceRates = "Service/Rates";

            public const string GetLookupByCategory = "Service/GetLookupByCategory/{0}"; 

            //public const string GetAllPaging = "Service/GetAll";
            //public const string Save = "Service";
            //public const string Delete = "Service";
            //public const string GetById = "Service";
            //public const string Start = "Service/start";
            //public const string Stop = "Service/Stop";
        }

        public static class VotingUrls
        {
            public const string GetAllVotingPaging = "voting/GetAll";
            public const string Save = "voting";
            public const string Delete = "voting";
            public const string GetById = "voting";
            public const string Start = "voting/start-voting";
            public const string Stop = "voting/stop";
            public const string Result = "voting/voting-result";
        }

        public static class CategoriesUrls
        {
            public const string GetAllPaging = "Category/GetAll";
            public const string Save = "Category";
            public const string Delete = "Category";
            public const string GetById = "Category";
        }

        public static class ComplaintAndSuggestionUrls
        {
            public const string GetAllPaging = "ComplaintsAndSuggestions/GetAll";
            public const string Save = "ComplaintsAndSuggestions";
            public const string Reply = "ComplaintsAndSuggestions/Replay";
            public const string GetById = "ComplaintsAndSuggestions";
        }

        public static class SurveyUrls
        {
            public const string Add = "Survey";
            public const string Delete = "Survey";
            public const string GetById = "Survey/GetById";
            public const string AddQuestionsToSurvey = "Survey/AddQuestionsToSurvey";
            public const string GetPagedList = "Survey/GetPagedList";
            public const string ChangeState = "Survey/ChangeState";
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

        public static class UsersUrls
        {
            public const string SetFavoritService = "User/SetFavoritService/{0}";
            public const string RemoveFavoritService = "User/RemoveFavoritService/{0}";
        }

        public static class NotificationsUrls
        {
            public const string GetAll = "Notifications/getall";
            public const string GetOne = "Notifications/getone/{0}";
            public const string GetCount = "Notifications/get-count";
            public const string UpdateSeen = "Notifications/update-seen";
            public const string RegisterWebToken = "Notifications/register-web-token/{0}";
        }

        public static class ServiceIntegrationsUrls
        {
            public const string RequestsCount = "IntegrationService/requests-count";
            public const string RequestsData = "IntegrationService/requests-data";
            public const string RequestsFilter = "IntegrationService/requests-filter";
            public const string AssetsCount = "IntegrationService/assets-count";
            public const string AssetsData = "IntegrationService/assets-data";
        }
        public static class OperatorsServiceIntegrationsUrls
        {
            public const string RequestsCount = "IntegrationOperatorsService/requests-count";
            public const string RequestsData = "IntegrationOperatorsService/requests-data";
            public const string RequestsFilter = "IntegrationOperatorsService/requests-filter";
            public const string AssetsCount = "IntegrationOperatorsService/assets-count";
            public const string AssetsData = "IntegrationOperatorsService/assets-data";
        }
        public static class IntegrationsUrls
        {
            public const string UserRegisteredNumber = "Integration/user-numbers";
            public const string UserRegisteredAddress = "Integration/user-address";
            public const string UserData = "Integration/user-data";
            public const string Upload = "Integration/upload";
            public const string Download = "Integration/download";
        }

        public static class MobileUrls
        {
            public const string SaveMaintenance = "Mobile/save-maintenance";
            public const string GetMaintenance = "Mobile/get-maintenance";
            public const string SaveBlockedVersion   = "Mobile/save-blocked-version";
            public const string DeleteBlockedVersion = "Mobile/delete-blocked-version/{0}";
            public const string GetAllBlockedVersions = "Mobile/getall-blocked-versions";
        }

        public static class CountiesUrls
        {
            public const string GetAllCountries = "Country/get-all-countries/{0}";
            public const string GetNonSaudiCountries = "Country/get-non-saudi-countries/{0}";
        }

        public static class UserDocumentUrls
        {
            public const string Create = "UserDocument/Create/{0}/{1}";
            public const string CreateMultiple = "UserDocument/CreateMultiple/{0}/{1}";
            public const string Delete = "UserDocument/Delete/{0}/{1}";
            public const string Edit = "UserDocument/Edit/{0}/{1}";
            public const string Search = "UserDocument/Search/{0}/{1}";
            public const string Counts = "UserDocument/Counts/{0}/{1}";
            public const string ManageUsers = "UserDocument/ManageUsers/{0}/{1}"; 
        }

        public static class UserRequestUrls
        {
            public const string CreateDraft = "UserRequest/CreateDraft/{0}/{1}";
            public const string CreateMultipleDraft = "UserRequest/CreateMultipleDraft/{0}/{1}";
            public const string Create = "UserRequest/Create/{0}/{1}";
            public const string CreateMultiple = "UserRequest/CreateMultiple/{0}/{1}";
            public const string DeleteDraft = "UserRequest/DeleteDraft/{0}/{1}";
            public const string Delete = "UserRequest/Delete/{0}/{1}";
            public const string Edit = "UserRequest/Edit/{0}/{1}";
            public const string EditStatus = "UserRequest/EditStatus/{0}/{1}";
            public const string Search = "UserRequest/Search/{0}";
            public const string GetLatestForHome = "UserRequest/GetLatestForHome/{0}/{1}";
            public const string GetSummary = "UserRequest/GetSummary/{0}/{1}";
            public const string TotalRequests = "UserRequest/TotalRequests/{0}/{1}";
            public const string ManageUsers = "UserRequest/ManageUsers/{0}/{1}"; 
        }
    }
}
