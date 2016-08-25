namespace StarboundModTools.UI.Designer
{
    partial class SBUIDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.treeView = new System.Windows.Forms.TreeView();
            this.preview = new StarboundModTools.UI.Designer.DrawPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.nodeChooser = new System.Windows.Forms.ComboBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.jsonOutput = new System.Windows.Forms.RichTextBox();
            this.jsonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(186, 482);
            this.treeView.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.AutoScroll = true;
            this.preview.EnableClock = false;
            this.preview.Fps = 30;
            this.preview.Location = new System.Drawing.Point(204, 12);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(640, 580);
            this.preview.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 500);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(64, 26);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(12, 532);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(64, 25);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // nodeChooser
            // 
            this.nodeChooser.FormattingEnabled = true;
            this.nodeChooser.Location = new System.Drawing.Point(82, 504);
            this.nodeChooser.Name = "nodeChooser";
            this.nodeChooser.Size = new System.Drawing.Size(111, 21);
            this.nodeChooser.TabIndex = 4;
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(82, 532);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 25);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(12, 566);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 6;
            this.typeLabel.Text = "Type";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(49, 563);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(152, 20);
            this.valueTextBox.TabIndex = 7;
            // 
            // jsonOutput
            // 
            this.jsonOutput.Location = new System.Drawing.Point(850, 45);
            this.jsonOutput.Name = "jsonOutput";
            this.jsonOutput.Size = new System.Drawing.Size(403, 546);
            this.jsonOutput.TabIndex = 8;
            this.jsonOutput.Text = "";
            // 
            // jsonLabel
            // 
            this.jsonLabel.AutoSize = true;
            this.jsonLabel.Font = new System.Drawing.Font("Maiandra GD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsonLabel.Location = new System.Drawing.Point(855, 14);
            this.jsonLabel.Name = "jsonLabel";
            this.jsonLabel.Size = new System.Drawing.Size(226, 26);
            this.jsonLabel.TabIndex = 9;
            this.jsonLabel.Text = ".Json File Source Code";
            // 
            // SBUIDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 601);
            this.Controls.Add(this.jsonLabel);
            this.Controls.Add(this.jsonOutput);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.nodeChooser);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.treeView);
            this.Name = "SBUIDesigner";
            this.Text = "SBUIDesigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private DrawPanel preview;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox nodeChooser;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.RichTextBox jsonOutput;
        private System.Windows.Forms.Label jsonLabel;
    }
}