using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Runtime.InteropServices;

namespace InterFaceV4
{
    public class DllImportv4
    {
        // 东软DLL -------------------------------------------------------------------------------------------------------
        [DllImport("joint.dll")]
        public static extern Boolean PacsInitialize();
        [DllImport("joint.dll")]
        public static extern int PacsView(int nPatientType, string str, int nType);
        [DllImport("joint.dll")]
        public static extern int PacsViewByPatientInfo(int nType, string str, int nPatientType);
        [DllImport("joint.dll")]
        public static extern void PacsRelease();
        //<---------------------------------------------------------------------------------------------------------------
    }
}
