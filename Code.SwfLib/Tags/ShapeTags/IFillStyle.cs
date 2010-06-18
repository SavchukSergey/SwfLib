using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Tags.ShapeTags {
    public interface IFillStyle {

        FillStyleType Type { get; }

        object AcceptVisitor(IFillStyleVisitor visitor);

    }
}
