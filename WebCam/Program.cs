using WebCamLib;

using WebCamImage wci = new()
{
    Width = 1280,
    Height = 720,
    Brightness = 80,
    Contrast = 80,
    Focus = 81
};

wci.CaptureImage();
string imgPath = GetImagePath();
wci.CapturedImage.Save
    (imgPath, System.Drawing.Imaging.ImageFormat.Bmp);

static string GetImagePath()
{
    DateTime dt = DateTime.UtcNow;
    string fileName = "img" + dt.ToString("yyMMddHHmm") + ".bmp";
    if (!Directory.Exists("C:\\tmp"))
        Directory.CreateDirectory("C:\\tmp");
    return Path.Combine("C:\\tmp", fileName);
}
