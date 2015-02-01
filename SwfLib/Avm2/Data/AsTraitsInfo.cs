namespace SwfLib.Avm2.Data {
    public struct AsTraitsInfo {
        public uint Name;
        
        public byte Flags;

        public AsSlotTraitsInfo Slot;
        
        public AsClassTraitsInfo Class;
        
        public AsFunctionTraitsInfo Function;
        
        public AsMethodTraitsInfo Method;
        
        public uint[] Metadata;

        public AsTraitKind Kind {
            get { return (AsTraitKind)(Flags & 0xF); }
            set {
                Flags = (byte)((Flags & 0xF0) | (int)value);
            }
        }

        public AsTraitAttributes Attributes {
            get { return (AsTraitAttributes)(Flags >> 4); }
            set {
                Flags = (byte)((Flags & 0xF) | (((int)value) << 4));
            }
        }

        public bool HasMetadata {
            get { return ((int)Attributes & (int)AsTraitAttributes.Metadata) != 0; }
        }
    }

    public struct AsSlotTraitsInfo {
        /// <summary>
        /// The slot_id field is an integer from 0 to N and is used to identify a position in which this trait resides. A
        /// value of 0 requests the AVM2 to assign a position. 
        /// </summary>
        public uint SlotId;

        /// <summary>
        /// This field is used to identify the type of the trait. It is an index into the multiname array of the
        /// constant_pool. A value of zero indicates that the type is the any type (*). 
        /// </summary>
        public uint TypeName;

        /// <summary>
        /// This field is an index that is used in conjunction with the vkind field in order to define a value for the
        /// trait. If it is 0, vkind is empty; otherwise it references one of the tables in the constant pool, depending on
        /// the value of vkind. 
        /// </summary>
        public uint ValueIndex;

        /// <summary>
        /// This field exists only when vindex is non-zero. It is used to determine how vindex will be interpreted.
        /// See the “Constant Kind” table above for details. 
        /// </summary>
        public AsConstantKind ValueKind;
    }

    public struct AsClassTraitsInfo {
        /// <summary>
        /// The slot_id field is an integer from 0 to N and is used to identify a position in which this trait resides. A
        /// value of 0 requests the AVM2 to assign a position. 
        /// </summary>
        public uint SlotId;

        /// <summary>
        /// The classi field is an index that points into the class array of the abcFile entry. 
        /// </summary>
        public uint Class;
    }

    public struct AsFunctionTraitsInfo {
        
        public uint SlotId;

        public uint Function;

    }

    public struct AsMethodTraitsInfo {
        
        /// <summary>
        /// The disp_id field is a compiler assigned integer that is used by the AVM2 to optimize the resolution of
        /// virtual function calls. An overridden method must have the same disp_id as that of the method in the
        /// base class. A value of zero disables this optimization. 
        /// </summary>
        public uint DispId;

        /// <summary>
        /// The method field is an index that points into the method array of the abcFile entry. 
        /// </summary>
        public uint Method;

    }
}
