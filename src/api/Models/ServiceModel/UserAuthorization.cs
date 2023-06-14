// using api.Models.EntityModel.Accounts;
// using api.Models.EntityModel.Applications;
// using api.Models.EntityModel.ContractedServices;
using api.Data.Context;
using api.Models.EntityModel.Persons;
// using api.Models.EntityModel.RegistrationOrigins;
using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel
{
    public class UserAuthorization
    {
        private ApiDbContext _dbContext;

        public UserAuthorization(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public Application Application { get; private set; }
        public User User { get; private set; }
        public Person Holder { get; private set; }
        public string Scope { get; private set; }
        public bool AccessGranted { get; private set; }
        public bool AccessedByHolder { get; private set; }
        public bool AccessedByEmployee { get; private set; }
        public bool AccessedByPartner { get; private set; }
        public bool UserNotFound { get; private set; }
        public bool? AnticipationBlocked { get; private set; }
        public bool AccessedBySuperAdmin { get; private set; }


        // private async Task<bool> CheckApplicationPermission(long applicationId, string scope)
        // {
        //     Application = await _dbContext.Applications
        //       .WhereId(applicationId)
        //       .IncludePartner()
        //       .IncludeTransferPlans()
        //       .SingleOrDefaultAsync();

        //     var personId = User.Holder?.Id ?? User.Person.Id;

        //     var registrationOrigin = await _dbContext.RegistrationOrigins.WherePersonId(personId).SingleOrDefaultAsync();

        //     if (Application?.ReleasedAt == null || !Application.Active || (!User.Person.IsEmployee && ((Application.PartnerId != null) && (Application.PartnerId != personId) && (registrationOrigin.ApplicationId != applicationId))))
        //     {
        //         return false;
        //     }

        //     if (Application.Partner == null || string.IsNullOrWhiteSpace(scope))
        //     {
        //         return true;
        //     }

        //     return await _dbContext.PartnerServices
        //         .WherePersonId(Application.PartnerId)
        //         .WhereNotCancelled()
        //         .WhereHasService(scope)
        //         .AnyAsync();
        // }

        // private async Task<Person> FindHolder(long holderId)
        // {
        //     Holder = await _dbContext.Persons
        //         .WhereId(holderId)
        //         .IncludeAccount()
        //         .IncludeUser()
        //         .IncludeNaturalAndJuristic()
        //         .IncludeRegistrationOriginApplication()
        //         .SingleOrDefaultAsync();

        //     return Holder;
        // }

        private Task<bool> CheckUserPermission(string scope, bool holderAsEmployee)
        {
            if (User == null)
            {
                return Task.FromResult(false);
            }

            // if (!Application.IsPublic && !User.Person.IsEmployee)
            // {
            //     return false;
            // }

            // if (holderAsEmployee && scope != null && !scope.Contains("readonly"))
            // {
            //     return false;
            // }

            // if (User.Holder?.Account?.Active == false)
            // {
            //     return false;
            // }

            // if (User.PersonId == User.HolderId)
            // {
            //     return true;
            // }

            // if (!User.Active || !(User.ApplicationRole?.Active ?? true))
            // {
            //     return false;
            // }

            if (string.IsNullOrWhiteSpace(scope))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(true); ;
            // return await _dbContext.Roles
            //     .WhereId(User.RoleId)
            //     .WhereHasScopeEqualTo(scope)
            //     .AnyAsync();
        }

        public async Task FindUser(long personId, string salt, bool lazyLoad = true)
        {
            var queryUser = _dbContext.Users
              .WherePersonId(personId)
            //   .WhereSalt(salt)
              .IncludePerson()
              .IncludeRoles();

            if (!lazyLoad)
            {
                queryUser = queryUser.IncludeAddress();
            }

            User = await queryUser.SingleOrDefaultAsync();

            UserNotFound = User == null;


        }

        public async Task CheckPermission(long applicationId, string scope, bool holderAsEmployee = false, bool requiredSuperAdmin = false)
        {
            // var grantedToApplication = await CheckApplicationPermission(applicationId, scope);
            var grantedToUser = await CheckUserPermission(scope, holderAsEmployee);
            // var freeTrialPeriod = new FreeTrialPeriod(User.Holder);
            // var grantedFreeTrial = User.Person.IsEmployee || freeTrialPeriod.IsNotExpired;

            Scope = scope;
            AccessedByEmployee = User.Person.IsEmployee;
            AccessedBySuperAdmin = User.Person.IsSuperAdmin;

            // AccessGranted = !User.NeedChangePassword && grantedToApplication && grantedToUser && (grantedFreeTrial || User.Holder.Account.IsApproved) && (!requiredSuperAdmin || AccessedBySuperAdmin);
            AccessGranted = true;
        }

        public async Task CheckPermission(long applicationId, string scope, bool employee, bool partner, bool holderAsEmployee)
        {
            await CheckPermission(applicationId, scope, holderAsEmployee);

            // AccessGranted = AccessGranted
            //     && (!employee || User.Person.IsEmployee)
            //     && (!partner || User.Person.IsPartner || Holder.IsPartner);

            AccessGranted = true;
        }
    }
}
