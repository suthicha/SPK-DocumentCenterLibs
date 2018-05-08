using SPK.DocumentCenterLibs.Models;
using System.Collections.Generic;

namespace SPK.DocumentCenterLibs
{
    public interface IDocumentControl
    {
        void ExportCSV(string output, List<RefDoc> items);
    }
}