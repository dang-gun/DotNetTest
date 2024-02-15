using GdPicture14;
using OnBarcode.Barcode.BarcodeScanner;
using RasterEdge.XImage.BarcodeScanner;
using ZXing;


namespace ZXingNet_Test;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();


    }

    private void button1_Click(object sender, EventArgs e)
    {
        var barcodeBitmap = (Bitmap)Bitmap.FromFile("C:\\Users\\Kim\\Pictures\\¼öÁ¤µÊ_Ä«µåqr3.png");
        //var barcodeBitmap = (Bitmap)Bitmap.FromFile("C:\\Users\\Kim\\Pictures\\¼öÁ¤µÊ_Ä«µåqr6.png");
        //var barcodeBitmap = (Bitmap)Bitmap.FromFile("C:\\Users\\Kim\\Pictures\\Camera Roll\\test3.jpg");

        // create a barcode reader instance
        var barcodeReader = new ZXing.Windows.Compatibility.BarcodeReader();
        // decode the barcode from the in memory bitmap
        var barcodeResult = barcodeReader.Decode(barcodeBitmap);

        if (1 == 1)
        {

        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
        string[] barcodes
            = BarcodeScanner.Scan(
                "C:\\Users\\Kim\\Pictures\\Camera Roll\\WIN_20231122_10_20_26_Pro.jpg"
                , OnBarcode.Barcode.BarcodeScanner.BarcodeType.QRCode);

        if (1 == 1)
        {

        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        String inputFilePath = "C:\\Users\\Kim\\Pictures\\Camera Roll\\WIN_20231122_10_20_26_Pro.jpg";

        //  Open JPEG file
        Bitmap bitmap = new Bitmap(inputFilePath);
        //  Initial reader's setting
        ReaderSettings settings = new ReaderSettings();
        //  Set target barcode type
        settings.AddTypesToRead(RasterEdge.XImage.BarcodeScanner.BarcodeType.QRCode);
        //  Scan barcodes from the document.
        Barcode[] result = BarcodeReader.ReadBarcodes(settings, bitmap);

        if (result.Length > 0)
        {
            foreach (Barcode barcode in result)
                Console.WriteLine("Barcode Data: " + barcode.DataString);
        }
        else
            Console.WriteLine("[No Barcode Found]");
    }

    private void button4_Click(object sender, EventArgs e)
    {
        using GdPictureImaging gdpictureImaging = new GdPictureImaging();
        // Select the image to process.
        int imageID = gdpictureImaging.CreateGdPictureImageFromFile(
                      "C:\\Users\\Kim\\Pictures\\Camera Roll\\WIN_20231129_17_04_01_Pro.jpg");
        //int imageID = gdpictureImaging.CreateGdPictureImageFromFile("C:\\Users\\Kim\\Pictures\\Camera Roll\\test2.jpg");
        // Scan the barcodes.
        gdpictureImaging.BarcodeMicroQRReaderDoScan(imageID);
        // Determine the number of scanned barcodes.
        int barcodeCount = gdpictureImaging.BarcodeMicroQRReaderGetBarcodeCount();
        string content = "";
        if (barcodeCount > 0)
        {
            content = "Number of barcodes scanned: " + barcodeCount.ToString();
            // Save the value of each barcode.
            for (int i = 1; i <= barcodeCount; i++)
            {
                content += $"\nBarcode Number: {i} Value: {gdpictureImaging.BarcodeMicroQRReaderGetBarcodeValue(i)}";
            }
        }
        // Write the values to the console.
        Console.WriteLine(content);
        // Release unnecessary resources.
        gdpictureImaging.BarcodeMicroQRReaderClear();
        gdpictureImaging.ReleaseGdPictureImage(imageID);
    }
}