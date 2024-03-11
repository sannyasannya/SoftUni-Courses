using System;
using System.Text;

namespace BoxData;

public class Box
{
    private double _length;
    private double _widht;
    private double _height;

    public Box(double lenght, double widht, double height)
    {
        this.Length = lenght;
        this.Widht = widht;
        this.Height = height;

    }

    public double Length
    {
        get { return this._length; } 
        private set 
        { 
            if(value <= 0)
            {
                throw new ArgumentException("Lenght cannot be zero or negative.");
            }
            this._length = value; 
        }
    }
    
    public double Widht
    {
        get { return this._widht; }
        private set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Widht cannot be zero or negative.");
            }
            this._widht = value; 
        }
    }

    public double Height
    {
        get { return this._height; }
        private set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this._height = value; 
        }
    }

    public double SurfaceArea()
    {
        //2*L*W + 2*L*H + 2*W*H
        return 2 * this.Length * this.Widht + 2 * this.Length * this.Height + 2 * this.Widht * this.Height;
    }

    public double Volume()
    {
        //L*W*H
        return this.Length * this.Widht * this.Height;
    }

    public override string ToString()
    {
        return $"Surface Area – {this.SurfaceArea():f2}{Environment.NewLine}Volume – {this.Volume():f2}";
    }
}
