
namespace Opc.Hda.Console.Test
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbls = new System.Windows.Forms.Label();
            this.txtServerSuffix = new System.Windows.Forms.TextBox();
            this.btnReadTag = new System.Windows.Forms.Button();
            this.txtDateStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(54, 1);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "192.168.1.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // lbls
            // 
            this.lbls.AutoSize = true;
            this.lbls.Location = new System.Drawing.Point(160, 4);
            this.lbls.Name = "lbls";
            this.lbls.Size = new System.Drawing.Size(64, 13);
            this.lbls.TabIndex = 3;
            this.lbls.Text = "ServerSuffix";
            // 
            // txtServerSuffix
            // 
            this.txtServerSuffix.Location = new System.Drawing.Point(230, 1);
            this.txtServerSuffix.Name = "txtServerSuffix";
            this.txtServerSuffix.Size = new System.Drawing.Size(207, 20);
            this.txtServerSuffix.TabIndex = 2;
            this.txtServerSuffix.Text = "Infinity.OPCDualSource";
            // 
            // btnReadTag
            // 
            this.btnReadTag.Location = new System.Drawing.Point(315, 60);
            this.btnReadTag.Name = "btnReadTag";
            this.btnReadTag.Size = new System.Drawing.Size(122, 23);
            this.btnReadTag.TabIndex = 4;
            this.btnReadTag.Text = "Читать в консоль";
            this.btnReadTag.UseVisualStyleBackColor = true;
            this.btnReadTag.Click += new System.EventHandler(this.btnReadTag_Click);
            // 
            // txtDateStart
            // 
            this.txtDateStart.Location = new System.Drawing.Point(89, 31);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(100, 20);
            this.txtDateStart.TabIndex = 5;
            this.txtDateStart.Text = "07.11.2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата начала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Дата окончания";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(337, 34);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(100, 20);
            this.txtDateEnd.TabIndex = 7;
            this.txtDateEnd.Text = "08.11.2021";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(41, 62);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(268, 20);
            this.txtTag.TabIndex = 9;
            this.txtTag.Text = "АСУТП.SHU_3T.AI.GPS3T_AI_PG_V_KOLL.XVXX";
            // 
            // txtMaxPoints
            // 
            this.txtMaxPoints.Location = new System.Drawing.Point(575, 34);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(100, 20);
            this.txtMaxPoints.TabIndex = 11;
            this.txtMaxPoints.Text = "500000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Макс.количество точек";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Читать в DataTable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Остановить чтение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReadDataFromHda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaxPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateStart);
            this.Controls.Add(this.btnReadTag);
            this.Controls.Add(this.lbls);
            this.Controls.Add(this.txtServerSuffix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Name = "ReadDataFromHda";
            this.Text = "ReadDataFromHda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbls;
        private System.Windows.Forms.TextBox txtServerSuffix;
        private System.Windows.Forms.Button btnReadTag;
        private System.Windows.Forms.TextBox txtDateStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtMaxPoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}