using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace WebCamLib;

public class WebCamImage : IDisposable
{
    VideoCapture? capture = null;

    public WebCamImage()
    {
        capture = new (0, VideoCapture.API.DShow);
        if (!capture.IsOpened)
            throw new ArgumentException("Camera not opened");
        GetProperties();
    }

    private void GetProperties()
    {
        Width = capture.Get(CapProp.FrameWidth);
        Height = capture.Get(CapProp.FrameHeight);
        Brightness = capture.Get(CapProp.Brightness);
        Contrast = capture.Get(CapProp.Contrast);
    }

    Mat? frame = null;
    private bool disposedValue;

    public void CaptureImage()
    {
        capture.Set(CapProp.FrameWidth, Width);
        capture.Set(CapProp.FrameHeight, Height);
        capture.Set(CapProp.Brightness, Brightness);
        capture.Set(CapProp.Contrast, Contrast);

        frame = capture.QueryFrame();
        GetProperties();
    }

    public double Width { get; set; }
    public double Height { get; set; } 
    public double Brightness { get; set; }
    public double Contrast { get; set; }
    public Bitmap CapturedImage => frame.ToBitmap();

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                frame?.Dispose();
                capture?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}