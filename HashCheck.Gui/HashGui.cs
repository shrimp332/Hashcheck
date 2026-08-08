using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

using HashCheck.Core;

namespace HashCheck.Gui
{
    public partial class HashGui : Form
    {
        private string? _filePath;
        public HashGui()
        {
            InitializeComponent();
        }

        private void fileInputPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileInputPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[]? files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string? path = files?[0];
            if (path == null)
                return;

            _filePath = path;
            filePathLabel.Text = _filePath;
            generateHash();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "All files (*.*)|*.*";
                dialog.Title = "Select a file to hash";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    _filePath = path;
                    filePathLabel.Text = path;
                    generateHash();
                }
            }
        }

        private void generateHash()
        {
            Dictionary<HashKind, string> hashes;
            // try bc might be a dir from the dragdrop or non-exist file
            try
            {
                hashes = Hasher.ComputeAllPath(_filePath);
            }
            catch
            {
                _filePath = null;
                filePathLabel.Text = "Drag file here";
                return;
            }
            hashOutputGridView.Rows.Clear();
            foreach (var hash in hashes)
            {
                // size of sha512 doesn't fit in the gui table, and the default renderer doesn't wrap lines with no spaces in them.
                // TODO: (maybe) insert spaces into the gui
                if (hash.Key == HashKind.SHA512)
                    continue;
                hashOutputGridView.Rows.Add(hash.Key, hash.Value);
            }
        }

        private void HashGui_Load(object sender, EventArgs e)
        {
            hashOutputGridView.Columns["HashAlgo"]!.Width = 100;
            hashOutputGridView.Columns["Hash"]!.Width = hashOutputGridView.Width - 100 - 3;
            hashOutputGridView.Columns["Hash"]!.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            hashOutputGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void verifyHashBtn_Click(object sender, EventArgs e)
        {
            HashVerififcation v;
            try
            {
                v = Hasher.VerifyHashPath(_filePath, verifyHashInput.Text);
            }
            catch (InvalidHashKindException)
            {
                resultOutputLabel.Text = "Error: Unable to infer hash type";
                return;
            }
            catch (Exception ex)
            {
                resultOutputLabel.Text = $"Error: {ex.Message}";
                return;
            }

            if (v.Verified)
            {
                resultOutputLabel.Text = $"Result: Hash verified with {v.Kind} algorithm";
            }
            else
            {
                resultOutputLabel.Text = $"Result: Hash did not match";
            }
        }

        private void hashOutputGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != hashOutputGridView.Columns["Hash"]!.Index) return;
            var hash = hashOutputGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (string.IsNullOrEmpty(hash)) return;

            commandOutput.Text = $"Copied {hash} to clipboard";
            Clipboard.SetText(hash);

        }
    }
}
