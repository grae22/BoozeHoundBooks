using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
  public partial class GenerateRecuringTransactionsDlg : Form
  {
    //-------------------------------------------------------------------------

    KBook m_book = null;

    //-------------------------------------------------------------------------

    public GenerateRecuringTransactionsDlg( KBook book )
    {
      m_book = book;

      InitializeComponent();

      ArrayList periods = book.GetPeriodList();

      PopulateComboBoxWithPeriods( periods, cbSourcePeriod, false );
      PopulateComboBoxWithPeriods( periods, cbDestPeriod, true );
    }

    //-------------------------------------------------------------------------

    void PopulateComboBoxWithPeriods( ArrayList periods,
                                      ComboBox box,
                                      bool isDest )
    {
      try
      {
        foreach( KPeriod p in periods )
        {
          box.Items.Add( p.GetId().ToString() );

          if( p.DateInPeriod( DateTime.Now ) )
          {
            if( isDest )
            {
              box.SelectedItem = p.GetId().ToString();
            }
            else
            {
              string s = ( p.GetId() - 1 ).ToString();

              if( box.Items.Contains( s ) )
              {
                box.SelectedItem = s;
              }
            }
          }
        }
      }
      catch
      {
        // Ignore.
      }
    }

    //-------------------------------------------------------------------------

    private void btnGenerate_Click( object sender, EventArgs e )
    {
      if( cbSourcePeriod.SelectedItem == null ||
          cbDestPeriod.SelectedItem == null )
      {
        MessageBox.Show( "Select the Periods.",
                         "Periods",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error );
        return;
      }

      if( MessageBox.Show( "Are you sure?",
                           "Generate?",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question ) == System.Windows.Forms.DialogResult.No )
      {
        return;
      }


    }

    //-------------------------------------------------------------------------
  }
}
