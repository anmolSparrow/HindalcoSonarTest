using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.OHC_and_AMC.BusinessClass
{
   public class MachineAMC: IDisposable
    {
        private bool disposed;

        /// <summary>
        /// Destructor
        /// </summary>
        ~MachineAMC()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherithed from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }

        #region Property Declaration
        public int SINO
        {
            get;
            set;
        }
        public string AMCCode
        {
            get; set;
        }
        public string NameOfAMC
        {
            get; set;
        }
        public string MahineCode
        {
            get; set;
        }
        public string MachineName
        {
            get; set;
        }
        public string Freequency
        {
            get; set;
        }
        public DateTime LastDateOfAMC
        {
            get; set;
        }
        public DateTime NextDateofAMC
        {
            get; set;
        }
        public string VendorName
        {
            get; set;
        }
        public string AMCDoneBy
        {
            get; set;
        }
        public string AMCReviewedBy
        {
            get; set;
        }
        public string ReportName
        {
            get; set;
        } 
        #endregion
    }
}
