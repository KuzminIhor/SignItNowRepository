using System.Linq;
using SignItNow.Core;
using SignItNow.Helpers;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Repositories;
using SignItNow.Repositories.Interfaces;
using SignItNow.Services;
using SignItNow.Services.Interfaces;
using Unity;

namespace SignItNow.AppData.Unity
{
	public class UnityConfig
	{
		public static IUnityContainer Container => ServiceLocator.Container;

		public static void Register()
		{
			ServiceLocator.RegisterSingleton<IEncryptorDecryptor, EncryptorDecryptor>();

			//Register Core
			var dbApp = new DBAppContext();
			ServiceLocator.RegisterSingleton(dbApp);

			var context = ServiceLocator.Get<DBAppContext>();

			if (context.UserRoles.FirstOrDefault(u => u.Role.Id == 1 && u.User.Id == 1) == null)
			{
				context.UserRoles.AddRange(new UserRole()
					{Role = context.Roles.FirstOrDefault(), User = context.Users.FirstOrDefault()});
				context.SaveChanges();
			}

			//Register services
			ServiceLocator.RegisterSingleton<IAuthenticationService, AuthenticationService>();
			ServiceLocator.RegisterSingleton<IFormRedirectionService, FormRedirectionService>();

			ServiceLocator.RegisterSingleton<IUploadDocumentService, UploadDocumentService>();

			ServiceLocator.RegisterSingleton<IUpdateUserService, UpdateUserService>();

			ServiceLocator.RegisterSingleton<IUserBannedService, UserBannedService>();

			ServiceLocator.RegisterSingleton<ICreateTaskService, CreateTaskService>();

			ServiceLocator.RegisterSingleton<IRevokeTaskService, RevokeTaskService>();

			ServiceLocator.RegisterSingleton<ISigningService, SigningService>();

			/*ServiceLocator.RegisterSingleton<IRenderDataTableRows, RenderUserDataTableRowsService>(nameof(RenderUserDataTableRowsService));
			ServiceLocator.RegisterSingleton<IRenderDataTableRows, RenderCurrencyDataTableRowsService>(nameof(RenderCurrencyDataTableRowsService));
			ServiceLocator.RegisterSingleton<IRenderDataTableRows, RenderBankDataTableRowsService>(nameof(RenderBankDataTableRowsService));*/

			//Register helpers
			ServiceLocator.RegisterSingleton<IFieldsValidator, FieldsValidator>();
			ServiceLocator.RegisterSingleton<IAuthenticationProcess, AuthenticationProcess>();
			ServiceLocator.RegisterSingleton<IFinishAuthentication, FinishAuthentication>();

			ServiceLocator.RegisterSingleton<IDocumentValidator, DocumentValidator>();
			ServiceLocator.RegisterSingleton<IUploadTempDocument, UploadTempDocument>();
			ServiceLocator.RegisterSingleton<IDeleteFileHelper, DeleteFileHelper>();

			ServiceLocator.RegisterSingleton<IUserFieldsValidator, UserFieldsValidator>();
			ServiceLocator.RegisterSingleton<IUpdateUserProcess, UpdateUserProcess>();

			ServiceLocator.RegisterSingleton<IFindSignerHelper, FindSignerHelper>();

			ServiceLocator.RegisterSingleton<ITaskElementsValidator, TaskElementsValidator>();
			ServiceLocator.RegisterSingleton<ICreateTaskProcess, CreateTaskProcess>();
			ServiceLocator.RegisterSingleton<IUploadDocumentForSign, UploadDocumentForSign>();

			ServiceLocator.RegisterSingleton<IRemoveTaskSigners, RemoveTaskSigners>();
			ServiceLocator.RegisterSingleton<IRemoveDocumentInfo, RemoveDocumentInfo>();
			ServiceLocator.RegisterSingleton<IRevokeTaskStatus, RevokeTaskStatus>();

			ServiceLocator.RegisterSingleton<ICheckSigningStatuses, CheckSigningStatuses>();
			ServiceLocator.RegisterSingleton<ICommentValidator, CommentValidator>();
			ServiceLocator.RegisterSingleton<IVisualizeSignatureProcess, VisualizeSignatureProcess>();
			ServiceLocator.RegisterSingleton<ISignTaskProcess, SignTaskProcess>();
			ServiceLocator.RegisterSingleton<IRejectTaskProcess, RejectTaskProcess>();
			ServiceLocator.RegisterSingleton<ILeaveCommentProcess, LeaveCommentProcess>();

			//Register repositories
			ServiceLocator.RegisterSingleton<IUserRepository, UserRepository>();
			ServiceLocator.RegisterSingleton<IRoleRepository, RoleRepository>();
			ServiceLocator.RegisterSingleton<IUserRoleRepository, UserRoleRepository>();
			ServiceLocator.RegisterSingleton<IDocumentInfoRepository, DocumentInfoRepository>();
			ServiceLocator.RegisterSingleton<ITaskInfoRepository, TaskInfoRepository>();
			ServiceLocator.RegisterSingleton<ITaskSignerRepository, TaskSignerRepository>();
		}
	}
}
