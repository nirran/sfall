﻿namespace FalloutClient {
    partial class DebugEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bGlobals = new System.Windows.Forms.Button();
            this.bMapVars = new System.Windows.Forms.Button();
            this.bCritters = new System.Windows.Forms.Button();
            this.bSGlobals = new System.Windows.Forms.Button();
            this.bArrays = new System.Windows.Forms.Button();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 215);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // bGlobals
            // 
            this.bGlobals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bGlobals.Location = new System.Drawing.Point(12, 233);
            this.bGlobals.Name = "bGlobals";
            this.bGlobals.Size = new System.Drawing.Size(100, 23);
            this.bGlobals.TabIndex = 1;
            this.bGlobals.Text = "Globals";
            this.bGlobals.UseVisualStyleBackColor = true;
            this.bGlobals.Click += new System.EventHandler(this.bGlobals_Click);
            // 
            // bMapVars
            // 
            this.bMapVars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bMapVars.Location = new System.Drawing.Point(118, 233);
            this.bMapVars.Name = "bMapVars";
            this.bMapVars.Size = new System.Drawing.Size(100, 23);
            this.bMapVars.TabIndex = 2;
            this.bMapVars.Text = "Map variables";
            this.bMapVars.UseVisualStyleBackColor = true;
            this.bMapVars.Click += new System.EventHandler(this.bMapVars_Click);
            // 
            // bCritters
            // 
            this.bCritters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCritters.Location = new System.Drawing.Point(118, 262);
            this.bCritters.Name = "bCritters";
            this.bCritters.Size = new System.Drawing.Size(100, 23);
            this.bCritters.TabIndex = 3;
            this.bCritters.Text = "Critters";
            this.bCritters.UseVisualStyleBackColor = true;
            this.bCritters.Click += new System.EventHandler(this.bCritters_Click);
            // 
            // bSGlobals
            // 
            this.bSGlobals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSGlobals.Location = new System.Drawing.Point(225, 233);
            this.bSGlobals.Name = "bSGlobals";
            this.bSGlobals.Size = new System.Drawing.Size(100, 23);
            this.bSGlobals.TabIndex = 4;
            this.bSGlobals.Text = "sfall globals";
            this.bSGlobals.UseVisualStyleBackColor = true;
            this.bSGlobals.Click += new System.EventHandler(this.bSGlobals_Click);
            // 
            // bArrays
            // 
            this.bArrays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bArrays.Location = new System.Drawing.Point(12, 262);
            this.bArrays.Name = "bArrays";
            this.bArrays.Size = new System.Drawing.Size(100, 23);
            this.bArrays.TabIndex = 5;
            this.bArrays.Text = "sfall arrays";
            this.bArrays.UseVisualStyleBackColor = true;
            this.bArrays.Click += new System.EventHandler(this.bArrays_Click);
            // 
            // Column0
            // 
            this.Column0.HeaderText = "ID";
            this.Column0.Name = "Column0";
            this.Column0.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value (Int)";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value (Float)";
            this.Column3.Name = "Column3";
            // 
            // bEdit
            // 
            this.bEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit.Location = new System.Drawing.Point(225, 262);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(100, 23);
            this.bEdit.TabIndex = 6;
            this.bEdit.Text = "Edit";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // DebugEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 297);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bArrays);
            this.Controls.Add(this.bSGlobals);
            this.Controls.Add(this.bCritters);
            this.Controls.Add(this.bMapVars);
            this.Controls.Add(this.bGlobals);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DebugEditor";
            this.Text = "DebugEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bGlobals;
        private System.Windows.Forms.Button bMapVars;
        private System.Windows.Forms.Button bCritters;
        private System.Windows.Forms.Button bSGlobals;
        private System.Windows.Forms.Button bArrays;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button bEdit;

    }
}