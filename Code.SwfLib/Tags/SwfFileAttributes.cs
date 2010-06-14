using System;

namespace Code.SwfLib.Tags
{
    [Flags]
    public enum SwfFileAttributes : uint
    {
        Reserved31 = 0x00000080,
        /// <summary>
        /// <para>If 1, the SWF file uses hardware acceleration to blit graphics to the screen, where such acceleration is available.</para>
        /// <para>If 0, the SWF file will not use hardware accelerated graphics facilitie</para>
        /// <para>Minimum file version is 10.</para>
        /// </summary>
        UseDirectBlit = 0x00000040,
        /// <summary>
        /// <para>If 1, the SWF file uses GPU compositing features when drawing graphics, where such acceleration is available.</para>
        /// <para>If 0, the SWF file will not use hardware accelerated graphics facilities.</para>
        /// <para>Minimum file version is 10.</para>
        /// </summary>
        UseGPU = 0x00000020,
        /// <summary>
        /// The HasMetadata flag identifies whether the SWF file contains the SymbolClass tag.
        /// </summary>
        HasMetadata = 0x00000010,
        /// <summary>
        /// If 1, this SWF uses ActionScript 3.0. If 0, this SWF uses ActionScript 1.0 or 2.0. Minimum file format version is 9.
        /// </summary>
        AllowAbc = 0x00000008,

        SupressCrossDomainCaching = 0x000000004,
        SwfRelativeUrls = 0x00000002,
        /// <summary>
        /// The UseNetwork flag signifies whether Flash Player should grant the SWF local or network file access if the SWF file is loaded locally.
        /// </summary>
        UseNetwork = 0x00000001,

        Reserved23 = 0x00800000,
        Reserved22 = 0x00400000,
        Reserved21 = 0x00200000,
        Reserved20 = 0x00100000,
        Reserved19 = 0x00080000,
        Reserved18 = 0x00040000,
        Reserved17 = 0x00020000,
        Reserved16 = 0x00010000,
        Reserved15 = 0x00008000,
        Reserved14 = 0x00004000,
        Reserved13 = 0x00002000,
        Reserved12 = 0x00001000,
        Reserved11 = 0x00000800,
        Reserved10 = 0x00000400,
        Reserved9 = 0x00000200,
        Reserved8 = 0x00000100,
        Reserved7 = 0x00000080,
        Reserved6 = 0x00000040,
        Reserved5 = 0x00000020,
        Reserved4 = 0x00000010,
        Reserved3 = 0x00000008,
        Reserved2 = 0x00000004,
        Reserved1 = 0x00000002,
        Reserved0 = 0x00000001,
    }
}
