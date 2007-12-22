using System.Collections.Generic;
using System.Windows.Forms;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace JesterDotNet.Controls
{
    public partial class AssemblyGraphTreeView : UserControl
    {
        private readonly IList<OpCode> _branchingOpCodes = new List<OpCode>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyGraphTreeView"/> class.
        /// </summary>
        public AssemblyGraphTreeView()
        {
            InitializeComponent();

            PopulateBranchingOpCodes();
        }

        /// <summary>
        /// Populates our collection of branching OpCodes so that we know which Op codes we're 
        /// looking for.
        /// </summary>
        private void PopulateBranchingOpCodes()
        {
            _branchingOpCodes.Add(OpCodes.Beq);
            _branchingOpCodes.Add(OpCodes.Beq_S);
            _branchingOpCodes.Add(OpCodes.Bge);
            _branchingOpCodes.Add(OpCodes.Bge_S);
            _branchingOpCodes.Add(OpCodes.Bge_Un);
            _branchingOpCodes.Add(OpCodes.Bge_Un_S);
            _branchingOpCodes.Add(OpCodes.Bgt);
            _branchingOpCodes.Add(OpCodes.Bgt_S);
            _branchingOpCodes.Add(OpCodes.Bgt_Un);
            _branchingOpCodes.Add(OpCodes.Bgt_Un_S);
            _branchingOpCodes.Add(OpCodes.Ble);
            _branchingOpCodes.Add(OpCodes.Ble_S);
            _branchingOpCodes.Add(OpCodes.Ble_Un);
            _branchingOpCodes.Add(OpCodes.Ble_Un_S);
            _branchingOpCodes.Add(OpCodes.Blt);
            _branchingOpCodes.Add(OpCodes.Blt_S);
            _branchingOpCodes.Add(OpCodes.Blt_Un);
            _branchingOpCodes.Add(OpCodes.Blt_Un_S);
            _branchingOpCodes.Add(OpCodes.Bne_Un);
            _branchingOpCodes.Add(OpCodes.Bne_Un_S);
            _branchingOpCodes.Add(OpCodes.Br);
            _branchingOpCodes.Add(OpCodes.Br_S);
            _branchingOpCodes.Add(OpCodes.Brfalse);
            _branchingOpCodes.Add(OpCodes.Brfalse_S);
            _branchingOpCodes.Add(OpCodes.Brtrue);
            _branchingOpCodes.Add(OpCodes.Brtrue_S);
        }

        /// <summary>
        /// Creates a <see cref="System.Windows.Forms.TreeNode">TreeNode</see> with the 
        /// given text and image key.
        /// </summary>
        /// <param name="text">The text of the TreeNode.</param>
        /// <param name="imageKey">The key corresponding to the TreeNode's image.</param>
        /// <returns></returns>
        private TreeNode CreateTreeNode(string text, string imageKey)
        {
            TreeNode treeNode = new TreeNode(text);
            treeNode.Checked = true;
            treeNode.ImageIndex = objectIconsImageList.Images.IndexOfKey(imageKey);
            treeNode.SelectedImageIndex = objectIconsImageList.Images.IndexOfKey(imageKey);

            return treeNode;
        }

        /// <summary>
        /// Reflects through the currently selected assembly and reflects the type tree
        /// in tvAssemblyGraph.
        /// </summary>
        public void LoadAssemblies(string[] fileNames)
        {
            treeView.Nodes.Clear();

            for (int theAssembly = 0; theAssembly < fileNames.Length; theAssembly++)
            {
                // Load our input assembly and create its node in the tree
                AssemblyDefinition inputAssembly =
                    AssemblyFactory.GetAssembly(fileNames[theAssembly]);

                TreeNode assemblyTreeNode =
                    CreateTreeNode(fileNames[theAssembly], "imgAssembly");
                treeView.Nodes.Add(assemblyTreeNode);

                // Retrieve the modules from the assembly.  Most assemblies only have one
                // module, but it is possible for assemblies to possess multiple modules
                for (int theModule = 0; theModule < inputAssembly.Modules.Count; theModule++)
                {
                    // Add a node to the tree to represent the module
                    TreeNode moduleTreeNode =
                        CreateTreeNode(inputAssembly.Modules[theModule].Name, "imgModule");
                    treeView.Nodes[theAssembly].Nodes.Add(moduleTreeNode);

                    // Add the classes in each type
                    for (int theType = 0;
                         theType < inputAssembly.Modules[theModule].Types.Count;
                         theType++)
                    {
                        // Add a node to the tree to represent the class
                        treeView.Nodes[theAssembly].Nodes[theModule].Nodes.Add(
                            CreateTreeNode(inputAssembly.Modules[theModule].Types[theType].FullName,
                                           "imgClass"));

                        // Create a test method for each method in this type
                        for (int theMethod = 0;
                             theMethod <
                             inputAssembly.Modules[theModule].Types[theType].Methods.Count;
                             theMethod++)
                        {
                            MethodDefinition methodDefinition =
                                inputAssembly.Modules[theModule].Types[theType].Methods[theMethod];
                            treeView.Nodes[theAssembly].Nodes[theModule].Nodes[theType].Nodes.Add(
                                CreateTreeNode(methodDefinition.Name, "imgMethod"));

                            // Store the method's MethodInfo object in this node's tag
                            // so that we may retrieve it later
                            treeView.Nodes[theAssembly].Nodes[theModule].Nodes[theType].Nodes[
                                theMethod].Tag =
                                methodDefinition;

                            // Interfaces or abstract classes don't have a body so we should skip 
                            // them
                            if (methodDefinition.HasBody)
                            {
                                MethodBody body = methodDefinition.Body;
                                CilWorker cilWorker = body.CilWorker;
                                foreach (Instruction instruction in body.Instructions)
                                {
                                    if (_branchingOpCodes.Contains(instruction.OpCode))
                                    {
                                        treeView.
                                            Nodes[theAssembly].
                                            Nodes[theModule].
                                            Nodes[theType].
                                            Nodes[theMethod].
                                            Nodes.Add(
                                            // TODO: We need a branch icon
                                            CreateTreeNode(instruction.OpCode.Name, "imgMethod"));
                                    }
                                }
                            }
                        }
                    }
                    moduleTreeNode.Expand();
                }
                assemblyTreeNode.Expand();
            }
        }

        /// <summary>
        /// Applies the check state of the given 
        /// <see cref="System.Windows.Forms.TreeNode">TreeNode</see> to all of its 
        /// children.
        /// </summary>
        /// <param name="treeNode">The TreeNode which contains the check state to apply.</param>
        private void CheckChildren(TreeNode treeNode)
        {
            if (treeNode.Nodes.Count != 0)
            {
                CheckChildren(treeNode.Nodes[0]);
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    treeNode.Nodes[i].Checked = treeNode.Checked;
                }
            }
        }
    }
}