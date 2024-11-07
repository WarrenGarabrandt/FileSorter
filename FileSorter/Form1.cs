using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class Form1 : Form
    {

        private string[] CommonTypes = new string[]
        {
            ".doc", ".docm", ".docx", ".dot", ".dotm", ".dotx",
            ".xls", ".xlsx", ".xlsm", ".csv", ".xla", ".xlam", ".xlsb", ".xlt", ".xltm",
            ".ppt", ".pptx", ".pot", ".potm", ".ppa", ".ppam", ".pps", ".ppsm", ".ppsx", 
            ".pub", ".vsd", ".vsdx", ".vdwm", ".dia", ".drawio", ".ai",
            ".mpp", ".mpx", ".mspdi",
            ".odt", ".fodt", ".ods", ".fods", ".odp", ".fodp", ".odg", ".fodg", ".odf", ".sda", ".sdb", ".sdc", ".sdd",
            ".rtf", ".txt", ".htm", ".html", ".wps", ".mht", ".mhtml", ".xml", ".prn", ".slk", ".xaml", ".js", ".css",
            ".xps", ".oxps", ".pdf",
            ".bmp", ".emf",".gif",".jpg",".jpeg",".png",".tif",".tiff",".tga",".eps",".webp",".svg", ".xcf", ".psd",
            ".epub", ".mobi", 
            ".eml", ".msg"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = dlg.SelectedPath;
                }
            }
        }

        private bool Updating = false;

        private void cmdScan_Click(object sender, EventArgs e)
        {
            DirIndex.Clear();
            DirList.Clear();
            FileList.Clear();
            ExtensionIndex.Clear();
            GC.Collect();
            WalkDirectory(txtSource.Text, null);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Updating = true;
            List<string> checkedItems = new List<string>();
            foreach (var item in chklstFileTypes.CheckedItems)
            {
                checkedItems.Add(item.ToString());
            }
            chklstFileTypes.Items.Clear();
            foreach (var item in ExtensionIndex)
            {
                chklstFileTypes.Items.Add(item.Key);
            }
            foreach (var item in checkedItems)
            {
                int index = chklstFileTypes.Items.IndexOf(item.ToString());
                if (index != -1)
                {
                    chklstFileTypes.SetItemChecked(index, true);
                }
            }
            RefreshCounters();
            
            Updating = false;
        }

        private void RefreshCounters()
        {
            lblFileCount.Text = string.Format("Total Files: {0}", FileList.Count());
            int fileCount = FileList.Where(x => x.Selected).Count();
            long fileSize = FileList.Where(x => x.Selected).Sum(y => y.Size);
            lblSelectedCount.Text = string.Format("Selected Files: {0}", fileCount);
            lblSelectedSize.Text = string.Format("Selected Size: {0}", PrettyFormat(fileSize));
        }

        private string PrettyFormat(long size)
        {
            if (Math.Abs(size) >= 1000000000000)
            {
                return string.Format("{0:0.00} TB", size / 1099511627776);
            }
            else if (Math.Abs(size) >= 1000000000)
            {
                return string.Format("{0:0.00} GB", size / 1073741824);
            }
            else if (Math.Abs(size) >= 1000000)
            {
                return string.Format("{0:0.00} MB", size / 1048576);
            }
            else if (Math.Abs(size) >= 1000)
            {
                return string.Format("{0:0.00} KB", size / 1024);
            }
            else
            {
                return string.Format("{0} bytes", size);
            }
        }

        public Dictionary<string, DirItem> DirIndex = new Dictionary<string, DirItem>();
        public List<DirItem> DirList = new List<DirItem>();
        public List<FileItem> FileList = new List<FileItem>();
        public Dictionary<string, List<FileItem>> ExtensionIndex = new Dictionary<string, List<FileItem>>();

        public class FileItem
        {
            public string FileName;
            public string Extension;
            public DirItem Parent;
            public long Size = 0;
            public bool Selected = false;
        }

        public class DirItem
        {
            public string PartialPath;
            public string AbsolutePath;
            public DirItem Parent;
            public List<DirItem> ChildDirs = new List<DirItem>();
            public List<FileItem> ChildFiles = new List<FileItem>();
        }
        
        private void WalkDirectory(string path, DirItem parent)
        {
            try
            {
                if (parent == null)
                {
                    parent = new DirItem()
                    {
                        AbsolutePath = path,
                        Parent = null,
                        ChildDirs = new List<DirItem>(),
                        ChildFiles = new List<FileItem>(),
                        PartialPath = ""
                    };
                    DirList.Add(parent);
                }
                try
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        try
                        {
                            FileInfo finfo = new FileInfo(file);
                            var newFileItem = new FileItem()
                            {
                                Extension = finfo.Extension,
                                Parent = parent,
                                FileName = finfo.Name,
                                Selected = false,
                                Size = finfo.Length
                            };
                            parent.ChildFiles.Add(newFileItem);
                            FileList.Add(newFileItem);

                            List<FileItem> extList = null;
                            if (!ExtensionIndex.TryGetValue(finfo.Extension, out extList))
                            {
                                extList = new List<FileItem>();
                                ExtensionIndex.Add(finfo.Extension, extList);
                            }
                            extList.Add(newFileItem);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                try
                {
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (var dir in dirs) 
                    {
                        DirectoryInfo info = new DirectoryInfo(dir);
                        DirItem newDirItem = new DirItem()
                        {
                            AbsolutePath = dir,
                            ChildDirs = new List<DirItem>(),
                            ChildFiles = new List<FileItem>(),
                            Parent = parent,
                            PartialPath = info.Name
                        };
                        parent.ChildDirs.Add(newDirItem);
                        WalkDirectory(dir, newDirItem);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void chklstFileTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (Updating)
            {
                return;
            }
            CheckState newVal = e.NewValue;
            bool NewBoolValue = newVal == CheckState.Checked;
            List<FileItem> ExtFiles;
            if (ExtensionIndex.TryGetValue(chklstFileTypes.Items[e.Index].ToString(), out ExtFiles))
            {
                foreach (var f in ExtFiles)
                {
                    f.Selected = NewBoolValue;
                }
            }
            RefreshCounters();
        }

        private void cmdBrowseOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtDestination.Text = dlg.SelectedPath;
                }
            }
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtSource.Text))
            {
                MessageBox.Show("Select a source directory that exists.");
                return;
            }
            if (DirList.Count == 0 || FileList.Count == 0)
            {
                MessageBox.Show("No files to process. Run a scan and check at least one file type.");
                return;
            }
            if (!Directory.Exists(txtDestination.Text))
            {
                MessageBox.Show("Select a destination directory.");
                return;
            }
            if (Directory.GetFiles(txtDestination.Text).Any() || Directory.GetDirectories(txtDestination.Text).Any())
            {
                MessageBox.Show("Make sure the destination directory is empty.");
                return;
            }
            if (!FileList.Where(x => x.Selected).Any())
            {
                MessageBox.Show("No files selected.");
                return;
            }
            RunProcess(txtDestination.Text);
        }

        private void cmdUncheckAllTypes_Click(object sender, EventArgs e)
        {
            Updating = true;
            for (int i = 0; i < chklstFileTypes.Items.Count; i++)
            {
                chklstFileTypes.SetItemChecked(i, false);
            }
            foreach (var f in FileList)
            {
                f.Selected = false;
            }
            Updating = false;
            RefreshCounters();
        }

        private void chkCheckAllTypes_Click(object sender, EventArgs e)
        {
            Updating = true;
            for (int i = 0; i < chklstFileTypes.Items.Count; i++)
            {
                chklstFileTypes.SetItemChecked(i, true);
            }
            foreach (var f in FileList)
            {
                f.Selected = true;
            }
            Updating = false;
            RefreshCounters();
        }

        private void cmdCheckCommonTypes_Click(object sender, EventArgs e)
        {
            foreach (var f in FileList)
            {
                if (CommonTypes.Contains(f.Extension, StringComparer.OrdinalIgnoreCase))
                {
                    f.Selected = true;
                }
                else
                {
                    f.Selected = false;
                }
            }
            Updating = true;
            for (int i = 0; i < chklstFileTypes.Items.Count; i++)
            {
                if (CommonTypes.Contains(chklstFileTypes.Items[i].ToString(), StringComparer.OrdinalIgnoreCase))
                {
                    chklstFileTypes.SetItemChecked(i, true);
                }
                else
                {
                    chklstFileTypes.SetItemChecked(i, false);

                }
            }
            Updating = false;
            RefreshCounters();
        }

        private void RunProcess(string destination)
        {
            int fileCount = FileList.Where(x => x.Selected).Count();
            int progress = 0;
            int success = 0;
            int error = 0;
            prgProcess.Value = 0;
            prgProcess.Maximum = fileCount + 2;
            foreach (var f in FileList)
            {
                progress++;
                prgProcess.Value = progress + 1;
                prgProcess.Value = progress;
                if (f.Selected)
                {
                    string destFolder = ComposePath(f.Parent, destination);
                    string srcFile = Path.Combine(f.Parent.AbsolutePath, f.FileName);
                    string destFile = Path.Combine(destFolder, f.FileName);
                    lblProcessFile.Text = string.Format("Processing {0} of {1}: {2}\r\nFrom \"{3}\" to \"{4}\"", progress, fileCount, f.FileName, srcFile, destFile);
                    Application.DoEvents();
                    if (!Directory.Exists(destFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(destFolder);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            continue;
                        }
                    }
                    try
                    {
                        File.Copy(srcFile, destFile, false);
                        success++;
                    }
                    catch (Exception ex)
                    {
                        error++;
                        MessageBox.Show(ex.Message);
                        continue;
                    }
                }
            }
            lblProcessFile.Text = string.Format("Done. {0} of {1} files copied, {2} errors.", success, fileCount, error);
            prgProcess.Value = prgProcess.Maximum;
        }

        private string ComposePath(DirItem dir, string destination)
        {
            if (dir.Parent == null)
            {
                return destination;
            }
            return Path.Combine(ComposePath(dir.Parent, destination), dir.PartialPath);
        }
    }
}
