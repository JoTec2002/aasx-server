namespace AasSecurity.Models
{
    internal class Permission
    {
        internal KindOfPermissionEnum? KindOfPermission { get; set; }
        //TODO (jtikekar, 0000-00-00): change to string
        internal List<string> Permissions { get; set; }
    }
}