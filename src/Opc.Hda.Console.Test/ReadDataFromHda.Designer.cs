
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadDataFromHda));
            this.txtTagsFileName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentTag = new System.Windows.Forms.TextBox();
            this.btnFindTagInTree = new System.Windows.Forms.Button();
            this.txtSearchTag = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateStart = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestOPC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerSuffix = new System.Windows.Forms.TextBox();
            this.lbls = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaxRowsInTable = new System.Windows.Forms.TextBox();
            this.txtTagFromTags = new System.Windows.Forms.TextBox();
            this.txtDayFromDays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReconnectPeriod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStopDtToSql = new System.Windows.Forms.Button();
            this.txtCurrentIndex_FromAll_dtFiles = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnRefreshTags = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbNoConsoleDetails = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTestSqlServer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSQLConnectionString = new System.Windows.Forms.TextBox();
            this.tree = new Opc.Hda.Controls.Tree.TreeViewAdv();
            this.treeColumn1 = new Opc.Hda.Controls.Tree.TreeColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTag.Location = new System.Drawing.Point(41, 210);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(317, 20);
            this.txtTag.TabIndex = 9;
            this.txtTag.Text = "<текущий экспортируемый тэг>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Дата окончания";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(279, 23);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(79, 20);
            this.txtDateEnd.TabIndex = 7;
            this.txtDateEnd.Text = "07.12.2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата начала";
            // 
            // txtDateStart
            // 
            this.txtDateStart.Location = new System.Drawing.Point(109, 23);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(76, 20);
            this.txtDateStart.TabIndex = 5;
            this.txtDateStart.Text = "06.12.2020";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 234);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(251, 18);
            this.progressBar1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestOPC);
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
            this.groupBox1.Text = "Подключение к OPC-HDA-серверу";
            // 
            // btnTestOPC
            // 
            this.btnTestOPC.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTestOPC.Location = new System.Drawing.Point(677, 12);
            this.btnTestOPC.Name = "btnTestOPC";
            this.btnTestOPC.Size = new System.Drawing.Size(48, 23);
            this.btnTestOPC.TabIndex = 28;
            this.btnTestOPC.Text = "Тест...";
            this.btnTestOPC.UseVisualStyleBackColor = false;
            this.btnTestOPC.Click += new System.EventHandler(this.btnTestOPC_Click);
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
            // txtMaxPoints
            // 
            this.txtMaxPoints.Location = new System.Drawing.Point(571, 13);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(100, 20);
            this.txtMaxPoints.TabIndex = 11;
            this.txtMaxPoints.Text = "100000";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(50, 13);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "192.168.1.1";
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
            // txtServerSuffix
            // 
            this.txtServerSuffix.Location = new System.Drawing.Point(226, 13);
            this.txtServerSuffix.Name = "txtServerSuffix";
            this.txtServerSuffix.Size = new System.Drawing.Size(207, 20);
            this.txtServerSuffix.TabIndex = 2;
            this.txtServerSuffix.Text = "Infinity.OPCHDAServer";
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(165, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Остановить выгрузку в *.dt-файлы";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Макс.количество строк в одной таблице";
            // 
            // txtMaxRowsInTable
            // 
            this.txtMaxRowsInTable.Location = new System.Drawing.Point(298, 71);
            this.txtMaxRowsInTable.Name = "txtMaxRowsInTable";
            this.txtMaxRowsInTable.Size = new System.Drawing.Size(60, 20);
            this.txtMaxRowsInTable.TabIndex = 13;
            this.txtMaxRowsInTable.Text = "4000000";
            // 
            // txtTagFromTags
            // 
            this.txtTagFromTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTagFromTags.Location = new System.Drawing.Point(269, 233);
            this.txtTagFromTags.Name = "txtTagFromTags";
            this.txtTagFromTags.Size = new System.Drawing.Size(110, 20);
            this.txtTagFromTags.TabIndex = 19;
            // 
            // txtDayFromDays
            // 
            this.txtDayFromDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDayFromDays.Location = new System.Drawing.Point(12, 182);
            this.txtDayFromDays.Name = "txtDayFromDays";
            this.txtDayFromDays.Size = new System.Drawing.Size(147, 20);
            this.txtDayFromDays.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(271, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Переподключаться каждые X дней (для ускорения):";
            // 
            // txtReconnectPeriod
            // 
            this.txtReconnectPeriod.Location = new System.Drawing.Point(298, 48);
            this.txtReconnectPeriod.Name = "txtReconnectPeriod";
            this.txtReconnectPeriod.Size = new System.Drawing.Size(60, 20);
            this.txtReconnectPeriod.TabIndex = 21;
            this.txtReconnectPeriod.Text = "1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 674);
            this.panel2.TabIndex = 22;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 396);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(731, 278);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Перетяните на серое поле .dt-файл для просмотра содежимого (можно извлечь для сви" +
    "х нужд Ctrl+A, Ctrl+C, периодичность - 1 минута)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(723, 239);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStopDtToSql);
            this.groupBox3.Controls.Add(this.txtCurrentIndex_FromAll_dtFiles);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.txtDateEnd);
            this.groupBox3.Controls.Add(this.txtDateStart);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtTag);
            this.groupBox3.Controls.Add(this.txtDayFromDays);
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnRefreshTags);
            this.groupBox3.Controls.Add(this.txtTagFromTags);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.cbNoConsoleDetails);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtReconnectPeriod);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMaxRowsInTable);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 311);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выгрузка архива телеметрии в *.dt-файлы (для АРМ Геолога)";
            // 
            // btnStopDtToSql
            // 
            this.btnStopDtToSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopDtToSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStopDtToSql.Location = new System.Drawing.Point(521, 269);
            this.btnStopDtToSql.Name = "btnStopDtToSql";
            this.btnStopDtToSql.Size = new System.Drawing.Size(200, 25);
            this.btnStopDtToSql.TabIndex = 31;
            this.btnStopDtToSql.Text = "Остановить загрузку из *.dt-файлов";
            this.btnStopDtToSql.UseVisualStyleBackColor = false;
            this.btnStopDtToSql.Click += new System.EventHandler(this.btnStopDtToSql_Click);
            // 
            // txtCurrentIndex_FromAll_dtFiles
            // 
            this.txtCurrentIndex_FromAll_dtFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentIndex_FromAll_dtFiles.Location = new System.Drawing.Point(364, 274);
            this.txtCurrentIndex_FromAll_dtFiles.Name = "txtCurrentIndex_FromAll_dtFiles";
            this.txtCurrentIndex_FromAll_dtFiles.Size = new System.Drawing.Size(151, 20);
            this.txtCurrentIndex_FromAll_dtFiles.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(453, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "2-й этап: загрузка архива из .dt-файлов в архив телеметрии АРМ Геолога";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(9, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(370, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "1-й этап: выгрузка данных из OPC HDA-сервера в .dt-файлы";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Перечень выгружаемых тэгов";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(385, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(342, 193);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // btnRefreshTags
            // 
            this.btnRefreshTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefreshTags.Location = new System.Drawing.Point(385, 231);
            this.btnRefreshTags.Name = "btnRefreshTags";
            this.btnRefreshTags.Size = new System.Drawing.Size(343, 23);
            this.btnRefreshTags.TabIndex = 26;
            this.btnRefreshTags.Text = "Обновить список поддерживаемых к загрузке Тэгов";
            this.btnRefreshTags.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button3.Location = new System.Drawing.Point(12, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(346, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Загрузить ВСЕ *.dt-файлы в архив АРМ Геолога";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(12, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(346, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Выгрузить архив телеметрии в *.dt-файлы";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbNoConsoleDetails
            // 
            this.cbNoConsoleDetails.AutoSize = true;
            this.cbNoConsoleDetails.Location = new System.Drawing.Point(19, 97);
            this.cbNoConsoleDetails.Name = "cbNoConsoleDetails";
            this.cbNoConsoleDetails.Size = new System.Drawing.Size(270, 17);
            this.cbNoConsoleDetails.TabIndex = 23;
            this.cbNoConsoleDetails.Text = "Не выводить детали по каждому дню в консоль";
            this.cbNoConsoleDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTestSqlServer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSQLConnectionString);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 45);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Подключение к архиву телеметрии АРМ Геолога";
            // 
            // btnTestSqlServer
            // 
            this.btnTestSqlServer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTestSqlServer.Location = new System.Drawing.Point(676, 16);
            this.btnTestSqlServer.Name = "btnTestSqlServer";
            this.btnTestSqlServer.Size = new System.Drawing.Size(48, 23);
            this.btnTestSqlServer.TabIndex = 29;
            this.btnTestSqlServer.Text = "Тест...";
            this.btnTestSqlServer.UseVisualStyleBackColor = false;
            this.btnTestSqlServer.Click += new System.EventHandler(this.btnTestSqlServer_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Строка подключения:";
            // 
            // txtSQLConnectionString
            // 
            this.txtSQLConnectionString.Location = new System.Drawing.Point(128, 19);
            this.txtSQLConnectionString.Name = "txtSQLConnectionString";
            this.txtSQLConnectionString.Size = new System.Drawing.Size(543, 20);
            this.txtSQLConnectionString.TabIndex = 25;
            this.txtSQLConnectionString.Text = "Server=.;Database=FOND;User ID=URRSSERVER\\Администратор;Trusted_Connection=true;C" +
    "onnection Timeout=0";
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
            // ReadDataFromHda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 674);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ReadDataFromHda";
            this.Text = "Выгрузка архива телеметрии из архивного OPC HDA-сервера";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxPoints;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerSuffix;
        private System.Windows.Forms.Label lbls;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaxRowsInTable;
        private System.Windows.Forms.TextBox txtTagFromTags;
        private System.Windows.Forms.TextBox txtDayFromDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReconnectPeriod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbNoConsoleDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSQLConnectionString;
        private System.Windows.Forms.Button btnTestOPC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefreshTags;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTestSqlServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCurrentIndex_FromAll_dtFiles;
        private System.Windows.Forms.Button btnStopDtToSql;
    }
}