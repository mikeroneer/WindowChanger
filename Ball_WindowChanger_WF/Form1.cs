using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;

namespace Ball_WindowChanger_WF
{
    public partial class WindowChanger : Form
    {
        Windows windows = new Windows();
        bool isEditing = false;
         

        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);

        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_HIDE = 6;

        // Konstruktor
        public WindowChanger()
        {
            InitializeComponent();

            ClearInput();

            timer1.Stop();

            // Dropdowns mit Stunden füllen
            for (int i = 0; i < 24; i++)
            {
                comStartHours.Items.Add(i.ToString("D2"));
                comEndHours.Items.Add(i.ToString("D2"));
            }

            // Dropdowns mit Minuten füllen
            for (int i = 0; i <= 60; i++)
            {
                comStartMinutes.Items.Add(i.ToString("D2"));
                comEndMinutes.Items.Add(i.ToString("D2"));
            }

            windows.RefreshOpenWindows();

            RefreshGetOpenWindowsList();

            lvChangingWindowsInterval.View = View.Details;
            lvChangingWindowsFromTo.View = View.Details;

            lblStatusStrip.Text = "";
        }

        // Events der Buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void btnRefreshOpenWindowList_Click(object sender, EventArgs e)
        {
            // Geöffnete, sichtbare Fenster aktualisieren
            this.RefreshGetOpenWindowsList();

            // Visuelle Listen aktualisieren
            this.RefreshListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnEntfernen_Click(object sender, EventArgs e)
        {
            Remove();
        }

        // Events der Menüleiste
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.OpenBinaryFile(this.openFileDialog.FileName);
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SaveBinaryFile(this.saveFileDialog.FileName);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void stoppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }
        
        private void hinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void entfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void endeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void überToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();

            aboutbox.ShowDialog();
        }

        // Andere Events
        private void WindowChanger_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            this.OpenBinaryFile(files[0]);
        }

        private void WindowChanger_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files[0].EndsWith(".fw"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void processes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void lViewChangingWindowsInterval(object sender, EventArgs e)
        {
            ListViewItem itemInterval = lvChangingWindowsInterval.FocusedItem;

            ClearInput();

            if (itemInterval != null)
            {
                txtIntervalTime.Text = itemInterval.SubItems[1].Text;
                txtActiveTime.Text = itemInterval.SubItems[2].Text;
            }

            //ListViewItem lvi = this.lvChangingWindowsInterval.FocusedItem;

            //if (lvi != null)
            //{
            //    lvi.Focused = false;
            //}
        }

        private void lvChangingWindowsFromTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem itemFromTo = lvChangingWindowsFromTo.FocusedItem;

            ClearInput();

            if (lvChangingWindowsFromTo.SelectedIndices.Count > 0)
            {
                string[] parts = itemFromTo.SubItems[1].Text.Split(new char[] { ':' });

                if (parts[0] != null)
                {
                    this.comStartHours.Text = parts[0];
                }

                if (parts[1] != null)
                {
                    this.comStartMinutes.Text = parts[1];
                }

                parts = itemFromTo.SubItems[2].Text.Split(new char[] { ':' });

                if (parts[0] != null)
                {
                    this.comEndHours.Text = parts[0];
                }

                if (parts[1] != null)
                {
                    this.comEndMinutes.Text = parts[1];
                }

                this.cbHasSound.Checked = windows.SelectedWindowsFromTo[itemFromTo.Index].HasSound;
            }

            //ListViewItem lvi = this.lvChangingWindowsFromTo.FocusedItem;

            //if (lvi != null)
            //{
            //    lvi.Focused = false;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");

            foreach (Window w in this.windows.SelectedWindowsInterval)
            {
                w.Update();
            }

            foreach (Window w in this.windows.SelectedWindowsFromTo)
            {
                w.Update();
            }
        }

        void WindowChanger_OnEnd(object sender)
        {
            Window w = sender as Window;

            if (w.HasSound && w.TimeType == Timetype.FromTo)
            {
                SendKeys.Send(" ");

                if (windows.BackgroundMusic != null)
                {
                    if (IsIconic(windows.BackgroundMusic.GetProcess.MainWindowHandle))
                    {
                        ShowWindowAsync(windows.BackgroundMusic.GetProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                    }

                    SetForegroundWindow(windows.BackgroundMusic.GetProcess.MainWindowHandle);
                    
                    SendKeys.Send(" ");

                    Thread.Sleep(10);

                    ShowWindowAsync(windows.BackgroundMusic.GetProcess.MainWindowHandle, SW_HIDE);
                }
            }

            ShowWindowAsync(w.GetProcess.MainWindowHandle, SW_HIDE);

            w.isInFront = false;
        }

        void WindowChanger_OnStart(object sender)
        {
            Window w = sender as Window;
            bool allowed = true;

            foreach (Window win in this.windows.SelectedWindowsFromTo)
            {
                if (win.isInFront)
                {
                    allowed = false;
                } 
            }

            if (allowed)
            {
                //ShowWindowAsync(w.GetProcess.MainWindowHandle, SW_SHOWMAXIMIZED);

                if (IsIconic(w.GetProcess.MainWindowHandle))
                {
                    ShowWindowAsync(w.GetProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                }

                SetForegroundWindow(w.GetProcess.MainWindowHandle);

                if (w.HasSound && w.TimeType == Timetype.FromTo)
                {
                    SendKeys.Send(" ");

                    if (windows.BackgroundMusic != null)
                    {
                        if (IsIconic(windows.BackgroundMusic.GetProcess.MainWindowHandle))
                        {
                            ShowWindowAsync(windows.BackgroundMusic.GetProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                        }

                        SetForegroundWindow(windows.BackgroundMusic.GetProcess.MainWindowHandle);

                        //ShowWindowAsync(windows.BackgroundMusic.GetProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                        //SetForegroundWindow(windows.BackgroundMusic.GetProcess.MainWindowHandle);

                        Console.WriteLine("Leertaste gedrückt");

                        SendKeys.Send(" ");

                        Thread.Sleep(10);

                        ShowWindowAsync(windows.BackgroundMusic.GetProcess.MainWindowHandle, SW_HIDE);
                    }
                }

                w.isInFront = true;
            }
        }
        
        // Methoden
        /// <summary>
        /// Fügt ein Fenster der jeweiligen Liste hinzu.
        /// </summary>
        private void Add()
        {
            // Falls ein Element aus einer Liste gewählt wurde
            if(this.lvChangingWindowsInterval.SelectedIndices.Count > 0 || this.lvChangingWindowsFromTo.SelectedIndices.Count > 0)
            {
                // handelt es sich um einen Editiervorgang
                isEditing = true;
            }

            // Falls kein offenes Fenster gewählt wurde und nicht editiert weird
            if (this.processes.SelectedItem == null && this.isEditing == false)
            {
                lblStatusStrip.Text = "Bitte ein Programm zum Hinzufügen auswählen!";
                return;
            }

            // Überprüfung, ob ein zeitlicher Wert eingegeben wurde
            if (this.comStartHours.Text.Equals("") || this.comStartMinutes.Text.Equals("") || this.comEndHours.Text.Equals("") || this.comEndMinutes.Text.Equals(""))
            {
                if (this.txtActiveTime.Text.Equals("") || this.txtIntervalTime.Text.Equals(""))
                {
                    lblStatusStrip.Text = "Bitte einen zeitlichen Wert festlegen!";
                    return;
                }
            }

            // Falls die Eingabe für einen Interval-Zeittyp nicht leer ist
            if (!(this.txtActiveTime.Text.Equals("") || this.txtIntervalTime.Text.Equals("")))
            {
                // Zeit in Minuten wurde gewählt
                int intervalTime;
                int activeTime;
                
                // Überprüfung auf richtiges Zeichenformat
                if (!(int.TryParse(txtActiveTime.Text, out activeTime)) || !(int.TryParse(txtIntervalTime.Text, out intervalTime)))
                {
                    this.lblStatusStrip.Text = "Richtiges Zeichenformat beachten (ganze Zahl)";
                    return;
                }

                // Falls editiert wird
                if (this.isEditing)
                {
                    // Informationen aktualisieren
                    this.windows.SelectedWindowsInterval[this.lvChangingWindowsInterval.FocusedItem.Index].IntervalTime = intervalTime;
                    this.windows.SelectedWindowsInterval[this.lvChangingWindowsInterval.FocusedItem.Index].ActiveTime = activeTime;

                    // Statusmeldung
                    this.lblStatusStrip.Text = "Fenstereinstellungen erfolgreich geändert!";

                    this.isEditing = false;
                }
                else
                {
                    // Kein Editiervorgang -> Neues Fenster der Liste der wechselnden Fenster hinzufügen
                    if (this.CreateIntervalWindow(this.windows.OpenWindows[this.processes.SelectedIndex].GetProcess, Timetype.Minutes, intervalTime, activeTime, cbHasSound.Checked))
                    {
                        // Statusmeldung
                        this.lblStatusStrip.Text = "Fenster erfolgreich hinzugefügt!"; 
                    }
                }
            }

            // Falls die Eingabe für einen Von-bis - Zeittyp nicht leer ist
            if (!(this.comStartHours.Text.Equals("") || this.comStartMinutes.Text.Equals("") || this.comEndHours.Text.Equals("") || this.comEndMinutes.Text.Equals("")))
            {
                // Ein Zeitraum zwischen der Start- und der Endzeit wurde gewählt
                int startTimeHours;
                int startTimeMinutes;
                int endTimeHours;
                int endTimeMinutes;

                // Überprüfung auf richtiges Zeichenformat
                if(!(int.TryParse(comStartHours.Text, out startTimeHours)) || !(int.TryParse(comStartMinutes.Text, out startTimeMinutes)) ||
                    !(int.TryParse(comEndHours.Text, out endTimeHours)) || !(int.TryParse(comEndMinutes.Text, out endTimeMinutes)))
                    {
                        this.lblStatusStrip.Text = "Richtiges Zeichenformat beachten (ganze Zahl)";
                        return;
                    }

                // Überprüfung auf gültige Uhrzeit
                if (startTimeHours > 23 || endTimeHours > 23 || startTimeMinutes > 60 || endTimeMinutes > 60)
                {
                    this.lblStatusStrip.Text = "Bitte gültige Uhrzeit eingeben!";
                    return;
                }

                // Falls editiert wird
                if (isEditing)
                {
                    Window win = this.windows.SelectedWindowsFromTo[lvChangingWindowsFromTo.FocusedItem.Index];

                    win.StartTime = win.NewTime(startTimeHours, startTimeMinutes);
                    win.EndTime = win.NewTime(endTimeHours, endTimeMinutes);
                    win.HasSound = this.cbHasSound.Checked;

                    isEditing = false;
                }
                else
                {
                    this.CreateFromToWindow(this.windows.OpenWindows[this.processes.SelectedIndex].GetProcess, Timetype.FromTo, startTimeHours, startTimeMinutes, endTimeHours, endTimeMinutes, cbHasSound.Checked);

                    // Statusmeldung
                    this.lblStatusStrip.Text = "Fenster erfolgreich hinzugefügt!";
                }
            }

            // Visuelle Liste aktualisieren
            this.RefreshListView();

            // Inhalte aus Feldern löschen
            this.ClearInput();
        }

        /// <summary>
        /// Erstellt ein neues Fenster mit Zeittyp Interval
        /// </summary>
        /// <param name="p">Zugehöriger Prozess</param>
        /// <param name="timeType">Art der Zeitgebung (Interval, Von-bis)</param>
        /// <param name="intervalTime">Interval, nach dem das Fenster in den Vordergrund geholt werden soll.</param>
        /// <param name="activeTime">Zeit des Fensters im Vordergrund</param>
        /// <returns>True, falls das selbe Fenster mit gleichen Einstellugen nicht schon hinzugefügt wurde.</returns>
        private bool CreateIntervalWindow(Process p, Timetype timetype, int intervalTime, int activeTime, bool hasSound)
        {
            Window newWindow = new Window(p, timetype, intervalTime, activeTime, hasSound);

            // Prüfen, ob das selbe Fenster mit den selben Zeiten schon gewählt wurde
            foreach (Window w in this.windows.SelectedWindowsInterval)
            {
                if (newWindow.Equals(w))
                {
                    // Statusmeldung
                    this.lblStatusStrip.Text = "Das selbe Fenster wurde mit den gleichen Zeiten schon hinzugefügt!";
                    return false;
                }
            }

            // Neues Fenster hinzufügen
            this.windows.Add(newWindow);

            this.windows.SelectedWindowsInterval.Last().OnStart += new Window.StartDelegate(WindowChanger_OnStart);
            this.windows.SelectedWindowsInterval.Last().OnEnd += new Window.EndDelegate(WindowChanger_OnEnd);

            return true;
        }

        /// <summary>
        /// Erstellt ein neues Fenster mit Zeittyp Von-bis
        /// </summary>
        /// <param name="p">Zugehöriger Prozess</param>
        /// <param name="timeType">Art der Zeitgebung (Interval, Von-bis)</param>
        /// <param name="startTimeHours">Stunden der Startzeit</param>
        /// <param name="startTimeMinutes">Minuten der Startzeit</param>
        /// <param name="endTimeHours">Stunden der Endzeit</param>
        /// <param name="endTimeMinutes">Minuten der Endzeit</param>
        /// <returns>True, falls das selbe Fenster mit gleichen Einstellugen nicht schon hinzugefügt wurde.</returns>
        private bool CreateFromToWindow(Process p, Timetype timetype, int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes, bool hasSound)
        {
            Window newWindow = new Window(p, timetype, startTimeHours, startTimeMinutes, endTimeHours, endTimeMinutes, hasSound);

            // Prüfen, ob das selbe Fenster mit den selben Zeiten schon gewählt wurde
            foreach (Window w in this.windows.SelectedWindowsFromTo)
            {
                if (newWindow.Equals(w))
                {
                    // Statusmeldung
                    this.lblStatusStrip.Text = "Das selbe Fenster wurde mit den gleichen Zeiten schon hinzugefügt!";
                    return false;
                }
            }

            // Neues Fenster hinzufügen
            this.windows.Add(newWindow);

            // Events einhängen
            this.windows.SelectedWindowsFromTo.Last().OnStart += new Window.StartDelegate(WindowChanger_OnStart);
            this.windows.SelectedWindowsFromTo.Last().OnEnd += new Window.EndDelegate(WindowChanger_OnEnd);

            return true;
        }

        private void Remove()
        {
            if (this.lvChangingWindowsInterval.FocusedItem == null && this.lvChangingWindowsFromTo.FocusedItem == null)
            {
                this.lblStatusStrip.Text = "Bitte ein Fenster zum Entfernen auswählen!";
            }

            if (this.lvChangingWindowsInterval.FocusedItem != null)
            {                
                ListViewItem item = this.lvChangingWindowsInterval.FocusedItem;

                this.windows.SelectedWindowsInterval.RemoveAt(item.Index);
                this.lvChangingWindowsInterval.Items.Remove(item);

                this.lblStatusStrip.Text = "Fenster wurde erfolgreich entfernt!";

                this.lvChangingWindowsInterval.FocusedItem = null;

                item.Focused = false;
            }

            if (this.lvChangingWindowsFromTo.FocusedItem != null)
            {
                ListViewItem item = this.lvChangingWindowsFromTo.FocusedItem;

                this.windows.SelectedWindowsFromTo.RemoveAt(item.Index);
                this.lvChangingWindowsFromTo.Items.Remove(item);
                
                this.lblStatusStrip.Text = "Fenster wurde erfolgreich entfernt!";

                item.Focused = false;
            }

            ClearInput();  
        }

        private void RefreshListView()
        {
            lvChangingWindowsInterval.Items.Clear();
            lvChangingWindowsFromTo.Items.Clear();

            ListViewItem lvi;

            foreach (Window w in windows.SelectedWindowsInterval)
            {
                lvi = new ListViewItem(w.Title);

                lvChangingWindowsInterval.Items.Add(lvi);
                lvi.SubItems.AddRange(new string[] { w.IntervalTime.ToString(), w.ActiveTime.ToString() });
            }

            foreach (Window w in windows.SelectedWindowsFromTo)
            {
                lvi = new ListViewItem(w.Title);

                lvChangingWindowsFromTo.Items.Add(lvi);
                lvi.SubItems.AddRange(new string[] { w.StartTime.Hour.ToString("D2") + ":" + w.StartTime.Minute.ToString("D2"), w.EndTime.Hour.ToString("D2") + ":" + w.EndTime.Minute.ToString("D2") });
            }

            if (this.lvChangingWindowsInterval.FocusedItem != null)
            {
                this.lvChangingWindowsInterval.FocusedItem.Focused = false;
            }

            if (this.lvChangingWindowsFromTo.FocusedItem != null)
            {
                this.lvChangingWindowsFromTo.FocusedItem.Focused = false;
            }

            if (this.processes.SelectedItem != null)
            {
                this.processes.ClearSelected();
            }

            isEditing = false;
        }

        private void ClearInput()
        {
            this.txtActiveTime.Clear();
            this.txtIntervalTime.Clear();
            this.comStartHours.Text = "";
            this.comStartMinutes.Text = "";
            this.comEndHours.Text = "";
            this.comEndMinutes.Text = "";
            this.cbHasSound.Checked = false;
        }

        private void RefreshGetOpenWindowsList()
        {
            this.windows.RefreshOpenWindows();

            this.processes.Items.Clear();

            foreach (Window w in windows.OpenWindows)
            {
                processes.Items.Add(w.Title);
            }
        }

        private void Start()
        {
            //AudioMixerHelper am;

            //am.SetVolume = 0;
            DisableInput();

            timer1.Interval = 60000;
            timer1.Start();

            ShowWindowAsync(Process.GetCurrentProcess().MainWindowHandle, SW_HIDE);

            this.lblStatusStrip.Text = "Startzeit: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }

        private void DisableInput()
        {
            btnStart.Enabled = false;
            comStartHours.Enabled = false;
            comStartMinutes.Enabled = false;
            comEndHours.Enabled = false;
            comEndMinutes.Enabled = false;
            txtActiveTime.Enabled = false;
            txtIntervalTime.Enabled = false;
            btnAdd.Enabled = false;
            btnEntfernen.Enabled = false;
            btnBackgroundMusic.Enabled = false;
            cbHasSound.Enabled = false;
        }

        private void EnableInput()
        {
            btnStart.Enabled = true;
            comStartHours.Enabled = true;
            comStartMinutes.Enabled = true;
            comEndHours.Enabled = true;
            comEndMinutes.Enabled = true;
            txtActiveTime.Enabled = true;
            txtIntervalTime.Enabled = true;
            btnAdd.Enabled = true;
            btnEntfernen.Enabled = true;
            btnBackgroundMusic.Enabled = true;
            cbHasSound.Enabled = true;
        }

        private void Stop()
        {
            timer1.Stop();

            foreach (Window w in this.windows.SelectedWindowsFromTo)
            {
                w.isInFront = false;
            }

            foreach (Window w in this.windows.SelectedWindowsInterval)
            {
                w.count = 0;
            }

            btnStart.Enabled = true;

            EnableInput();

            this.lblStatusStrip.Text = "Stopp";
        }

        private void SaveBinaryFile(string path)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(path, FileMode.Create);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Windows)); 

                xmlSerializer.Serialize(fs, this.windows);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void OpenBinaryFile(string path)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(path, FileMode.Open);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Windows));

                this.windows = xmlSerializer.Deserialize(fs) as Windows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            RefreshListView();
        }

        private void btnBackgroundMusic_Click_1(object sender, EventArgs e)
        {
            this.windows.BackgroundMusic = new Window(this.windows.OpenWindows[this.processes.SelectedIndex].GetProcess);

            this.lblStatusStrip.Text = "\"" + this.windows.BackgroundMusic.Title + "\"" + " wurde als Hintergrundmusik festgelegt!";
        } 
    }
}
