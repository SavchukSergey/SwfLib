using System;
using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Data;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcCommon {
        
        public static string ToXml(this AbcMultiname multiname) {
            if (multiname is AbcMultinameVoid) return "";
            if (multiname is AbcMultinameAny) return "*";
            return multiname.ToString();
        }

        public static XElement ToXml(this IEnumerable<AbcTrait> traits) {
            var res = new XElement("traits");
            foreach (var trait in traits) {
                res.Add(ToXml(trait));
            }
            return res;
        }

        public static XElement ToXml(this AbcTrait trait) {
            var res = new XElement("trait",
                new XAttribute("name", trait.Name.ToXml()),
                new XAttribute("kind", trait.Kind));

            switch (trait.Kind) {
                case AsTraitKind.Slot:
                    var slot = (AbcSlotTrait)trait;
                    res.Add(new XAttribute("slotId", slot.SlotId));
                    res.Add(new XAttribute("typeName", slot.TypeName.ToXml()));
                    res.Add(new XAttribute("value", ToXml(slot.Value)));
                    break;
                case AsTraitKind.Const:
                    var con = (AbcConstTrait)trait;
                    res.Add(new XAttribute("slotId", con.SlotId));
                    res.Add(new XAttribute("typeName", con.TypeName.ToXml()));
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

        public static string ToXml(this AbcConstant value) {
            return value.ToString(); //todo:
        }

    }
}
