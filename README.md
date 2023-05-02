# SwfLib

SwfLib a C# library for parsing swf files into Document Object Model.

After parsing you can access individual tags, modify their properties and save whole swf file.

It supports ActionScript 2.0.

ActionScript 3.0. is planned.

Donations: ```xmr:82mT5rwYg6AAdfFAAiSfdH9nhnSWNoPB71qGb6C5fvgYTL54PHAV24DQKaxu4pVMurG2CqPVxQ1aSXTTNdkApqnRTbu7CHy```

## Usage examples:

```c#
using (var source = File.Open("source.swf", FileMode.Open, FileAccess.Read)) {
    var swf = SwfFile.ReadFrom(source);
    swf.Tags.Add(new SetBackgroundColorTag { Color = new SwfRGB(10, 224, 224) });
    using (var target = File.Open("target.swf", FileMode.Create, FileAccess.ReadWrite)) {
        swf.WriteTo(target);
        target.Flush();
    }
}
```

#SwfLibMill

SwfLibMill is a console application that use swfmill format to represent content of flash file as xml document.

Swf file can be converted to xml file, changed and converted to swf file.

## Example

```xml
<?xml version="1.0"?>
<swf version="8" compressed="0">
  <Header framerate="20" frames="1">
    <size>
      <Rectangle left="0" right="100" top="0" bottom="100"/>
    </size>
    <tags>
      <FileAttributes hasMetaData="0" allowABC="0" suppressCrossDomainCaching="0" swfRelativeURLs="0" useNetwork="1" useDirectBlit="0" useGPU="0"/>
      <SetBackgroundColor>
        <color>
          <Color red="10" green="224" blue="224"/>
        </color>
      </SetBackgroundColor>
      <ShowFrame/>
      <End/>
    </tags>
  </Header>
</swf>
```
