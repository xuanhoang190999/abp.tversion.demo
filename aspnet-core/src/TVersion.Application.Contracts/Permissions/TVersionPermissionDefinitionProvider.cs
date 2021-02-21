using TVersion.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TVersion.Permissions
{
    public class TVersionPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TVersionPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(TVersionPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TVersionResource>(name);
        }
    }
}
