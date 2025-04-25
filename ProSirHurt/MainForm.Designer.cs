namespace ProSirHurt
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            openFileButton = new ToolStripButton();
            saveFileButton = new ToolStripButton();
            copyButton = new ToolStripButton();
            pasteButton = new ToolStripButton();
            newTabButton = new ToolStripButton();
            closeTabButton = new ToolStripButton();
            refreshButton = new ToolStripButton();
            killRobloxButton = new ToolStripButton();
            attachButton = new ToolStripButton();
            executeButton = new ToolStripButton();
            settingsButton = new ToolStripButton();
            scriptList = new TreeView();
            codeEditor = new TabControl();
            tabPage1 = new TabPage();
            richTextBox1 = new RichTextBox();
            toolStrip1.SuspendLayout();
            codeEditor.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { openFileButton, saveFileButton, copyButton, pasteButton, newTabButton, closeTabButton, refreshButton, killRobloxButton, attachButton, executeButton, settingsButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(384, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // openFileButton
            // 
            openFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openFileButton.Image = (Image)resources.GetObject("openFileButton.Image");
            openFileButton.ImageTransparentColor = Color.Magenta;
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(23, 22);
            openFileButton.Text = "Open File";
            // 
            // saveFileButton
            // 
            saveFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveFileButton.Image = (Image)resources.GetObject("saveFileButton.Image");
            saveFileButton.ImageTransparentColor = Color.Magenta;
            saveFileButton.Name = "saveFileButton";
            saveFileButton.Size = new Size(23, 22);
            saveFileButton.Text = "Save File";
            // 
            // copyButton
            // 
            copyButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyButton.Image = (Image)resources.GetObject("copyButton.Image");
            copyButton.ImageTransparentColor = Color.Magenta;
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(23, 22);
            copyButton.Text = "Copy";
            // 
            // pasteButton
            // 
            pasteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pasteButton.Image = (Image)resources.GetObject("pasteButton.Image");
            pasteButton.ImageTransparentColor = Color.Magenta;
            pasteButton.Name = "pasteButton";
            pasteButton.Size = new Size(23, 22);
            pasteButton.Text = "Paste";
            // 
            // newTabButton
            // 
            newTabButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newTabButton.Image = (Image)resources.GetObject("newTabButton.Image");
            newTabButton.ImageTransparentColor = Color.Magenta;
            newTabButton.Name = "newTabButton";
            newTabButton.Size = new Size(23, 22);
            newTabButton.Text = "New Tab";
            // 
            // closeTabButton
            // 
            closeTabButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            closeTabButton.Image = (Image)resources.GetObject("closeTabButton.Image");
            closeTabButton.ImageTransparentColor = Color.Magenta;
            closeTabButton.Name = "closeTabButton";
            closeTabButton.Size = new Size(23, 22);
            closeTabButton.Text = "Close Tab";
            // 
            // refreshButton
            // 
            refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
            refreshButton.ImageTransparentColor = Color.Magenta;
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(23, 22);
            refreshButton.Text = "Refresh UI";
            // 
            // killRobloxButton
            // 
            killRobloxButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            killRobloxButton.Image = (Image)resources.GetObject("killRobloxButton.Image");
            killRobloxButton.ImageTransparentColor = Color.Magenta;
            killRobloxButton.Name = "killRobloxButton";
            killRobloxButton.Size = new Size(23, 22);
            killRobloxButton.Text = "Kill Roblox";
            // 
            // attachButton
            // 
            attachButton.Alignment = ToolStripItemAlignment.Right;
            attachButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            attachButton.Image = (Image)resources.GetObject("attachButton.Image");
            attachButton.ImageTransparentColor = Color.Magenta;
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(23, 22);
            attachButton.Text = "Attach";
            // 
            // executeButton
            // 
            executeButton.Alignment = ToolStripItemAlignment.Right;
            executeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            executeButton.Image = (Image)resources.GetObject("executeButton.Image");
            executeButton.ImageTransparentColor = Color.Magenta;
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(23, 22);
            executeButton.Text = "Execute";
            // 
            // settingsButton
            // 
            settingsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            settingsButton.Image = (Image)resources.GetObject("settingsButton.Image");
            settingsButton.ImageTransparentColor = Color.Magenta;
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(23, 22);
            settingsButton.Text = "Settings";
            // 
            // scriptList
            // 
            scriptList.Dock = DockStyle.Right;
            scriptList.Location = new Point(289, 25);
            scriptList.Name = "scriptList";
            scriptList.Size = new Size(95, 236);
            scriptList.TabIndex = 1;
            // 
            // codeEditor
            // 
            codeEditor.Controls.Add(tabPage1);
            codeEditor.Dock = DockStyle.Fill;
            codeEditor.Location = new Point(0, 25);
            codeEditor.Multiline = true;
            codeEditor.Name = "codeEditor";
            codeEditor.SelectedIndex = 0;
            codeEditor.Size = new Size(289, 236);
            codeEditor.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(281, 208);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tab 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.AcceptsTab = true;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(275, 202);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(codeEditor);
            Controls.Add(scriptList);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pro-SirHurt";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            codeEditor.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton openFileButton;
        private ToolStripButton saveFileButton;
        private ToolStripButton copyButton;
        private ToolStripButton pasteButton;
        private ToolStripButton newTabButton;
        private ToolStripButton closeTabButton;
        private ToolStripButton killRobloxButton;
        private ToolStripButton attachButton;
        private ToolStripButton executeButton;
        private ToolStripButton refreshButton;
        private TreeView scriptList;
        private TabControl codeEditor;
        private TabPage tabPage1;
        private RichTextBox richTextBox1;
        private ToolStripButton settingsButton;
    }
}
