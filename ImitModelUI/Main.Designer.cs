namespace ImitModelUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мастераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чекиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterAddToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.услугиToolStripMenuItem,
            this.мастераToolStripMenuItem,
            this.чекиToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceAddToolStripMenuItem});
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.услугиToolStripMenuItem.Text = "Услуги";
            this.услугиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // мастераToolStripMenuItem
            // 
            this.мастераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterAddToolStripMenuItem1});
            this.мастераToolStripMenuItem.Name = "мастераToolStripMenuItem";
            this.мастераToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.мастераToolStripMenuItem.Text = "Мастера";
            this.мастераToolStripMenuItem.Click += new System.EventHandler(this.мастераToolStripMenuItem_Click);
            // 
            // чекиToolStripMenuItem
            // 
            this.чекиToolStripMenuItem.Name = "чекиToolStripMenuItem";
            this.чекиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.чекиToolStripMenuItem.Text = "Чеки";
            this.чекиToolStripMenuItem.Click += new System.EventHandler(this.чекиToolStripMenuItem_Click);
            // 
            // serviceAddToolStripMenuItem
            // 
            this.serviceAddToolStripMenuItem.Name = "serviceAddToolStripMenuItem";
            this.serviceAddToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviceAddToolStripMenuItem.Text = "Добавить";
            // 
            // masterAddToolStripMenuItem1
            // 
            this.masterAddToolStripMenuItem1.Name = "masterAddToolStripMenuItem1";
            this.masterAddToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.masterAddToolStripMenuItem1.Text = "Добавить";
            this.masterAddToolStripMenuItem1.Click += new System.EventHandler(this.masterAddToolStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem таблицыToolStripMenuItem;
        private ToolStripMenuItem услугиToolStripMenuItem;
        private ToolStripMenuItem мастераToolStripMenuItem;
        private ToolStripMenuItem чекиToolStripMenuItem;
        private ToolStripMenuItem serviceAddToolStripMenuItem;
        private ToolStripMenuItem masterAddToolStripMenuItem1;
    }
}