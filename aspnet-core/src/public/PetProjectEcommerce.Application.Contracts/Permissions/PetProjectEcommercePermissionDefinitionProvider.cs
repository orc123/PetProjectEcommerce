using PetProjectEcommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PetProjectEcommerce.Permissions;

public class PetProjectEcommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PetProjectEcommercePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PetProjectEcommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PetProjectEcommerceResource>(name);
    }
}
