namespace GUI
{
    partial class QuestionPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionPage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ticketIDBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.questionBox = new System.Windows.Forms.TextBox();
            this.ResponseBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.label1.Location = new System.Drawing.Point(111, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(114, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.label3.Location = new System.Drawing.Point(114, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Question";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.label4.Location = new System.Drawing.Point(114, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Response";
            // 
            // ticketIDBox
            // 
            this.ticketIDBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketIDBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketIDBox.Location = new System.Drawing.Point(257, 39);
            this.ticketIDBox.Name = "ticketIDBox";
            this.ticketIDBox.ReadOnly = true;
            this.ticketIDBox.Size = new System.Drawing.Size(446, 26);
            this.ticketIDBox.TabIndex = 4;
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.Location = new System.Drawing.Point(257, 89);
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(446, 26);
            this.titleBox.TabIndex = 5;
            // 
            // questionBox
            // 
            this.questionBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.questionBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionBox.Location = new System.Drawing.Point(115, 180);
            this.questionBox.Multiline = true;
            this.questionBox.Name = "questionBox";
            this.questionBox.ReadOnly = true;
            this.questionBox.Size = new System.Drawing.Size(588, 117);
            this.questionBox.TabIndex = 6;
            // 
            // ResponseBox
            // 
            this.ResponseBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ResponseBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseBox.Location = new System.Drawing.Point(115, 361);
            this.ResponseBox.Multiline = true;
            this.ResponseBox.Name = "ResponseBox";
            this.ResponseBox.ReadOnly = true;
            this.ResponseBox.Size = new System.Drawing.Size(588, 117);
            this.ResponseBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F);
            this.button1.Location = new System.Drawing.Point(340, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 53);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResponseBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.ticketIDBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionPage";
            this.Text = "QuestionPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ticketIDBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.TextBox ResponseBox;
        private System.Windows.Forms.Button button1;
    }
}