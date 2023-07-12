using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMPCLApp.Class_Operation
{
    public sealed class SettingOption
    {

        private static readonly SettingOption instance = new SettingOption(); // this used for Without Thread Safe and Simple Singleton Class
        static SettingOption()
        {

        }
        private SettingOption()
        {

        }
        public static SettingOption Instance
        {
            get
            {
                return instance;
            }
        }
        public string UserName
        {
            get;set;
        }
        public string DisplayName
        {
            get;set;
        }
        public string FromAddress
        {
            get;set;
        }

        public string ToAddress
        {
            get;set;
        }
        public string CCAddress
        {
            get;set;
        }
        public string Signature
        {
            get;set;
        }

        //private  static volatile  SettingOption _Instance;
        //    private static readonly object Instancelock = new object();

        //    private  static SettingOption Instance  // Double checkin Instance Locking and Thread Safe Class Property
        //    {          
        //        get
        //        {
        //            if (_Instance == null)
        //            {
        //                lock (Instancelock)
        //                {
        //                    if (_Instance == null)
        //                    {
        //                        _Instance = new SettingOption();
        //                    }
        //                    return _Instance;
        //                }
        //            }
        //            return _Instance;
        //        }
        //    }
    }
}
