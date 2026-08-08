namespace HashCheck.Gui
{
    partial class HashGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HashGui));
            fileInputPanel = new Panel();
            filePathLabel = new Label();
            openFileButton = new Button();
            hashOutputGridView = new DataGridView();
            HashAlgo = new DataGridViewTextBoxColumn();
            Hash = new DataGridViewTextBoxColumn();
            verifyHashInput = new TextBox();
            verifyHashBtn = new Button();
            verifyLabel = new Label();
            resultOutputLabel = new Label();
            fileInputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hashOutputGridView).BeginInit();
            SuspendLayout();
            // 
            // fileInputPanel
            // 
            fileInputPanel.AllowDrop = true;
            fileInputPanel.BorderStyle = BorderStyle.FixedSingle;
            fileInputPanel.Controls.Add(filePathLabel);
            resources.ApplyResources(fileInputPanel, "fileInputPanel");
            fileInputPanel.Name = "fileInputPanel";
            fileInputPanel.DragDrop += fileInputPanel_DragDrop;
            fileInputPanel.DragEnter += fileInputPanel_DragEnter;
            // 
            // filePathLabel
            // 
            resources.ApplyResources(filePathLabel, "filePathLabel");
            filePathLabel.Name = "filePathLabel";
            // 
            // openFileButton
            // 
            resources.ApplyResources(openFileButton, "openFileButton");
            openFileButton.Name = "openFileButton";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // hashOutputGridView
            // 
            hashOutputGridView.AllowUserToAddRows = false;
            hashOutputGridView.AllowUserToDeleteRows = false;
            hashOutputGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hashOutputGridView.Columns.AddRange(new DataGridViewColumn[] { HashAlgo, Hash });
            resources.ApplyResources(hashOutputGridView, "hashOutputGridView");
            hashOutputGridView.Name = "hashOutputGridView";
            hashOutputGridView.ReadOnly = true;
            hashOutputGridView.RowHeadersVisible = false;
            // 
            // HashAlgo
            // 
            resources.ApplyResources(HashAlgo, "HashAlgo");
            HashAlgo.Name = "HashAlgo";
            HashAlgo.ReadOnly = true;
            // 
            // Hash
            // 
            resources.ApplyResources(Hash, "Hash");
            Hash.Name = "Hash";
            Hash.ReadOnly = true;
            // 
            // verifyHashInput
            // 
            resources.ApplyResources(verifyHashInput, "verifyHashInput");
            verifyHashInput.Name = "verifyHashInput";
            // 
            // verifyHashBtn
            // 
            resources.ApplyResources(verifyHashBtn, "verifyHashBtn");
            verifyHashBtn.Name = "verifyHashBtn";
            verifyHashBtn.UseVisualStyleBackColor = true;
            verifyHashBtn.Click += verifyHashBtn_Click;
            // 
            // verifyLabel
            // 
            resources.ApplyResources(verifyLabel, "verifyLabel");
            verifyLabel.Name = "verifyLabel";
            // 
            // resultOutputLabel
            // 
            resources.ApplyResources(resultOutputLabel, "resultOutputLabel");
            resultOutputLabel.Name = "resultOutputLabel";
            // 
            // HashGui
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resultOutputLabel);
            Controls.Add(verifyLabel);
            Controls.Add(verifyHashBtn);
            Controls.Add(verifyHashInput);
            Controls.Add(hashOutputGridView);
            Controls.Add(openFileButton);
            Controls.Add(fileInputPanel);
            Name = "HashGui";
            Load += HashGui_Load;
            fileInputPanel.ResumeLayout(false);
            fileInputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hashOutputGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel fileInputPanel;
        private Label filePathLabel;
        private Button openFileButton;
        private DataGridView hashOutputGridView;
        private DataGridViewTextBoxColumn HashAlgo;
        private DataGridViewTextBoxColumn Hash;
        private TextBox verifyHashInput;
        private Button verifyHashBtn;
        private Label verifyLabel;
        private Label resultOutputLabel;
    }
}