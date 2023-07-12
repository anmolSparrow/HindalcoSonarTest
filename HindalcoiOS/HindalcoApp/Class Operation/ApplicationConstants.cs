using CADImport;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.xmp;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Class_Operation
{

    public struct SourceMachine
    {
        public string LineType;
        public List<string> Input;
        public List<string> Output;
        public double[] StartPoint;
        public double[] EndPoint;

    }
    public struct SourceMachineOutput
    {
        public List<string> Input;
        public List<string> Output;
    }
    public class ApplicationConstants
    {
        public static readonly string defaultstr;
        public static readonly string languagepath;
        public static readonly string loadfilestr;
        public static readonly string msgBoxDebugCaption;
        public static readonly string sepstr;
        public static readonly string notsupportedstr;
        public static readonly string notsupportedextstr;
        public static readonly string appnamestr;
        public static readonly string sepstr2;
        public static readonly string jpgextstr;
        public static readonly string bmpextstr;
        public static readonly string tiffextstr;
        public static readonly string gifextstr;
        public static readonly string emfextstr;
        public static readonly string wmfextstr;
        public static readonly string pngextstr;
        public static readonly string dxfextstr;
        public static readonly string lngextstr;
        public static readonly string languagestr;
        public static readonly string languageIDstr;
        public static readonly string backcolorstr;
        public static readonly string blackstr;
        public static readonly string showentitystr;
        public static readonly string drawmodestr;
        public static readonly string truestr;
        public static readonly string shxpathcnstr;
        public static readonly string installstr;
        public static readonly string sepstr3;
        public static readonly string typelcstr;
        public static readonly string floatingstr;
        public static readonly string hoststr;
        public static readonly string portstr;
        public static readonly string appconst;
        public static readonly string blackstr2;
        public static readonly string whitestr;
        public static readonly string registerstr;
        public static readonly string colordrawstr;
        public static readonly string datextstr;
        public static readonly string messagestr;
        public static readonly string headstr1;
        public static readonly string headstr2;
        public static readonly string headstr3;
        public static readonly string headstr4;
        public static readonly string namestr;
        public static readonly string visiblestr;
        public static readonly string freezestr;
        public static readonly string colorstr;
        public static readonly string entitiesstr;
        public static readonly string blocksstr;
        public static readonly string vportsstr;
        public static readonly string ltypesstr;
        public static readonly string layoutsstr;
        public static readonly string layersstr;
        public static readonly string stylesstr;
        public static readonly string xrefsstr;
        public static readonly string imagesettingsstr;
        public static readonly string file_notsupportedstr;
        public static readonly string MessageDisplay;
        public static readonly string[] hatchStyle;
        public static readonly string xmlextstr, xmlextstr2, txtextstr;
        static ApplicationConstants()
        {
            hatchStyle = new string[8]{"BDiagonal", "Cross", "DiagCross", "FDiagonal",
                                       "Horizontal", "PatternData", "Solid", "Vertical"};
            defaultstr = "Default";
            languagepath = "LanguagePath";
            sepstr = " - ";
            sepstr2 = " : ";
            loadfilestr = "Loading file...";
            msgBoxDebugCaption = "Debug application message";
            notsupportedstr = "not supported";
            notsupportedextstr = "Not supported in current version!";
            appnamestr = "CADImportNet Demo";
            xmlextstr = ".XML";
            xmlextstr2 = ".xml";
            languagestr = "Language";
            languageIDstr = "LanguageID";
            backcolorstr = "BackgroundColor";
            blackstr = "BLACK";
            showentitystr = "ShowEntity";
            drawmodestr = "drawMode";
            truestr = "TRUE";
            shxpathcnstr = "SHXPathCount";
            installstr = "Install";
            sepstr3 = ";";
            typelcstr = "Type_license";
            floatingstr = "floating";
            hoststr = "Host";
            portstr = "Port";
            appconst = "Application";
            blackstr2 = "Black";
            whitestr = "White";
            registerstr = "register";
            colordrawstr = "ColorDraw";
            datextstr = ".dat";
            messagestr = "If you proceed with this operation, all added objects will be lost. Continue?";
            headstr1 = "Head1";
            headstr2 = "Head2";
            headstr3 = "Head3";
            headstr4 = "Head4";
            namestr = "Name";
            visiblestr = "Visible";
            freezestr = "Freeze";
            colorstr = "Color";
            entitiesstr = "Entities";
            blocksstr = "Blocks";
            vportsstr = "VPorts";
            ltypesstr = "LTypes";
            layoutsstr = "Layouts";
            layersstr = "Layers";
            stylesstr = "Styles";
            xrefsstr = "XRefs";
            imagesettingsstr = "ImageSettings";
            sepstr3 = string.Empty + (char)13 + (char)10;
            txtextstr = ".txt";
            MessageDisplay = "HindalcoiOS";
            lngextstr = ".lng";
        }
        public static string GetColor(System.Drawing.Color val)
        {
            if (val.Equals(CADConst.clNone))
                return "[black/white]";
            if (val.Equals(CADConst.clByBlock))
                return "[ByBlock]";
            if (val.Equals(CADConst.clByLayer))
                return "[ByLayer]";
            return val.ToString();
        }
    }
    public class OffsetCalculator
    {
        public DPoint basePoint, finalPoint, offsetValue;
        public bool isFirstClick = true;

        public OffsetCalculator()
        {

        }
        public void Calculate()
        {
            offsetValue = DPoint.Offset(finalPoint, basePoint, false);
        }
    }
}
