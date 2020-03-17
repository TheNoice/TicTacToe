namespace TicTacToe
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBotRight = new System.Windows.Forms.Button();
            this.buttonBotCenter = new System.Windows.Forms.Button();
            this.buttonBotLeft = new System.Windows.Forms.Button();
            this.buttonMidRight = new System.Windows.Forms.Button();
            this.buttonMidCenter = new System.Windows.Forms.Button();
            this.buttonMidLeft = new System.Windows.Forms.Button();
            this.buttonTopRight = new System.Windows.Forms.Button();
            this.buttonTopCenter = new System.Windows.Forms.Button();
            this.buttonTopLeft = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.buttonBotRight, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBotCenter, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBotLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMidRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMidCenter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMidLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonTopRight, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTopCenter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTopLeft, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonBotRight
            // 
            this.buttonBotRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBotRight.Location = new System.Drawing.Point(253, 241);
            this.buttonBotRight.Name = "buttonBotRight";
            this.buttonBotRight.Size = new System.Drawing.Size(121, 115);
            this.buttonBotRight.TabIndex = 8;
            this.buttonBotRight.UseVisualStyleBackColor = true;
            this.buttonBotRight.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonBotCenter
            // 
            this.buttonBotCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBotCenter.Location = new System.Drawing.Point(128, 241);
            this.buttonBotCenter.Name = "buttonBotCenter";
            this.buttonBotCenter.Size = new System.Drawing.Size(119, 115);
            this.buttonBotCenter.TabIndex = 7;
            this.buttonBotCenter.UseVisualStyleBackColor = true;
            this.buttonBotCenter.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonBotLeft
            // 
            this.buttonBotLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBotLeft.Location = new System.Drawing.Point(3, 241);
            this.buttonBotLeft.Name = "buttonBotLeft";
            this.buttonBotLeft.Size = new System.Drawing.Size(119, 115);
            this.buttonBotLeft.TabIndex = 6;
            this.buttonBotLeft.UseVisualStyleBackColor = true;
            this.buttonBotLeft.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonMidRight
            // 
            this.buttonMidRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMidRight.Location = new System.Drawing.Point(253, 122);
            this.buttonMidRight.Name = "buttonMidRight";
            this.buttonMidRight.Size = new System.Drawing.Size(121, 113);
            this.buttonMidRight.TabIndex = 5;
            this.buttonMidRight.UseVisualStyleBackColor = true;
            this.buttonMidRight.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonMidCenter
            // 
            this.buttonMidCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMidCenter.Location = new System.Drawing.Point(128, 122);
            this.buttonMidCenter.Name = "buttonMidCenter";
            this.buttonMidCenter.Size = new System.Drawing.Size(119, 113);
            this.buttonMidCenter.TabIndex = 4;
            this.buttonMidCenter.UseVisualStyleBackColor = true;
            this.buttonMidCenter.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonMidLeft
            // 
            this.buttonMidLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMidLeft.Location = new System.Drawing.Point(3, 122);
            this.buttonMidLeft.Name = "buttonMidLeft";
            this.buttonMidLeft.Size = new System.Drawing.Size(119, 113);
            this.buttonMidLeft.TabIndex = 3;
            this.buttonMidLeft.UseVisualStyleBackColor = true;
            this.buttonMidLeft.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonTopRight
            // 
            this.buttonTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopRight.Location = new System.Drawing.Point(253, 3);
            this.buttonTopRight.Name = "buttonTopRight";
            this.buttonTopRight.Size = new System.Drawing.Size(121, 113);
            this.buttonTopRight.TabIndex = 2;
            this.buttonTopRight.UseVisualStyleBackColor = true;
            this.buttonTopRight.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonTopCenter
            // 
            this.buttonTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopCenter.Location = new System.Drawing.Point(128, 3);
            this.buttonTopCenter.Name = "buttonTopCenter";
            this.buttonTopCenter.Size = new System.Drawing.Size(119, 113);
            this.buttonTopCenter.TabIndex = 1;
            this.buttonTopCenter.UseVisualStyleBackColor = true;
            this.buttonTopCenter.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // buttonTopLeft
            // 
            this.buttonTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopLeft.Location = new System.Drawing.Point(3, 3);
            this.buttonTopLeft.Name = "buttonTopLeft";
            this.buttonTopLeft.Size = new System.Drawing.Size(119, 113);
            this.buttonTopLeft.TabIndex = 0;
            this.buttonTopLeft.UseVisualStyleBackColor = true;
            this.buttonTopLeft.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(45, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 398);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(360, 370);
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonTopLeft;
        private System.Windows.Forms.Button buttonBotRight;
        private System.Windows.Forms.Button buttonBotCenter;
        private System.Windows.Forms.Button buttonBotLeft;
        private System.Windows.Forms.Button buttonMidRight;
        private System.Windows.Forms.Button buttonMidCenter;
        private System.Windows.Forms.Button buttonMidLeft;
        private System.Windows.Forms.Button buttonTopRight;
        private System.Windows.Forms.Button buttonTopCenter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

