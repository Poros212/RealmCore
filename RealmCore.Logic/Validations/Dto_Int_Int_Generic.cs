using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Validations
{
    public sealed record Dto_Int_Int_Generic<T>
    {
        public bool IsOK { get; init; }
        public int ValueX { get; init; }
        public int ValueY { get; init; }
        public T? GenericObject { get; init; }
    }
}