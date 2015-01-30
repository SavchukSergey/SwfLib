using System.Globalization;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcMethodParam {

        public string Name { get; set; }

        public AbcMultiname Type { get; set; }

        public AbcMethodParamDefaultValue Default { get; set; }

    }

    public abstract class AbcMethodParamDefaultValue {

        public static implicit operator AbcMethodParamDefaultValue(int val) {
            return new AbcMethodParamInt { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(uint val) {
            return new AbcMethodParamUInt { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(double val) {
            return new AbcMethodParamDouble { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(string val) {
            return new AbcMethodParamString { Value = val };
        }

        public static implicit operator AbcMethodParamDefaultValue(bool val) {
            return new AbcMethodParamBoolean { Value = val };
        }

        public abstract AsConstantType Type { get; }

        public static AbcMethodParamNull Null = new AbcMethodParamNull();

        public static AbcMethodParamUndefined Undefined = new AbcMethodParamUndefined();

    }

    public class AbcMethodParamInt : AbcMethodParamDefaultValue {

        public int Value { get; set; }

        public override string ToString() {
            return "int: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Integer; }
        }
    }

    public class AbcMethodParamUInt : AbcMethodParamDefaultValue {

        public uint Value { get; set; }

        public override string ToString() {
            return "uint: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.UInteger; }
        }
    }

    public class AbcMethodParamDouble : AbcMethodParamDefaultValue {

        public double Value { get; set; }

        public override string ToString() {
            return "double: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Double; }
        }
    }

    public class AbcMethodParamString : AbcMethodParamDefaultValue {

        public string Value { get; set; }

        public override string ToString() {
            return "string: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.String; }
        }
    }

    public class AbcMethodParamBoolean : AbcMethodParamDefaultValue {

        public bool Value { get; set; }

        public override string ToString() {
            return "boolean: " + Value.ToString(CultureInfo.InvariantCulture);
        }

        public override AsConstantType Type {
            get { return Value ? AsConstantType.True : AsConstantType.False; }
        }
    }

    public class AbcMethodParamNull : AbcMethodParamDefaultValue {

        public override string ToString() {
            return "null";
        }

        public override AsConstantType Type {
            get { return AsConstantType.Null; }
        }
    }

    public class AbcMethodParamUndefined : AbcMethodParamDefaultValue {

        public override string ToString() {
            return "undefined";
        }

        public override AsConstantType Type {
            get { return AsConstantType.Undefined; }
        }
    }

    public class AbcMethodParamNamespace : AbcMethodParamDefaultValue {

        public AbcNamespace Value { get; set; }

        public override string ToString() {
            return "namespace: " + Value;
        }

        public override AsConstantType Type {
            get { return AsConstantType.Namespace; }
        }
    }
}
