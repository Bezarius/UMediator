namespace Editor.Mediator
{
    public static class NPMHelper
    {
        public static bool CheckPackageExists(string packageName)
        {
            string output = CmdCommandExecutor.Execute("dotnet", $"tool list --global");
            return output.Contains(packageName.ToLower());
        }

        public static string InstallPackage(string packageName, string version = null)
        {
            string args = $"tool install --global {packageName}";
            if (!string.IsNullOrEmpty(version))
            {
                args += $" --version {version}";
            }

            return CmdCommandExecutor.Execute("dotnet", args);
        }

        public static string DeletePackage(string packageName)
        {
            string args = $"tool uninstall --global {packageName}";
            return CmdCommandExecutor.Execute("dotnet", args);
        }
    }
}