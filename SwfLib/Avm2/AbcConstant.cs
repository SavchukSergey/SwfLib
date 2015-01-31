using System.Globalization;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public abstract class AbcConstant {

        public static implicit operator AbcConstant(int val) {
            return new AbcConstantInt { Value = val };
        }

        public static implicit operator AbcConstant(uint val) {
            return new AbcConstantUInt { Value = val };
        }

        public static implicit operator AbcConstant(double val) {
            return new AbcConstantDouble { Value = val };
        }

        public static implicit operator AbcConstant(string val) {
            return new AbcConstantString { Value = val };
        }

        public static implicit operator AbcConstant(bool val) {
            return new AbcConstantBoolean { Value = val };
        }

        public static implicit operator AbcConstant(AbcNamespace val) {
            return new AbcConstantNamespace { Value = val };
        }

        public abstract AsConstantType Type { get; }

        public static AbcConstantNull Null = new AbcConstantNull();

        public static AbcConstantUndefined Undefined = new AbcConstantUndefined();

    }

    public class AbcConstantInt : AbcConstant {

        public int Value { get; set; }

        public override string ToString() {
            return "int: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Integer; }
        }
    }

    public class AbcConstantUInt : AbcConstant {

        public uint Value { get; set; }

        public override string ToString() {
            return "uint: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.UInteger; }
        }
    }

    public class AbcConstantDouble : AbcConstant {

        public double Value { get; set; }

        public override string ToString() {
            return "double: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Double; }
        }
    }

    public class AbcConstantString : AbcConstant {

        public string Value { get; set; }

        public override string ToString() {
            return "string: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.String; }
        }
    }

    public class AbcConstantBoolean : AbcConstant {

        public bool Value { get; set; }

        public override string ToString() {
            return "boolean: " + Value.ToString(CultureInfo.InvariantCulture);
        }

        public override AsConstantType Type {
            get { return Value ? AsConstantType.True : AsConstantType.False; }
        }
    }

    public class AbcConstantNull : AbcConstant {

        public override string ToString() {
            return "null";
        }

        public override AsConstantType Type {
            get { return AsConstantType.Null; }
        }
    }

    public class AbcConstantUndefined : AbcConstant {

        public override string ToString() {
            return "undefined";
        }

        public override AsConstantType Type {
            get { return AsConstantType.Undefined; }
        }
    }

    public class AbcConstantNamespace : AbcConstant {

        public AbcNamespace Value { get; set; }

        public override string ToString() {
            return "namespace: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Namespace; }
        }
    }
}
