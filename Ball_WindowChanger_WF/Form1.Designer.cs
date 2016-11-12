namespace Ball_WindowChanger_WF
{
    partial class WindowChanger
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowChanger));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEntfernen = new System.Windows.Forms.Button();
            this.txtActiveTime = new System.Windows.Forms.TextBox();
            this.lblActiveTime = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.comStartHours = new System.Windows.Forms.ComboBox();
            this.comEndHours = new System.Windows.Forms.ComboBox();
            this.comStartMinutes = new System.Windows.Forms.ComboBox();
            this.comEndMinutes = new System.Windows.Forms.ComboBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.endeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ändernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshOpenWindowList = new System.Windows.Forms.Button();
            this.txtIntervalTime = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lvChangingWindowsInterval = new System.Windows.Forms.ListView();
            this.windowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intervalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lifeTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvChangingWindowsFromTo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processes = new System.Windows.Forms.ListBox();
            this.btnBackgroundMusic = new System.Windows.Forms.Button();
            this.cbHasSound = new System.Windows.Forms.CheckBox();
            this.menu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(571, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 31);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Hinzufügen/Ändern>>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEntfernen
            // 
            this.btnEntfernen.Location = new System.Drawing.Point(571, 348);
            this.btnEntfernen.Name = "btnEntfernen";
            this.btnEntfernen.Size = new System.Drawing.Size(126, 31);
            this.btnEntfernen.TabIndex = 3;
            this.btnEntfernen.Text = "<< Entfernen";
            this.btnEntfernen.UseVisualStyleBackColor = true;
            this.btnEntfernen.Click += new System.EventHandler(this.btnEntfernen_Click);
            // 
            // txtActiveTime
            // 
            this.txtActiveTime.Location = new System.Drawing.Point(637, 282);
            this.txtActiveTime.Name = "txtActiveTime";
            this.txtActiveTime.Size = new System.Drawing.Size(60, 20);
            this.txtActiveTime.TabIndex = 7;
            // 
            // lblActiveTime
            // 
            this.lblActiveTime.AutoSize = true;
            this.lblActiveTime.Location = new System.Drawing.Point(641, 266);
            this.lblActiveTime.Name = "lblActiveTime";
            this.lblActiveTime.Size = new System.Drawing.Size(58, 13);
            this.lblActiveTime.TabIndex = 8;
            this.lblActiveTime.Text = "Aktive Zeit";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(571, 172);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(45, 13);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Startzeit";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(570, 216);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(42, 13);
            this.lblEnd.TabIndex = 10;
            this.lblEnd.Text = "Endzeit";
            // 
            // comStartHours
            // 
            this.comStartHours.FormattingEnabled = true;
            this.comStartHours.Location = new System.Drawing.Point(572, 188);
            this.comStartHours.Name = "comStartHours";
            this.comStartHours.Size = new System.Drawing.Size(60, 21);
            this.comStartHours.TabIndex = 11;
            // 
            // comEndHours
            // 
            this.comEndHours.FormattingEnabled = true;
            this.comEndHours.Location = new System.Drawing.Point(572, 232);
            this.comEndHours.Name = "comEndHours";
            this.comEndHours.Size = new System.Drawing.Size(60, 21);
            this.comEndHours.TabIndex = 12;
            // 
            // comStartMinutes
            // 
            this.comStartMinutes.FormattingEnabled = true;
            this.comStartMinutes.Location = new System.Drawing.Point(636, 188);
            this.comStartMinutes.Name = "comStartMinutes";
            this.comStartMinutes.Size = new System.Drawing.Size(60, 21);
            this.comStartMinutes.TabIndex = 13;
            // 
            // comEndMinutes
            // 
            this.comEndMinutes.FormattingEnabled = true;
            this.comEndMinutes.Location = new System.Drawing.Point(636, 232);
            this.comEndMinutes.Name = "comEndMinutes";
            this.comEndMinutes.Size = new System.Drawing.Size(60, 21);
            this.comEndMinutes.TabIndex = 14;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.optionenToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(718, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.toolStripSeparator1,
            this.endeToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // endeToolStripMenuItem
            // 
            this.endeToolStripMenuItem.Name = "endeToolStripMenuItem";
            this.endeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.endeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.endeToolStripMenuItem.Text = "Ende";
            this.endeToolStripMenuItem.Click += new System.EventHandler(this.endeToolStripMenuItem_Click);
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hinzufügenToolStripMenuItem,
            this.ändernToolStripMenuItem,
            this.entfernenToolStripMenuItem});
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.optionenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // hinzufügenToolStripMenuItem
            // 
            this.hinzufügenToolStripMenuItem.Name = "hinzufügenToolStripMenuItem";
            this.hinzufügenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.hinzufügenToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.hinzufügenToolStripMenuItem.Text = "Hinzufügen";
            this.hinzufügenToolStripMenuItem.Click += new System.EventHandler(this.hinzufügenToolStripMenuItem_Click);
            // 
            // ändernToolStripMenuItem
            // 
            this.ändernToolStripMenuItem.Name = "ändernToolStripMenuItem";
            this.ändernToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ändernToolStripMenuItem.Text = "Ändern";
            // 
            // entfernenToolStripMenuItem
            // 
            this.entfernenToolStripMenuItem.Name = "entfernenToolStripMenuItem";
            this.entfernenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.entfernenToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.entfernenToolStripMenuItem.Text = "Entfernen";
            this.entfernenToolStripMenuItem.Click += new System.EventHandler(this.entfernenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stoppToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.bearbeitenToolStripMenuItem.Text = "Optionen";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stoppToolStripMenuItem
            // 
            this.stoppToolStripMenuItem.Name = "stoppToolStripMenuItem";
            this.stoppToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.stoppToolStripMenuItem.Text = "Stopp";
            this.stoppToolStripMenuItem.Click += new System.EventHandler(this.stoppToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.überToolStripMenuItem.Text = "Über";
            this.überToolStripMenuItem.Click += new System.EventHandler(this.überToolStripMenuItem_Click);
            // 
            // btnRefreshOpenWindowList
            // 
            this.btnRefreshOpenWindowList.Location = new System.Drawing.Point(570, 33);
            this.btnRefreshOpenWindowList.Name = "btnRefreshOpenWindowList";
            this.btnRefreshOpenWindowList.Size = new System.Drawing.Size(126, 31);
            this.btnRefreshOpenWindowList.TabIndex = 16;
            this.btnRefreshOpenWindowList.Text = "Aktualisieren";
            this.btnRefreshOpenWindowList.UseVisualStyleBackColor = true;
            this.btnRefreshOpenWindowList.Click += new System.EventHandler(this.btnRefreshOpenWindowList_Click);
            // 
            // txtIntervalTime
            // 
            this.txtIntervalTime.Location = new System.Drawing.Point(572, 282);
            this.txtIntervalTime.Name = "txtIntervalTime";
            this.txtIntervalTime.Size = new System.Drawing.Size(60, 20);
            this.txtIntervalTime.TabIndex = 17;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(572, 266);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 18;
            this.lblInterval.Text = "Interval";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatusStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 469);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(718, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "-- Beta --";
            // 
            // lblStatusStrip
            // 
            this.lblStatusStrip.Name = "lblStatusStrip";
            this.lblStatusStrip.Size = new System.Drawing.Size(70, 17);
            this.lblStatusStrip.Text = "Initialisieren";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(570, 385);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(127, 35);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(570, 426);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 35);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Stopp";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "config";
            this.openFileDialog.Filter = "Fensterwechsel-Dateien(*.fw)|*.fw|Alle Dateien|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "config";
            this.saveFileDialog.Filter = "Fensterwechsel-Dateien(*.fw)|*.fw|Alle Dateien|*.*";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "Test";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Automatischer Fensterwechsel";
            this.notifyIcon.Visible = true;
            // 
            // lvChangingWindowsInterval
            // 
            this.lvChangingWindowsInterval.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.windowName,
            this.intervalTime,
            this.lifeTime});
            this.lvChangingWindowsInterval.FullRowSelect = true;
            this.lvChangingWindowsInterval.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChangingWindowsInterval.Location = new System.Drawing.Point(15, 314);
            this.lvChangingWindowsInterval.MultiSelect = false;
            this.lvChangingWindowsInterval.Name = "lvChangingWindowsInterval";
            this.lvChangingWindowsInterval.Size = new System.Drawing.Size(534, 147);
            this.lvChangingWindowsInterval.TabIndex = 27;
            this.lvChangingWindowsInterval.UseCompatibleStateImageBehavior = false;
            this.lvChangingWindowsInterval.View = System.Windows.Forms.View.List;
            this.lvChangingWindowsInterval.ItemActivate += new System.EventHandler(this.lViewChangingWindowsInterval);
            this.lvChangingWindowsInterval.SelectedIndexChanged += new System.EventHandler(this.lViewChangingWindowsInterval);
            // 
            // windowName
            // 
            this.windowName.Text = "Name";
            this.windowName.Width = 400;
            // 
            // intervalTime
            // 
            this.intervalTime.Text = "Intervall";
            this.intervalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lifeTime
            // 
            this.lifeTime.Text = "Aktive Zeit";
            this.lifeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lifeTime.Width = 70;
            // 
            // lvChangingWindowsFromTo
            // 
            this.lvChangingWindowsFromTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvChangingWindowsFromTo.FullRowSelect = true;
            this.lvChangingWindowsFromTo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChangingWindowsFromTo.Location = new System.Drawing.Point(15, 171);
            this.lvChangingWindowsFromTo.MultiSelect = false;
            this.lvChangingWindowsFromTo.Name = "lvChangingWindowsFromTo";
            this.lvChangingWindowsFromTo.Size = new System.Drawing.Size(534, 137);
            this.lvChangingWindowsFromTo.TabIndex = 26;
            this.lvChangingWindowsFromTo.UseCompatibleStateImageBehavior = false;
            this.lvChangingWindowsFromTo.View = System.Windows.Forms.View.List;
            this.lvChangingWindowsFromTo.SelectedIndexChanged += new System.EventHandler(this.lvChangingWindowsFromTo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Startzeit";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Endzeit";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // processes
            // 
            this.processes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processes.FormattingEnabled = true;
            this.processes.HorizontalScrollbar = true;
            this.processes.Location = new System.Drawing.Point(15, 33);
            this.processes.Name = "processes";
            this.processes.Size = new System.Drawing.Size(534, 132);
            this.processes.TabIndex = 25;
            this.processes.SelectedIndexChanged += new System.EventHandler(this.processes_SelectedIndexChanged);
            // 
            // btnBackgroundMusic
            // 
            this.btnBackgroundMusic.Location = new System.Drawing.Point(570, 97);
            this.btnBackgroundMusic.Name = "btnBackgroundMusic";
            this.btnBackgroundMusic.Size = new System.Drawing.Size(126, 31);
            this.btnBackgroundMusic.TabIndex = 28;
            this.btnBackgroundMusic.Text = "Hintergrundmusik";
            this.btnBackgroundMusic.UseVisualStyleBackColor = true;
            this.btnBackgroundMusic.Click += new System.EventHandler(this.btnBackgroundMusic_Click_1);
            // 
            // cbHasSound
            // 
            this.cbHasSound.AutoSize = true;
            this.cbHasSound.Location = new System.Drawing.Point(573, 308);
            this.cbHasSound.Name = "cbHasSound";
            this.cbHasSound.Size = new System.Drawing.Size(77, 17);
            this.cbHasSound.TabIndex = 29;
            this.cbHasSound.Text = "Hat Sound";
            this.cbHasSound.UseVisualStyleBackColor = true;
            // 
            // WindowChanger
            // 
            this.AcceptButton = this.btnAdd;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 491);
            this.Controls.Add(this.cbHasSound);
            this.Controls.Add(this.btnBackgroundMusic);
            this.Controls.Add(this.lvChangingWindowsInterval);
            this.Controls.Add(this.lvChangingWindowsFromTo);
            this.Controls.Add(this.processes);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.txtIntervalTime);
            this.Controls.Add(this.btnRefreshOpenWindowList);
            this.Controls.Add(this.comEndMinutes);
            this.Controls.Add(this.comStartMinutes);
            this.Controls.Add(this.comEndHours);
            this.Controls.Add(this.comStartHours);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblActiveTime);
            this.Controls.Add(this.txtActiveTime);
            this.Controls.Add(this.btnEntfernen);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "WindowChanger";
            this.Text = "Fensterwechsel";
            this.TopMost = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WindowChanger_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WindowChanger_DragEnter);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEntfernen;
        private System.Windows.Forms.TextBox txtActiveTime;
        private System.Windows.Forms.Label lblActiveTime;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox comStartHours;
        private System.Windows.Forms.ComboBox comEndHours;
        private System.Windows.Forms.ComboBox comStartMinutes;
        private System.Windows.Forms.ComboBox comEndMinutes;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ändernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entfernenToolStripMenuItem;
        private System.Windows.Forms.Button btnRefreshOpenWindowList;
        private System.Windows.Forms.TextBox txtIntervalTime;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoppToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListView lvChangingWindowsInterval;
        private System.Windows.Forms.ColumnHeader windowName;
        private System.Windows.Forms.ColumnHeader intervalTime;
        private System.Windows.Forms.ColumnHeader lifeTime;
        private System.Windows.Forms.ListView lvChangingWindowsFromTo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListBox processes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnBackgroundMusic;
        private System.Windows.Forms.CheckBox cbHasSound;
    }
}

