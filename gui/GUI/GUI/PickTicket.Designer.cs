namespace GUI
{
    partial class PickTicket
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickTicket));
            this.unassignedLV = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unassignedLV
            // 
            this.unassignedLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.User});
            this.unassignedLV.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.unassignedLV.FullRowSelect = true;
            this.unassignedLV.GridLines = true;
            this.unassignedLV.Location = new System.Drawing.Point(52, 96);
            this.unassignedLV.Name = "unassignedLV";
            this.unassignedLV.Size = new System.Drawing.Size(801, 400);
            this.unassignedLV.TabIndex = 0;
            this.unassignedLV.UseCompatibleStateImageBehavior = false;
            this.unassignedLV.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 435;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 160;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.button1.Location = new System.Drawing.Point(398, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 64);
            this.button1.TabIndex = 1;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.label1.Location = new System.Drawing.Point(48, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose new Tickets to solve (double-click on row):";
            // 
            // PickTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 595);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unassignedLV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PickTicket";
            this.Text = "PickTicket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView unassignedLV;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}