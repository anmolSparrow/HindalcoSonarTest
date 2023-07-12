using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Class_Operation
{
    public class SerializationXml
    {
        [DataMember]
        public Dictionary<string, List<string>> Map_list { set; get; }
        public SerializationXml()
        {
            Map_list = new Dictionary<string, List<string>>();
        }
        private static DataContractSerializer serializer;

        public static bool Serialize(string filePath, SerializationXml sTest)
        {
            bool IsStatus;
            //Stopwatch f = new Stopwatch();
            //f.Start();
            //var openTiming = f.ElapsedMilliseconds;
            serializer = new DataContractSerializer(typeof(SerializationXml));
            try
            {
                using (var writer = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    serializer.WriteObject(writer, sTest);
                    IsStatus = true;
                }
            }
            catch (Exception Ex)
            {
                IsStatus = false;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //f.Stop();
            //string Time = "Elapsed: " + (f.ElapsedMilliseconds).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
            //Console.WriteLine("Serilization={0}", Time);
            return IsStatus;
        }
        public static SerializationXml DeSerialize(string filePath)
        {
            //Stopwatch f = new Stopwatch();
            //f.Start();
            //var openTiming = f.ElapsedMilliseconds;
            serializer = new DataContractSerializer(typeof(SerializationXml));

            SerializationXml serializeTest;

            using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    serializeTest = serializer.ReadObject(reader) as SerializationXml;
                }
                catch (Exception Ex)
                {
                    serializeTest = null;
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //f.Stop();
            //string Time = "Elapsed: " + (f.ElapsedMilliseconds).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
            //Console.WriteLine("DSerilization={0}", Time);
            return serializeTest;
        }
    }
}
