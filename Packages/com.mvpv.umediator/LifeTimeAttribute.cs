using System;

namespace Mediator
{
    public enum OperationLifeTime
    {
        Transient,
        Singleton
    }
    
    [AttributeUsage(AttributeTargets.Class)]
    public partial class LifeTimeAttribute : Attribute
    {
        public OperationLifeTime LifeTime { get; }

        public LifeTimeAttribute(OperationLifeTime lifeTime)
        {
            LifeTime = lifeTime;
        }
    }
}