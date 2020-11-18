namespace WifiAnalyzerRDSOS
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
            this.networksComboBox = new System.Windows.Forms.ComboBox();
            this.interfaceIndexLabel = new System.Windows.Forms.Label();
            this.availableNetworkNoLabel = new System.Windows.Forms.Label();
            this.interfaceGUIDlabel = new System.Windows.Forms.Label();
            this.showNetworkLabel = new System.Windows.Forms.Label();
            this.InterfaceGuidTextBox = new System.Windows.Forms.TextBox();
            this.availableNetworkEntriesTextBox = new System.Windows.Forms.TextBox();
            this.interfaceDescriptionlabel = new System.Windows.Forms.Label();
            this.interfaceDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.interfaceStatusLabel = new System.Windows.Forms.Label();
            this.interfaceStatusTextBox = new System.Windows.Forms.TextBox();
            this.interfacesComboBox = new System.Windows.Forms.ComboBox();
            this.availableNetworksDataGridView = new System.Windows.Forms.DataGridView();
            this.goToSnifferButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.availableNetworksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // networksComboBox
            // 
            this.networksComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networksComboBox.FormattingEnabled = true;
            this.networksComboBox.Location = new System.Drawing.Point(554, 47);
            this.networksComboBox.Name = "networksComboBox";
            this.networksComboBox.Size = new System.Drawing.Size(225, 28);
            this.networksComboBox.TabIndex = 1;
            this.networksComboBox.SelectedIndexChanged += new System.EventHandler(this.networksComboBox_SelectedIndexChanged);
            // 
            // interfaceIndexLabel
            // 
            this.interfaceIndexLabel.AutoSize = true;
            this.interfaceIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceIndexLabel.Location = new System.Drawing.Point(29, 25);
            this.interfaceIndexLabel.Name = "interfaceIndexLabel";
            this.interfaceIndexLabel.Size = new System.Drawing.Size(116, 20);
            this.interfaceIndexLabel.TabIndex = 2;
            this.interfaceIndexLabel.Text = "Interface Index";
            // 
            // availableNetworkNoLabel
            // 
            this.availableNetworkNoLabel.AutoSize = true;
            this.availableNetworkNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableNetworkNoLabel.Location = new System.Drawing.Point(420, 16);
            this.availableNetworkNoLabel.Name = "availableNetworkNoLabel";
            this.availableNetworkNoLabel.Size = new System.Drawing.Size(188, 20);
            this.availableNetworkNoLabel.TabIndex = 3;
            this.availableNetworkNoLabel.Text = "Available Network Entries";
            // 
            // interfaceGUIDlabel
            // 
            this.interfaceGUIDlabel.AutoSize = true;
            this.interfaceGUIDlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceGUIDlabel.Location = new System.Drawing.Point(29, 198);
            this.interfaceGUIDlabel.Name = "interfaceGUIDlabel";
            this.interfaceGUIDlabel.Size = new System.Drawing.Size(119, 20);
            this.interfaceGUIDlabel.TabIndex = 4;
            this.interfaceGUIDlabel.Text = "Interface GUID";
            this.interfaceGUIDlabel.Click += new System.EventHandler(this.interfaceGUIDlabel_Click);
            // 
            // showNetworkLabel
            // 
            this.showNetworkLabel.AutoSize = true;
            this.showNetworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showNetworkLabel.Location = new System.Drawing.Point(421, 47);
            this.showNetworkLabel.Name = "showNetworkLabel";
            this.showNetworkLabel.Size = new System.Drawing.Size(115, 20);
            this.showNetworkLabel.TabIndex = 5;
            this.showNetworkLabel.Text = "Show Network:";
            // 
            // InterfaceGuidTextBox
            // 
            this.InterfaceGuidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterfaceGuidTextBox.Location = new System.Drawing.Point(33, 221);
            this.InterfaceGuidTextBox.Name = "InterfaceGuidTextBox";
            this.InterfaceGuidTextBox.ReadOnly = true;
            this.InterfaceGuidTextBox.Size = new System.Drawing.Size(348, 26);
            this.InterfaceGuidTextBox.TabIndex = 7;
            // 
            // availableNetworkEntriesTextBox
            // 
            this.availableNetworkEntriesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableNetworkEntriesTextBox.Location = new System.Drawing.Point(614, 13);
            this.availableNetworkEntriesTextBox.Name = "availableNetworkEntriesTextBox";
            this.availableNetworkEntriesTextBox.ReadOnly = true;
            this.availableNetworkEntriesTextBox.Size = new System.Drawing.Size(165, 26);
            this.availableNetworkEntriesTextBox.TabIndex = 8;
            // 
            // interfaceDescriptionlabel
            // 
            this.interfaceDescriptionlabel.AutoSize = true;
            this.interfaceDescriptionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceDescriptionlabel.Location = new System.Drawing.Point(29, 129);
            this.interfaceDescriptionlabel.Name = "interfaceDescriptionlabel";
            this.interfaceDescriptionlabel.Size = new System.Drawing.Size(157, 20);
            this.interfaceDescriptionlabel.TabIndex = 9;
            this.interfaceDescriptionlabel.Text = "Interface Description";
            // 
            // interfaceDescriptionTextBox
            // 
            this.interfaceDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceDescriptionTextBox.Location = new System.Drawing.Point(33, 152);
            this.interfaceDescriptionTextBox.Name = "interfaceDescriptionTextBox";
            this.interfaceDescriptionTextBox.ReadOnly = true;
            this.interfaceDescriptionTextBox.Size = new System.Drawing.Size(348, 26);
            this.interfaceDescriptionTextBox.TabIndex = 10;
            // 
            // interfaceStatusLabel
            // 
            this.interfaceStatusLabel.AutoSize = true;
            this.interfaceStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceStatusLabel.Location = new System.Drawing.Point(29, 61);
            this.interfaceStatusLabel.Name = "interfaceStatusLabel";
            this.interfaceStatusLabel.Size = new System.Drawing.Size(128, 20);
            this.interfaceStatusLabel.TabIndex = 11;
            this.interfaceStatusLabel.Text = "Interface Status:";
            // 
            // interfaceStatusTextBox
            // 
            this.interfaceStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceStatusTextBox.Location = new System.Drawing.Point(33, 89);
            this.interfaceStatusTextBox.Name = "interfaceStatusTextBox";
            this.interfaceStatusTextBox.ReadOnly = true;
            this.interfaceStatusTextBox.Size = new System.Drawing.Size(348, 26);
            this.interfaceStatusTextBox.TabIndex = 12;
            // 
            // interfacesComboBox
            // 
            this.interfacesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfacesComboBox.FormattingEnabled = true;
            this.interfacesComboBox.Location = new System.Drawing.Point(163, 22);
            this.interfacesComboBox.Name = "interfacesComboBox";
            this.interfacesComboBox.Size = new System.Drawing.Size(218, 28);
            this.interfacesComboBox.TabIndex = 13;
            this.interfacesComboBox.SelectedIndexChanged += new System.EventHandler(this.interfacesComboBox_SelectedIndexChanged);
            // 
            // availableNetworksDataGridView
            // 
            this.availableNetworksDataGridView.Location = new System.Drawing.Point(425, 97);
            this.availableNetworksDataGridView.Name = "availableNetworksDataGridView";
            this.availableNetworksDataGridView.Size = new System.Drawing.Size(354, 235);
            this.availableNetworksDataGridView.TabIndex = 14;
            // 
            // goToSnifferButton
            // 
            this.goToSnifferButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.goToSnifferButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToSnifferButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.goToSnifferButton.Location = new System.Drawing.Point(103, 283);
            this.goToSnifferButton.Name = "goToSnifferButton";
            this.goToSnifferButton.Size = new System.Drawing.Size(165, 35);
            this.goToSnifferButton.TabIndex = 15;
            this.goToSnifferButton.Text = "Go To Sniffer";
            this.goToSnifferButton.UseVisualStyleBackColor = false;
            this.goToSnifferButton.Click += new System.EventHandler(this.goToSnifferButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 382);
            this.Controls.Add(this.goToSnifferButton);
            this.Controls.Add(this.availableNetworksDataGridView);
            this.Controls.Add(this.interfacesComboBox);
            this.Controls.Add(this.interfaceStatusTextBox);
            this.Controls.Add(this.interfaceStatusLabel);
            this.Controls.Add(this.interfaceDescriptionTextBox);
            this.Controls.Add(this.interfaceDescriptionlabel);
            this.Controls.Add(this.availableNetworkEntriesTextBox);
            this.Controls.Add(this.InterfaceGuidTextBox);
            this.Controls.Add(this.showNetworkLabel);
            this.Controls.Add(this.interfaceGUIDlabel);
            this.Controls.Add(this.availableNetworkNoLabel);
            this.Controls.Add(this.interfaceIndexLabel);
            this.Controls.Add(this.networksComboBox);
            this.Name = "MainForm";
            this.Text = "WifiAnalyzer";
            ((System.ComponentModel.ISupportInitialize)(this.availableNetworksDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox networksComboBox;
        private System.Windows.Forms.Label interfaceIndexLabel;
        private System.Windows.Forms.Label availableNetworkNoLabel;
        private System.Windows.Forms.Label interfaceGUIDlabel;
        private System.Windows.Forms.Label showNetworkLabel;
        private System.Windows.Forms.TextBox InterfaceGuidTextBox;
        private System.Windows.Forms.TextBox availableNetworkEntriesTextBox;
        private System.Windows.Forms.Label interfaceDescriptionlabel;
        private System.Windows.Forms.TextBox interfaceDescriptionTextBox;
        private System.Windows.Forms.Label interfaceStatusLabel;
        private System.Windows.Forms.TextBox interfaceStatusTextBox;
        private System.Windows.Forms.ComboBox interfacesComboBox;
        private System.Windows.Forms.DataGridView availableNetworksDataGridView;
        private System.Windows.Forms.Button goToSnifferButton;
    }
}

