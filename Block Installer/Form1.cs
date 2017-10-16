using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Block_Installer
{
    public partial class MainForm : Form
    {
        private string rootGameFolder;
        private string materialsFolder;         // reference to materials blocks folder containing texture folders
        private string iconsFolder;             // reference to folder containing resource icons
        private string albedoFolder;
        private string emissiveMaskAlphaFolder;
        private string heightSmoothnessSpecularityFolder;
        private string normalFolder;
        
        private string texturePackFolder; // reference to the minecraft texture pack folder
        private string texturePackBlockTexturesFolder; // Reference to the block textures folder within the texture pack folder

        private string backupTexturesFolder; // Reference to backup directory in game folder
        private string tempFolder;

        Dictionary<string, string> textureNames = new Dictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.ColonySurvivalRootFolder != null)
            {
                locationInput.Text = Properties.Settings.Default.ColonySurvivalRootFolder;
            }

            if (Properties.Settings.Default.TexturePackRootFolder != null)
            {
                modFolderInput.Text = Properties.Settings.Default.TexturePackRootFolder;
            }

            // TODO allow user to select localization
            setupFileVariables();
        }

        // Browse handler for gameroot
        private void GameRootBrowseBtn_Click(object sender, EventArgs e)
        {
            // Open a dialog to choose root folder
            DialogResult result = RootFolderSelectDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                rootGameFolder = RootFolderSelectDialog.SelectedPath;
                locationInput.Text = rootGameFolder;
            }
        }

        // browse handler for mod root
        private void ModRootBrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = RootFolderSelectDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                texturePackFolder = RootFolderSelectDialog.SelectedPath;
                modFolderInput.Text = texturePackFolder;
            }
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            statusTxt.Clear();
            SetStatus("Verifying folders", false);
            
            // Verify the root folder
            if (!verifyRootFolder())
                return;
            
            // Verify the mod folder
            if (!verifyTexturePack())
                return;
            
            // Save the field values once verified
            Properties.Settings.Default.Save();
            
            createNamesDictionary();

            formatMaterialsAndCopyToTemp();

            copyMaterialsToGameFolder();
        }

        private void copyMaterialsToGameFolder()
        {
            if(Directory.Exists(tempFolder))
            {
                new Microsoft.VisualBasic.Devices.Computer().
                    FileSystem.CopyDirectory(tempFolder, albedoFolder, true);

                SetStatus("Succesfully set new textures", false);
            }
        }

        private void backupCSTextures()
        {
            if (!Directory.Exists(backupTexturesFolder))
                Directory.CreateDirectory(backupTexturesFolder);

            SetStatus("Backing up Colony Survival textures", false);
            if(Directory.Exists(backupTexturesFolder))
            {
                new Microsoft.VisualBasic.Devices.Computer().
                    FileSystem.CopyDirectory(materialsFolder, backupTexturesFolder, true);

                SetStatus("Succesfully copied textures to backup location in game directory", false);
            } else
            {
                SetStatus("Couldn't find backup folder at " + backupTexturesFolder, true);
            }
        }

        private void restoreCSTextures()
        {
            if (!Directory.Exists(backupTexturesFolder))
            {
                SetStatus("Couldn't locate backup textures at " + backupTexturesFolder, true);
                return;
            }

            SetStatus("Restoring backed up textures", false);

            new Microsoft.VisualBasic.Devices.Computer().
                    FileSystem.CopyDirectory(backupTexturesFolder, materialsFolder, true);

            SetStatus("Succesfully restores backuped up textures", false);
        }

        private void formatMaterialsAndCopyToTemp()
        {
            if(!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            } else {
                string[] filePaths = Directory.GetFiles(tempFolder);
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
            }

            foreach(KeyValuePair<string, string> entry in textureNames)
            {
                var csName = entry.Key + ".png";
                var mcName = entry.Value + ".png";
                var originPath = Path.Combine(texturePackBlockTexturesFolder, mcName);
                var newPath = Path.Combine(tempFolder, csName);

                // check file exists
                if(File.Exists(originPath)) {

                    // open the image to read height and width
                    using (FileStream file = new FileStream(originPath, FileMode.Open, FileAccess.Read))
                    {
                        using (Image tif = Image.FromStream(stream: file,
                                                            useEmbeddedColorManagement: false,
                                                            validateImageData: false))
                        {
                            // get height and width of original image
                            float width = tif.PhysicalDimension.Width;
                            float height = tif.PhysicalDimension.Height;

                            // if image is the right size then copy it to temp
                            if (height == 256 && width == 256)
                            {
                                File.Copy(originPath, newPath);
                            // if image is too tall then rezie (normally a block with multiple states)
                            } else if (width == 256 && height > 256)
                            {
                                int x = 0, y = 0, newWidth = 256, newHeight = 256;
                                Bitmap source = new Bitmap(originPath);
                                Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(x, y, newWidth, newHeight), source.PixelFormat);
                                CroppedImage.Save(newPath, ImageFormat.Png);

                                SetStatus("Cropped copy of " + mcName + " due to height", false);

                            // If the image is outside or accepted dimensions attempt a resize
                            } else if (((width < 256 && height < 256) || (width > 256 && height > 256)) && resizeYes.Checked == true)
                            {
                                int newWidth = 256, newHeight = 256;

                                try
                                {
                                    // take the original image, resize and then save to temp
                                    var destRect = new Rectangle(0, 0, newWidth, newHeight);
                                    var destImage = new Bitmap(newWidth, newHeight);
                                    Bitmap source = new Bitmap(originPath);

                                    destImage.SetResolution(source.HorizontalResolution, source.VerticalResolution);

                                    using (var graphics = Graphics.FromImage(destImage))
                                    {
                                        graphics.CompositingMode = CompositingMode.SourceCopy;
                                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                        using (var wrapMode = new ImageAttributes())
                                        {
                                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                                            graphics.DrawImage(source, destRect, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                                            graphics.Save();
                                        }
                                    }

                                    destImage.Save(newPath, ImageFormat.Png);
                                } catch (Exception e)
                                {
                                    SetStatus("failed to resize " + originPath, true);
                                }
                            }
                        }
                    }
                }
            }

            SetStatus("Copied items to Temp Folder succesfully - " + tempFolder, false);
        }



        private void createNamesDictionary()
        {
            // textureNames
            var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"values\TextureNames.xml");
            textureNames = XElement.Load(xmlPath)
                .Elements("texture")
                .ToDictionary(
                    el => (string)el.Attribute("CSName"),
                    el => (string)el.Attribute("MCName")
                );
        }

        private void setupFileVariables()
        {
            // Colony Survival
            materialsFolder = Path.Combine(rootGameFolder, @"gamedata\textures\materials\blocks");
            iconsFolder = Path.Combine(rootGameFolder, @"gamedata\textures\icons");

            albedoFolder = Path.Combine(materialsFolder, @"albedo");
            emissiveMaskAlphaFolder = Path.Combine(materialsFolder, @"emissiveMaskAlpha");
            heightSmoothnessSpecularityFolder = Path.Combine(materialsFolder, @"heightSmoothnessSpecularity");
            normalFolder = Path.Combine(materialsFolder, @"normal");

            backupTexturesFolder = Path.Combine(rootGameFolder, @"textureBackups");
            tempFolder = Path.Combine(Path.GetTempPath() + @"mxTextures");

            // Texture Pack
            texturePackBlockTexturesFolder = Path.Combine(texturePackFolder, @"assets\minecraft\textures\blocks");
        }

        private bool verifyTexturePack()
        {
            // Root Folder contains a value
            if (texturePackFolder != null && texturePackFolder.Length != 0)
            {
                // Root Folder directory exists
                if (Directory.Exists(texturePackFolder))
                {
                    SetStatus("Verified texture pack directory", false);
                    
                    // found the texture blocks folder
                    if (Directory.Exists(texturePackBlockTexturesFolder))
                    {
                        SetStatus("Verified textures in Texture Pack", false);
                    } else
                    {
                        SetStatus("Could not find the blocks folder at " + texturePackBlockTexturesFolder, true);
                    }

                    return true;
                }
                else
                {
                    SetStatus("Texture pack folder doesn't exist at " + texturePackFolder, true);
                    return false;
                }
            }
            else
            {
                SetStatus("Texture pack folder selection doesn't contain a value", true);
                return false;
            }
        }

        private bool verifyRootFolder()
        {
            // Root Folder contains a value
            if (rootGameFolder != null && rootGameFolder.Length != 0)
            {
                // Root Folder directory exists
                if (Directory.Exists(rootGameFolder))
                {
                    // Found colonyClient executable in folder
                    string[] files = Directory.GetFiles(rootGameFolder);
                    if (Array.Exists(files, element => element.EndsWith("colonyclient.exe")))
                    {
                        SetStatus("Verified game directory", false);

                        if (!Directory.Exists(materialsFolder))
                        {
                            SetStatus("Couldn't locate materials folder", true);
                            return false;
                        }

                        if (!Directory.Exists(iconsFolder))
                        {
                            SetStatus("Couldn't locate icons folder", true);
                            return false;
                        }

                        if (!Directory.Exists(iconsFolder))
                        {
                            SetStatus("Couldn't locate icons folder", true);
                            return false;
                        }

                        if (!Directory.Exists(albedoFolder))
                        {
                            SetStatus("Couldn't locate albedo folder in " + albedoFolder, true);
                            return false;
                        }

                        if (!Directory.Exists(emissiveMaskAlphaFolder))
                        {
                            SetStatus("Couldn't locate emissiveMaskAlpha folder in " + emissiveMaskAlphaFolder, true);
                            return false;
                        }

                        if (!Directory.Exists(heightSmoothnessSpecularityFolder))
                        {
                            SetStatus("Couldn't locate heightSmoothnessSpecularityFolder folder in " + heightSmoothnessSpecularityFolder, true);
                            return false;
                        }

                        if (!Directory.Exists(normalFolder))
                        {
                            SetStatus("Couldn't locate normal folder in " + normalFolder, true);
                            return false;
                        }

                        return true;
                    }
                    else
                    {
                        SetStatus("Couldn't verify colonyclient.exe is located in selected root folder", true);
                        return false;
                    }
                }
                else
                {
                    SetStatus("Root folder doesn't exist at " + rootGameFolder, true);
                    return false;
                }
            }
            else
            {
                SetStatus("Root folder selection doesn't contain a value", true);
                return false;
            }
        }
        
        private void SetStatus(string message, bool error)
        {
            int characterCountBefore = statusTxt.Text.Length;
            int characterCountAfter;

            // type
            // false = text
            // true = error
            switch (error)
            {
                case false:
                    statusTxt.AppendText(DateTime.Now.ToShortTimeString().ToString() + ": " + message + "\n");
                    characterCountAfter = statusTxt.Text.Length;

                    statusTxt.Select(characterCountBefore, characterCountAfter);
                    statusTxt.SelectionColor = Color.Green;
                    break;
                case true:
                    statusTxt.AppendText(DateTime.Now.ToShortTimeString().ToString() + ": " + message + "\n");
                    characterCountAfter = statusTxt.Text.Length;

                    statusTxt.Select(characterCountBefore, characterCountAfter);
                    statusTxt.SelectionColor = Color.Red;
                    break;
            }
        }

        private void RootFolderSelectDialog_HelpRequest(object sender, EventArgs e)
        {
            // Empty Method, required for dialog
        }

        private void locationInput_TextChanged(object sender, EventArgs e)
        {
            rootGameFolder = locationInput.Text;
            Properties.Settings.Default.ColonySurvivalRootFolder = rootGameFolder;
        }

        private void modFolderInput_TextChanged(object sender, EventArgs e)
        {
            texturePackFolder = modFolderInput.Text;
            Properties.Settings.Default.TexturePackRootFolder = texturePackFolder;

            texturePackBlockTexturesFolder = Path.Combine(texturePackFolder, @"assets\minecraft\textures\blocks");
        }

        private void backupTexturesBtn_Click(object sender, EventArgs e)
        {
            backupCSTextures();
        }

        private void restoreTexturesBtn_Click(object sender, EventArgs e)
        {
            restoreCSTextures();
        }
    }
}
