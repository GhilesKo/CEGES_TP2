using System;
using System.Collections.Generic;
using System.Text;

namespace CEGES_Core.Exceptions
{
    public class TooManyAnalystesEntreprisesException : Exception
    {
        public TooManyAnalystesEntreprisesException(string nomAnalyste) : base($"L'analyste {nomAnalyste} a déjà trop d'entreprises assignées") { }
    }
}
