using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Ball_WindowChanger_WF
{
    public enum Timetype 
    { 
        Minutes, 
        FromTo 
    };

    // Repräsentiert ein zu wechselndes Fenster
    [Serializable]
    public class Window
    {
        // Membervariablen
        int processId;
        string title;
        Timetype timeType;
        int intervalTime;
        int activeTime;
        DateTime startTime;
        DateTime endTime;
        bool hasSound = false;
        public int count = 0;
        int temp = 0;

        public bool isInFront = false;

        bool flag = false;

        // Delegates und Events
        public delegate void StartDelegate(object sender);
        public event StartDelegate OnStart;

        public delegate void EndDelegate(object sender);
        public event EndDelegate OnEnd;

        // Get/Set - Methoden
        /// <summary>
        /// Liefert oder setzt den Titel des Fensters
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt den Zeittyp
        /// </summary>
        public Timetype TimeType
        {
            get
            {
                return this.timeType;
            }
            set
            {
                this.timeType = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt die Intervalzeit
        /// </summary>
        public int IntervalTime
        {
            get
            {
                return this.intervalTime;
            }
            set
            {
                this.intervalTime = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt die aktive Zeit eines Fensters
        /// </summary>
        public int ActiveTime
        {
            get
            {
                return this.activeTime;
            }
            set
            {
                this.activeTime = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt die Startzeit, an der das Fenster in den Vordergrund geholt werden soll.
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        /// <summary>
        /// Liefert oder setzt die Endzeit, an der das Fenster nicht mehr im Vordergrund sein soll.
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        /// <summary>
        /// Liefert den zugehörigen Prozess zum Fenster
        /// </summary>
        public Process GetProcess
        {
            get
            {
                return Process.GetProcessById(this.processId);
            }
        }

        public bool HasSound
        {
            get
            {
                return this.hasSound;
            }
            set
            {
                this.hasSound = value;
            }
        }

        // Konstruktoren

        public Window()
        {
        }

        /// <summary>
        /// Erstellt ein neues Fenster.
        /// </summary>
        /// <param name="p">Zugehöriger Prozess</param>
        public Window(Process p)
        {
            this.processId = p.Id;
            this.Title = p.MainWindowTitle;
        }

        /// <summary>
        /// Erstellt ein neues Fenster.
        /// </summary>
        /// <param name="p">Zugehöriger Prozess</param>
        /// <param name="timeType">Art der Zeitgebung (Interval, Von-bis)</param>
        /// <param name="intervalTime">Interval, nach dem das Fenster in den Vordergrund geholt werden soll.</param>
        /// <param name="activeTime">Zeit des Fensters im Vordergrund</param>
        public Window(Process p, Timetype timeType, int intervalTime, int activeTime, bool hasSound)
        {
            this.processId = p.Id;
            this.Title = p.MainWindowTitle;
            this.TimeType = timeType;
            this.IntervalTime = intervalTime;
            this.ActiveTime = activeTime;
            this.HasSound = hasSound;
        }

        /// <summary>
        /// Erstellt ein neues Fenster.
        /// </summary>
        /// <param name="p">Zugehöriger Prozess</param>
        /// <param name="timeType">Art der Zeitgebung (Interval, Von-bis)</param>
        /// <param name="startTimeHours">Stunden der Startzeit</param>
        /// <param name="startTimeMinutes">Minuten der Startzeit</param>
        /// <param name="endTimeHours">Stunden der Endzeit</param>
        /// <param name="endTimeMinutes">Minuten der Endzeit</param>
        public Window(Process p, Timetype timeType, int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes, bool hasSound)
        {
            this.processId = p.Id;
            this.Title = p.MainWindowTitle;
            this.TimeType = timeType;
            this.StartTime = this.NewTime(startTimeHours, startTimeMinutes);
            this.EndTime = this.NewTime(endTimeHours, endTimeMinutes);
            this.HasSound = hasSound;
        }

        // Methoden
        /// <summary>
        /// Vergleicht ein Fenster mit einem Fenster.
        /// </summary>
        /// <param name="obj">Vergleichsfenster</param>
        /// <returns>True, falls die gleichen Prozesse mit gleichen Zeitwerten vorliegen.</returns>
        public override bool Equals(object obj)
        {
            Window other = obj as Window;

            if (this.TimeType == Timetype.FromTo)
            {
                if (this.GetProcess.Equals(other.GetProcess) && (this.StartTime == other.startTime) && (this.EndTime == other.EndTime))
                {
                    return true;
                }
            }

            if (this.TimeType == Timetype.Minutes)
            {
                if (this.GetProcess.Equals(other.GetProcess) && (this.IntervalTime == other.IntervalTime) && (this.ActiveTime == other.ActiveTime))
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Überprüft das Fenster auf Zeittyp Interval.
        /// </summary>
        /// <returns>True, falls es sich um ein Fenster mit Interval-Zeittyp handelt.</returns>
        public bool IsIntervalWindow()
        {
            if(this.timeType.Equals(Timetype.Minutes))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Erstellt ein Zeitobjekt basierend auf Stunden und Minuten
        /// </summary>
        /// <param name="hours">Stunde der Zeit</param>
        /// <param name="minutes">Minute der Zeit</param>
        /// <returns>Neues Zeitobjekt</returns>
        public DateTime NewTime(int hours, int minutes)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, DateTime.Now.Second, DateTimeKind.Local);
        }

        public void Update()
        {
            if (this.TimeType == Timetype.FromTo)
            {
                if (!this.flag && this.StartTime.Minute == DateTime.Now.Minute && this.StartTime.Hour == DateTime.Now.Hour)
                {
                    if (this.OnStart != null)
                    {
                        this.flag = true;
                        this.OnStart(this);
                    }
                }

                if (this.flag && this.EndTime.Minute == DateTime.Now.Minute && this.EndTime.Hour == DateTime.Now.Hour)
                {
                    if (this.OnEnd != null)
                    {
                        this.flag = false;
                        this.OnEnd(this);
                    }
                }
            }
            if (this.TimeType == Timetype.Minutes)
            {
                this.count++;

                if (!this.flag && this.count >= this.IntervalTime)
                {
                    this.flag = true;

                    this.temp = this.count;

                    if (OnStart != null && !this.isInFront)
                    {
                        OnStart(this);
                    }
                }

                if (this.flag && this.count >= this.temp + this.ActiveTime)
                {
                    this.flag = false;

                    this.count = 0;

                    if (OnEnd != null && this.isInFront)
                    {
                        OnEnd(this);
                    }
                }
            }
        }
    }
}
