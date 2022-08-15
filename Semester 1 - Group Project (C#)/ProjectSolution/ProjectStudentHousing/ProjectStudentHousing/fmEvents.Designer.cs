namespace ProjectStudentHousing
{
    partial class fmEvents
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
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.lbEventList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScheduleEvent = new System.Windows.Forms.Button();
            this.mCalendarEvents = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnShowDetails.FlatAppearance.BorderSize = 0;
            this.btnShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDetails.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowDetails.ForeColor = System.Drawing.Color.White;
            this.btnShowDetails.Location = new System.Drawing.Point(354, 347);
            this.btnShowDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(353, 58);
            this.btnShowDetails.TabIndex = 18;
            this.btnShowDetails.Text = "Details";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click_1);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnDeleteEvent.FlatAppearance.BorderSize = 0;
            this.btnDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEvent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteEvent.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEvent.Location = new System.Drawing.Point(172, 347);
            this.btnDeleteEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(158, 58);
            this.btnDeleteEvent.TabIndex = 17;
            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = false;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click_1);
            // 
            // lbEventList
            // 
            this.lbEventList.BackColor = System.Drawing.Color.White;
            this.lbEventList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEventList.FormattingEnabled = true;
            this.lbEventList.ItemHeight = 25;
            this.lbEventList.Location = new System.Drawing.Point(354, 80);
            this.lbEventList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbEventList.Name = "lbEventList";
            this.lbEventList.Size = new System.Drawing.Size(353, 254);
            this.lbEventList.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(345, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 51);
            this.label7.TabIndex = 15;
            this.label7.Text = "Event list";
            // 
            // btnScheduleEvent
            // 
            this.btnScheduleEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnScheduleEvent.FlatAppearance.BorderSize = 0;
            this.btnScheduleEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleEvent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnScheduleEvent.ForeColor = System.Drawing.Color.White;
            this.btnScheduleEvent.Location = new System.Drawing.Point(18, 347);
            this.btnScheduleEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScheduleEvent.Name = "btnScheduleEvent";
            this.btnScheduleEvent.Size = new System.Drawing.Size(148, 58);
            this.btnScheduleEvent.TabIndex = 14;
            this.btnScheduleEvent.Text = "Add Event";
            this.btnScheduleEvent.UseVisualStyleBackColor = false;
            this.btnScheduleEvent.Click += new System.EventHandler(this.btnScheduleEvent_Click_1);
            // 
            // mCalendarEvents
            // 
            this.mCalendarEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mCalendarEvents.Location = new System.Drawing.Point(18, 80);
            this.mCalendarEvents.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.mCalendarEvents.Name = "mCalendarEvents";
            this.mCalendarEvents.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 51);
            this.label1.TabIndex = 12;
            this.label1.Text = "Upcoming events";
            // 
            // fmEvents
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.lbEventList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnScheduleEvent);
            this.Controls.Add(this.mCalendarEvents);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmEvents";
            this.Text = "fmEvents";
            this.Load += new System.EventHandler(this.fmEvents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.ListBox lbEventList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScheduleEvent;
        private System.Windows.Forms.MonthCalendar mCalendarEvents;
        private System.Windows.Forms.Label label1;
    }
}