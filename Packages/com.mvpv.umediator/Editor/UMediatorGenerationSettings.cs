using System;
using System.IO;
using UnityEditor;

namespace Editor.Mediator
{
    [Serializable]
    public class UMediatorGenerationSettings
    {
        public DefaultAsset SearchFolder;
        public DefaultAsset OutputFolder;
        public string Namespace;
    }
}