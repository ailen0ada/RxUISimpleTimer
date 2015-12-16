namespace RxUISimpleTimer.WinForms
{
    partial class MainForm
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ElapsedLabel = new System.Windows.Forms.Label();
            this.LapTimes = new System.Windows.Forms.ListBox();
            this.ButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LapButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.MainLayout.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.ElapsedLabel, 0, 0);
            this.MainLayout.Controls.Add(this.LapTimes, 0, 2);
            this.MainLayout.Controls.Add(this.ButtonsPanel, 0, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 3;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.Size = new System.Drawing.Size(482, 453);
            this.MainLayout.TabIndex = 4;
            // 
            // ElapsedLabel
            // 
            this.ElapsedLabel.AutoSize = true;
            this.ElapsedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElapsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedLabel.Location = new System.Drawing.Point(3, 0);
            this.ElapsedLabel.Name = "ElapsedLabel";
            this.ElapsedLabel.Size = new System.Drawing.Size(476, 135);
            this.ElapsedLabel.TabIndex = 1;
            this.ElapsedLabel.Text = "00:00:00.000";
            this.ElapsedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LapTimes
            // 
            this.LapTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LapTimes.FormattingEnabled = true;
            this.LapTimes.ItemHeight = 16;
            this.LapTimes.Location = new System.Drawing.Point(3, 228);
            this.LapTimes.Name = "LapTimes";
            this.LapTimes.Size = new System.Drawing.Size(476, 222);
            this.LapTimes.TabIndex = 2;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.ColumnCount = 3;
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.Controls.Add(this.LapButton, 2, 0);
            this.ButtonsPanel.Controls.Add(this.StopButton, 1, 0);
            this.ButtonsPanel.Controls.Add(this.StartButton, 0, 0);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 138);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.RowCount = 1;
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsPanel.Size = new System.Drawing.Size(476, 84);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // LapButton
            // 
            this.LapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LapButton.Location = new System.Drawing.Point(336, 20);
            this.LapButton.Margin = new System.Windows.Forms.Padding(20);
            this.LapButton.Name = "LapButton";
            this.LapButton.Size = new System.Drawing.Size(120, 44);
            this.LapButton.TabIndex = 8;
            this.LapButton.Text = "Lap";
            this.LapButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Location = new System.Drawing.Point(178, 20);
            this.StopButton.Margin = new System.Windows.Forms.Padding(20);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(118, 44);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Location = new System.Drawing.Point(20, 20);
            this.StartButton.Margin = new System.Windows.Forms.Padding(20);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(118, 44);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.MainLayout);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Label ElapsedLabel;
        private System.Windows.Forms.ListBox LapTimes;
        private System.Windows.Forms.TableLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Button LapButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
    }
}

