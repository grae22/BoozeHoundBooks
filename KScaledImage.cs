using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace BoozeHoundBooks
{
  public class KScaledImage
  {
    // class vars -------------------------------------------------------------

    private Image m_original;
    private Hashtable m_scaledImage = new Hashtable();

    //-------------------------------------------------------------------------

    public KScaledImage(Image image)
    {
      m_original = (Image) image.Clone();
    }

    //-------------------------------------------------------------------------

    public Image GetImage(Size size)
    {
      // specified size same as original? just return the original image
      if (size == m_original.Size)
      {
        return (Image) m_original.Clone();
      }

      // already have a scaled image of the specified width & height?
      String key = size.Width + "," + size.Height;

      if (m_scaledImage.Contains(key))
      {
        IDictionaryEnumerator e = m_scaledImage.GetEnumerator();

        while (e.MoveNext())
        {
          if (e.Key.Equals(key))
          {
            return (Image) ((Image) e.Value).Clone();
          }
        }

        return null;
      }

      // don't already have one, create one now
      Bitmap bmp = new Bitmap((Image) m_original.Clone());
      Bitmap newBmp = new Bitmap(size.Width, size.Height);

      Graphics gr = Graphics.FromImage(newBmp);

      gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //.HighQualityBilinear;

      gr.DrawImage(bmp, 0, 0, size.Width, size.Height);
      gr.Dispose();

      Image newImage = newBmp;

      m_scaledImage.Add(key, newImage);

      return newImage;
    }

    //-------------------------------------------------------------------------
  }
}