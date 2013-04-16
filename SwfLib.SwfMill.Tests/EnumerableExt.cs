using System;
using System.Collections.Generic;
using System.Linq;

namespace SwfLib.SwfMill.Tests {
    public static class EnumerableExt {

        public static IEnumerable<TResult> FullOuterJoin<TInner, TOuter, TKey, TResult>(this IEnumerable<TInner> inner, IEnumerable<TOuter> outer,
           Func<TInner, TKey> innerKeySelector, Func<TOuter, TKey> outerKeySelector, Func<TInner, TOuter, TResult> resultSelector)
            where TInner : class
            where TOuter : class
            where TKey : class {
            IList<TOuter> outerLeft = outer.ToList();
            foreach (var innerItem in inner) {
                TKey innerKey = innerKeySelector(innerItem);
                bool hasPair = false;
                foreach (var outerItem in outer) {
                    TKey outerKey = outerKeySelector(outerItem);
                    if (innerKey.Equals(outerKey)) {
                        hasPair = true;
                        outerLeft.Remove(outerItem);
                        yield return resultSelector(innerItem, outerItem);
                    }
                }
                if (!hasPair) yield return resultSelector(innerItem, null);
            }
            foreach (var outerItem in outerLeft) {
                yield return resultSelector(null, outerItem);
            }
        }

    }
}
