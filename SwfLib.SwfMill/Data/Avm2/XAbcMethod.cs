using System;
using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Avm2;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcMethod {

        public static XElement ToXml(this AbcMethod method) {
            var res = new XElement("method");
            if (!string.IsNullOrWhiteSpace(method.Name)) {
                res.Add(new XAttribute("name", method.Name));
            }

            var retType = method.ReturnType.ToXml();
            if (!string.IsNullOrWhiteSpace(retType)) {
                res.Add(new XAttribute("returns", retType));
            }

            if (method.NeedArguments) {
                res.Add(new XAttribute("needArguments", CommonFormatter.Format(method.NeedArguments)));
            }
            if (method.NeedActivation) {
                res.Add(new XAttribute("needActivation", CommonFormatter.Format(method.NeedActivation)));
            }
            if (method.NeedRest) {
                res.Add(new XAttribute("needRest", CommonFormatter.Format(method.NeedRest)));
            }
            if (method.SetDxns) {
                res.Add(new XAttribute("setDxns", CommonFormatter.Format(method.SetDxns)));
            }
            if (method.IgnoreRest) {
                res.Add(new XAttribute("ignoreRest", CommonFormatter.Format(method.IgnoreRest)));
            }
            if (method.Native) {
                res.Add(new XAttribute("native", CommonFormatter.Format(method.Native)));
            }

            if (method.Params.Count > 0) {
                var xParams = new XElement("params");
                foreach (var param in method.Params) {
                    xParams.Add(ToXml(param));
                }
                res.Add(xParams);
            }
            if (method.Body != null) {
                res.Add(ToXml(method.Body));
            }

            return res;
        }

        public static XElement ToXml(this AbcMethodBody body) {
            var labels = new HashSet<uint>();
            body.ToXml(labels);
            return body.ToXml(labels);
        }

        public static XElement ToXml(this AbcMethodBody body, ISet<uint> labels) {
            var xBody = new XElement("body",
                new XAttribute("maxStack", body.MaxStack),
                new XAttribute("maxScopeDepth", body.MaxScopeDepth),
                new XAttribute("initScopeDepth", body.InitScopeDepth),
                new XAttribute("localCount", body.LocalCount)
            );
            if (body.Traits.Count > 0) {
                xBody.Add(body.Traits.ToXml());
            }

            Func<uint, string> labelFormatter = target => {
                labels.Add(target);
                return string.Format("lbl_{0:x6}", target);
            };
            var writer = new XAbcOpcodeWriter(labelFormatter);

            var xCode = new XElement("code");
            foreach (var instruction in body.Code) {
                var xInstruction = instruction.Opcode.AcceptVisitor(writer, instruction);
                if (labels.Contains(instruction.Offset)) {
                    xInstruction.Add(new XAttribute("label", string.Format("lbl_{0:x6}", instruction.Offset)));
                }
                xCode.Add(xInstruction);
            }
            xBody.Add(xCode);

            if (body.Exceptions.Count != 0) {
                var xExcs = new XElement("exceptions");
                foreach (var exc in body.Exceptions) {
                    var xExc = new XElement("exception",
                        new XAttribute("from", labelFormatter(exc.From)),
                        new XAttribute("to", labelFormatter(exc.To)),
                        new XAttribute("target", labelFormatter(exc.Target)),
                        new XAttribute("excType", exc.ExceptionType.ToXml()),
                        new XAttribute("varName", exc.VariableName.ToXml()));
                    xExcs.Add(xExc);
                }
                xBody.Add(xExcs);
            }
            return xBody;
        }

        public static XElement ToXml(AbcMethodParam param) {
            var res = new XElement("param");
            res.Add(new XAttribute("type", param.Type.ToXml()));
            if (!string.IsNullOrWhiteSpace(param.Name)) {
                res.Add(new XAttribute("name", param.Name));
            }
            if (param.Default != null) {
                res.Add(new XAttribute("default", param.Default.ToXml()));
            }
            return res;
        }

    }
}
