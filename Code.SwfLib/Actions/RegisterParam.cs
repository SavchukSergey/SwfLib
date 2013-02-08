namespace Code.SwfLib.Actions {
    public class RegisterParam {

        public RegisterParam() {

        }

        public RegisterParam(byte reg, string name) {
            Register = reg;
            Name = name;
        }

        public byte Register;

        public string Name;

    }
}
