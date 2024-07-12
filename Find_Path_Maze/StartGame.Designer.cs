namespace Find_Path_Maze
{
    partial class StartGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartGame));
            this.bttStart = new System.Windows.Forms.Button();
            this.bttExit = new System.Windows.Forms.Button();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // bttStart
            // 
            this.bttStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bttStart.Location = new System.Drawing.Point(46, 132);
            this.bttStart.Name = "bttStart";
            this.bttStart.Size = new System.Drawing.Size(90, 47);
            this.bttStart.TabIndex = 0;
            this.bttStart.Text = "Start";
            this.bttStart.UseVisualStyleBackColor = true;
            this.bttStart.Click += new System.EventHandler(this.bttStart_Click);
            // 
            // bttExit
            // 
            this.bttExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bttExit.Location = new System.Drawing.Point(350, 132);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(90, 47);
            this.bttExit.TabIndex = 1;
            this.bttExit.Text = "Exit";
            this.bttExit.UseVisualStyleBackColor = true;
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(46, 64);
            this.txtCharacterName.Multiline = true;
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(393, 49);
            this.txtCharacterName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtCharacterName, "Nhập Tên Nhân Vật");
            this.txtCharacterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCharacterName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập Tên Nhân Vật:";
            // 
            // StartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Find_Path_Maze.Properties.Resources.background_start_game;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(485, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCharacterName);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.bttStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartGame_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttStart;
        private System.Windows.Forms.Button bttExit;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
    }
}