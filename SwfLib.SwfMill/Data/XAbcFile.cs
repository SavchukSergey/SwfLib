using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Data;

namespace SwfLib.SwfMill.Data {
    public static class XAbcFile {

        public static XElement ToXml(AbcFileInfo abcInfo) {
            var abc = AbcFile.From(abcInfo);
            var res = new XElement("abcFile",
                new XAttribute("minorVersion", abc.MinorVersion),
                new XAttribute("majorVersion", abc.MajorVersion)
            );

            if (abc.Classes.Count > 0) {
                var xClasses = new XElement("classes");
                foreach (var cls in abc.Classes) {
                    xClasses.Add(ToXml(cls));
                }
                res.Add(xClasses);
            }

            if (abc.Scripts.Count > 0) {
                var xScripts = new XElement("scripts");
                foreach (var script in abc.Scripts) {
                    xScripts.Add(ToXml(script));
                }
                res.Add(xScripts);
            }

            if (abc.Methods.Count > 0) {
                var xMethods = new XElement("methods");
                foreach (var method in abc.Methods) {
                    xMethods.Add(ToXml(method));
                }
                res.Add(xMethods);
            }

            return res;
        }

        private static XElement ToXml(IEnumerable<AbcTrait> traits) {
            var res = new XElement("traits");
            foreach (var trait in traits) {
                res.Add(ToXml(trait));
            }
            return res;
        }

        private static XElement ToXml(AbcTrait trait) {
            var res = new XElement("trait");
            //todo:
            return res;
        }

        private static XElement ToXml(AbcMethod method) {
            var res = new XElement("method");
            if (!string.IsNullOrWhiteSpace(method.Name)) {
                res.Add(new XAttribute("name", method.Name));
            }

            var retType = ToXml(method.ReturnType);
            if (!string.IsNullOrWhiteSpace(retType)) {
                res.Add(new XAttribute("returns", retType));
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

        private static XElement ToXml(AbcMethodParam param) {
            var res = new XElement("param");
            res.Add(new XAttribute("type", ToXml(param.Type)));
            if (!string.IsNullOrWhiteSpace(param.Name)) {
                res.Add(new XAttribute("name", param.Name));
            }
            return res;
        }

        private static XElement ToXml(AbcMethodBody body) {
            var xBody = new XElement("body",
                new XAttribute("maxStack", body.MaxStack),
                new XAttribute("maxScopeDepth", body.MaxScopeDepth),
                new XAttribute("initScopeDepth", body.InitScopeDepth),
                new XAttribute("localCount", body.LocalCount)
            );
            if (body.Traits.Count > 0) {
                xBody.Add(ToXml(body.Traits));
            }
            return xBody;
        }

        private static XElement ToXml(AbcClass cls) {
            var res = new XElement("class");
            res.Add(ToXml(cls.Instance));

            if (cls.Traits.Count > 0) {
                res.Add(ToXml(cls.Traits));
            }
            return res;
        }

        private static XElement ToXml(AbcScript script) {
            var res = new XElement("script");
            if (script.Traits.Count > 0) {
                res.Add(ToXml(script.Traits));
            }
            return res;
        }

        private static XElement ToXml(AbcInstance instance) {
            var xInstance = new XElement("instance");
            xInstance.Add(new XAttribute("name", ToXml(instance.Name)));
            xInstance.Add(new XAttribute("extends", ToXml(instance.SuperName)));
            if (instance.Traits.Count > 0) {
                xInstance.Add(ToXml(instance.Traits));
            }

            if (instance.Interfaces.Count > 0) {
                var xInterfaces = new XElement("implements");
                foreach (var inter in instance.Interfaces) {
                    xInterfaces.Add(new XElement("interface", inter));
                }
                xInstance.Add(xInterfaces);
            }

            return xInstance;
        }

        private static string ToXml(AbcMultiname multiname) {
            if (multiname is AbcMultinameVoid) return "";
            if (multiname is AbcMultinameAny) return "*";
            return multiname.ToString();
        }
    }
}
