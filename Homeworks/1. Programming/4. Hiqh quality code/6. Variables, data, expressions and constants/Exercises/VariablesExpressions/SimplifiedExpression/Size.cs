// <copyright file="Size.cs" company="MyCompany">
//     Copyright MyCompany. All rights reserved.
// </copyright>
using System;

/// <summary>
/// Size of a figure depending on width and height.
/// </summary>
public class Size
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Size"/> class with given width and height.
    /// </summary>
    /// <param name="width">Width of the figure.</param>
    /// <param name="height">Height of the figure.</param>
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    /// <summary>
    /// Gets or sets width of the figure.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets height of the figure.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Calculates size after rotation.
    /// </summary>
    /// <param name="size">Previous size of the figure.</param>
    /// <param name="rotationAngle">Angle of rotation.</param>
    /// <returns>New instance of size with calculated width and height.</returns>
    public static Size GetRotatedSize(Size size, double rotationAngle)
    {
        double absoluteCosOfAngle = Math.Abs(Math.Cos(rotationAngle));
        double absoluteSinOfAngle = Math.Abs(Math.Sin(rotationAngle));
        double newWidth = (absoluteCosOfAngle * size.Width) + (absoluteSinOfAngle * size.Height);
        double newHeight = (absoluteSinOfAngle * size.Width) + (absoluteCosOfAngle * size.Height);

        return new Size(newWidth, newHeight);
    }
}
