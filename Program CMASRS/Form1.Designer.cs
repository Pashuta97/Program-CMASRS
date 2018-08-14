namespace Program_CMASRS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._dataGridViewElements = new System.Windows.Forms.DataGridView();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._reloadButton = new System.Windows.Forms.Button();
            this._submitButton = new System.Windows.Forms.Button();
            this._findRelevantButton = new System.Windows.Forms.Button();
            this._dataGridViewItems = new System.Windows.Forms.DataGridView();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._printDialog = new System.Windows.Forms.PrintDialog();
            this._printDocument = new System.Drawing.Printing.PrintDocument();
            this._richTextBox = new RichTextBoxPrintCtrl.RichTextBoxPrintCtrl();
            this._dataGridViewCriteria = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewItems)).BeginInit();
            this._menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCriteria)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewElements
            // 
            this._dataGridViewElements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._dataGridViewElements.BackgroundColor = System.Drawing.SystemColors.Control;
            this._dataGridViewElements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dataGridViewElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewElements.Location = new System.Drawing.Point(12, 114);
            this._dataGridViewElements.Name = "_dataGridViewElements";
            this._dataGridViewElements.Size = new System.Drawing.Size(628, 160);
            this._dataGridViewElements.TabIndex = 0;
            // 
            // _comboBox1
            // 
            this._comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Location = new System.Drawing.Point(12, 280);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(121, 21);
            this._comboBox1.TabIndex = 1;
            // 
            // _reloadButton
            // 
            this._reloadButton.Location = new System.Drawing.Point(186, 280);
            this._reloadButton.Name = "_reloadButton";
            this._reloadButton.Size = new System.Drawing.Size(121, 21);
            this._reloadButton.TabIndex = 2;
            this._reloadButton.Text = "Reload";
            this._reloadButton.UseVisualStyleBackColor = true;
            this._reloadButton.Click += new System.EventHandler(this._reloadButton_Click);
            // 
            // _submitButton
            // 
            this._submitButton.Location = new System.Drawing.Point(354, 280);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(121, 21);
            this._submitButton.TabIndex = 3;
            this._submitButton.Text = "Submit";
            this._submitButton.UseVisualStyleBackColor = true;
            this._submitButton.Click += new System.EventHandler(this._submitButton_Click);
            // 
            // _findRelevantButton
            // 
            this._findRelevantButton.Location = new System.Drawing.Point(519, 279);
            this._findRelevantButton.Name = "_findRelevantButton";
            this._findRelevantButton.Size = new System.Drawing.Size(121, 21);
            this._findRelevantButton.TabIndex = 4;
            this._findRelevantButton.Text = "Find relevant";
            this._findRelevantButton.UseVisualStyleBackColor = true;
            this._findRelevantButton.Click += new System.EventHandler(this._findRelevantButton_Click);
            // 
            // _dataGridViewItems
            // 
            this._dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this._dataGridViewItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewItems.Location = new System.Drawing.Point(12, 307);
            this._dataGridViewItems.Name = "_dataGridViewItems";
            this._dataGridViewItems.Size = new System.Drawing.Size(229, 175);
            this._dataGridViewItems.TabIndex = 5;
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(652, 24);
            this._menuStrip.TabIndex = 9;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveAsToolStripMenuItem,
            this._printToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _saveAsToolStripMenuItem
            // 
            this._saveAsToolStripMenuItem.Name = "_saveAsToolStripMenuItem";
            this._saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this._saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // _printToolStripMenuItem
            // 
            this._printToolStripMenuItem.Name = "_printToolStripMenuItem";
            this._printToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this._printToolStripMenuItem.Text = "Print";
            // 
            // _printDialog
            // 
            this._printDialog.UseEXDialog = true;
            // 
            // _richTextBox
            // 
            this._richTextBox.Location = new System.Drawing.Point(247, 307);
            this._richTextBox.Name = "_richTextBox";
            this._richTextBox.ReadOnly = true;
            this._richTextBox.Size = new System.Drawing.Size(393, 175);
            this._richTextBox.TabIndex = 10;
            this._richTextBox.Text = "";
            // 
            // _dataGridViewCriteria
            // 
            this._dataGridViewCriteria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._dataGridViewCriteria.BackgroundColor = System.Drawing.SystemColors.Control;
            this._dataGridViewCriteria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dataGridViewCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCriteria.Location = new System.Drawing.Point(12, 27);
            this._dataGridViewCriteria.Name = "_dataGridViewCriteria";
            this._dataGridViewCriteria.Size = new System.Drawing.Size(628, 86);
            this._dataGridViewCriteria.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 494);
            this.Controls.Add(this._dataGridViewCriteria);
            this.Controls.Add(this._richTextBox);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._dataGridViewItems);
            this.Controls.Add(this._findRelevantButton);
            this.Controls.Add(this._submitButton);
            this.Controls.Add(this._reloadButton);
            this.Controls.Add(this._comboBox1);
            this.Controls.Add(this._dataGridViewElements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewItems)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCriteria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewElements;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.Button _reloadButton;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.Button _findRelevantButton;
        private System.Windows.Forms.DataGridView _dataGridViewItems;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _printToolStripMenuItem;
        private System.Windows.Forms.PrintDialog _printDialog;
        private System.Drawing.Printing.PrintDocument _printDocument;
        private RichTextBoxPrintCtrl.RichTextBoxPrintCtrl _richTextBox;
        private System.Windows.Forms.DataGridView _dataGridViewCriteria;
    }
}

