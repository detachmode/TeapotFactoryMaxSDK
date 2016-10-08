using Autodesk.Max;

namespace TeapotFactoryMax.Helper
{
    public static class Kernel
    {
        public static IGlobal Global = GlobalInterface.Instance;
        public static IInterface13 Interface = Global.COREInterface13;

    }
}