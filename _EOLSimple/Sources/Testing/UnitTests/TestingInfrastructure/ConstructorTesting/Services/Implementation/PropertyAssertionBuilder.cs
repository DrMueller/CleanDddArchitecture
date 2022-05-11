using System;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation.PropertyAsserters;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation.PropertyAsserters.Implementation;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation
{
    internal class PropertyAssertionBuilder<T, TP> : IPropertyAssertionBuilder<T, TP>
    {
        private readonly Expression<Func<T, TP>> _propertyExpression;
        private readonly ConstructorPropertyMapper<T> _propertyMapper;
        private IPropertyValueAsserter<TP> _propertyAsserter = null!;

        public PropertyAssertionBuilder(ConstructorPropertyMapper<T> propertyMapper, Expression<Func<T, TP>> propertyExpression)
        {
            _propertyMapper = propertyMapper;
            _propertyExpression = propertyExpression;
        }

        public AssertionResult Assert(T objectToCheck)
        {
            var actualPropertyValue = _propertyExpression.Compile().Invoke(objectToCheck);

            return _propertyAsserter.Assert(actualPropertyValue);
        }

        public IConstructorPropertyMapper<T> WithValue(TP expectedValue)
        {
            _propertyAsserter = new EqualityAsserter<TP>(expectedValue);

            return _propertyMapper;
        }

        public IConstructorPropertyMapper<T> WithValues(TP values)
        {
            _propertyAsserter = new CollectionAsserter<TP>(values);

            return _propertyMapper;
        }
    }
}