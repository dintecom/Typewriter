﻿using Typewriter.CodeModel.Attributes;

namespace Typewriter.CodeModel
{
    /// <summary>
    /// Represents a property.
    /// </summary>
    [Context(nameof(Property), "Properties")]
    public abstract class Property : Item
    {
        /// <summary>
        /// All attributes defined on the property.
        /// </summary>
        public abstract IAttributeCollection Attributes { get; }

        /// <summary>
        /// The XML documentation comment of the property.
        /// </summary>
        public abstract DocComment DocComment { get; }

        /// <summary>
        /// The full original name of the property including namespace and containing class names.
        /// </summary>
        public abstract string FullName { get; }

        /// <summary>
        /// Determines if the property has a getter.
        /// </summary>
        public abstract bool HasGetter { get; }

        /// <summary>
        /// Determines if the property has a setter.
        /// </summary>
        public abstract bool HasSetter { get; }

        /// <summary>
        /// Determines if the property is abstract.
        /// </summary>
        public abstract bool IsAbstract { get; }

        /// <summary>
        /// Determines if the property is virtual.
        /// </summary>
        public abstract bool IsVirtual { get; }

        /// <summary>
        /// The name of the property (camelCased).
        /// </summary>
#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable IDE1006 // Naming Styles

        // ReSharper disable once InconsistentNaming
        public abstract string name { get; }
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// The name of the property.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The parent context of the property.
        /// </summary>
        public abstract Item Parent { get; }

        /// <summary>
        /// The type of the property.
        /// </summary>
        public abstract Type Type { get; }

        /// <summary>
        /// Converts the current instance to string.
        /// </summary>
        public static implicit operator string(Property instance)
        {
            return instance.ToString();
        }
    }
}