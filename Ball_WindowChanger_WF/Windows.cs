using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Ball_WindowChanger_WF
{
    [Serializable]
    public class Windows
    {
        List<Window> selectedWindowsList_FromTo = new List<Window>();
        List<Window> selectedWindowsList_Interval = new List<Window>();
        List<Window> openWindowsList = new List<Window>();
        Window backgroundMusic = null;

        [XmlIgnore]
        public List<Window> OpenWindows
        {
            get
            {
                return this.openWindowsList;
            }
        }

        public List<Window> SelectedWindowsInterval
        {
            get
            {
                return this.selectedWindowsList_Interval;
            }
            set
            {
                this.selectedWindowsList_Interval = value;
            }
        }

        public List<Window> SelectedWindowsFromTo
        {
            get
            {
                return this.selectedWindowsList_FromTo;
            }
            set
            {
                this.selectedWindowsList_FromTo = value;
            }
        }

        public Window BackgroundMusic
        {
            get
            {
                return this.backgroundMusic;
            }
            set
            {
                this.backgroundMusic = value;
            }
        }
  
        public void Add(Window sw)
        {
            if (sw.IsIntervalWindow())
            {
                this.selectedWindowsList_Interval.Add(sw);
            }
            else
            {
                this.selectedWindowsList_FromTo.Add(sw);
            }
        }

        /// <summary>
        /// Fügt alle sichtbar geöffneten Fenster der Liste hinzu.
        /// </summary>
        public void RefreshOpenWindows()
        {
            this.openWindowsList.Clear();

            foreach (Process p in Process.GetProcesses())
            {
                string title = p.MainWindowTitle;

                if (!string.IsNullOrEmpty(title))
                {
                    openWindowsList.Add(new Window(p));
                }
            }
        }
    }
}
