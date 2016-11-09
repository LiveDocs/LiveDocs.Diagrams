namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Factories
{
    using System;

    using Ploeh.AutoFixture;

    public abstract class InstanceFactory<T> : ICustomization
    {
        private IFixture fixture;

        public void Customize(IFixture fixture)
        {
            if (fixture == null)
            {
                throw new ArgumentNullException(nameof(fixture));
            }

            this.fixture = fixture;
            this.fixture.Register(this.CreateInstance);
        }

        public abstract T CreateInstance();

        protected TType CreateType<TType>()
        {
            return this.fixture.Create<TType>();
        }
    }
}