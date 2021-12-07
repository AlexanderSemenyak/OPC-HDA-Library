
namespace Opc.Hda
{
    partial class ReadDataFromHda
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
            this.txtTagsFileName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentTag = new System.Windows.Forms.TextBox();
            this.btnFindTagInTree = new System.Windows.Forms.Button();
            this.txtSearchTag = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tree = new Opc.Hda.Controls.Tree.TreeViewAdv();
            this.treeColumn1 = new Opc.Hda.Controls.Tree.TreeColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateStart = new System.Windows.Forms.TextBox();
            this.btnReadTag = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbls = new System.Windows.Forms.Label();
            this.txtServerSuffix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtMaxRowsInTable = new System.Windows.Forms.TextBox();
            this.txtTagFromTags = new System.Windows.Forms.TextBox();
            this.txtDayFromDays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReconnectPeriod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbNoConsoleDetails = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTagsFileName
            // 
            this.txtTagsFileName.AllowDrop = true;
            this.txtTagsFileName.BackColor = System.Drawing.SystemColors.Info;
            this.txtTagsFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTagsFileName.Location = new System.Drawing.Point(0, 0);
            this.txtTagsFileName.Name = "txtTagsFileName";
            this.txtTagsFileName.Size = new System.Drawing.Size(390, 20);
            this.txtTagsFileName.TabIndex = 19;
            this.txtTagsFileName.Text = "<Перетяните файл с тэгами>";
            this.txtTagsFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.txtTagsFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tree);
            this.panel1.Controls.Add(this.txtCurrentTag);
            this.panel1.Controls.Add(this.btnFindTagInTree);
            this.panel1.Controls.Add(this.txtSearchTag);
            this.panel1.Controls.Add(this.txtTagsFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(737, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 674);
            this.panel1.TabIndex = 20;
            // 
            // txtCurrentTag
            // 
            this.txtCurrentTag.AllowDrop = true;
            this.txtCurrentTag.BackColor = System.Drawing.SystemColors.Info;
            this.txtCurrentTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCurrentTag.Location = new System.Drawing.Point(0, 63);
            this.txtCurrentTag.Name = "txtCurrentTag";
            this.txtCurrentTag.Size = new System.Drawing.Size(390, 20);
            this.txtCurrentTag.TabIndex = 22;
            this.txtCurrentTag.Text = "АСУТП.SHU_3T.AI.GPS3T_AI_PG_V_KOLL.XVXX";
            // 
            // btnFindTagInTree
            // 
            this.btnFindTagInTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFindTagInTree.Location = new System.Drawing.Point(0, 40);
            this.btnFindTagInTree.Name = "btnFindTagInTree";
            this.btnFindTagInTree.Size = new System.Drawing.Size(390, 23);
            this.btnFindTagInTree.TabIndex = 21;
            this.btnFindTagInTree.Text = "Найти тэг...";
            this.btnFindTagInTree.Click += new System.EventHandler(this.btnFindTagInTree_Click);
            // 
            // txtSearchTag
            // 
            this.txtSearchTag.AllowDrop = true;
            this.txtSearchTag.BackColor = System.Drawing.SystemColors.Info;
            this.txtSearchTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchTag.Location = new System.Drawing.Point(0, 20);
            this.txtSearchTag.Name = "txtSearchTag";
            this.txtSearchTag.Size = new System.Drawing.Size(390, 20);
            this.txtSearchTag.TabIndex = 20;
            this.txtSearchTag.Text = "АСУТП.SHU_3T.AI.GPS3T_AI_PG_V_KOLL.XVXX";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(731, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 674);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // tree
            // 
            this.tree.BackColor = System.Drawing.SystemColors.Window;
            this.tree.Columns.Add(this.treeColumn1);
            this.tree.DefaultToolTipProvider = null;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.DragDropMarkColor = System.Drawing.Color.Black;
            this.tree.LineColor = System.Drawing.SystemColors.ControlDark;
            this.tree.Location = new System.Drawing.Point(0, 83);
            this.tree.Model = null;
            this.tree.Name = "tree";
            this.tree.SelectedNode = null;
            this.tree.Size = new System.Drawing.Size(390, 591);
            this.tree.TabIndex = 18;
            this.tree.UseColumns = true;
            this.tree.SelectionChanged += new System.EventHandler(this.tree_SelectionChanged);
            // 
            // treeColumn1
            // 
            this.treeColumn1.FieldName = "";
            this.treeColumn1.Header = "";
            this.treeColumn1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn1.TooltipText = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTag.Location = new System.Drawing.Point(40, 250);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(308, 20);
            this.txtTag.TabIndex = 9;
            this.txtTag.Text = "<текущий экспортируемый тэг>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Дата окончания";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(107, 65);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(100, 20);
            this.txtDateEnd.TabIndex = 7;
            this.txtDateEnd.Text = "07.12.2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата начала";
            // 
            // txtDateStart
            // 
            this.txtDateStart.Location = new System.Drawing.Point(107, 45);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(100, 20);
            this.txtDateStart.TabIndex = 5;
            this.txtDateStart.Text = "06.12.2020";
            // 
            // btnReadTag
            // 
            this.btnReadTag.Location = new System.Drawing.Point(205, 140);
            this.btnReadTag.Name = "btnReadTag";
            this.btnReadTag.Size = new System.Drawing.Size(122, 23);
            this.btnReadTag.TabIndex = 4;
            this.btnReadTag.Text = "Читать в консоль";
            this.btnReadTag.UseVisualStyleBackColor = true;
            this.btnReadTag.Click += new System.EventHandler(this.btnReadTag_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 276);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(344, 18);
            this.progressBar1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(723, 350);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaxPoints);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServerSuffix);
            this.groupBox1.Controls.Add(this.lbls);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 40);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPC";
            // 
            // lbls
            // 
            this.lbls.AutoSize = true;
            this.lbls.Location = new System.Drawing.Point(156, 16);
            this.lbls.Name = "lbls";
            this.lbls.Size = new System.Drawing.Size(64, 13);
            this.lbls.TabIndex = 3;
            this.lbls.Text = "ServerSuffix";
            // 
            // txtServerSuffix
            // 
            this.txtServerSuffix.Location = new System.Drawing.Point(226, 13);
            this.txtServerSuffix.Name = "txtServerSuffix";
            this.txtServerSuffix.Size = new System.Drawing.Size(207, 20);
            this.txtServerSuffix.TabIndex = 2;
            this.txtServerSuffix.Text = "Infinity.OPCHDAServer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Макс.количество точек";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(50, 13);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "192.168.1.1";
            // 
            // txtMaxPoints
            // 
            this.txtMaxPoints.Location = new System.Drawing.Point(571, 13);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(100, 20);
            this.txtMaxPoints.TabIndex = 11;
            this.txtMaxPoints.Text = "100000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Остановить чтение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Макс.количество строк в одной таблице";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(354, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(363, 225);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "АСУТП.SHU_3T.AI.GPS3T_AI_PG_V_KOLL.XVXX";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // txtMaxRowsInTable
            // 
            this.txtMaxRowsInTable.Location = new System.Drawing.Point(227, 114);
            this.txtMaxRowsInTable.Name = "txtMaxRowsInTable";
            this.txtMaxRowsInTable.Size = new System.Drawing.Size(100, 20);
            this.txtMaxRowsInTable.TabIndex = 13;
            this.txtMaxRowsInTable.Text = "300000";
            // 
            // txtTagFromTags
            // 
            this.txtTagFromTags.Location = new System.Drawing.Point(355, 276);
            this.txtTagFromTags.Name = "txtTagFromTags";
            this.txtTagFromTags.Size = new System.Drawing.Size(137, 20);
            this.txtTagFromTags.TabIndex = 19;
            // 
            // txtDayFromDays
            // 
            this.txtDayFromDays.Location = new System.Drawing.Point(92, 299);
            this.txtDayFromDays.Name = "txtDayFromDays";
            this.txtDayFromDays.Size = new System.Drawing.Size(255, 20);
            this.txtDayFromDays.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Переключаться каждые X дней (для ускорения):";
            // 
            // txtReconnectPeriod
            // 
            this.txtReconnectPeriod.Location = new System.Drawing.Point(267, 91);
            this.txtReconnectPeriod.Name = "txtReconnectPeriod";
            this.txtReconnectPeriod.Size = new System.Drawing.Size(60, 20);
            this.txtReconnectPeriod.TabIndex = 21;
            this.txtReconnectPeriod.Text = "4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbNoConsoleDetails);
            this.panel2.Controls.Add(this.txtReconnectPeriod);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtDayFromDays);
            this.panel2.Controls.Add(this.txtTagFromTags);
            this.panel2.Controls.Add(this.txtMaxRowsInTable);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnReadTag);
            this.panel2.Controls.Add(this.txtDateStart);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtDateEnd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTag);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 674);
            this.panel2.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Читать в DataTable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbNoConsoleDetails
            // 
            this.cbNoConsoleDetails.AutoSize = true;
            this.cbNoConsoleDetails.Location = new System.Drawing.Point(12, 226);
            this.cbNoConsoleDetails.Name = "cbNoConsoleDetails";
            this.cbNoConsoleDetails.Size = new System.Drawing.Size(256, 17);
            this.cbNoConsoleDetails.TabIndex = 23;
            this.cbNoConsoleDetails.Text = "Не писать детали по каждому дню в консоль";
            this.cbNoConsoleDetails.UseVisualStyleBackColor = true;
            // 
            // ReadDataFromHda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 674);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ReadDataFromHda";
            this.Text = "ReadDataFromHda";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Opc.Hda.Controls.Tree.TreeViewAdv tree;
        private System.Windows.Forms.TextBox txtTagsFileName;
        private Controls.Tree.TreeColumn treeColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnFindTagInTree;
        private System.Windows.Forms.TextBox txtSearchTag;
        private System.Windows.Forms.TextBox txtCurrentTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateStart;
        private System.Windows.Forms.Button btnReadTag;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxPoints;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerSuffix;
        private System.Windows.Forms.Label lbls;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtMaxRowsInTable;
        private System.Windows.Forms.TextBox txtTagFromTags;
        private System.Windows.Forms.TextBox txtDayFromDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReconnectPeriod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbNoConsoleDetails;
        private System.Windows.Forms.Button button1;
    }
}