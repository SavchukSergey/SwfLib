using System;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Data;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcTrait {
        public static XElement ToXml(this AbcTrait trait) {
            var res = new XElement("trait",
                new XAttribute("name", trait.Name.ToXml()),
                new XAttribute("kind", trait.Kind));

            if (trait.Final) {
                res.Add(new XAttribute("final", CommonFormatter.Format(trait.Final)));
            }
            if (trait.Override) {
                res.Add(new XAttribute("override", CommonFormatter.Format(trait.Override)));
            }
            switch (trait.Kind) {
                case AsTraitKind.Slot:
                    var slot = (AbcSlotTrait)trait;
                    res.Add(new XAttribute("slotId", slot.SlotId));
                    res.Add(new XAttribute("typeName", slot.TypeName.ToXml()));
                    res.Add(new XAttribute("value", slot.Value.ToXml()));
                    break;
                case AsTraitKind.Const:
                    var con = (AbcConstTrait)trait;
                    res.Add(new XAttribute("slotId", con.SlotId));
                    res.Add(new XAttribute("typeName", con.TypeName.ToXml()));
                    res.Add(new XAttribute("value", con.Value.ToXml()));
                    break;
                case AsTraitKind.Class:
                    var cl = (AbcClassTrait)trait;
                    res.Add(new XAttribute("slotId", cl.SlotId));
                    //todo: class ref
                    break;
                case AsTraitKind.Function:
                    var func = (AbcFunctionTrait)trait;
                    res.Add(new XAttribute("slotId", func.SlotId));
                    //todo: method ref
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
            if (trait.Metadata.Count > 0) {
                res.Add(trait.Metadata.ToXml());
            }
            return res;
        }

    }
}
