using UnityEditor;
using UnityEngine;

namespace Editor.Mediator
{
    public static class UMediatorGenerator
    {
        public static void Run()
        {
            var settings = UMediatorGeneratorSettingsScriptableObject.Instance;
            
            var @namespace = settings.Settings.Namespace;
            var inputRelativePath = AssetDatabase
                .GetAssetPath(settings.Settings.SearchFolder)
                .Replace("Assets/", "./");
            var outputRelativePath = AssetDatabase
                .GetAssetPath(settings.Settings.OutputFolder)
                .Replace("Assets/", "./");
            
            var result = CmdCommandExecutor.Execute("dotnet",
                $"umgen \"{inputRelativePath}\" \"{outputRelativePath}\" \"{@namespace}\"");
            
            Debug.Log("Generating VContainerCustomMediatorRegistration.cs result: " + result);
            AssetDatabase.Refresh();
        }
    }
}