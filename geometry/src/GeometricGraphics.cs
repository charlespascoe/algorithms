using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public class GeometricGraphics {
    private int imageWidth;
    private int imageHeight;
    private decimal scale;
    private Graphics graphics;
    private Vector renderOrigin;

    public Bitmap Image { get; private set; }

    public GeometricGraphics(int imageWidth, int imageHeight) : this(imageWidth, imageHeight, new Vector(), 1m) { }

    public GeometricGraphics(int imageWidth, int imageHeight, Vector renderOrigin, decimal scale) {
        this.imageWidth = imageWidth;
        this.imageHeight = imageHeight;
        this.Image = new Bitmap(imageWidth, imageHeight);
        this.graphics = Graphics.FromImage(this.Image);
        this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
        this.graphics.Clear(Color.White);
        this.renderOrigin = renderOrigin;
        this.scale = scale;

    }

    public GeometricGraphics DrawAxes() {
        Vector scaledOrigin = this.scale * this.renderOrigin;
        this.graphics.DrawLine(new Pen(Color.Gray), (float)scaledOrigin.X, 0, (float)scaledOrigin.X, this.imageHeight);
        this.graphics.DrawLine(new Pen(Color.Gray), 0, this.imageHeight - (float)scaledOrigin.Y, this.imageWidth, this.imageHeight - (float)scaledOrigin.Y);
        return this;
    }

    public GeometricGraphics DrawGrid(int step) {
        int i = 0;

        Vector scaledOrigin = this.scale * this.renderOrigin;

        for (float x = (float)(this.scale * step); x < this.imageWidth; x += (float)this.scale * step) {
            this.graphics.DrawLine(new Pen(Color.LightGray), (float)scaledOrigin.X + x, 0, (float)scaledOrigin.X + x, this.imageHeight);
            this.graphics.DrawLine(new Pen(Color.LightGray), (float)scaledOrigin.X - x, 0, (float)scaledOrigin.X - x, this.imageHeight);
        }

        for (float y = (float)(this.scale * step); y < this.imageHeight; y += (float)this.scale * step) {
            this.graphics.DrawLine(new Pen(Color.LightGray), 0, this.imageHeight - (float)scaledOrigin.Y + y, this.imageWidth, this.imageHeight - (float)scaledOrigin.Y + y);
            this.graphics.DrawLine(new Pen(Color.LightGray), 0, this.imageHeight - (float)scaledOrigin.Y - y, this.imageWidth, this.imageHeight - (float)scaledOrigin.Y - y);
        }

        return this;
    }

    public GeometricGraphics DrawPoint(Vector point) {
        return this.DrawPoint(point, new SolidBrush(Color.Black));
    }

    public GeometricGraphics DrawPoint(Vector point, Brush brush) {
        Vector scaledPoint = this.scale * (point + this.renderOrigin);
        this.graphics.FillEllipse(brush, (float)scaledPoint.X - 1, this.imageHeight - (float)scaledPoint.Y - 1, 3f, 3f);
        return this;
    }

    public GeometricGraphics DrawLine(Line line, bool includePoints = false) {
        return this.DrawLine(line, includePoints, new Pen(Color.Black));
    }

    public GeometricGraphics DrawLine(Line line, bool includePoints, Pen pen) {
        Vector scaledPoint1 = this.scale * (line.Point1 + this.renderOrigin);
        Vector scaledPoint2 = this.scale * (line.Point2 + this.renderOrigin);
        this.graphics.DrawLine(pen, (float)scaledPoint1.X, this.imageHeight - (float)scaledPoint1.Y, (float)scaledPoint2.X, this.imageHeight - (float)scaledPoint2.Y);

        if (includePoints) {
            this.DrawPoint(line.Point1, new SolidBrush(pen.Color));
            this.DrawPoint(line.Point2, new SolidBrush(pen.Color));
        }

        return this;
    }
}
