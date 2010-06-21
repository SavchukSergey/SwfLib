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
        /// <summary>
        /// Change the background color. 
        /// </summary>
        SetBackgroundColor = 9,
        /// <summary>
        /// Defines a text of characters displayed using a font. This definition doesn't support any transparency.
        /// </summary>
        DefineText = 11,
        DoAction = 12,
        DefineBitsJPEG2 = 21,
        /// <summary>
        /// Declaration of complex 2D shapes. 
        /// </summary>
        DefineShape2 = 22,
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
        /// <summary>
        /// Defines an RGBA bitmap compressed using ZLIB (similar to the PNG format). 
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
        /// <summary>
        /// Exports a list of definitions to other movies. You can in this way create one or more movies to hold a colection of objects to be reused by other movies without having to insert these info in each movie. A single export is enough for an entire movie (and you should have just one). 
        /// </summary>
        Export = 56,
        DoInitAction = 59,
        /// <summary>
        /// This tag is used when debugging an SWF movie. It gives information about what debug file to load to match the SWF movie with the source. The identifier is a UUID. 
        /// </summary>
        DebugID = 63,
        /// <summary>
        /// The data of this tag is a 16 bits word followed by an MD5 password like the Protect tag. When it exists and you know the password, you will be given the right to debug the movie with Flash V6.x and over.
        /// </summary>
        ProtectDebug2 = 64,
        /// <summary>
        /// Change limits used to ensure scripts don't use more resources than you choose. In version 7, it supports a maximum recursive depth and a maximum amount of time scripts can be run for in seconds. 
        /// </summary>
        ScriptLimits = 65,
        /// <summary>
        /// Since version 8, this tag is required and needs to be the very first tag in the movie. It is used as a way to better handle security with the Flash Player.
        /// </summary>
        FileAttributes = 69,
        PlaceObject3 = 70,
        DoAbc = 72,
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
        MetaData = 77,
        /// <summary>
        /// Define scale factors for a window, a button, or other similar objects. 
        /// </summary>
        DefineScalingGrid = 78,
        /// <summary>
        /// New container tag for ActionScripts under SWF 9. Includes an identifier, a name and actions. 
        /// </summary>
        DoAbcDefine = 82,
        /// <summary>
        /// Define the legal font name and copyright.
        /// </summary>
        DefineFontName = 88,
    }
}