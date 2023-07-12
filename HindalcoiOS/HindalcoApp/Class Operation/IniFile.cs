using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Class_Operation
{
   public class IniFile
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        public static string path = string.Empty;
       
        public static void SetPath(string pathfile)
        {
            path = pathfile;
        }
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp,255, path);
            return temp.ToString();

        }
        public static bool KeyExists(string Key, string Section = null)
        {
            return IniReadValue(Key, Section).Length > 0;
        }
    }
}
