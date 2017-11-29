using Xamarin.Forms;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Frame), typeof(TaskManager.Droid.FrameRenderer))]
namespace TaskManager.Droid
{
    public class FrameRenderer : Xamarin.Forms.Platform.Android.FrameRenderer
    {
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            DrawOutline(canvas, canvas.Width, canvas.Height, canvas.Width/2);
        }

        void DrawOutline(Canvas canvas, int width, int height, float cornerRadius)
        {
            using (var paint = new Paint { AntiAlias = true })
            using (var path = new Path())
            using (Path.Direction direction = Path.Direction.Cw)
            using (Paint.Style style = Paint.Style.Stroke)
            using (var rect = new RectF(0, 0, width, height))
            {
                float rx = Forms.Context.ToPixels(cornerRadius);
                float ry = Forms.Context.ToPixels(cornerRadius);

                path.AddRoundRect(rect, rx, ry, direction);

                paint.StrokeWidth = 3;
                paint.SetStyle(style);
                paint.Color = Android.Graphics.Color.ParseColor("#e6e8ed");

                canvas.DrawPath(path, paint);
            }
        }
    }
}