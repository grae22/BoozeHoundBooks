using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
  public partial class KAccountSetupForm
  {
    // class vars -------------------------------------------------------------
    private KBook m_book = null;

    private KAccount m_account = null;
    private Color m_colour = Color.FromName(KAccount.c_noColourName);
    private bool m_editMode = false;

    //-------------------------------------------------------------------------

    public KAccountSetupForm(KBook book)
    {
      try
      {
        // init components
        InitializeComponent();

        // init
        m_book = book;
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    public KAccountSetupForm(KBook book, KAccount account)
    {
      try
      {
        // init
        m_book = book;
        m_account = account;
        m_editMode = true;

        // init components
        InitializeComponent();

        this.Text = "Edit Account '" + m_account.GetAccountName() + "'";

        if (m_account.IsMasterAccount())
        {
          nameBox.Enabled = false;
          descriptionBox.Enabled = false;
          typeBox.Enabled = false;
          masterAccountBox.Enabled = false;
          inheritParentColour.Checked = false;
          inheritParentColour.Enabled = false;
          hideInTree.Checked = false;
        }

        okButton.Text = "Save";
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void KAccountSetupFormLoad(object sender, EventArgs e)
    {
      try
      {
        // misc
        colourPnl.BackColor = m_colour;
        inheritParentColour.Checked = true;

        // load account types into list box
        foreach (KAccount acc in m_book.GetAccountList())
        {
          if (acc.IsMasterAccount() &&
              acc.GetAccountType() != KAccount.c_unknown)
          {
            typeBox.Items.Add(acc);
          }
        }

        if (typeBox.Items.Count > 0)
        {
          typeBox.SelectedIndex = 0;
        }

        // editing? set account info
        if (m_editMode)
        {
          nameBox.Text = m_account.GetAccountName();
          descriptionBox.Text = m_account.GetDescription();
          typeBox.Text = m_account.GetAccountTypeName();
          colourPnl.BackColor = m_account.GetColour();
          hideInTree.Checked = m_account.HideInTree;

          if (m_account.IsInheritsParentColour())
          {
            inheritParentColour.Checked = true;
          }
          else
          {
            inheritParentColour.Checked = false;
          }

          if (m_account.IsMasterAccount() == false)
          {
            masterAccountBox.SelectedItem = m_account.GetParent();
          }
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void ColourPnlClick(object sender, System.EventArgs e)
    {
      try
      {
        // inherit parent colour? don't do anything
        if (inheritParentColour.Checked)
        {
          return;
        }

        // do colour dialog
        ColorDialog dlg = new ColorDialog();

        dlg.Color = m_account.GetColour();

        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
          m_colour = dlg.Color;

          colourPnl.BackColor = m_colour;
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void OkButtonClick(object sender, System.EventArgs e)
    {
      try
      {
        KAccount parent = (KAccount) masterAccountBox.SelectedItem;

        // check name
        if (nameBox.Text.Equals(""))
        {
          MessageBox.Show("You must enter a name.",
            "Account Name",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

          return;
        }

        // does parent account already have child with this name?
        if (m_editMode == false)
        {
          foreach (KAccount a in parent.GetChildren(false))
          {
            if (a.GetAccountName().Equals(nameBox.Text, StringComparison.OrdinalIgnoreCase))
            {
              KMainForm.InfoMsg("An account already exists with this name.", "Account Name");

              return;
            }
          }
        }

        // does the parent account have transactions?
        if (parent.GetTransactions().Count > 0)
        {
          DialogResult r =
            KMainForm.ConfirmMsg("The parent account you have selected has transactions.\n\n" +
                                 "Parent accounts can not have transactions - these transactions " +
                                 "will be moved to the new account you are creating.\n\n" +
                                 "Continue?",
              "Parent Account Transactions");

          if (r == DialogResult.No)
          {
            return;
          }
        }

        // hide the form
        Hide();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void CancelBtnClick(object sender, System.EventArgs e)
    {
      try
      {
        Dispose();
      }
      catch (Exception ex)
      {
        KMainForm.ErrorMsg(ex.Message, "Error");
      }
    }

    //-------------------------------------------------------------------------

    void TypeBoxSelectedValueChanged(object sender, System.EventArgs e)
    {
      try
      {
        // clear master account box
        masterAccountBox.Items.Clear();

        // add select master account & it's children to master account box
        AddAccountToMasterAccountBox((KAccount) typeBox.SelectedItem);

        // select first item
        if (masterAccountBox.Items.Count > 0)
        {
          masterAccountBox.SelectedIndex = 0;
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    private void AddAccountToMasterAccountBox(KAccount acc)
    {
      try
      {
        // add account
        masterAccountBox.Items.Add(acc);

        // add account's children
        foreach (KAccount child in acc.GetChildren(false))
        {
          AddAccountToMasterAccountBox(child);
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void MasterAccountBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        // set colour with selected master account's colour
        if (inheritParentColour.Checked)
        {
          colourPnl.BackColor = ((KAccount) masterAccountBox.SelectedItem).GetColour();
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void InheritParentColourCheckedChanged(object sender, EventArgs e)
    {
      try
      {
        // inheriting? get the parent colour
        if (inheritParentColour.Checked)
        {
          colourPnl.Enabled = false;

          if (masterAccountBox.SelectedItem != null)
          {
            colourPnl.BackColor = ((KAccount) masterAccountBox.SelectedItem).GetColour();
          }
          else
          {
            colourPnl.BackColor = Color.FromName(KAccount.c_noColourName);
          }

          m_colour = colourPnl.BackColor;
        }
        // not inheriting, make colour selectable
        else
        {
          colourPnl.Enabled = true;
          m_colour = colourPnl.BackColor;
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    public String GetName()
    {
      return nameBox.Text;
    }

    //-------------------------------------------------------------------------

    public String GetDescription()
    {
      return descriptionBox.Text;
    }

    //-------------------------------------------------------------------------

    public String GetAccountType()
    {
      return typeBox.Text;
    }

    //-------------------------------------------------------------------------

    public KAccount GetMasterAccount()
    {
      if (m_account != null &&
          m_account.IsMasterAccount())
      {
        return null;
      }
      else
      {
        return (KAccount) masterAccountBox.SelectedItem;
      }
    }

    //-------------------------------------------------------------------------

    public Color GetColour()
    {
      if (inheritParentColour.Checked)
      {
        return Color.FromName(KAccount.c_noColourName);
      }
      else
      {
        return m_colour;
      }
    }

    //-------------------------------------------------------------------------

    public bool GetHideInTree()
    {
      return hideInTree.Checked;
    }

    //-------------------------------------------------------------------------
  }
}