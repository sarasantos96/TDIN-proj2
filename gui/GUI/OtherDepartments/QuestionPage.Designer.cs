namespace OtherDepartments
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
            this.titleBox = new System.Windows.Forms.TextBox();
            this.questionBox = new System.Windows.Forms.TextBox();
            this.responseBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sendResponseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(82, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(82, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Question";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(82, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Response";
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.SystemColors.Window;
            this.titleBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.titleBox.Location = new System.Drawing.Point(160, 32);
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(511, 26);
            this.titleBox.TabIndex = 3;
            // 
            // questionBox
            // 
            this.questionBox.BackColor = System.Drawing.SystemColors.Window;
            this.questionBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.questionBox.Location = new System.Drawing.Point(85, 118);
            this.questionBox.Multiline = true;
            this.questionBox.Name = "questionBox";
            this.questionBox.ReadOnly = true;
            this.questionBox.Size = new System.Drawing.Size(586, 106);
            this.questionBox.TabIndex = 4;
            // 
            // responseBox
            // 
            this.responseBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.responseBox.Location = new System.Drawing.Point(85, 275);
            this.responseBox.Multiline = true;
            this.responseBox.Name = "responseBox";
            this.responseBox.Size = new System.Drawing.Size(586, 113);
            this.responseBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sendResponseButton
            // 
            this.sendResponseButton.Location = new System.Drawing.Point(86, 394);
            this.sendResponseButton.Name = "sendResponseButton";
            this.sendResponseButton.Size = new System.Drawing.Size(143, 27);
            this.sendResponseButton.TabIndex = 7;
            this.sendResponseButton.Text = "Send response";
            this.sendResponseButton.UseVisualStyleBackColor = true;
            this.sendResponseButton.Click += new System.EventHandler(this.sendResponseButton_Click);
            // 
            // QuestionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 522);
            this.Controls.Add(this.sendResponseButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.responseBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.titleBox);
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
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.TextBox responseBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sendResponseButton;
    }
}