namespace LiveDocs.Diagrams.Selenium.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public static class PropertyHelper
    {
        public static string GetPropertyName<TPage>(Expression<Func<TPage, IWebElement>> propertySelector)
        {
            if (propertySelector == null)
            {
                throw new ArgumentNullException(nameof(propertySelector));
            }

            var expression = propertySelector.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("Expression is not a property.");
            }

            return expression.Member.Name;
        }

        public static FindsByAttribute GetFindByAttribute<TPage>(Expression<Func<TPage, IWebElement>> propertySelector)
        {
            var propertyName = GetPropertyName(propertySelector);
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return null;
            }

            var propertyInfo = typeof(TPage).GetProperty(propertyName);
            return propertyInfo?.GetCustomAttribute(typeof(FindsByAttribute)) as FindsByAttribute;
        }

        public static string GetElementDetails<TPage>(Expression<Func<TPage, IWebElement>> propertySelector)
        {
            var propertyName = GetPropertyName(propertySelector);
            var findsByAttribute = GetFindByAttribute(propertySelector);
            return findsByAttribute == null
                ? $"{propertyName}"
                : $"{propertyName} ({findsByAttribute.How} '{findsByAttribute.Using}')";
        }
    }
}