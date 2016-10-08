using Autodesk.Max;

namespace TeapotFactoryMax
{
    public static class Kernel
    {
        public static IGlobal Global = GlobalInterface.Instance;
        public static IInterface13 Interface = Global.COREInterface13;

    }
}