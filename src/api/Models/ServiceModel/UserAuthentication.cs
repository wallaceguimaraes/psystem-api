using api.Authorization;
using Microsoft.Extensions.Options;
using api.Data.Context;
using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;
using api.Extensions;

namespace api.Models.ServiceModel
{
    public class UserAuthentication
    {
        private readonly ApiDbContext _dbContext;
        // private readonly INotificationsApi _notificationsApi;
        private readonly ILogger<UserAuthentication> _logger;
        private readonly AuthOptions _authOptions;
        // private readonly UserAuthenticationOptions _userAuthOptions;

        public UserAuthentication(
            ApiDbContext dbContext,
            // INotificationsApi notificationsApi,
            ILogger<UserAuthentication> logger,
            IOptions<AuthOptions> authOptionsAccessor
             //  :IOptions<UserAuthenticationOptions> userAuthOptionsAccessor
             )
        {
            _dbContext = dbContext;
            // _notificationsApi = notificationsApi;
            _logger = logger;
            _authOptions = authOptionsAccessor.Value;
            // _userAuthOptions = userAuthOptionsAccessor.Value;
        }

        // public Application Application { get; private set; }
        // public Person Holder { get; private set; }
        public User User { get; private set; } = new User();
        public bool HashExpired { get; private set; }
        public bool HashIsInvalid { get; private set; }
        public bool NotificationFailed { get; private set; }
        public bool HolderNotFound { get; private set; }
        public bool ApplicationNotFound { get; private set; }
        public bool WrongPassword { get; private set; }
        public bool PasswordUsedRecently { get; private set; }
        public string ValidateAuthCodeErrorMessage { get; set; }

        // public async Task FindUser(long userId)
        // {
        //     User = await _dbContext.Users
        //         .WherePersonId(userId)
        //         .IncludePerson()
        //         .SingleOrDefaultAsync();
        // }

        // public async Task<bool> FindUser(string email)
        // {
        //     User = await _dbContext.Users
        //         .WhereEmail(email)
        //         .IncludePerson()
        //         .IncludeHolder()
        //         .SingleOrDefaultAsync();

        //     return User != null;
        // }

        // public async Task<bool> FindUser(int legacyLogin, string password)
        // {
        //     User = await _dbContext.Users
        //         .IncludePerson()
        //         .SingleOrDefaultAsync();

        //     if (User != null && User.Active && (!User.IsSubuser || (User.IsSubuser && User.Holder.Account.Active)))
        //     {
        //         return User.Password == password.Encrypt(User.Salt);
        //     }

        //     return false;
        // }

        public async Task<bool> SignIn(string login, string password, string company = "")
        {
            //Find Company

            User = await _dbContext.Users
                .WhereEmail(login)
                .IncludePerson()
                .SingleOrDefaultAsync();

            if (User == null) return false;


            return User.Password == password.Encrypt(User.Salt);
        }

        // public async Task<bool> SignIn(long applicationId, string hash)
        // {
        //     await FindApplication(applicationId);

        //     var userHash = UserHash.Decode(hash);

        //     HashIsInvalid = userHash == null || userHash.ApplicationId != applicationId || Application == null || !Application.Active;
        //     if (HashIsInvalid) return false;

        //     await FindUser(userHash.UserId);

        //     HashExpired = userHash.Expired || userHash.Salt != User?.Salt;
        //     if (HashExpired) return false;

        //     await _dbContext.SaveChangesAsync();

        //     return true;
        // }

        // public async Task<bool> SignInForHolder(long partnerId, long holderId)
        // {
        //     await FindHolder(holderId, partnerId);
        //     HolderNotFound = Holder == null;
        //     if (HolderNotFound) return false;

        //     return true;
        // }

        // public async Task<bool> ChangePassword(string oldPassword, string password, string ip)
        // {

        //     WrongPassword = User.Password != oldPassword.Encrypt(User.Salt);
        //     if (WrongPassword) return false;

        //     User.Salt = new Salt().ToString();
        //     User.Password = password.Encrypt(User.Salt);

        //     PasswordUsedRecently = LastPasswordsIsInvalid(User.PersonId, password);
        //     if (PasswordUsedRecently) return false;

        //     _dbContext.LastPasswords.Add(MapToLastPassword(User, ip));

        //     await _dbContext.SaveChangesAsync();

        //     return true;
        // }

        // public bool LastPasswordsIsInvalid(long personId, string password)
        // {
        //     var lastThreePasswords = _dbContext.LastPasswords
        //         .WherePersonId(personId)
        //         .OrderByCreatedAtDesc()
        //         .Skip(0)
        //         .Take(3)
        //         .ToList();

        //     return lastThreePasswords.Any(x => x.Password == password.Encrypt(x.Salt));
        // }

        // public LastPassword MapToLastPassword(User user, string ip)
        // {
        //     return new LastPassword
        //     {
        //         PersonId = user.PersonId,
        //         Password = user.Password,
        //         Salt = user.Salt,
        //         CreatedAt = DateTime.Now,
        //         Ip = ip
        //     };
        // }

        // public async Task<bool> NewPassword(string newPassword, string ip)
        // {
        //     if (User == null) return false;

        //     User.Salt = new Salt().ToString();
        //     User.Password = newPassword.Encrypt(User.Salt);

        //     if (User.ChangePasswordUntil.HasValue && User.Person.IsEmployee)
        //         User.ChangePasswordUntil = DateTime.Today.AddDays(_userAuthOptions.EmployeePasswordExpirationDays);

        //     _dbContext.LastPasswords.Add(MapToLastPassword(User, ip));

        //     await _dbContext.SaveChangesAsync();

        //     return true;
        // }

        // public async Task<bool> SendEmailRecovery(User user, long applicationId, string appUrl, bool sellerPartner)
        // {
        //     HashIsInvalid = Application == null || !Application.Active || User == null;
        //     if (HashIsInvalid) return false;

        //     var notifiedUser = new UserNotification(user, applicationId, appUrl);

        //     if (sellerPartner)
        //     {
        //         var partnerId = user.Holder.RegistrationOrigin.Application.PartnerId ?? default(long);

        //         var partnerAccount = await _dbContext.Accounts
        //                                     .Where(account => account.HolderId == partnerId)
        //                                     .SingleOrDefaultAsync();

        //         NotificationFailed = !await _notificationsApi.SendEmailRecovery(notifiedUser, sellerPartner, partnerAccount.CommercialName, partnerAccount.Logo);
        //     }
        //     else
        //     {
        //         NotificationFailed = !await _notificationsApi.SendEmailRecovery(notifiedUser, sellerPartner);
        //     }

        //     if (NotificationFailed) return false;

        //     return true;
        // }
    }
}