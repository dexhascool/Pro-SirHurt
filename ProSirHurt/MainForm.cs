using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProSirHurt
{
    public partial class MainForm : Form
    {
        private readonly string scriptsFolder;

        public MainForm()
        {
            InitializeComponent();

            scriptsFolder = Path.Combine(Application.StartupPath, "scripts");

            this.Load += MainForm_Load;
            newTabButton.Click += NewTab_Click;
            closeTabButton.Click += CloseTab_Click;
            openFileButton.Click += OpenFile_Click;
            saveFileButton.Click += SaveFile_Click;
            copyButton.Click += Copy_Click;
            pasteButton.Click += Paste_Click;
            refreshButton.Click += RefreshButton_Click;
            killRobloxButton.Click += KillRobloxButton_Click;
            settingsButton.Click += SettingsButton_Click;
            attachButton.Click += AttachButton_Click;
            executeButton.Click += ExecuteButton_Click;
            scriptList.AfterSelect += TreeViewScripts_AfterSelect;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(scriptsFolder))
                Directory.CreateDirectory(scriptsFolder);

            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            scriptList.Nodes.Clear();
            PopulateNodes(scriptList.Nodes, scriptsFolder);
            scriptList.ExpandAll();
        }

        private void PopulateNodes(TreeNodeCollection nodes, string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                var dirNode = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                PopulateNodes(dirNode.Nodes, dir);
                nodes.Add(dirNode);
            }
            foreach (var file in Directory.GetFiles(path, "*.lua"))
            {
                var fileNode = new TreeNode(Path.GetFileName(file)) { Tag = file };
                nodes.Add(fileNode);
            }
        }

        private void TreeViewScripts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var path = e.Node.Tag as string;
            if (File.Exists(path))
                OpenFile(path);
        }

        private void NewTab_Click(object sender, EventArgs e)
        {
            int index = codeEditor.TabPages.Count + 1;
            var tab = new TabPage($"Tab {index}");
            var rtb = new RichTextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.Both,
                AcceptsTab = true
            };
            tab.Controls.Add(rtb);
            codeEditor.TabPages.Add(tab);
            codeEditor.SelectedTab = tab;
        }

        private void CloseTab_Click(object sender, EventArgs e)
        {
            if (codeEditor.TabCount > 0)
                codeEditor.TabPages.Remove(codeEditor.SelectedTab);
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.InitialDirectory = scriptsFolder;
            dlg.Filter = "Lua Scripts|*.lua|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
                OpenFile(dlg.FileName);
        }

        private void OpenFile(string path)
        {
            var content = File.ReadAllText(path);
            var tab = new TabPage(Path.GetFileName(path));
            var rtb = new RichTextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.Both,
                AcceptsTab = true,
                Text = content
            };
            tab.Controls.Add(rtb);
            tab.Tag = path;
            codeEditor.TabPages.Add(tab);
            codeEditor.SelectedTab = tab;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (codeEditor.SelectedTab == null)
                return;
            var tab = codeEditor.SelectedTab;
            var rtb = GetActiveRichTextBox();
            string path = tab.Tag as string;

            if (string.IsNullOrEmpty(path))
            {
                using var dlg = new SaveFileDialog();
                dlg.InitialDirectory = scriptsFolder;
                dlg.Filter = "Lua Scripts|*.lua|All Files|*.*";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                path = dlg.FileName;
            }

            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(path, rtb.Text);
            tab.Text = Path.GetFileName(path);
            tab.Tag = path;
            PopulateTreeView();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            var rtb = GetActiveRichTextBox();
            if (rtb != null && rtb.SelectedText.Length > 0)
                rtb.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            var rtb = GetActiveRichTextBox();
            if (rtb != null)
                rtb.Paste();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void KillRobloxButton_Click(object sender, EventArgs e)
        {
            var names = new[] { "RobloxPlayerBeta", "RobloxPlayer", "RobloxStudio" };
            foreach (var name in names)
                foreach (var proc in Process.GetProcessesByName(name))
                    try { proc.Kill(); } catch { }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings not available yet.", "Settings");
        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
            var injector = Path.Combine(Application.StartupPath, "sirhurt.exe");
            if (File.Exists(injector))
                Process.Start(injector);
            else
                MessageBox.Show("Injector not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            // TODO: make execute work lol
            MessageBox.Show("Execute not implemented yet.", "Execute");
        }

        private RichTextBox GetActiveRichTextBox()
        {
            if (codeEditor.SelectedTab?.Controls.Count > 0)
                return codeEditor.SelectedTab.Controls[0] as RichTextBox;
            return null;
        }
    }
}