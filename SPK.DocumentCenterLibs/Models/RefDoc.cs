namespace SPK.DocumentCenterLibs.Models
{
    public class RefDoc
    {
        [RefDocField("META path")]
        public string METAPath { get; set; }

        [RefDocField("title")]
        public string Title { get; set; }

        [RefDocField("ShipmentType")]
        public string ShipmentType { get; set; }

        [RefDocField("BranchCode")]
        public string BranchCode { get; set; }

        [RefDocField("RefNo")]
        public string RefNo { get; set; }

        [RefDocField("DecNO")]
        public string DecNo { get; set; }

        [RefDocField("CommercialInvoices")]
        public string CommercialInvoices { get; set; }

        [RefDocField("CmpTaxNo")]
        public string CmpTaxNo { get; set; }

        [RefDocField("CmpBranch")]
        public string CmpBranch { get; set; }

        [RefDocField("CmpName")]
        public string CmpName { get; set; }

        [RefDocField("VesselName")]
        public string VesselName { get; set; }

        [RefDocField("VoyNumber")]
        public string VoyNumber { get; set; }

        [RefDocField("MasterBL")]
        public string MasterBL { get; set; }

        [RefDocField("HouseBL")]
        public string HouseBL { get; set; }

        [RefDocField("DestCountry")]
        public string DestCountry { get; set; }

        [RefDocField("DeptCountry")]
        public string DeptCountry { get; set; }

        [RefDocField("ETA")]
        public string ETA { get; set; }

        [RefDocField("ETD")]
        public string ETD { get; set; }

        [RefDocField("UDateDeclare")]
        public string UDateDeclare { get; set; }

        [RefDocField("UDateRelease")]
        public string UDateRelease { get; set; }

        [RefDocField("MaterialType")]
        public string MaterialType { get; set; }

        public string CSVHead()
        {
            return "META path,title,ShipmentType,BranchCode,RefNo,DecNO,CommercialInvoices,CmpTaxNo,CmpBranch,CmpName,VesselName,VoyNumber,MasterBL,HouseBL,DestCountry,DeptCountry,ETA,ETD,UDateDeclare,UDateRelease,MaterialType";
        }

        public string CSVLine()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                METAPath,
                Title,
                ShipmentType,
                BranchCode,
                RefNo,
                DecNo,
                FixComma(CommercialInvoices),
                CmpTaxNo,
                CmpBranch,
                FixComma(CmpName),
                FixComma(VesselName),
                FixComma(VoyNumber),
                FixComma(MasterBL),
                FixComma(HouseBL),
                DestCountry,
                DeptCountry,
                ETA,
                ETD,
                UDateDeclare,
                UDateRelease,
                MaterialType);
        }

        private string FixComma(string content)
        {
            if (content.IndexOf(",") > 0)
                return string.Format("\"{0}\"", content);
            else
                return content;
        }
    }
}