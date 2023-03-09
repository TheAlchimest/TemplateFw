using Dashboard.Common.WebClientHelpers;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Identity;

namespace TemplateFw.Dashboard.Auth
{
    public interface IRoleProvider
    {
        Task<ICollection<string>> GetUserRolesAsync(AdminDto admin);
        Task<AdminDto> GetAdmin(string userName);
    }

    public class RoleProvider : IRoleProvider
    {
        public const string SERVICES_ADMIN = "Services";
        public const string Faq = "Faqs";
        public const string POLLS_ADMIN = "Polls";
        public const string VOTINGS_ADMIN = "Votings";
        public const string COMPLAINTS_ADMIN = "Complaints";
        public const string ANNOUNCING_ADMIN = "Announcing";
        public const string SUPER_ADMIN = "SuperAdmin";
        public const string INDIVIDUALS_ACCOUNTS_ADMIN = "IndividualsAccounts";
        public const string INTERNAL_BUSINESS_ACCOUNTS_ADMIN = "InternalBusinessAccounts";
        public const string EXTERNAL_BUSINESS_ACCOUNTS_ADMIN = "ExternalBusinessAccounts";
        public const string GOVERNMENT_ACCOUNTS_ADMIN = "GovernmentAccounts";
        public const string SERVICE_PROVIDERS_ACCOUNTS_ADMIN = "ServiceProvidersAccounts";
        public const string SECURITY_ACCOUNTS_ADMIN = "SecurityAccounts";
        public const string MOBILE_ADMIN = "Mobile";
        public const string ADMIN = "admin";

        public async Task<AdminDto> GetAdmin(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var admins = await ApiRequestHelper.InternalAPI.GetAsync<GenericApiResponse<List<AdminDto>>>(InternalApiDictionary.AdminUrls.GetAllAdmins);
                var admin = admins?.Data?.Where(a => a.UserName.ToLower() == userName.ToLower())?.FirstOrDefault();
                return admin;
            }

            return null;
        }

        public async Task<ICollection<string>> GetUserRolesAsync(AdminDto admin)
        {
            ICollection<string> result = new List<string>();

            if (admin.CanManageServices == true)
            {
                result.Add(SERVICES_ADMIN);
            }
            if (admin.CanManageIndividualsAccounts == true)
            {
                result.Add(INDIVIDUALS_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageInternalBusinessAccounts == true)
            {
                result.Add(INTERNAL_BUSINESS_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageExternalBusinessAccounts == true)
            {
                result.Add(EXTERNAL_BUSINESS_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageGovernmentAccounts == true)
            {
                result.Add(GOVERNMENT_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageServiceProvidersAccounts == true)
            {
                result.Add(SERVICE_PROVIDERS_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageSecurityAccounts == true)
            {
                result.Add(SECURITY_ACCOUNTS_ADMIN);
            }
            if (admin.CanManageFaqs == true)
            {
                result.Add(Faq);
            }
            if (admin.CanManagePolls == true)
            {
                result.Add(POLLS_ADMIN);
            }
            if (admin.CanManageVotings == true)
            {
                result.Add(VOTINGS_ADMIN);
            }
            if (admin.CanManageComplaints == true)
            {
                result.Add(COMPLAINTS_ADMIN);
            }
            if (admin.CanManageAnnounces == true)
            {
                result.Add(ANNOUNCING_ADMIN);
            }
            if (admin.CanManageMobile == true)
            {
                result.Add(MOBILE_ADMIN);
            }
            if (admin.CanManageAdmins == true)
            {
                result.Add(SUPER_ADMIN);
            }
            if (result.Count > 0)
            {
                result.Add(ADMIN);
            }

            return await Task.FromResult(result);
        }
    }
}
