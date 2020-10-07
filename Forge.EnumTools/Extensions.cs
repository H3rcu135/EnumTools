using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Forge.EnumTools
{

    /// <summary>
    /// An extension method that adds new functionality to Enums.
    /// </summary>
    public static partial class EnumExtensions
    {

        /// <summary>
        /// Get the following enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to iterate through.</typeparam>
        /// <param name="enumValue">The current Enum value.</param>
        /// <returns></returns>
        public static TEnum Next<TEnum> ( this TEnum enumValue ) where TEnum : Enum
        {

            bool loop = enumValue.GetType ().GetCustomAttribute<LoopingAttribute> () != null;

            TEnum [] array = (TEnum []) Enum.GetValues ( enumValue.GetType () );

            int index = Array.IndexOf ( array, enumValue );

            return ( index == array.Length - 1 ) ? array [ loop ? 0 : array.Length - 1 ] : array [ index + 1 ];

        }

        /// <summary>
        /// Get the following enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to iterate through.</typeparam>
        /// <param name="enumValue">The current Enum value.</param>
        /// <param name="loop">Does the method loop around?</param>
        /// <returns></returns>
        public static TEnum Next<TEnum> ( this TEnum enumValue, bool loop ) where TEnum : Enum
        {

            TEnum [] array = (TEnum []) Enum.GetValues ( enumValue.GetType () );

            int index = Array.IndexOf ( array, enumValue );

            return ( index == array.Length - 1 ) ? array [ loop ? 0 : array.Length - 1 ] : array [ index + 1 ];

        }

        /// <summary>
        /// Get the preceding enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to iterate through.</typeparam>
        /// <param name="enumValue">The current Enum value.</param>
        /// <returns></returns>
        public static TEnum Prev<TEnum> ( this TEnum enumValue ) where TEnum : Enum
        {

            bool loop = enumValue.GetType ().GetCustomAttribute<LoopingAttribute> () != null;

            TEnum [] array = (TEnum []) Enum.GetValues ( enumValue.GetType () );

            int index = Array.IndexOf ( array, enumValue );

            return ( index == 0 ) ? array [ loop ? array.Length - 1 : 0 ] : array [ index - 1 ];

        }

        /// <summary>
        /// Get the preceding enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to iterate through.</typeparam>
        /// <param name="enumValue">The current Enum value.</param>
        /// <param name="loop">Does the method loop around?</param>
        /// <returns></returns>
        public static TEnum Prev<TEnum> ( this TEnum enumValue, bool loop ) where TEnum : Enum
        {

            TEnum [] array = (TEnum []) Enum.GetValues ( enumValue.GetType () );

            int index = Array.IndexOf ( array, enumValue );

            return ( index == 0 ) ? array [ loop ? array.Length - 1 : 0 ] : array [ index - 1 ];

        }

        /// <summary>
        /// Get a random enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to iterate through.</typeparam>
        /// <param name="random">The instance of random to call from.</param>
        /// <returns></returns>
        public static TEnum NextEnum<TEnum> ( this Random random ) where TEnum : Enum
        {

            TEnum [] array = (TEnum []) Enum.GetValues ( typeof ( TEnum ) );

            List<TEnum> list = new List<TEnum> ();

            foreach ( TEnum t in array )
            {

                CountAttribute attribute = typeof ( TEnum ).GetMember ( t.ToString () ).FirstOrDefault ( m => m.DeclaringType == typeof ( TEnum ) ).GetCustomAttribute<CountAttribute> ();

                if ( attribute != null )
                    for ( int i = 0; i < attribute.Count; i++ )
                        list.Add ( t );
                else
                    list.Add ( t );

            }

            return list [ random.Next ( list.Count ) ];

        }

    }

}