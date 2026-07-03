namespace QRCodeLib
{
    using QRCoder;
    public class QRCodeGen
    {
        public string Address { get; set; }
        public QRCodeGen(string address)
        {
            Address = address;
            generateQRCode(Address);
        }
        private void generateQRCode(string address)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData qrCodeData = generator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q);

            QRCoder.BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(qrCodeData);

            byte[] bytes = bitmapByteQRCode.GetGraphic(20);
            using (FileStream fs = new FileStream(@"Address.bmp", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
