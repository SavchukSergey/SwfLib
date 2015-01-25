namespace SwfLib.Avm2 {
    public class AsTraitsVisitor {
        AbcFile abc;

        public AsTraitsVisitor(AbcFile abc) {
            this.abc = abc;
        }

        //todo:
        //final void run()
        //{
        //    foreach (ref v; abc.Instances)
        //        visitTraits(v.Traits);
        //    foreach (ref v; abc.Classes)
        //        visitTraits(v.Traits);
        //    foreach (ref v; abc.Scripts)
        //        visitTraits(v.Traits);
        //    foreach (ref v; abc.Bodies)
        //        visitTraits(v.Traits);
        //}

        //final void visitTraits(ABCFile.TraitsInfo[] Traits)
        //{
        //    foreach (ref trait; Traits)
        //        visitTrait(trait);
        //}

        //abstract void visitTrait(ref ABCFile.TraitsInfo trait);
    }
}
