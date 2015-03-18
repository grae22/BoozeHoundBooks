/*
 * Created by SharpDevelop.
 * User: Graeme
 * Date: 2009/09/26
 * Time: 09:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BoozeHoundBooks
{
	partial class KAccountSetupForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
      this.label1 = new System.Windows.Forms.Label();
      this.nameBox = new System.Windows.Forms.TextBox();
      this.descriptionBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.typeBox = new System.Windows.Forms.ListBox();
      this.masterAccountBox = new System.Windows.Forms.ListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.colourPnl = new System.Windows.Forms.Panel();
      this.inheritParentColour = new System.Windows.Forms.CheckBox();
      this.hideInTree = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point( 37, 12 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 35, 13 );
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // nameBox
      // 
      this.nameBox.Location = new System.Drawing.Point( 81, 9 );
      this.nameBox.Name = "nameBox";
      this.nameBox.Size = new System.Drawing.Size( 100, 20 );
      this.nameBox.TabIndex = 1;
      // 
      // descriptionBox
      // 
      this.descriptionBox.Location = new System.Drawing.Point( 81, 38 );
      this.descriptionBox.Name = "descriptionBox";
      this.descriptionBox.Size = new System.Drawing.Size( 100, 20 );
      this.descriptionBox.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point( 12, 41 );
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size( 60, 13 );
      this.label2.TabIndex = 2;
      this.label2.Text = "Description";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point( 212, 12 );
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size( 31, 13 );
      this.label3.TabIndex = 4;
      this.label3.Text = "Type";
      // 
      // typeBox
      // 
      this.typeBox.FormattingEnabled = true;
      this.typeBox.Location = new System.Drawing.Point( 249, 9 );
      this.typeBox.Name = "typeBox";
      this.typeBox.Size = new System.Drawing.Size( 119, 82 );
      this.typeBox.TabIndex = 5;
      this.typeBox.SelectedValueChanged += new System.EventHandler( this.TypeBoxSelectedValueChanged );
      // 
      // masterAccountBox
      // 
      this.masterAccountBox.FormattingEnabled = true;
      this.masterAccountBox.Location = new System.Drawing.Point( 81, 98 );
      this.masterAccountBox.Name = "masterAccountBox";
      this.masterAccountBox.Size = new System.Drawing.Size( 287, 225 );
      this.masterAccountBox.TabIndex = 6;
      this.masterAccountBox.SelectedIndexChanged += new System.EventHandler( this.MasterAccountBoxSelectedIndexChanged );
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point( 12, 103 );
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size( 60, 30 );
      this.label4.TabIndex = 7;
      this.label4.Text = "Master Account";
      this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point( 293, 336 );
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size( 75, 23 );
      this.okButton.TabIndex = 8;
      this.okButton.Text = "Create";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler( this.OkButtonClick );
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point( 293, 363 );
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size( 75, 23 );
      this.cancelBtn.TabIndex = 9;
      this.cancelBtn.Text = "Close";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler( this.CancelBtnClick );
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point( 33, 343 );
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size( 37, 13 );
      this.label5.TabIndex = 10;
      this.label5.Text = "Colour";
      this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // colourPnl
      // 
      this.colourPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.colourPnl.Location = new System.Drawing.Point( 81, 338 );
      this.colourPnl.Name = "colourPnl";
      this.colourPnl.Size = new System.Drawing.Size( 23, 23 );
      this.colourPnl.TabIndex = 11;
      this.colourPnl.Click += new System.EventHandler( this.ColourPnlClick );
      // 
      // inheritParentColour
      // 
      this.inheritParentColour.AutoSize = true;
      this.inheritParentColour.Location = new System.Drawing.Point( 110, 342 );
      this.inheritParentColour.Name = "inheritParentColour";
      this.inheritParentColour.Size = new System.Drawing.Size( 89, 17 );
      this.inheritParentColour.TabIndex = 12;
      this.inheritParentColour.Text = "Inherit Parent";
      this.inheritParentColour.UseVisualStyleBackColor = true;
      this.inheritParentColour.CheckedChanged += new System.EventHandler( this.InheritParentColourCheckedChanged );
      // 
      // hideInTree
      // 
      this.hideInTree.AutoSize = true;
      this.hideInTree.Location = new System.Drawing.Point( 81, 68 );
      this.hideInTree.Name = "hideInTree";
      this.hideInTree.Size = new System.Drawing.Size( 80, 17 );
      this.hideInTree.TabIndex = 13;
      this.hideInTree.Text = "Hide in tree";
      this.hideInTree.UseVisualStyleBackColor = true;
      // 
      // KAccountSetupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 382, 398 );
      this.ControlBox = false;
      this.Controls.Add( this.hideInTree );
      this.Controls.Add( this.inheritParentColour );
      this.Controls.Add( this.colourPnl );
      this.Controls.Add( this.label5 );
      this.Controls.Add( this.cancelBtn );
      this.Controls.Add( this.okButton );
      this.Controls.Add( this.label4 );
      this.Controls.Add( this.masterAccountBox );
      this.Controls.Add( this.typeBox );
      this.Controls.Add( this.label3 );
      this.Controls.Add( this.descriptionBox );
      this.Controls.Add( this.label2 );
      this.Controls.Add( this.nameBox );
      this.Controls.Add( this.label1 );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KAccountSetupForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Account Setup";
      this.Load += new System.EventHandler( this.KAccountSetupFormLoad );
      this.ResumeLayout( false );
      this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox inheritParentColour;
		private System.Windows.Forms.Panel colourPnl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox masterAccountBox;
		private System.Windows.Forms.ListBox typeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox descriptionBox;
		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox hideInTree;
	}
}
