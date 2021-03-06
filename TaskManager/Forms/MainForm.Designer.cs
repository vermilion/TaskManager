﻿namespace TaskManager.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.queryGridView = new System.Windows.Forms.DataGridView();
            this.AndOr = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.showClosedToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.queriesBox = new System.Windows.Forms.ToolStripComboBox();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAssignedTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 672);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Tag = " ";
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.splitContainer1);
            this.mainPage.Controls.Add(this.toolStrip1);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(930, 646);
            this.mainPage.TabIndex = 0;
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.queryGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.taskGridView);
            this.splitContainer1.Size = new System.Drawing.Size(924, 615);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 4;
            // 
            // queryGridView
            // 
            this.queryGridView.AllowUserToResizeColumns = false;
            this.queryGridView.AllowUserToResizeRows = false;
            this.queryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.queryGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.queryGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.queryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AndOr,
            this.Field,
            this.Operator,
            this.Value});
            this.queryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.queryGridView.Location = new System.Drawing.Point(0, 0);
            this.queryGridView.MultiSelect = false;
            this.queryGridView.Name = "queryGridView";
            this.queryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.queryGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryGridView.Size = new System.Drawing.Size(924, 116);
            this.queryGridView.TabIndex = 3;
            this.queryGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView2MouseDown);
            // 
            // AndOr
            // 
            this.AndOr.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.AndOr.DisplayStyleForCurrentCellOnly = true;
            this.AndOr.FillWeight = 20F;
            this.AndOr.HeaderText = "And/Or";
            this.AndOr.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.AndOr.Name = "AndOr";
            this.AndOr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Field
            // 
            this.Field.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Field.DisplayStyleForCurrentCellOnly = true;
            this.Field.FillWeight = 20F;
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Operator
            // 
            this.Operator.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Operator.DisplayStyleForCurrentCellOnly = true;
            this.Operator.FillWeight = 15F;
            this.Operator.HeaderText = "Operator";
            this.Operator.Items.AddRange(new object[] {
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>",
            "like"});
            this.Operator.Name = "Operator";
            this.Operator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Value
            // 
            this.Value.FillWeight = 45F;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taskGridView
            // 
            this.taskGridView.AllowUserToAddRows = false;
            this.taskGridView.AllowUserToDeleteRows = false;
            this.taskGridView.AllowUserToOrderColumns = true;
            this.taskGridView.AllowUserToResizeRows = false;
            this.taskGridView.AutoGenerateColumns = false;
            this.taskGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.taskGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.taskGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.taskGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.State,
            this.CreatedBy,
            this.CreationDate,
            this.Priority,
            this.Progress,
            this.AssignedTo,
            this.Title});
            this.taskGridView.DataSource = this.bindingSource1;
            this.taskGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskGridView.GridColor = System.Drawing.SystemColors.Control;
            this.taskGridView.Location = new System.Drawing.Point(0, 0);
            this.taskGridView.MultiSelect = false;
            this.taskGridView.Name = "taskGridView";
            this.taskGridView.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.taskGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.taskGridView.RowHeadersVisible = false;
            this.taskGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskGridView.Size = new System.Drawing.Size(924, 495);
            this.taskGridView.TabIndex = 2;
            this.taskGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.FillWeight = 5F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.State.DefaultCellStyle = dataGridViewCellStyle2;
            this.State.FillWeight = 8F;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.FillWeight = 10F;
            this.CreatedBy.HeaderText = "Created By";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CreationDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.CreationDate.FillWeight = 12F;
            this.CreationDate.HeaderText = "Creation Date";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Priority.DefaultCellStyle = dataGridViewCellStyle4;
            this.Priority.FillWeight = 5F;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Progress
            // 
            this.Progress.DataPropertyName = "Progress";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = null;
            this.Progress.DefaultCellStyle = dataGridViewCellStyle5;
            this.Progress.FillWeight = 3F;
            this.Progress.HeaderText = "%";
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            // 
            // AssignedTo
            // 
            this.AssignedTo.DataPropertyName = "AssignedTo";
            this.AssignedTo.FillWeight = 10F;
            this.AssignedTo.HeaderText = "Assigned To";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.DefaultCellStyle = dataGridViewCellStyle6;
            this.Title.FillWeight = 30F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.Sort = "ID DESC";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.showClosedToolStripMenuItem,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.queriesBox});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::TaskManager.Properties.Resources._1349864069_start;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton2.Text = "Run";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // showClosedToolStripMenuItem
            // 
            this.showClosedToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.showClosedToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showClosedToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showClosedToolStripMenuItem.Name = "showClosedToolStripMenuItem";
            this.showClosedToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.showClosedToolStripMenuItem.Text = "New Task";
            this.showClosedToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::TaskManager.Properties.Resources._1349872619_text_x_makefile;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(113, 22);
            this.toolStripButton1.Text = "Column options";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton3.Text = "Save query";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
            // 
            // queriesBox
            // 
            this.queriesBox.AutoSize = false;
            this.queriesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queriesBox.Name = "queriesBox";
            this.queriesBox.Size = new System.Drawing.Size(240, 23);
            this.queriesBox.SelectedIndexChanged += new System.EventHandler(this.QueriesBoxSelectedIndexChanged);
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 30;
            // 
            // columnState
            // 
            this.columnState.Text = "State";
            this.columnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnState.Width = 100;
            // 
            // columnCreatedBy
            // 
            this.columnCreatedBy.Text = "CreatedBy";
            this.columnCreatedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCreatedBy.Width = 110;
            // 
            // columnCreationDate
            // 
            this.columnCreationDate.Text = "CreationDate";
            this.columnCreationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCreationDate.Width = 137;
            // 
            // columnProgress
            // 
            this.columnProgress.Text = "%";
            this.columnProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnProgress.Width = 39;
            // 
            // columnAssignedTo
            // 
            this.columnAssignedTo.Text = "AssignedTo";
            this.columnAssignedTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAssignedTo.Width = 104;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 400;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 672);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskManager";
            this.tabControl1.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnState;
        private System.Windows.Forms.ColumnHeader columnCreatedBy;
        private System.Windows.Forms.ColumnHeader columnAssignedTo;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnCreationDate;
        private System.Windows.Forms.ColumnHeader columnProgress;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton showClosedToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView taskGridView;
        private System.Windows.Forms.DataGridView queryGridView;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripComboBox queriesBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewComboBoxColumn AndOr;
        private System.Windows.Forms.DataGridViewComboBoxColumn Field;
        private System.Windows.Forms.DataGridViewComboBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}

