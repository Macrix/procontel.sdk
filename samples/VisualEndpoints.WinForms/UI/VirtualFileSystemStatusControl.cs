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
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using ProconTel.Sdk.UI.VirtualFileSystem;

namespace UI.WinForms.NewSdk.Tests.StatusControls
{
  public partial class VirtualFileSystemStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IVirtualFileSystem _virtualFileSystem;
    public VirtualFileSystemStatusControl()
    {
      InitializeComponent();
    }
    public VirtualFileSystemStatusControl(IVirtualFileSystem virtualFileSystem, IRootInfo[] rootInfo) : this()
    {
      _virtualFileSystem = virtualFileSystem;
    }
    public void OnStatusControlHidden()
    {
    }

    public void OnStatusControlShown()
    {
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

        getDirectoriesGrid.DataSource = null;
        getFilesGrid.DataSource = null;

        getDirectoriesGrid.Refresh();
        getFilesGrid.Refresh();
        return true;
      }
      else
      {
        return false;
      }   
    }

    public async void DisplayStatus(object statusInformation)
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
    private async void ExecuteButton_Click(object sender, EventArgs e)
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

