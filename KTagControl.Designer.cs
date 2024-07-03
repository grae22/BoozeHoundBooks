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
        uiMainPanel = new GroupBox();
        uiAddButton = new Button();
        uiNewTag = new TextBox();
        uiTagList = new CheckedListBox();
        uiMainPanel.SuspendLayout();
        SuspendLayout();
        // 
        // uiMainPanel
        // 
        uiMainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        uiMainPanel.Controls.Add(uiAddButton);
        uiMainPanel.Controls.Add(uiNewTag);
        uiMainPanel.Controls.Add(uiTagList);
        uiMainPanel.Dock = DockStyle.Fill;
        uiMainPanel.Location = new Point(0, 0);
        uiMainPanel.Name = "uiMainPanel";
        uiMainPanel.Size = new Size(296, 164);
        uiMainPanel.TabIndex = 0;
        uiMainPanel.TabStop = false;
        uiMainPanel.Text = "Tags";
        // 
        // uiAddButton
        // 
        uiAddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        uiAddButton.Location = new Point(128, 128);
        uiAddButton.Name = "uiAddButton";
        uiAddButton.Size = new Size(75, 23);
        uiAddButton.TabIndex = 2;
        uiAddButton.TabStop = false;
        uiAddButton.Text = "Add";
        uiAddButton.UseVisualStyleBackColor = true;
        uiAddButton.Click += uiAddButton_Click;
        // 
        // uiNewTag
        // 
        uiNewTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        uiNewTag.Location = new Point(22, 128);
        uiNewTag.Name = "uiNewTag";
        uiNewTag.Size = new Size(100, 23);
        uiNewTag.TabIndex = 0;
        uiNewTag.TabStop = false;
        uiNewTag.TextChanged += uiNewTag_TextChanged;
        // 
        // uiTagList
        // 
        uiTagList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        uiTagList.CheckOnClick = true;
        uiTagList.FormattingEnabled = true;
        uiTagList.HorizontalScrollbar = true;
        uiTagList.Location = new Point(22, 25);
        uiTagList.MultiColumn = true;
        uiTagList.Name = "uiTagList";
        uiTagList.Size = new Size(258, 94);
        uiTagList.TabIndex = 0;
        uiTagList.TabStop = false;
        // 
        // KTagControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(uiMainPanel);
        Name = "KTagControl";
        Size = new Size(296, 164);
        uiMainPanel.ResumeLayout(false);
        uiMainPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox uiMainPanel;
    private CheckedListBox uiTagList;
    private Button uiAddButton;
    private TextBox uiNewTag;
}
