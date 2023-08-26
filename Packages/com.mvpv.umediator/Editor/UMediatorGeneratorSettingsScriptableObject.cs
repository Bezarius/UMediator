using UnityEngine;

namespace Editor.Mediator
{
    [CreateAssetMenu(fileName = "UMediator", menuName = "Settings/UMediator")]
    public class UMediatorGeneratorSettingsScriptableObject : ScriptableObject
    {
        public UMediatorGenerationSettings Settings;

        private static UMediatorGeneratorSettingsScriptableObject _instance;

        public static UMediatorGeneratorSettingsScriptableObject Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = Resources.Load<UMediatorGeneratorSettingsScriptableObject>("UMediator");
                if (_instance == null)
                {
                    Debug.LogError(
                        "UMediatorGenerationSettings asset not found. Make sure to create a UMediatorGenerationSettings asset.");
                }

                return _instance;
            }
        }
    }
}