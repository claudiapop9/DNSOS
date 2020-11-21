namespace WifiAnalyzerRDSOS
{
    partial class SnifferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnifferForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startSnifferButton = new System.Windows.Forms.ToolStripButton();
            this.stopSnifferButton = new System.Windows.Forms.ToolStripButton();
            this.previousPacketButton = new System.Windows.Forms.ToolStripButton();
            this.nextPacketButton = new System.Windows.Forms.ToolStripButton();
            this.firstPacketButton = new System.Windows.Forms.ToolStripButton();
            this.lastPacketButton = new System.Windows.Forms.ToolStripButton();
            this.packetsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packetInfoTextBox = new System.Windows.Forms.TextBox();
            this.packetInfoLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSnifferButton,
            this.stopSnifferButton,
            this.previousPacketButton,
            this.nextPacketButton,
            this.firstPacketButton,
            this.lastPacketButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 27);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startSnifferButton
            // 
            this.startSnifferButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startSnifferButton.Image = ((System.Drawing.Image)(resources.GetObject("startSnifferButton.Image")));
            this.startSnifferButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startSnifferButton.Name = "startSnifferButton";
            this.startSnifferButton.Size = new System.Drawing.Size(24, 24);
            this.startSnifferButton.Text = "startSnifferButton";
            this.startSnifferButton.ToolTipText = "Start sniffing";
            this.startSnifferButton.Click += new System.EventHandler(this.startSnifferButton_Click);
            // 
            // stopSnifferButton
            // 
            this.stopSnifferButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopSnifferButton.Image = ((System.Drawing.Image)(resources.GetObject("stopSnifferButton.Image")));
            this.stopSnifferButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopSnifferButton.Name = "stopSnifferButton";
            this.stopSnifferButton.Size = new System.Drawing.Size(24, 24);
            this.stopSnifferButton.Text = "stopSnifferButton";
            this.stopSnifferButton.ToolTipText = "Stop sniffing";
            this.stopSnifferButton.Click += new System.EventHandler(this.stopSnifferButton_Click);
            // 
            // previousPacketButton
            // 
            this.previousPacketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousPacketButton.Image = ((System.Drawing.Image)(resources.GetObject("previousPacketButton.Image")));
            this.previousPacketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousPacketButton.Name = "previousPacketButton";
            this.previousPacketButton.Size = new System.Drawing.Size(24, 24);
            this.previousPacketButton.Text = "previousPacketButton";
            this.previousPacketButton.ToolTipText = "Previous packet";
            // 
            // nextPacketButton
            // 
            this.nextPacketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPacketButton.Image = ((System.Drawing.Image)(resources.GetObject("nextPacketButton.Image")));
            this.nextPacketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPacketButton.Name = "nextPacketButton";
            this.nextPacketButton.Size = new System.Drawing.Size(24, 24);
            this.nextPacketButton.Text = "nextPacketButton";
            this.nextPacketButton.ToolTipText = "Next packet";
            // 
            // firstPacketButton
            // 
            this.firstPacketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstPacketButton.Image = ((System.Drawing.Image)(resources.GetObject("firstPacketButton.Image")));
            this.firstPacketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstPacketButton.Name = "firstPacketButton";
            this.firstPacketButton.Size = new System.Drawing.Size(24, 24);
            this.firstPacketButton.Text = "firstPacketButton";
            this.firstPacketButton.ToolTipText = "First packet";
            // 
            // lastPacketButton
            // 
            this.lastPacketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastPacketButton.Image = ((System.Drawing.Image)(resources.GetObject("lastPacketButton.Image")));
            this.lastPacketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastPacketButton.Name = "lastPacketButton";
            this.lastPacketButton.Size = new System.Drawing.Size(24, 24);
            this.lastPacketButton.Text = "lastPacketButton";
            this.lastPacketButton.ToolTipText = "Last packet";
            // 
            // packetsListView
            // 
            this.packetsListView.AllowColumnReorder = true;
            this.packetsListView.AutoArrange = false;
            this.packetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.packetsListView.FullRowSelect = true;
            this.packetsListView.GridLines = true;
            this.packetsListView.HideSelection = false;
            this.packetsListView.Location = new System.Drawing.Point(11, 41);
            this.packetsListView.Margin = new System.Windows.Forms.Padding(2);
            this.packetsListView.MultiSelect = false;
            this.packetsListView.Name = "packetsListView";
            this.packetsListView.Size = new System.Drawing.Size(603, 342);
            this.packetsListView.TabIndex = 13;
            this.packetsListView.UseCompatibleStateImageBehavior = false;
            this.packetsListView.View = System.Windows.Forms.View.Details;
            this.packetsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.packetsListView_ItemSelectionChanged);
            this.packetsListView.SelectedIndexChanged += new System.EventHandler(this.packetsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Source";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Destination";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Protocol";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Length";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 80;
            // 
            // packetInfoTextBox
            // 
            this.packetInfoTextBox.Location = new System.Drawing.Point(11, 439);
            this.packetInfoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.packetInfoTextBox.Multiline = true;
            this.packetInfoTextBox.Name = "packetInfoTextBox";
            this.packetInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.packetInfoTextBox.Size = new System.Drawing.Size(435, 164);
            this.packetInfoTextBox.TabIndex = 14;
            // 
            // packetInfoLabel
            // 
            this.packetInfoLabel.AutoSize = true;
            this.packetInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packetInfoLabel.Location = new System.Drawing.Point(11, 410);
            this.packetInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packetInfoLabel.Name = "packetInfoLabel";
            this.packetInfoLabel.Size = new System.Drawing.Size(125, 17);
            this.packetInfoLabel.TabIndex = 15;
            this.packetInfoLabel.Text = "Packet Information";
            // 
            // SnifferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 627);
            this.Controls.Add(this.packetInfoLabel);
            this.Controls.Add(this.packetInfoTextBox);
            this.Controls.Add(this.packetsListView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SnifferForm";
            this.Text = "SnifferForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startSnifferButton;
        private System.Windows.Forms.ToolStripButton stopSnifferButton;
        private System.Windows.Forms.ToolStripButton previousPacketButton;
        private System.Windows.Forms.ToolStripButton nextPacketButton;
        private System.Windows.Forms.ToolStripButton firstPacketButton;
        private System.Windows.Forms.ToolStripButton lastPacketButton;
        private System.Windows.Forms.ListView packetsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox packetInfoTextBox;
        private System.Windows.Forms.Label packetInfoLabel;
    }
}