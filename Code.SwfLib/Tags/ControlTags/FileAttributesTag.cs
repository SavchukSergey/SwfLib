namespace Code.SwfLib.Tags.ControlTags
{
    public class FileAttributesTag : ControlBaseTag
    {

        public SwfFileAttributes Attributes;

        public bool UseNetwork
        {
            get { return (Attributes & SwfFileAttributes.UseNetwork) > 0; }
            set
            {
                if (value)
                {
                    Attributes = Attributes | SwfFileAttributes.UseNetwork;
                }
                else
                {
                    Attributes = Attributes & (~SwfFileAttributes.UseNetwork);
                }
            }
        }

        public bool HasMetadata
        {
            get { return (Attributes & SwfFileAttributes.HasMetadata) > 0; }
            set
            {
                if (value)
                {
                    Attributes = Attributes | SwfFileAttributes.HasMetadata;
                }
                else
                {
                    Attributes = Attributes & (~SwfFileAttributes.HasMetadata);
                }
            }
        }

        public bool SupressCrossDomainCaching
        {
            get { return (Attributes & SwfFileAttributes.SupressCrossDomainCaching) > 0; }
            set
            {
                if (value)
                {
                    Attributes = Attributes | SwfFileAttributes.SupressCrossDomainCaching;
                }
                else
                {
                    Attributes = Attributes & (~SwfFileAttributes.SupressCrossDomainCaching);
                }
            }
        }

        public bool SwfRelativeUrls
        {
            get { return (Attributes & SwfFileAttributes.SwfRelativeUrls) > 0; }
            set
            {
                if (value)
                {
                    Attributes = Attributes | SwfFileAttributes.SwfRelativeUrls;
                }
                else
                {
                    Attributes = Attributes & (~SwfFileAttributes.SwfRelativeUrls);
                }
            }
        }

        public bool AllowAbc
        {
            get { return (Attributes & SwfFileAttributes.AllowAbc) > 0; }
            set
            {
                if (value)
                {
                    Attributes = Attributes | SwfFileAttributes.AllowAbc;
                }
                else
                {
                    Attributes = Attributes & (~SwfFileAttributes.AllowAbc);
                }
            }
        }

        public bool UseGPU {
            get { return (Attributes & SwfFileAttributes.UseGPU) > 0; }
            set {
                if (value) {
                    Attributes = Attributes | SwfFileAttributes.UseGPU;
                } else {
                    Attributes = Attributes & (~SwfFileAttributes.UseGPU);
                }
            }
        }

        public bool UseDirectBlit {
            get { return (Attributes & SwfFileAttributes.UseDirectBlit) > 0; }
            set {
                if (value) {
                    Attributes = Attributes | SwfFileAttributes.UseDirectBlit;
                } else {
                    Attributes = Attributes & (~SwfFileAttributes.UseDirectBlit);
                }
            }
        }


        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}