using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.PermitToWork
{
    public class PPERequired
    {
        public string PermitCode { get; set; }
        public Boolean Helmet { get; set; }
       
        public string HelmeteRmark { get; set; }

        public Boolean SafetyGlasses { get; set; }

        public string SafetyGlassesRemark { get; set; }

        public Boolean FaceShield { get; set; }

        public string FaceShieldRemark { get; set; }

        public Boolean SafetyGoggles { get; set; }

        public string SafetyGogglesRemark { get; set; }

        public Boolean EarPlugs { get; set; }

        public string EarPlugsRemark { get; set; }

        public Boolean EarMuffs { get; set; }
        public string EarMuffsRemark { get; set; }

        public Boolean DustMasks { get; set; }
        public string DustMasksRemark { get; set; }

        public Boolean GasMasks { get; set; }

        public string GasMasksRemark { get; set; }

        public Boolean HandGlovesChemicals { get; set; }

        public string HandGlovesChemicalsRemark { get; set; }

        public Boolean HandGlovesElectrical { get; set; }

        public string HandGlovesElectricalRemark { get; set; }

        public Boolean HandGlovesOthers { get; set; }

        public string HandGlovesOthersRemark { get; set; }

        public Boolean SafetyNet { get; set; }

        public string SafetyNetRemark { get; set; }

        public Boolean SafetyShoes { get; set; }

        public string SafetyShoesRemark { get; set; }

        public Boolean GumBoots { get; set; }

        public string GumBootsRemark { get; set; }

        public Boolean CrawlingNet { get; set; }

        public string CrawlingNetRemark { get; set; }

        public Boolean Apron { get; set; }

        public string ApronRemark { get; set; }

        public Boolean SafetyBelt { get; set; }

        public string SafetyBeltRemark { get; set; }

        public Boolean SCBA { get; set; }

        public string SCBARemark { get; set; }

        public void SetPPERequiredToData(PPERequired ppeRequired )
        {
            DataTable dt = CreateDatatable(ppeRequired);
            Resources.Instance.AddPPERequired(dt);
        }
        private DataTable CreateDatatable(PPERequired ppeReq)
        {
            DataTable ppeDt = null;
            ppeDt= new DataTable();
            ppeDt.Columns.Add("PermitCode", typeof(string));
            ppeDt.Columns.Add("Helmet", typeof(bool));
            ppeDt.Columns.Add("SafetyGlasses", typeof(bool));
            ppeDt.Columns.Add("FaceShield", typeof(bool));
            ppeDt.Columns.Add("SafetyGoggles", typeof(bool));
            ppeDt.Columns.Add("EarPlugs", typeof(bool));
            ppeDt.Columns.Add("EarMuffs", typeof(bool));
            ppeDt.Columns.Add("DustMasks", typeof(bool));
            ppeDt.Columns.Add("GasMasks", typeof(bool));
            ppeDt.Columns.Add("HandGlovesChemicals", typeof(bool));
            ppeDt.Columns.Add("HandGlovesElectrical", typeof(bool));
            ppeDt.Columns.Add("HandGlovesOthers", typeof(bool));
            ppeDt.Columns.Add("SafetyNet", typeof(bool));
            ppeDt.Columns.Add("SafetyShoes", typeof(bool));
            ppeDt.Columns.Add("GumBoots", typeof(bool));
            ppeDt.Columns.Add("CrawlingNet", typeof(bool));
            ppeDt.Columns.Add("Apron", typeof(bool));
            ppeDt.Columns.Add("SafetyBelt", typeof(bool));
            ppeDt.Columns.Add("SCBA", typeof(bool));

            DataRow dr = ppeDt.NewRow();
            dr["PermitCode"]=ppeReq.PermitCode;
            dr["Helmet"] = ppeReq.Helmet;
            dr["SafetyGlasses"] = ppeReq.SafetyGlasses;
            dr["FaceShield"] = ppeReq.FaceShield;
            dr["SafetyGoggles"] = ppeReq.SafetyGoggles;
            dr["EarPlugs"] = ppeReq.EarPlugs;
            dr["EarMuffs"] = ppeReq.EarMuffs;
            dr["DustMasks"] = ppeReq.DustMasks;
            dr["GasMasks"] = ppeReq.GasMasks;
            dr["HandGlovesChemicals"] =ppeReq.HandGlovesChemicals;
            dr["HandGlovesElectrical"] = ppeReq.HandGlovesElectrical;
            dr["HandGlovesOthers"] = ppeReq.HandGlovesOthers;
            dr["SafetyNet"] = ppeReq.SafetyNet;
            dr["SafetyShoes"] = ppeReq.SafetyShoes;
            dr["GumBoots"] = ppeReq.GumBoots;
            dr["CrawlingNet"] = ppeReq.CrawlingNet;
            dr["Apron"] = ppeReq.Apron;
            dr["SafetyBelt"] = ppeReq.SafetyBelt;
            dr["SCBA"] = ppeReq.SCBA;
            ppeDt.Rows.Add(dr);
            return  ppeDt;
        }

    }
}
