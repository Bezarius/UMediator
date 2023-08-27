using System;
using UnityEditor;

namespace Editor.Mediator
{
    [Serializable]
    public class UMediatorGenerationSettings
    {
        public DefaultAsset OutputFolder;
        public string Namespace;
    }
}