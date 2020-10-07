#region Using Directives

using System;

#endregion

namespace Forge.EnumTools
{

    /// <summary>
    /// An extension attribute allowing a user to change the odds of selecting a random element
    /// </summary>
    [AttributeUsage ( AttributeTargets.Field, AllowMultiple = false, Inherited = false )]
    public class CountAttribute : Attribute
    {

        #region Fields

        private readonly int m_Count;

        #endregion

        #region Properties

        /// <summary>
        /// The number of times this value exists.
        /// </summary>
        public int Count => m_Count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Count with a valus of count.
        /// </summary>
        /// <param name="count">The number of times the value exists.</param>
        public CountAttribute ( int count ) => m_Count = count;

        /// <summary>
        /// Initializes a new instance of Count with a valus of 1.
        /// </summary>
        public CountAttribute () => m_Count = 1;

        #endregion

    }

}