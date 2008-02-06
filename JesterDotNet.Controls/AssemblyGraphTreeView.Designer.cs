namespace JesterDotNet.Controls
{
    partial class AssemblyGraphTreeView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyGraphTreeView));
            this.treeView = new System.Windows.Forms.TreeView();
            this.objectIconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.CheckBoxes = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.objectIconsImageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(150, 150);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewAfterCheck);
            this.treeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeCheck);
            // 
            // objectIconsImageList
            // 
            this.objectIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objectIconsImageList.ImageStream")));
            this.objectIconsImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.objectIconsImageList.Images.SetKeyName(0, "imgAssembly");
            this.objectIconsImageList.Images.SetKeyName(1, "imgModule");
            this.objectIconsImageList.Images.SetKeyName(2, "imgNamespace");
            this.objectIconsImageList.Images.SetKeyName(3, "imgClass");
            this.objectIconsImageList.Images.SetKeyName(4, "imgMethod");
            this.objectIconsImageList.Images.SetKeyName(5, "imgBranch");
            this.objectIconsImageList.Images.SetKeyName(6, "imgInterface");
            // 
            // AssemblyGraphTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView);
            this.Name = "AssemblyGraphTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ImageList objectIconsImageList;
    }
}
