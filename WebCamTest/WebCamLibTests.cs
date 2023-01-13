using Emgu.CV;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using WebCamLib;
namespace WebCamTest;

[TestClass]
public class WebCamLibTests
{
    [TestMethod]
    public void CanCaptureDefaultSizedFrame()
    {
        using WebCamImage wci = new();
        wci.CaptureImage();
        Assert.AreEqual(640, wci.Width);
        Assert.AreEqual(480, wci.Height);
    }

    [TestMethod]
    public void CanCaptureCustomSizedFrame()
    {
        using WebCamImage wci = new()
        {
            Width = 1280,
            Height = 720
        };
        wci.CaptureImage();
        Assert.AreEqual(1280, wci.Width);
        Assert.AreEqual(720, wci.Height);
    }

    [TestMethod]
    public void CanRetrieveBitmap()
    {
        using WebCamImage wci = new()
        {
            Width = 1280,
            Height = 720,
            Brightness = 80,
            Contrast = 80
        };

        wci.CaptureImage();
        Image img = wci.CapturedImage;
        Assert.IsInstanceOfType(img, typeof(Bitmap));
        Assert.AreEqual(1280, img.Width);
        Assert.AreEqual(720, img.Height);
    }
}