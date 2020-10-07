#region Using Directives

using System;

#endregion

namespace Forge.EnumTools
{

    /// <summary>
    /// An extension attribute that allows Next and Prev to loop to the oppoiste end of the array while iterating.
    /// </summary>
    [AttributeUsage ( AttributeTargets.Enum, AllowMultiple = false, Inherited = false )]
    public class LoopingAttribute : Attribute { }

}