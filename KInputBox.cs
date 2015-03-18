using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
  public partial class KInputBox : Form
  {
    // class vars -------------------------------------------------------------
    
    private bool m_numeric;
    private bool m_allowBlank;
    private String m_value;
    
    //-------------------------------------------------------------------------
    
    public KInputBox( String title, String text, bool allowBlank, bool numeric )
    {
      InitializeComponent();
      
      this.Text = title;
      groupBox.Text = text;
      
      m_numeric = numeric;
      m_allowBlank = allowBlank;
    }
    
    //-------------------------------------------------------------------------
    
    void OkBtnClick(object sender, EventArgs e)
    {
      // blank?
    	if ( m_allowBlank == false &&
           inputBox.Text.Equals( "" ) )
      {
        KMainForm.InfoMsg( "You must enter a value.", "Value" );
        return;
      }
      
      // numeric?
      if ( m_numeric )
      {
        try
        {
          Double.Parse( inputBox.Text );
        }
        catch
        {
          KMainForm.InfoMsg( "You must enter a numeric value.", "Value" );
          return;
        }
      }
      
      // set input value
      m_value = inputBox.Text;
      
      // close
      Dispose();
      
      this.DialogResult = DialogResult.OK;
    }
    
    //-------------------------------------------------------------------------
    
    public String GetInputText()
    {
      return m_value;
    }
    
    //-------------------------------------------------------------------------
    
    void CancelBtnClick(object sender, EventArgs e)
    {
    	Dispose();
    	
    	this.DialogResult = DialogResult.Cancel;
    }
    
    //-------------------------------------------------------------------------
  }
}
