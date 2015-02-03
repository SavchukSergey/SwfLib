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

        public abstract AsConstantKind Type { get; }

        public static AbcConstantNull Null = new AbcConstantNull();

        public static AbcConstantUndefined Undefined = new AbcConstantUndefined();

    }

    public class AbcConstantInt : AbcConstant {

        public int Value { get; set; }

        public override string ToString() {
            return "int: " + Value;
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.Integer; }
        }
    }

    public class AbcConstantUInt : AbcConstant {

        public uint Value { get; set; }

        public override string ToString() {
            return "uint: " + Value;
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.UInteger; }
        }
    }

    public class AbcConstantDouble : AbcConstant {

        public double Value { get; set; }

        public override string ToString() {
            return "double: " + Value;
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.Double; }
        }
    }

    public class AbcConstantString : AbcConstant {

        public string Value { get; set; }

        public override string ToString() {
            return "string: " + Value;
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.String; }
        }
    }

    public class AbcConstantBoolean : AbcConstant {

        public bool Value { get; set; }

        public override string ToString() {
            return "boolean: " + Value.ToString(CultureInfo.InvariantCulture);
        }

        public override AsConstantKind Type {
            get { return Value ? AsConstantKind.True : AsConstantKind.False; }
        }
    }

    public class AbcConstantNull : AbcConstant {

        public override string ToString() {
            return "null";
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.Null; }
        }
    }

    public class AbcConstantUndefined : AbcConstant {

        public override string ToString() {
            return "undefined";
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.Undefined; }
        }
    }

    public class AbcConstantNamespace : AbcConstant {

        public AbcNamespace Value { get; set; }

        public override string ToString() {
            return "namespace: " + Value;
        }

        public override AsConstantKind Type {
            get { return AsConstantKind.Namespace; }
        }
    }
}
