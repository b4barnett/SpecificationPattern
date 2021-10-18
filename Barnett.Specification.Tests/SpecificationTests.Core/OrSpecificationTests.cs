﻿using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class OrTests
    {
        [Test]
        public void OrSpecification_BothSpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> OrSpecification = null;
            
            OrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_OnlyLeftSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> OrSpecification = null;
            
            OrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_OnlyRightSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> OrSpecification = null;
            
            OrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_BothSpecificationFalse_EvaluatesFalse()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> OrSpecification = null;
            
            OrSpecification.Matches( null ).Should().BeFalse();
        }

        [Test]
        public void OrExtension_CreatesOrSpecification()
        {
            //force failure
            false.Should().BeTrue();
        }
    }
}