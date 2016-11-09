namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Attributes
{
    using System;
    using System.Reflection;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Xunit2;

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CustomizeWithAttribute : CustomizeAttribute
    {
        private readonly Type type;

        public CustomizeWithAttribute(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(ICustomization).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(
                            $"Type must implement {typeof(ICustomization).Name}");
            }

            this.type = type;
        }

        public override ICustomization GetCustomization(ParameterInfo parameter)
        {
            return Activator.CreateInstance(this.type) as ICustomization;            
        }
    }
}