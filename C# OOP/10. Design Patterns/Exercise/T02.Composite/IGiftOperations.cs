using System;
using System.Collections.Generic;
using System.Text;

namespace T02.Composite
{
    internal interface IGiftOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
