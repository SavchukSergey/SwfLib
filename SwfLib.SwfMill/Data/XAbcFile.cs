using System;
using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Data;

namespace SwfLib.SwfMill.Data {
    public static class XAbcFile {

        public const string TAG_NAME = "abcFile";

        public static XElement ToXml(AbcFileInfo abcInfo) {
            var abc = AbcFile.From(abcInfo);
            var res = new XElement(TAG_NAME,
                new XAttribute("minorVersion", abc.MinorVersion),
                new XAttribute("majorVersion", abc.MajorVersion)
            );

            if (abc.Metadata.Count > 0) {
                var xMeta = new XElement("meta");
                foreach (var meta in abc.Metadata) {
                    xMeta.Add(ToXml(meta));
                }
                res.Add(xMeta);
            }
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
            var res = new XElement("trait",
                new XAttribute("name", ToXml(trait.Name)),
                new XAttribute("kind", trait.Kind));

            switch (trait.Kind) {
                case AsTraitKind.Slot:
                    var slot = (AbcSlotTrait)trait;
                    res.Add(new XAttribute("slotId", slot.SlotId));
                    res.Add(new XAttribute("typeName", ToXml(slot.TypeName)));
                    res.Add(new XAttribute("value", ToXml(slot.Value)));
                    break;
                case AsTraitKind.Const:
                    var con = (AbcSlotTrait)trait;
                    res.Add(new XAttribute("slotId", con.SlotId));
                    res.Add(new XAttribute("typeName", ToXml(con.TypeName)));
                    res.Add(new XAttribute("value", ToXml(con.Value)));
                    break;
                case AsTraitKind.Class:
                    var cl = (AbcClassTrait)trait;
                    res.Add(new XAttribute("slotId", cl.SlotId));
                    //todo: class ref
                    break;
                case AsTraitKind.Method:
                    var met = (AbcMethodTrait)trait;
                    res.Add(new XAttribute("dispId", met.DispId));
                    //todo: method ref
                    break;
                case AsTraitKind.Getter:
                    var getter = (AbcGetterTrait)trait;
                    res.Add(new XAttribute("dispId", getter.DispId));
                    //todo: method ref
                    break;
                case AsTraitKind.Setter:
                    var setter = (AbcSetterTrait)trait;
                    res.Add(new XAttribute("dispId", setter.DispId));
                    //todo: method ref
                    break;
                default:
                    throw new Exception("unsupported trait kind " + trait.Kind);
            }
            //todo: metadata
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

        private static XElement ToXml(AbcMethodParam param) {
            var res = new XElement("param");
            res.Add(new XAttribute("type", ToXml(param.Type)));
            if (!string.IsNullOrWhiteSpace(param.Name)) {
                res.Add(new XAttribute("name", param.Name));
            }
            if (param.Default != null) {
                res.Add(new XAttribute("default", ToXml(param.Default)));
            }
            return res;
        }

        private static XElement ToXml(AbcMetadata meta) {
            var res = new XElement("meta", new XAttribute("name", meta.Name));
            if (meta.Items.Count > 0) {
                var xItems = new XElement("items");
                foreach (var item in meta.Items) {
                    xItems.Add(new XElement("item", new XAttribute("key", item.Key), new XAttribute("value", item.Value)));
                }
                res.Add(xItems);
            }
            return res;
        }

        private static string ToXml(AbcConstant value) {
            return value.ToString(); //todo:
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
