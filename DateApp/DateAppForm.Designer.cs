namespace DateApp
{
    partial class DateAppForm
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
            this.buttonQueryFemales = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.firstnameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lastnameBox = new System.Windows.Forms.TextBox();
            this.birthdayBox = new System.Windows.Forms.TextBox();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.buttonQueryMales = new System.Windows.Forms.Button();
            this.nameIDBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewPerson = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.postNumberBox = new System.Windows.Forms.TextBox();
            this.profBox = new System.Windows.Forms.ComboBox();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.buttonImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.seekingBox = new System.Windows.Forms.ComboBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonQueryFemales
            // 
            this.buttonQueryFemales.Location = new System.Drawing.Point(12, 184);
            this.buttonQueryFemales.Name = "buttonQueryFemales";
            this.buttonQueryFemales.Size = new System.Drawing.Size(75, 23);
            this.buttonQueryFemales.TabIndex = 0;
            this.buttonQueryFemales.Text = "Females";
            this.buttonQueryFemales.UseVisualStyleBackColor = true;
            this.buttonQueryFemales.Click += new System.EventHandler(this.buttonQueryFemales_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Firstname";
            // 
            // firstnameBox
            // 
            this.firstnameBox.Location = new System.Drawing.Point(12, 45);
            this.firstnameBox.Name = "firstnameBox";
            this.firstnameBox.Size = new System.Drawing.Size(100, 20);
            this.firstnameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lastname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "birthday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(753, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "profession";
            // 
            // lastnameBox
            // 
            this.lastnameBox.Location = new System.Drawing.Point(118, 45);
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.Size = new System.Drawing.Size(100, 20);
            this.lastnameBox.TabIndex = 2;
            // 
            // birthdayBox
            // 
            this.birthdayBox.Location = new System.Drawing.Point(437, 45);
            this.birthdayBox.Name = "birthdayBox";
            this.birthdayBox.Size = new System.Drawing.Size(100, 20);
            this.birthdayBox.TabIndex = 5;
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Location = new System.Drawing.Point(12, 72);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(75, 23);
            this.buttonNewUser.TabIndex = 17;
            this.buttonNewUser.Text = "New User";
            this.buttonNewUser.UseVisualStyleBackColor = true;
            this.buttonNewUser.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonQueryMales
            // 
            this.buttonQueryMales.Location = new System.Drawing.Point(94, 184);
            this.buttonQueryMales.Name = "buttonQueryMales";
            this.buttonQueryMales.Size = new System.Drawing.Size(75, 23);
            this.buttonQueryMales.TabIndex = 18;
            this.buttonQueryMales.Text = "Males";
            this.buttonQueryMales.UseVisualStyleBackColor = true;
            this.buttonQueryMales.Click += new System.EventHandler(this.buttonQueryMales_Click);
            // 
            // nameIDBox
            // 
            this.nameIDBox.Location = new System.Drawing.Point(15, 153);
            this.nameIDBox.Name = "nameIDBox";
            this.nameIDBox.Size = new System.Drawing.Size(100, 20);
            this.nameIDBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Name Or ID";
            // 
            // listViewPerson
            // 
            this.listViewPerson.Location = new System.Drawing.Point(12, 213);
            this.listViewPerson.Name = "listViewPerson";
            this.listViewPerson.Size = new System.Drawing.Size(776, 225);
            this.listViewPerson.TabIndex = 21;
            this.listViewPerson.UseCompatibleStateImageBehavior = false;
            this.listViewPerson.View = System.Windows.Forms.View.Details;
            this.listViewPerson.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.itemShowPicture);
            this.listViewPerson.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewPerson_ItemSelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Mail";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(647, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Post Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(859, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Seeking";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(224, 45);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(100, 20);
            this.mailBox.TabIndex = 3;
            // 
            // postNumberBox
            // 
            this.postNumberBox.Location = new System.Drawing.Point(650, 45);
            this.postNumberBox.Name = "postNumberBox";
            this.postNumberBox.Size = new System.Drawing.Size(100, 20);
            this.postNumberBox.TabIndex = 7;
            // 
            // profBox
            // 
            this.profBox.FormattingEnabled = true;
            this.profBox.Location = new System.Drawing.Point(543, 45);
            this.profBox.Name = "profBox";
            this.profBox.Size = new System.Drawing.Size(100, 21);
            this.profBox.TabIndex = 6;
            // 
            // statusBox
            // 
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Location = new System.Drawing.Point(757, 44);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(99, 21);
            this.statusBox.TabIndex = 8;
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(887, 81);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(75, 23);
            this.buttonImage.TabIndex = 30;
            this.buttonImage.Text = "Image";
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(794, 213);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(222, 225);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePicture.TabIndex = 31;
            this.profilePicture.TabStop = false;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(121, 151);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 32;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // genderBox
            // 
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "M",
            "F"});
            this.genderBox.Location = new System.Drawing.Point(330, 45);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(100, 21);
            this.genderBox.TabIndex = 4;
            // 
            // seekingBox
            // 
            this.seekingBox.FormattingEnabled = true;
            this.seekingBox.Items.AddRange(new object[] {
            "M",
            "F",
            "B"});
            this.seekingBox.Location = new System.Drawing.Point(862, 44);
            this.seekingBox.Name = "seekingBox";
            this.seekingBox.Size = new System.Drawing.Size(100, 21);
            this.seekingBox.TabIndex = 9;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(794, 184);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(192, 23);
            this.buttonUpdate.TabIndex = 33;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Enabled = false;
            this.buttonDeleteUser.Location = new System.Drawing.Point(794, 155);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(192, 23);
            this.buttonDeleteUser.TabIndex = 34;
            this.buttonDeleteUser.Text = "Delete User";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // DateAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 450);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.seekingBox);
            this.Controls.Add(this.genderBox);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.profBox);
            this.Controls.Add(this.postNumberBox);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listViewPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameIDBox);
            this.Controls.Add(this.buttonQueryMales);
            this.Controls.Add(this.buttonNewUser);
            this.Controls.Add(this.birthdayBox);
            this.Controls.Add(this.lastnameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstnameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQueryFemales);
            this.Name = "DateAppForm";
            this.Text = "Date App V0.0.3";
            this.Load += new System.EventHandler(this.DateAppFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQueryFemales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstnameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lastnameBox;
        private System.Windows.Forms.TextBox birthdayBox;
        private System.Windows.Forms.Button buttonNewUser;
        private System.Windows.Forms.Button buttonQueryMales;
        private System.Windows.Forms.TextBox nameIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox postNumberBox;
        private System.Windows.Forms.ComboBox profBox;
        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.ComboBox seekingBox;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDeleteUser;
    }
}

