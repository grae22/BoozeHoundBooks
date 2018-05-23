using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace BoozeHoundBooks
{
  public partial class KSummaryExpressionBuilderForm : Form
  {
    // class constants --------------------------------------------------------

    private const int c_maxFieldCount = 50;

    // class vars -------------------------------------------------------------

    private KBook m_book;
    private RadioButton m_selectedField;
    private KSummaryExpression m_expression;
    private bool m_editMode = false;

    //-------------------------------------------------------------------------

    public KSummaryExpressionBuilderForm(KBook book)
    {
      InitializeComponent();

      // init
      m_book = book;

      SetupFieldPanel();
    }

    //-------------------------------------------------------------------------

    public KSummaryExpressionBuilderForm(KSummaryExpression expression, KBook book)
    {
      InitializeComponent();

      // init
      m_editMode = true;
      m_expression = expression;
      m_book = book;

      SetupFieldPanel();

      nameBox.Text = expression.GetName();
      descriptionBox.Text = expression.GetDescription();

      // populate fields
      IEnumerator fields = m_expression.Fields.GetEnumerator();
      int i = 0;

      while (fields.MoveNext())
      {
        KSummaryExpression.KField field = (KSummaryExpression.KField) fields.Current;

        ((RadioButton) fieldPnl.Controls[i++]).Text = field.ToString().Trim();
      }
    }

    //-------------------------------------------------------------------------

    private void SetupFieldPanel()
    {
      // setup field panel
      for (int i = 0; i < c_maxFieldCount; i++)
      {
        RadioButton btn = new RadioButton();
        btn.Appearance = Appearance.Button;
        btn.AutoSize = true;
        btn.MinimumSize = new Size(32, 32);
        btn.Click += FieldSelected;
        btn.Font = new Font(btn.Font, FontStyle.Bold);
        btn.TextAlign = ContentAlignment.MiddleCenter;

        fieldPnl.Controls.Add(btn);
      }

      ((RadioButton) fieldPnl.Controls[0]).Checked = true;
      m_selectedField = (RadioButton) fieldPnl.Controls[0];
    }

    //-------------------------------------------------------------------------

    void SaveBtnClick(object sender, EventArgs e)
    {
      try
      {
        // no name?
        String name = nameBox.Text;

        if (name.Equals(""))
        {
          KMainForm.InfoMsg("You must enter a name for the expression.", "Name");

          nameBox.Focus();

          return;
        }

        // set up new expression ob
        if (m_editMode == false)
        {
          m_expression = new KSummaryExpression(name, descriptionBox.Text);
        }
        else
        {
          m_expression.RemoveAllFields();
        }

        // loop through fields
        for (int i = 0; i < c_maxFieldCount; i++)
        {
          RadioButton btn = (RadioButton) fieldPnl.Controls[i];

          // ignore unused fields
          if (btn.Text.Equals("") == false)
          {
            // what type of field?
            KSummaryExpression.KField field;

            // operator
            if (KSummaryExpression.KField.GetOperatorTypeFromText(btn.Text) !=
                KSummaryExpression.KField.OperatorType.Unknown)
            {
              field = new KSummaryExpression.KField(KSummaryExpression.KField.GetOperatorTypeFromText(btn.Text));
            }

            // value
            else if (KCommon.IsNumeric(btn.Text))
            {
              field = new KSummaryExpression.KField(decimal.Parse(btn.Text));
            }

            // must be an account
            else
            {
              KAccount acc = m_book.GetAccount(btn.Text);

              if (acc != null)
              {
                field = new KSummaryExpression.KField(acc);
              }
              else
              {
                throw new Exception("KSummaryExpressionBuilderForm.SaveBtnClick() : Account not found - '" + btn.Text +
                                    "'.");
              }
            }

            // add field to expression
            m_expression.AddField(field);
          }
        }

        // check the expression
        String msg;

        if (m_expression.BuildExpression(out msg) == false)
        {
          KMainForm.InfoMsg(msg, "Invalid Expression");

          return;
        }

        // add to the book
        if (m_editMode == false)
        {
          m_book.AddSummaryExpression(m_expression);
        }

        // close
        Dispose();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    void CancelBtnClick(object sender, EventArgs e)
    {
      Dispose();
    }

    //-------------------------------------------------------------------------

    private void OperatorSelected(object sender, EventArgs e)
    {
      if (m_selectedField != null)
      {
        // set with selected operator
        m_selectedField.Text = ((Button) sender).Text;

        // select the next field
        MoveToNextField();
      }
    }

    //-------------------------------------------------------------------------

    private void FieldSelected(object sender, EventArgs e)
    {
      m_selectedField = (RadioButton) sender;
    }

    //-------------------------------------------------------------------------

    void ValueBtnClick(object sender, EventArgs e)
    {
      // do input dialog
      KInputBox dlg = new KInputBox("Value", "Enter a value:", false, true);

      DialogResult r = dlg.ShowDialog(this);

      if (r == DialogResult.Cancel)
      {
        return;
      }

      m_selectedField.Text = dlg.GetInputText();

      // select the next field
      MoveToNextField();

      BringToFront();
    }

    //-------------------------------------------------------------------------

    private void MoveToNextField()
    {
      int i = fieldPnl.Controls.IndexOf(m_selectedField);

      if (i != -1 &&
          i + 1 < fieldPnl.Controls.Count)
      {
        ((RadioButton) fieldPnl.Controls[i + 1]).Checked = true;
        m_selectedField = (RadioButton) fieldPnl.Controls[i + 1];
      }
    }

    //-------------------------------------------------------------------------

    void AccountBtnClick(object sender, EventArgs e)
    {
      KSelectAccountForm dlg = new KSelectAccountForm(m_book);

      DialogResult r = dlg.ShowDialog(this);

      if (r == DialogResult.Cancel)
      {
        return;
      }

      m_selectedField.Text = dlg.GetSelectedAccount().GetQualifiedAccountName();

      MoveToNextField();

      BringToFront();
    }

    //-------------------------------------------------------------------------

    void ShiftLeftBtnClick(object sender, EventArgs e)
    {
      // nothing selected?
      if (m_selectedField == null)
      {
        return;
      }

      // is there space?
      // find selected control
      int selectedIndex = fieldPnl.Controls.IndexOf(m_selectedField);

      if (selectedIndex == -1)
      {
        return;
      }

      if (((RadioButton) fieldPnl.Controls[selectedIndex]).Text.Equals(""))
      {
        return;
      }

      // no space found?
      if (selectedIndex == 0 ||
          ((RadioButton) fieldPnl.Controls[selectedIndex - 1]).Text.Equals("") == false)
      {
        KMainForm.InfoMsg("Field can not be shifted - there is no space.", "Shift Left");
        return;
      }

      // shift to the left
      ((RadioButton) fieldPnl.Controls[selectedIndex - 1]).Text = ((RadioButton) fieldPnl.Controls[selectedIndex]).Text;
      ((RadioButton) fieldPnl.Controls[selectedIndex]).Text = "";

      // re-select selected item
      ((RadioButton) fieldPnl.Controls[selectedIndex - 1]).Checked = true;
      m_selectedField = ((RadioButton) fieldPnl.Controls[selectedIndex - 1]);
    }

    //-------------------------------------------------------------------------

    void ShiftRightBtnClick(object sender, EventArgs e)
    {
      // nothing selected?
      if (m_selectedField == null)
      {
        return;
      }

      // is there space?
      // find selected control
      int selectedIndex = fieldPnl.Controls.IndexOf(m_selectedField);

      if (selectedIndex == -1)
      {
        return;
      }

      if (((RadioButton) fieldPnl.Controls[selectedIndex]).Text.Equals(""))
      {
        return;
      }

      // no space found?
      if (selectedIndex == c_maxFieldCount - 1 ||
          ((RadioButton) fieldPnl.Controls[selectedIndex + 1]).Text.Equals("") == false)
      {
        KMainForm.InfoMsg("Field can not be shifted - there is no space.", "Shift Right");
        return;
      }

      // shift to the left
      ((RadioButton) fieldPnl.Controls[selectedIndex + 1]).Text = ((RadioButton) fieldPnl.Controls[selectedIndex]).Text;
      ((RadioButton) fieldPnl.Controls[selectedIndex]).Text = "";

      // re-select selected item
      ((RadioButton) fieldPnl.Controls[selectedIndex + 1]).Checked = true;
      m_selectedField = ((RadioButton) fieldPnl.Controls[selectedIndex + 1]);
    }

    //-------------------------------------------------------------------------

    void RemoveBtnClick(object sender, EventArgs e)
    {
      // find selected control
      int selectedIndex = fieldPnl.Controls.IndexOf(m_selectedField);

      if (selectedIndex == -1)
      {
        return;
      }

      ((RadioButton) fieldPnl.Controls[selectedIndex]).Text = "";
    }

    //-------------------------------------------------------------------------
  }
}