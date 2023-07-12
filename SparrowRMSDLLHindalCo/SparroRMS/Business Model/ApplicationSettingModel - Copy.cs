using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
  public  class ApplicationSettingModel
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string Logo { get; set; }
        public string Appversion { get; set; }
        public DateTime relDate { get; set; }
        public string InstalledPath { get; set; }
        public string aliasName { get; set; }

    }
}
