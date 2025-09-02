using SkiaSharp;
using Svg.Skia;
using SkiaSharp.Views.Maui;

namespace ArmDemoTryout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.White);

            using var paint = new SKPaint { Color = SKColors.Blue, IsAntialias = true };
            canvas.DrawRect(50, 50, 200, 100, paint);

            string svgContent = "<svg width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>";
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgContent));
            var svg = new SKSvg();
            svg.Load(stream);
            canvas.DrawPicture(svg.Picture);
        }
    }
}
