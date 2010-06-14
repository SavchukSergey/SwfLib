using System;

namespace Code.SwfLib.Tags
{
    [Flags]
    public enum SwfFileAttributes
    {
        Reserved0 = 1,
        /// <summary>
        /// <para>If 1, the SWF file uses hardware acceleration to blit graphics to the screen, where such acceleration is available.</para>
        /// <para>If 0, the SWF file will not use hardware accelerated graphics facilitie</para>
        /// <para>Minimum file version is 10.</para>
        /// </summary>
        UseDirectBlit = 2,
        /// <summary>
        /// <para>If 1, the SWF file uses GPU compositing features when drawing graphics, where such acceleration is available.</para>
        /// <para>If 0, the SWF file will not use hardware accelerated graphics facilities.</para>
        /// <para>Minimum file version is 10.</para>
        /// </summary>
        UseGPU = 4,
        /// <summary>
        /// The HasMetadata flag identifies whether the SWF file contains the SymbolClass tag.
        /// </summary>
        HasMetadata = 8,
        AllowAbc = 16,
        SupressCrossDomainCaching = 32,
        SwfRelativeUrls = 64,
        /// <summary>
        /// The UseNetwork flag signifies whether Flash Player should grant the SWF local or network file access if the SWF file is loaded locally.
        /// </summary>
        UseNetwork = 128,
        Reserved8 = 256,
        Reserved9 = 512,
        Reserved10 = 1024,
    }
}
