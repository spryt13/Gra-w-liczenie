namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.losujDzialanieButton = new System.Windows.Forms.Button();
            this.liczba1Label = new System.Windows.Forms.Label();
            this.liczba2Label = new System.Windows.Forms.Label();
            this.znakLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userInputTexBox = new System.Windows.Forms.TextBox();
            this.sprawdzenieButton = new System.Windows.Forms.Button();
            this.poprawnoscLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // losujDzialanieButton
            // 
            this.losujDzialanieButton.Location = new System.Drawing.Point(183, 217);
            this.losujDzialanieButton.Name = "losujDzialanieButton";
            this.losujDzialanieButton.Size = new System.Drawing.Size(75, 94);
            this.losujDzialanieButton.TabIndex = 0;
            this.losujDzialanieButton.Text = "losuj nastepne dzialanie";
            this.losujDzialanieButton.UseVisualStyleBackColor = true;
            this.losujDzialanieButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // liczba1Label
            // 
            this.liczba1Label.AutoSize = true;
            this.liczba1Label.Location = new System.Drawing.Point(163, 137);
            this.liczba1Label.Name = "liczba1Label";
            this.liczba1Label.Size = new System.Drawing.Size(40, 13);
            this.liczba1Label.TabIndex = 1;
            this.liczba1Label.Text = "liczba1";
            // 
            // liczba2Label
            // 
            this.liczba2Label.AutoSize = true;
            this.liczba2Label.Location = new System.Drawing.Point(283, 137);
            this.liczba2Label.Name = "liczba2Label";
            this.liczba2Label.Size = new System.Drawing.Size(40, 13);
            this.liczba2Label.TabIndex = 2;
            this.liczba2Label.Text = "liczba2";
            // 
            // znakLabel
            // 
            this.znakLabel.AutoSize = true;
            this.znakLabel.Location = new System.Drawing.Point(223, 137);
            this.znakLabel.Name = "znakLabel";
            this.znakLabel.Size = new System.Drawing.Size(30, 13);
            this.znakLabel.TabIndex = 3;
            this.znakLabel.Text = "znak";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "=";
            // 
            // userInputTexBox
            // 
            this.userInputTexBox.Location = new System.Drawing.Point(403, 134);
            this.userInputTexBox.Name = "userInputTexBox";
            this.userInputTexBox.Size = new System.Drawing.Size(100, 20);
            this.userInputTexBox.TabIndex = 5;
            this.userInputTexBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInputTexBox_KeyDown);
            // 
            // sprawdzenieButton
            // 
            this.sprawdzenieButton.Location = new System.Drawing.Point(403, 200);
            this.sprawdzenieButton.Name = "sprawdzenieButton";
            this.sprawdzenieButton.Size = new System.Drawing.Size(75, 110);
            this.sprawdzenieButton.TabIndex = 6;
            this.sprawdzenieButton.Text = "sprawdzenie";
            this.sprawdzenieButton.UseVisualStyleBackColor = true;
            this.sprawdzenieButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // poprawnoscLabel
            // 
            this.poprawnoscLabel.AutoSize = true;
            this.poprawnoscLabel.Location = new System.Drawing.Point(311, 249);
            this.poprawnoscLabel.Name = "poprawnoscLabel";
            this.poprawnoscLabel.Size = new System.Drawing.Size(0, 13);
            this.poprawnoscLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.poprawnoscLabel);
            this.Controls.Add(this.sprawdzenieButton);
            this.Controls.Add(this.userInputTexBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.znakLabel);
            this.Controls.Add(this.liczba2Label);
            this.Controls.Add(this.liczba1Label);
            this.Controls.Add(this.losujDzialanieButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sprawdź się!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button losujDzialanieButton;
        private System.Windows.Forms.Label liczba1Label;
        private System.Windows.Forms.Label liczba2Label;
        private System.Windows.Forms.Label znakLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userInputTexBox;
        private System.Windows.Forms.Button sprawdzenieButton;
        private System.Windows.Forms.Label poprawnoscLabel;
    }
}

