using SolidWorks.Interop.sldworks;
using System;
using System.Diagnostics;
using System.IO;

namespace SolidworksVersion
{
    public class Version
    {
        private const string SolidworksFile = "SolidWorks.Interop.sldworks.dll";
        private readonly System.Version _revision;
        public Version(SldWorks sldWorks)
        {
            _revision = System.Version.Parse(sldWorks.RevisionNumber());
        }

        public AppVersion Major => (AppVersion)_revision.Major;
        public ServicePack Minor => (ServicePack)_revision.Minor;
        public bool CompareAppFileAndSolidworksAppVersion()
        {
            // it's COM reference
            if (!File.Exists(SolidworksFile))
            {
                return true;
            }

            System.Version fileRevision = System.Version.Parse(FileVersionInfo.GetVersionInfo(SolidworksFile)?.FileVersion) ?? throw new NullReferenceException($"Not found {SolidworksFile}");

            return Major == (AppVersion)fileRevision.Major;
        }
    }

    record Ver
    {
        
    }

}
