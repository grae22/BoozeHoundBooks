namespace BoozeHoundBooks;

partial class KTagControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        uiMainPanel = new Panel();
        label1 = new Label();
        uiAddButton = new Button();
        uiNewTag = new TextBox();
        uiTagList = new CheckedListBox();
        uiMainPanel.SuspendLayout();
        SuspendLayout();
        // 
        // uiMainPanel
        // 
        uiMainPanel.Controls.Add(label1);
        uiMainPanel.Controls.Add(uiAddButton);
        uiMainPanel.Controls.Add(uiNewTag);
        uiMainPanel.Controls.Add(uiTagList);
        uiMainPanel.Dock = DockStyle.Fill;
        uiMainPanel.Location = new Point(0, 0);
        uiMainPanel.Name = "uiMainPanel";
        uiMainPanel.Size = new Size(296, 171);
        uiMainPanel.TabIndex = 0;
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(296, 15);
        label1.TabIndex = 3;
        label1.Text = "Tags";
        label1.TextAlign = ContentAlignment.TopCenter;
        // 
        // uiAddButton
        // 
        uiAddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        uiAddButton.Location = new Point(109, 138);
        uiAddButton.Name = "uiAddButton";
        uiAddButton.Size = new Size(75, 23);
        uiAddButton.TabIndex = 2;
        uiAddButton.Text = "Add";
        uiAddButton.UseVisualStyleBackColor = true;
        uiAddButton.Click += uiAddButton_Click;
        // 
        // uiNewTag
        // 
        uiNewTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        uiNewTag.Location = new Point(3, 138);
        uiNewTag.Name = "uiNewTag";
        uiNewTag.Size = new Size(100, 23);
        uiNewTag.TabIndex = 1;
        uiNewTag.TextChanged += uiNewTag_TextChanged;
        // 
        // uiTagList
        // 
        uiTagList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        uiTagList.CheckOnClick = true;
        uiTagList.FormattingEnabled = true;
        uiTagList.Location = new Point(3, 21);
        uiTagList.Name = "uiTagList";
        uiTagList.Size = new Size(290, 112);
        uiTagList.TabIndex = 0;
        // 
        // KTagControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(uiMainPanel);
        Name = "KTagControl";
        Size = new Size(296, 171);
        uiMainPanel.ResumeLayout(false);
        uiMainPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel uiMainPanel;
    private CheckedListBox uiTagList;
    private Button uiAddButton;
    private TextBox uiNewTag;
    private Label label1;
}
