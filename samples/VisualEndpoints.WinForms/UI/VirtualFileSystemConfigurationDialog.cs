using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProconTel.Sdk.UI.Services;
using ProconTel.Sdk.UI.VirtualFileSystem;

namespace UI.WinForms.NewSdk.Tests.Configurations
{
  public partial class VirtualFileSystemConfigurationDialog : Form
  {
    private readonly IVirtualFileSystem _virtualFileSystem;
    public VirtualFileSystemConfigurationDialog()
    {
      InitializeComponent();
    }
    public VirtualFileSystemConfigurationDialog(IVirtualFileSystem virtualFileSystem) : this()
    {
      _virtualFileSystem = virtualFileSystem;
    }
    public async void fillGetRootsGrid(IRootInfo[] roots, string directoryPath, string filePath)
    {
      var getFileSystemNameAsync = await _virtualFileSystem.GetFileSystemNameAsync();
      var isDirectoryExistAsync = await _virtualFileSystem.DirectoryExistsAsync(directoryPath);
      var isFileExistAsync = await _virtualFileSystem.FileExistsAsync(filePath);

      var rootsResult = roots.Select(r => new
      {
        Caption = r.Caption,
        FullPath = r.FullPath,
        ID = r.ID,
        VirtualPath = r.VirtualPath,
        GetFileSystemName = getFileSystemNameAsync,
        IsDirectoryExist = isDirectoryExistAsync,
        IsFileExist = isFileExistAsync,
      }).ToList();
      getRootsGrid.DataSource = rootsResult;
    }
    public void fillFilesGrid(IVirtualFileInfo[] getFiles)
    {
      var getFilesResult = getFiles.Select(h => new
      {
        FullPath = h.FullPath,
        ID = h.ID,
        Name = h.Name,
        Parent = h.Parent,
        Root = h.Root,
      }).ToList();
      getFilesGrid.DataSource = getFilesResult;
    }
    public void fillDirectoriesGrid(IVirtualDirectoryInfo[] getDirectory)
    {
      var getDirectoriesresults = getDirectory.Select(g => new
      {
        Fullpath = g.FullPath,
        ID = g.ID,
        Name = g.Name,
        Parent = g.Parent,
        Root = g.Root,
        VirtualPath = g.VirtualPath,
      }).ToList();
      getDirectoriesGrid.DataSource = getDirectoriesresults;
    }
    public bool checkIfExist(string directoryPath, string fileName)
    {
      if (Directory.Exists(directoryPath))
      {
        if (Directory.Exists(directoryPath))
        {
          if (File.Exists(fileName))
          {
            File.Delete(fileName);
          }
        }
        Directory.Delete(directoryPath);

        getFilesGrid.DataSource = null;
        getDirectoriesGrid.DataSource = null;
        getFilesGrid.Refresh();
        getDirectoriesGrid.Refresh();
        return true;
      }
      else
      {
        return false;
      }
    }
    private async void VirtualFileSystemConfigurationDialog_Load(object sender, EventArgs e)
    {
      string filePath = @"C:\testDirectory\test.txt";
      string directoryPath = @"c:\testDirectory";
      var roots = await _virtualFileSystem.GetRootsAsync();
      if (checkIfExist(directoryPath, filePath) == false && roots != null)
      {
        await _virtualFileSystem.CreateDirectoryAsync(directoryPath);
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine("Done! ");
        }
        var getDirectories = await _virtualFileSystem.GetDirectoriesAsync(roots[0]);
        var searchDriectories = getDirectories.FirstOrDefault(x => x.Name == "testDirectory");
        if (searchDriectories != null)
        {
          var getFiles = await _virtualFileSystem.GetFilesAsync(searchDriectories, "*.txt");
          fillFilesGrid(getFiles);
        }
        fillDirectoriesGrid(getDirectories);
      }
      fillGetRootsGrid(roots, directoryPath, filePath);
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      string filePath = @"C:\testDirectory\test.txt";
      string directoryPath = @"c:\testDirectory";
      var roots = await _virtualFileSystem.GetRootsAsync();
      if (checkIfExist(directoryPath, filePath) == false && roots != null)
      {
        await _virtualFileSystem.CreateDirectoryAsync(directoryPath);
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine("Done! ");
        }
        var getDirectories = await _virtualFileSystem.GetDirectoriesAsync(roots[0]);
        var searchDriectories = getDirectories.FirstOrDefault(x => x.Name == "testDirectory");
        if (searchDriectories != null)
        {
          var getFiles = await _virtualFileSystem.GetFilesAsync(searchDriectories, "*.txt");
          fillFilesGrid(getFiles);
        }
        fillDirectoriesGrid(getDirectories);
      }
      fillGetRootsGrid(roots, directoryPath, filePath);
    }
  }
}
