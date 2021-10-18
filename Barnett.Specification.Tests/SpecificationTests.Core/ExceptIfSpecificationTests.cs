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
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> except = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> spec = specification.ExpectIf( except );

            spec.Matches( Unit.None ).Should().BeFalse();
        }
        
        [Test]
        public void ExceptSpecification_FirstSpecificationIsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> except = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> spec = specification.ExpectIf( except );

            spec.Matches( Unit.None ).Should().BeTrue();
        }
        
        [Test]
        public void ExceptSpecification_FirstSpecificationIsFalse_EvaluatesFalse()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> except = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> spec = specification.ExpectIf( except );

            spec.Matches( Unit.None ).Should().BeFalse();
        }
        
        [Test]
        public void ExceptSpecification_BothSpecificationsAreFalse_EvaluatesFalse()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> except = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> spec = specification.ExpectIf( except );

            spec.Matches( Unit.None ).Should().BeFalse();
        }
    }
}