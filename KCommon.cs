using System;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace BoozeHoundBooks
{
	public class KCommon
	{
	  //---------------------------------------------------------------

	  public static String GetFilenameFromPath( String path )
	  {
	    String name = path;
	    
	    // find the last path separator
	    int lastBackSlash = path.LastIndexOf( "\\" );
	    int lastDoubleBackSlash = path.LastIndexOf( "\\\\" );
	    int lastForwardSlash = path.LastIndexOf( "/" );
	    int lastDoubleForwardSlash = path.LastIndexOf( "//" );    // just in case...
	    
	    int lastSeparator = lastBackSlash;
	    
	    if ( lastSeparator < lastDoubleBackSlash )
	    {
	      lastSeparator = lastDoubleBackSlash;
	    }
	    
	    if ( lastSeparator < lastForwardSlash )
	    {
	      lastSeparator = lastForwardSlash;
	    }
	    
	    if ( lastSeparator < lastDoubleForwardSlash )
	    {
	      lastSeparator = lastDoubleForwardSlash;
	    }
	    
	    // find file extension (if any)
	    int ext = path.LastIndexOf( "." );
	    
	    if ( ext != -1 )
	    {
	      name = path.Substring( 0, ext );
	    }
	    
	    // strip the path info
	    name = name.Substring( lastSeparator + 1 );
	    
	    return name;
	  }
		
		//---------------------------------------------------------------
		
		public static String GetRgbString( Color colour )
		{
		  return colour.R + "," + colour.G + "," + colour.B;
		}
		
		//---------------------------------------------------------------
		
		public static Color GetColourFromRgbString( String rgb )
		{
		  Color col = Color.Black;
		  String[] s = rgb.Split( ',' );
		  
		  if ( s.Length == 3 )
		  {
		    col = Color.FromArgb( int.Parse( s[0] ), int.Parse( s[1] ), int.Parse( s[2] ) );
		  }
		  
		  return col;
		}
		
		//---------------------------------------------------------------
		
		public static Image CreateImageFromResource( Assembly assembly, String resourceName )
		{
		  Stream stream = assembly.GetManifestResourceStream( resourceName );
		  
		  if ( stream == null )
		  {
		    throw new Exception( "KCommon.CreateImageFromResource() : '" + resourceName + "' not found." );
		  }
		  
		  Image img = Image.FromStream( stream );
		  
		  return img;
		}
		
		//---------------------------------------------------------------
		
		public static bool IsNumeric( String text )
		{
		  try
		  {
		    Double.Parse( text );
		    
		    return true;
		  }
		  catch
		  {
		    return false;
		  }
		}
		
		//---------------------------------------------------------------
	}
}
