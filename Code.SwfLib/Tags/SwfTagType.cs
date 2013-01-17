namespace Code.SwfLib.Tags {
    /// <summary>
    /// http://www.m2osw.com/en/swf_alexref.html
    /// </summary>
    public enum SwfTagType : ushort {
        /// <summary>
        /// Mark the end of the file. It can't appear anywhere else but the end of the file. 
        /// </summary>
        End = 0,
        /// <summary>
        /// Display the current display list and pauses for 1 frame as defined in the file header. 
        /// </summary>
        ShowFrame = 1,
        /// <summary>
        /// Define a simple geometric shape. 
        /// </summary>
        DefineShape = 2,
        PlaceObject = 4,
        RemoveObject = 5,
        /// <summary>
        /// This tag defines a bitmap character with JPEG compression.
        /// </summary>
        DefineBits = 6,
        DefineButton =7,
        /// <summary>
        /// This tag defines the JPEG encoding table (the Tables/Misc segment) for all JPEG images defined using the DefineBits tag.
        /// </summary>
        JPEGTables = 8,
        /// <summary>
        /// Change the background color. 
        /// </summary>
        SetBackgroundColor = 9,
        DefineFont = 10,
        /// <summary>
        /// Defines a text of characters displayed using a font. This definition doesn't support any transparency.
        /// </summary>
        DefineText = 11,
        DoAction = 12,
        DefineFontInfo = 13,
        DefineSound = 14,
        StartSound = 15,
        DefineButtonSound = 17,
        SoundStreamHead = 18,
        SoundStreamBlock = 19,
        DefineBitsLossless = 20,
        DefineBitsJPEG2 = 21,
        /// <summary>
        /// DefineShape2 extends the capabilities of DefineShape with the ability to support more than 255 styles in the style list and multiple style lists in a single shape.
        /// </summary>
        DefineShape2 = 22,
        DefineButtonCxform = 23,
        /// <summary>
        /// The Protect tag marks a file as not importable for editing in an authoring environment.
        /// </summary>
        Protect = 24,
        /// <summary>
        /// Place an object in the current display list.
        /// </summary>
        PlaceObject2 = 26,
        RemoveObject2 = 28,
        /// <summary>
        /// Declare a simple geometric shape.
        /// </summary>
        DefineShape3 = 32,
        /// <summary>
        /// Defines a text of characters displayed using a font. Transparency is supported with this tag.
        /// </summary>
        DefineText2 = 33,
        DefineButton2 = 34,
        DefineBitsJPEG3 = 35,
        /// <summary>
        /// DefineBitsLossless2 extends DefineBitsLossless with support for opacity (alpha values).
        /// </summary>
        DefineBitsLossless2 = 36,
        DefineEditText = 37,
        /// <summary>
        /// Declares an animated character. This is similar to a shape with a display list so the character can be changing on its own over time. 
        /// </summary>
        DefineSprite = 39,
        /// <summary>
        /// This tag defines information about the product used to generate the animation. The product identifier should be unique among all the products. The info includes a product identifier, a product edition, a major and minor version, a build number and the date of compilation. All of this information is all about the generator, not the output movie. 
        /// </summary>
        ProductInfo = 41,
        /// <summary>
        /// Names a frame or anchor. This frame can later be referenced using this name. 
        /// </summary>
        FrameLabel = 43,
        SoundStreamHead2 = 45,
        /// <summary>
        /// The DefineMorphShape tag defines the start and end states of a morph sequence.
        /// </summary>
        DefineMorphShape = 46,
        DefineFont2 = 48,
        /// <summary>
        /// The ExportAssets tag makes portions of a SWF file available for import by other SWF files.
        /// </summary>
        ExportAssets = 56,
        /// <summary>
        /// The ImportAssets tag imports characters from another SWF file.
        /// </summary>
        ImportAssets = 57,
        /// <summary>
        /// The EnableDebugger tag enables debugging. 
        /// </summary>
        EnableDebugger = 58,
        DoInitAction = 59,
        /// <summary>
        /// This tag is used when debugging an SWF movie. It gives information about what debug file to load to match the SWF movie with the source. The identifier is a UUID. 
        /// </summary>
        DefineFontInfo2 = 62,
        DebugID = 63,
        /// <summary>
        /// The EnableDebugger2 tag enables debugging.
        /// </summary>
        EnableDebugger2 = 64,
        /// <summary>
        /// Change limits used to ensure scripts don't use more resources than you choose. In version 7, it supports a maximum recursive depth and a maximum amount of time scripts can be run for in seconds. 
        /// </summary>
        ScriptLimits = 65,
        SetTabIndex = 66,
        /// <summary>
        /// Since version 8, this tag is required and needs to be the very first tag in the movie. It is used as a way to better handle security with the Flash Player.
        /// </summary>
        FileAttributes = 69,
        PlaceObject3 = 70,
        /// <summary>
        /// The ImportAssets2 tag imports characters from another SWF file
        /// </summary>
        ImportAssets2 = 71,
        DoAbcDefine = 72,
        /// <summary>
        /// Since SWF8, this tag was added to allow a clear definition of where a glyph starts. This is a hint to ensure that glyphs are properly drawn on pixel boundaries. Note that it is only partially useful for italic fonts since only vertical hints really make a difference.
        /// </summary>
        DefineFontAlignZones = 73,
        /// <summary>
        /// Define whether CSM text should be used in a previous DefineText, DefineText2 or DefineEditText.
        /// </summary>
        CSMTextSettings = 74,
        DefineFont3 = 75,
        /// <summary>
        /// Instantiate objects from a set of classes. 
        /// </summary>
        SymbolClass = 76,
        /// <summary>
        /// This tag includes XML code which describes the movie. The format is RDF compliant to the XMP as defined on W3C.
        /// </summary>
        Metadata = 77,
        /// <summary>
        /// The DefineScalingGrid tag introduces the concept of 9-slice scaling, which allows component-style scaling to be applied to a sprite or button character.
        /// </summary>
        DefineScalingGrid = 78,
        /// <summary>
        /// New container tag for ActionScripts under SWF 9. Includes an identifier, a name and actions. 
        /// </summary>
        DoAbc = 82,
        /// <summary>
        /// DefineShape4 extends the capabilities of DefineShape3 by using a new line style record in the shape.
        /// </summary>
        DefineShape4 = 83,
        /// <summary>
        /// The DefineMorphShape2 tag extends the capabilities of DefineMorphShape by using a new morph line style record in the morph shape.
        /// </summary>
        DefineMorphShape2 = 84,
        /// <summary>
        /// The DefineSceneAndFrameLabelData tag contains scene and frame label data for a MovieClip.
        /// </summary>
        DefineSceneAndFrameLabelData = 86,
        /// <summary>
        /// Define the legal font name and copyright.
        /// </summary>
        DefineFontName = 88,
        StartSound2,
        /// <summary>
        /// This tag defines a bitmap character with JPEG compression. This tag extends DefineBitsJPEG3, adding a deblocking parameter.
        /// </summary>
        DefineBitsJPEG4 = 90,
        DefineFont4 = 91
    }
}