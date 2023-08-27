using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Mediator
{
    public class UMediatorSettingsProvider : SettingsProvider
    {
        public const string PkgName = "mediatorregistrations.generator";

        private SerializedObject _serializedObject;
        private SerializedProperty _settings;
        private bool _generatorIsInstalled = false;


        private const string PreferencesPath = "Project/UMediator";

        [SettingsProvider]
        public static SettingsProvider CreatePreferencesProvider()
        {
            var provider = new UMediatorSettingsProvider(PreferencesPath, SettingsScope.Project);
            return provider;
        }

        private UMediatorSettingsProvider(string path, SettingsScope scope)
            : base(path, scope)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            var settings = UMediatorGeneratorSettingsScriptableObject.Instance;
            if (settings == null)
            {
                Debug.LogError("UMediatorSettings not found, create it.");
            }

            _serializedObject = new SerializedObject(settings);
            _settings = _serializedObject.FindProperty(nameof(UMediatorGeneratorSettingsScriptableObject.Settings));
            _generatorIsInstalled = NPMHelper.CheckPackageExists(PkgName);
        }


        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.LabelField("UMediator Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_settings, true);
            if (EditorGUI.EndChangeCheck())
            {
                _serializedObject.ApplyModifiedProperties();
            }
            
            if (!_generatorIsInstalled)
            {
                if (GUILayout.Button("Install"))
                {
                    NPMHelper.InstallPackage(PkgName);
                    _generatorIsInstalled = NPMHelper.CheckPackageExists(PkgName);
                }
            }
            else
            {
                if (GUILayout.Button("Generate"))
                {
                    UMediatorGenerator.Run();
                }

                if (GUILayout.Button("Remove"))
                {
                    NPMHelper.DeletePackage(PkgName);
                    _generatorIsInstalled = NPMHelper.CheckPackageExists(PkgName);
                }
            }
        }
    }
}