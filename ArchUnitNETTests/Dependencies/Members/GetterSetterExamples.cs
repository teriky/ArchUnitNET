//  Copyright 2019 Florian Gather <florian.gather@tngtech.com>
// 	Copyright 2019 Paula Ruiz <paularuiz22@gmail.com>
// 	Copyright 2019 Fritz Brandhuber <fritz.brandhuber@tngtech.com>
// 
// 	SPDX-License-Identifier: Apache-2.0

using System;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody

namespace ArchUnitNETTests.Dependencies.Members
{
    public class GetterMethodDependencyExamples
    {
        public Guid AcceptedCase { get; } = new Guid("35353");

        public Guid FirstUnacceptedCase { get; } = Guid.NewGuid();

        public Guid SecondUnacceptedCase => Guid.NewGuid();
    }

    public class SetterMethodDependencyExamples
    {
        internal ChildField _castingLambdaPairBacking;
        internal ChildField _castingPairBacking;
        internal ChildField _constructorLambdaPairBacking;
        internal ChildField _constructorPairBacking;
        internal ChildField _methodLambdaPairBacking;
        internal ChildField _methodPairBacking;

        public PropertyType CastingPair
        {
            set { _castingPairBacking = (ChildField) value; }
        }

        public PropertyType CastingLambdaPair
        {
            set => _castingLambdaPairBacking = (ChildField) value;
        }

        public PropertyType ConstructorPair
        {
            set { _constructorPairBacking = new PropertyType(value) as ChildField; }
        }

        public PropertyType ConstructorLambdaPair
        {
            set => _constructorLambdaPairBacking = new PropertyType(value) as ChildField;
        }

        public PropertyType MethodPair
        {
            set { _methodPairBacking = ChildField.NewPropertyType(value) as ChildField; }
        }

        public PropertyType MethodLambdaPair
        {
            set { _methodLambdaPairBacking = ChildField.NewPropertyType(value) as ChildField; }
        }
    }

    public class ChildField : PropertyType
    {
        public static PropertyType NewPropertyType(object thing)
        {
            return new PropertyType(thing);
        }
    }
}