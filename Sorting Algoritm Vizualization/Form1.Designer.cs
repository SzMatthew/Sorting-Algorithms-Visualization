namespace Sorting_Algoritm_Vizualization
{
    partial class Sorting_Form
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.algorithm_name = new System.Windows.Forms.Label();
            this.lb_complete = new System.Windows.Forms.Label();
            this.lb_number_selector = new System.Windows.Forms.Label();
            this.lb_algorithm_selector = new System.Windows.Forms.Label();
            this.p_canvas = new System.Windows.Forms.PictureBox();
            this.value_elapsed_time = new System.Windows.Forms.Label();
            this.lb_elapsed_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // algorithm_name
            // 
            this.algorithm_name.AutoSize = true;
            this.algorithm_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.algorithm_name.Location = new System.Drawing.Point(395, 523);
            this.algorithm_name.Name = "algorithm_name";
            this.algorithm_name.Size = new System.Drawing.Size(238, 31);
            this.algorithm_name.TabIndex = 1;
            this.algorithm_name.Text = "Sorting Algorithm";
            this.algorithm_name.Visible = false;
            // 
            // lb_complete
            // 
            this.lb_complete.AutoSize = true;
            this.lb_complete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_complete.Location = new System.Drawing.Point(1027, 13);
            this.lb_complete.Name = "lb_complete";
            this.lb_complete.Size = new System.Drawing.Size(205, 26);
            this.lb_complete.TabIndex = 2;
            this.lb_complete.Text = "Sort is completed!";
            this.lb_complete.Visible = false;
            // 
            // lb_number_selector
            // 
            this.lb_number_selector.AutoSize = true;
            this.lb_number_selector.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_number_selector.Location = new System.Drawing.Point(1027, 43);
            this.lb_number_selector.Name = "lb_number_selector";
            this.lb_number_selector.Size = new System.Drawing.Size(0, 22);
            this.lb_number_selector.TabIndex = 3;
            // 
            // lb_algorithm_selector
            // 
            this.lb_algorithm_selector.AutoSize = true;
            this.lb_algorithm_selector.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_algorithm_selector.Location = new System.Drawing.Point(1027, 43);
            this.lb_algorithm_selector.Name = "lb_algorithm_selector";
            this.lb_algorithm_selector.Size = new System.Drawing.Size(71, 22);
            this.lb_algorithm_selector.TabIndex = 4;
            this.lb_algorithm_selector.Text = "chocies";
            // 
            // p_canvas
            // 
            this.p_canvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.p_canvas.Location = new System.Drawing.Point(13, 13);
            this.p_canvas.Name = "p_canvas";
            this.p_canvas.Size = new System.Drawing.Size(1014, 500);
            this.p_canvas.TabIndex = 5;
            this.p_canvas.TabStop = false;
            this.p_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_Event);
            // 
            // value_elapsed_time
            // 
            this.value_elapsed_time.AutoSize = true;
            this.value_elapsed_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.value_elapsed_time.Location = new System.Drawing.Point(1027, 523);
            this.value_elapsed_time.Name = "value_elapsed_time";
            this.value_elapsed_time.Size = new System.Drawing.Size(84, 26);
            this.value_elapsed_time.TabIndex = 6;
            this.value_elapsed_time.Text = "00:000";
            this.value_elapsed_time.Visible = false;
            // 
            // lb_elapsed_time
            // 
            this.lb_elapsed_time.AutoSize = true;
            this.lb_elapsed_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_elapsed_time.Location = new System.Drawing.Point(863, 523);
            this.lb_elapsed_time.Name = "lb_elapsed_time";
            this.lb_elapsed_time.Size = new System.Drawing.Size(164, 26);
            this.lb_elapsed_time.TabIndex = 7;
            this.lb_elapsed_time.Text = "Elapsed Time:";
            this.lb_elapsed_time.Visible = false;
            // 
            // Sorting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 563);
            this.Controls.Add(this.lb_elapsed_time);
            this.Controls.Add(this.value_elapsed_time);
            this.Controls.Add(this.p_canvas);
            this.Controls.Add(this.lb_algorithm_selector);
            this.Controls.Add(this.lb_number_selector);
            this.Controls.Add(this.lb_complete);
            this.Controls.Add(this.algorithm_name);
            this.Name = "Sorting_Form";
            this.Text = "Sorting Algorithm Visualization";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.p_canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Label algorithm_name;
        public System.Windows.Forms.Label lb_complete;
        public System.Windows.Forms.Label lb_number_selector;
        public System.Windows.Forms.Label lb_algorithm_selector;
        public System.Windows.Forms.PictureBox p_canvas;
        public System.Windows.Forms.Label value_elapsed_time;
        private System.Windows.Forms.Label lb_elapsed_time;
    }
}

