using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class ExceptIfSpecificationTests
    {
        [Test]
        public void ExceptSpecification_BothSpecificationsAreTrue_EvaluatesFalse()
        {
            ISpecification<bool?> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> except = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> spec = specification.ExpectIf( except );

            spec.Matches( null ).Should().BeFalse();
        }
        
        [Test]
        public void ExceptSpecification_FirstSpecificationIsTrue_EvaluatesTrue()
        {
            ISpecification<bool?> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> except = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> spec = specification.ExpectIf( except );

            spec.Matches( null ).Should().BeTrue();
        }
        
        [Test]
        public void ExceptSpecification_FirstSpecificationIsFalse_EvaluatesFalse()
        {
            ISpecification<bool?> specification = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> except = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> spec = specification.ExpectIf( except );

            spec.Matches( null ).Should().BeFalse();
        }
        
        [Test]
        public void ExceptSpecification_BothSpecificationsAreFalse_EvaluatesFalse()
        {
            ISpecification<bool?> specification = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> except = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> spec = specification.ExpectIf( except );

            spec.Matches( null ).Should().BeFalse();
        }
    }
}