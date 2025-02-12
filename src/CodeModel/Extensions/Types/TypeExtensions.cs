﻿using System;
using System.Linq;
using Type = Typewriter.CodeModel.Type;

namespace Typewriter.Extensions.Types
{
    /// <summary>
    /// Extension methods for working with types.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns the name of the type without [].
        /// </summary>
        /// <param name="type"><see cref="Type"/>.</param>
        public static string ClassName(this Type type)
        {
            return type.Name.TrimEnd('[', ']');
        }

        /// <summary>
        /// The default value of the type.
        /// (Dictionary types returns {}, enumerable types returns [],
        /// boolean types returns false, numeric types returns 0, void returns void(0),
        /// Guid types return empty guid string, Date types return new Date(0),
        /// all other types return null).
        /// </summary>
        /// <param name="type"><see cref="Type"/>.</param>
#pragma warning disable MA0051 // Method is too long
        public static string Default(this Type type)
#pragma warning restore MA0051 // Method is too long
        {
            if (type.IsNullable)
            {
                return "null";
            }

#pragma warning disable S125

            // Dictionary = { [key: type]: type; }
#pragma warning restore S125
            if (type.Name.StartsWith("{", StringComparison.OrdinalIgnoreCase) && !type.IsValueTuple)
            {
                return "{}";
            }

            if (type.IsEnumerable)
            {
                return "[]";
            }

            if (type.Name.Equals("boolean", StringComparison.OrdinalIgnoreCase))
            {
                return "false";
            }

            if (type.Name.Equals("number", StringComparison.OrdinalIgnoreCase))
            {
                return "0";
            }

            if (type.Name.Equals("void", StringComparison.OrdinalIgnoreCase))
            {
                return "void(0)";
            }

            var slc = type.Settings?.StringLiteralCharacter ?? '"';
            if (type.IsGuid)
            {
                return $"{slc}00000000-0000-0000-0000-00000000000{slc}";
            }

            if (type.IsDate)
            {
                return "new Date()";
            }

            if (type.IsEnum)
            {
                return type.DefaultValue;
            }

            if (type.IsTimeSpan)
            {
                return $"{slc}00:00:00{slc}";
            }

            if (type.Name.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                return $"{slc}{slc}";
            }

            return $"new {type.Name}()";
        }

        /// <summary>
        /// Returns the first TypeArgument of a generic type or the type itself if it's not generic.
        /// </summary>
        /// <param name="type"><see cref="Type"/>.</param>
        public static Type Unwrap(this Type type)
        {
            return type.IsGeneric ? type.TypeArguments[0] : type;
        }
    }
}
