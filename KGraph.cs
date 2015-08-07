using System;
using System.Collections;
using System.Drawing;

namespace BoozeHoundBooks
{
  public class KGraph
  {
    // class vars -------------------------------------------------------------

    private String m_name; 
    private ArrayList m_point = new ArrayList( 50 );
    private Color m_colour = Color.Black;
    
    //-------------------------------------------------------------------------
    
    public KGraph( String name, Color colour )
    {
      m_name = name;
      m_colour = colour;
    }
    
    //-------------------------------------------------------------------------
    
    public void AddPoint( Point point )
    {
      m_point.Add( point );
    }
    
    //-------------------------------------------------------------------------
    
    public IEnumerator GetPoints()
    {
      return m_point.GetEnumerator();
    }
    
    //-------------------------------------------------------------------------
    
    public String Name
    {
      get { return m_name; }
      
      set { m_name = value; }
    }
    
    //-------------------------------------------------------------------------
    
    public Color Colour
    {
      get { return m_colour; }
      
      set { m_colour = value; }
    }
    
    //-------------------------------------------------------------------------
  }
}
