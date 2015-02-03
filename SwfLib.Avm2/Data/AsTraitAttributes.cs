using System;

namespace SwfLib.Avm2.Data {
    [Flags]
    public enum AsTraitAttributes : byte {
        /// <summary>
        /// Is used with Trait_Method, Trait_Getter and Trait_Setter. It marks a method that cannot be overridden by a sub-class
        /// </summary>
        Final = 1,
        
        /// <summary>
        /// Is used with Trait_Method, Trait_Getter and Trait_Setter. It marks a method that has been overridden in this class
        /// </summary>
        Override = 2,
        
        /// <summary>
        /// Is used to signal that the fields metadata_count and metadata follow the data field in the traits_info entry
        /// </summary>
        Metadata = 4
    }
}
