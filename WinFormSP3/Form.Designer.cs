namespace WinFormSP3
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startBut = new Button();
            workers1Label = new Label();
            workers2Label = new Label();
            label1 = new Label();
            label2 = new Label();
            arrivedVehiclesView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            parkingVehiclesLabel = new Label();
            label4 = new Label();
            label5 = new Label();
            pauseButton = new Button();
            parkingVehiclesView = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            takenVehiclesView = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            controlledVehiclesView = new ListView();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            paymentQueueView = new ListView();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            payingView = new ListView();
            columnHeader21 = new ColumnHeader();
            columnHeader22 = new ColumnHeader();
            columnHeader23 = new ColumnHeader();
            columnHeader24 = new ColumnHeader();
            payingVehiclesLabel = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label21 = new Label();
            strongerCurrentOfVehiclesCheck = new CheckBox();
            strongerCurrentOfVehiclesLabel = new Label();
            groupBox5 = new GroupBox();
            salaryTotallabel = new Label();
            salaryWorker2CarVanlabel = new Label();
            label8 = new Label();
            salaryWorker2Alllabel = new Label();
            salaryWorker1label = new Label();
            workers2CarVanBox = new TextBox();
            workers2CarVanLabel = new Label();
            advancedSimulationCheck = new CheckBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            globalStatView = new ListView();
            columnHeader36 = new ColumnHeader();
            columnHeader37 = new ColumnHeader();
            columnHeader33 = new ColumnHeader();
            columnHeader38 = new ColumnHeader();
            columnHeader39 = new ColumnHeader();
            columnHeader40 = new ColumnHeader();
            groupBox3 = new GroupBox();
            localStatView = new ListView();
            columnHeader31 = new ColumnHeader();
            columnHeader32 = new ColumnHeader();
            Unit = new ColumnHeader();
            statusLabel = new Label();
            workers2AllBox = new TextBox();
            workers1Box = new TextBox();
            label12 = new Label();
            slowModeGroup = new GroupBox();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label10 = new Label();
            label14 = new Label();
            label13 = new Label();
            occuranceTimeBar = new TrackBar();
            sleepTimeBar = new TrackBar();
            label11 = new Label();
            replicationBox = new TextBox();
            fastModeCheck = new CheckBox();
            label9 = new Label();
            label3 = new Label();
            stopBut = new Button();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            workers2View = new ListView();
            columnHeader26 = new ColumnHeader();
            columnHeader42 = new ColumnHeader();
            columnHeader27 = new ColumnHeader();
            columnHeader28 = new ColumnHeader();
            columnHeader34 = new ColumnHeader();
            columnHeader35 = new ColumnHeader();
            workers1View = new ListView();
            columnHeader25 = new ColumnHeader();
            columnHeader41 = new ColumnHeader();
            columnHeader29 = new ColumnHeader();
            columnHeader30 = new ColumnHeader();
            tabPage4 = new TabPage();
            strongerCurrentCH1 = new CheckBox();
            label23 = new Label();
            workers2CarVanCH1 = new TextBox();
            statusLabelCH1 = new Label();
            label15 = new Label();
            stopButtonCH1 = new Button();
            workers2AllCH1 = new TextBox();
            replicationsCH1 = new TextBox();
            label22 = new Label();
            label6 = new Label();
            startButtonCH1 = new Button();
            chartViewCH1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPage3 = new TabPage();
            strongerCurrentCH2 = new CheckBox();
            label24 = new Label();
            statusLabelCH2 = new Label();
            stopButtonCH2 = new Button();
            workers1CH2 = new TextBox();
            label16 = new Label();
            replicationsCH2 = new TextBox();
            label17 = new Label();
            startButtonCH2 = new Button();
            chartViewCH2 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            slowModeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)occuranceTimeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepTimeBar).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // startBut
            // 
            startBut.Location = new Point(6, 6);
            startBut.Name = "startBut";
            startBut.Size = new Size(87, 23);
            startBut.TabIndex = 0;
            startBut.Text = "Start";
            startBut.UseVisualStyleBackColor = true;
            startBut.Click += startBut_Click;
            // 
            // workers1Label
            // 
            workers1Label.AutoSize = true;
            workers1Label.Location = new Point(6, 20);
            workers1Label.Name = "workers1Label";
            workers1Label.Size = new Size(110, 15);
            workers1Label.TabIndex = 1;
            workers1Label.Text = "Workers1, Busy: 0/0";
            // 
            // workers2Label
            // 
            workers2Label.AutoSize = true;
            workers2Label.Location = new Point(269, 19);
            workers2Label.Name = "workers2Label";
            workers2Label.Size = new Size(110, 15);
            workers2Label.TabIndex = 2;
            workers2Label.Text = "Workers2, Busy: 0/0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 3;
            label1.Text = "Arrived Vehicles Queue";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(247, 18);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 6;
            label2.Text = "Taken Vehicles";
            // 
            // arrivedVehiclesView
            // 
            arrivedVehiclesView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            arrivedVehiclesView.Location = new Point(6, 36);
            arrivedVehiclesView.Name = "arrivedVehiclesView";
            arrivedVehiclesView.Size = new Size(235, 246);
            arrivedVehiclesView.TabIndex = 7;
            arrivedVehiclesView.UseCompatibleStateImageBehavior = false;
            arrivedVehiclesView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "No.";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Id";
            columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Type";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Arrival Time";
            columnHeader4.Width = 90;
            // 
            // parkingVehiclesLabel
            // 
            parkingVehiclesLabel.AutoSize = true;
            parkingVehiclesLabel.Location = new Point(488, 18);
            parkingVehiclesLabel.Name = "parkingVehiclesLabel";
            parkingVehiclesLabel.Size = new Size(130, 15);
            parkingVehiclesLabel.TabIndex = 10;
            parkingVehiclesLabel.Text = "Parking Vehicles Queue";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(729, 18);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 12;
            label4.Text = "Controlling Vehicles";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(970, 18);
            label5.Name = "label5";
            label5.Size = new Size(154, 15);
            label5.TabIndex = 14;
            label5.Text = "Waiting for Payment Queue";
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(6, 35);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(87, 23);
            pauseButton.TabIndex = 19;
            pauseButton.Text = "Pause / Play";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // parkingVehiclesView
            // 
            parkingVehiclesView.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            parkingVehiclesView.Location = new Point(488, 36);
            parkingVehiclesView.Name = "parkingVehiclesView";
            parkingVehiclesView.Size = new Size(235, 246);
            parkingVehiclesView.TabIndex = 22;
            parkingVehiclesView.UseCompatibleStateImageBehavior = false;
            parkingVehiclesView.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "No.";
            columnHeader5.Width = 40;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Id";
            columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Type";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Arrival Time";
            columnHeader8.Width = 90;
            // 
            // takenVehiclesView
            // 
            takenVehiclesView.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            takenVehiclesView.Location = new Point(247, 36);
            takenVehiclesView.Name = "takenVehiclesView";
            takenVehiclesView.Size = new Size(235, 246);
            takenVehiclesView.TabIndex = 23;
            takenVehiclesView.UseCompatibleStateImageBehavior = false;
            takenVehiclesView.View = View.Details;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "No.";
            columnHeader9.Width = 40;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Id";
            columnHeader10.Width = 40;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Type";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Arrival Time";
            columnHeader12.Width = 90;
            // 
            // controlledVehiclesView
            // 
            controlledVehiclesView.Columns.AddRange(new ColumnHeader[] { columnHeader13, columnHeader14, columnHeader15, columnHeader16 });
            controlledVehiclesView.Location = new Point(729, 36);
            controlledVehiclesView.Name = "controlledVehiclesView";
            controlledVehiclesView.Size = new Size(235, 246);
            controlledVehiclesView.TabIndex = 24;
            controlledVehiclesView.UseCompatibleStateImageBehavior = false;
            controlledVehiclesView.View = View.Details;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "No.";
            columnHeader13.Width = 40;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Id";
            columnHeader14.Width = 40;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Type";
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Arrival Time";
            columnHeader16.Width = 90;
            // 
            // paymentQueueView
            // 
            paymentQueueView.Columns.AddRange(new ColumnHeader[] { columnHeader17, columnHeader18, columnHeader19, columnHeader20 });
            paymentQueueView.Location = new Point(970, 36);
            paymentQueueView.Name = "paymentQueueView";
            paymentQueueView.Size = new Size(235, 246);
            paymentQueueView.TabIndex = 25;
            paymentQueueView.UseCompatibleStateImageBehavior = false;
            paymentQueueView.View = View.Details;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "No.";
            columnHeader17.Width = 40;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Id";
            columnHeader18.Width = 40;
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Type";
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Arrival Time";
            columnHeader20.Width = 90;
            // 
            // payingView
            // 
            payingView.Columns.AddRange(new ColumnHeader[] { columnHeader21, columnHeader22, columnHeader23, columnHeader24 });
            payingView.Location = new Point(1211, 36);
            payingView.Name = "payingView";
            payingView.Size = new Size(235, 246);
            payingView.TabIndex = 28;
            payingView.UseCompatibleStateImageBehavior = false;
            payingView.View = View.Details;
            // 
            // columnHeader21
            // 
            columnHeader21.Text = "No.";
            columnHeader21.Width = 40;
            // 
            // columnHeader22
            // 
            columnHeader22.Text = "Id";
            columnHeader22.Width = 40;
            // 
            // columnHeader23
            // 
            columnHeader23.Text = "Type";
            // 
            // columnHeader24
            // 
            columnHeader24.Text = "Arrival Time";
            columnHeader24.Width = 90;
            // 
            // payingVehiclesLabel
            // 
            payingVehiclesLabel.AutoSize = true;
            payingVehiclesLabel.Location = new Point(1211, 18);
            payingVehiclesLabel.Name = "payingVehiclesLabel";
            payingVehiclesLabel.Size = new Size(88, 15);
            payingVehiclesLabel.TabIndex = 29;
            payingVehiclesLabel.Text = "Paying Vehicles";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1475, 725);
            tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label21);
            tabPage1.Controls.Add(strongerCurrentOfVehiclesCheck);
            tabPage1.Controls.Add(strongerCurrentOfVehiclesLabel);
            tabPage1.Controls.Add(groupBox5);
            tabPage1.Controls.Add(workers2CarVanBox);
            tabPage1.Controls.Add(workers2CarVanLabel);
            tabPage1.Controls.Add(advancedSimulationCheck);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(statusLabel);
            tabPage1.Controls.Add(workers2AllBox);
            tabPage1.Controls.Add(workers1Box);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(slowModeGroup);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(replicationBox);
            tabPage1.Controls.Add(fastModeCheck);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(stopBut);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(pauseButton);
            tabPage1.Controls.Add(startBut);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1467, 697);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Simulation";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(346, 43);
            label21.Name = "label21";
            label21.Size = new Size(160, 15);
            label21.TabIndex = 52;
            label21.Text = "(Workers Breaks, Certificates)";
            // 
            // strongerCurrentOfVehiclesCheck
            // 
            strongerCurrentOfVehiclesCheck.AutoSize = true;
            strongerCurrentOfVehiclesCheck.Location = new Point(533, 62);
            strongerCurrentOfVehiclesCheck.Name = "strongerCurrentOfVehiclesCheck";
            strongerCurrentOfVehiclesCheck.Size = new Size(15, 14);
            strongerCurrentOfVehiclesCheck.TabIndex = 51;
            strongerCurrentOfVehiclesCheck.UseVisualStyleBackColor = true;
            // 
            // strongerCurrentOfVehiclesLabel
            // 
            strongerCurrentOfVehiclesLabel.AutoSize = true;
            strongerCurrentOfVehiclesLabel.Location = new Point(346, 61);
            strongerCurrentOfVehiclesLabel.Name = "strongerCurrentOfVehiclesLabel";
            strongerCurrentOfVehiclesLabel.Size = new Size(156, 15);
            strongerCurrentOfVehiclesLabel.TabIndex = 50;
            strongerCurrentOfVehiclesLabel.Text = "Stronger Current Of Vehicles";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(salaryTotallabel);
            groupBox5.Controls.Add(salaryWorker2CarVanlabel);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(salaryWorker2Alllabel);
            groupBox5.Controls.Add(salaryWorker1label);
            groupBox5.Location = new Point(950, 9);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(475, 129);
            groupBox5.TabIndex = 49;
            groupBox5.TabStop = false;
            groupBox5.Text = "Monthly Salaries";
            // 
            // salaryTotallabel
            // 
            salaryTotallabel.AutoSize = true;
            salaryTotallabel.Location = new Point(6, 78);
            salaryTotallabel.Name = "salaryTotallabel";
            salaryTotallabel.Size = new Size(87, 15);
            salaryTotallabel.TabIndex = 4;
            salaryTotallabel.Text = "salaryTotallabel";
            // 
            // salaryWorker2CarVanlabel
            // 
            salaryWorker2CarVanlabel.AutoSize = true;
            salaryWorker2CarVanlabel.Location = new Point(6, 58);
            salaryWorker2CarVanlabel.Name = "salaryWorker2CarVanlabel";
            salaryWorker2CarVanlabel.Size = new Size(143, 15);
            salaryWorker2CarVanlabel.TabIndex = 3;
            salaryWorker2CarVanlabel.Text = "salaryWorker2CarVanlabel";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 66);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 2;
            // 
            // salaryWorker2Alllabel
            // 
            salaryWorker2Alllabel.AutoSize = true;
            salaryWorker2Alllabel.Location = new Point(6, 39);
            salaryWorker2Alllabel.Name = "salaryWorker2Alllabel";
            salaryWorker2Alllabel.Size = new Size(120, 15);
            salaryWorker2Alllabel.TabIndex = 1;
            salaryWorker2Alllabel.Text = "salaryWorker2Alllabel";
            // 
            // salaryWorker1label
            // 
            salaryWorker1label.AutoSize = true;
            salaryWorker1label.Location = new Point(6, 19);
            salaryWorker1label.Name = "salaryWorker1label";
            salaryWorker1label.Size = new Size(106, 15);
            salaryWorker1label.TabIndex = 0;
            salaryWorker1label.Text = "salaryWorker1label";
            // 
            // workers2CarVanBox
            // 
            workers2CarVanBox.Location = new Point(236, 97);
            workers2CarVanBox.Name = "workers2CarVanBox";
            workers2CarVanBox.Size = new Size(84, 23);
            workers2CarVanBox.TabIndex = 48;
            workers2CarVanBox.Text = "1";
            // 
            // workers2CarVanLabel
            // 
            workers2CarVanLabel.AutoSize = true;
            workers2CarVanLabel.Location = new Point(99, 100);
            workers2CarVanLabel.Name = "workers2CarVanLabel";
            workers2CarVanLabel.Size = new Size(99, 15);
            workers2CarVanLabel.TabIndex = 47;
            workers2CarVanLabel.Text = "Workers2,CarVan:";
            // 
            // advancedSimulationCheck
            // 
            advancedSimulationCheck.AutoSize = true;
            advancedSimulationCheck.Location = new Point(533, 35);
            advancedSimulationCheck.Name = "advancedSimulationCheck";
            advancedSimulationCheck.Size = new Size(15, 14);
            advancedSimulationCheck.TabIndex = 46;
            advancedSimulationCheck.UseVisualStyleBackColor = true;
            advancedSimulationCheck.CheckedChanged += advancedSimulationCheck_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(346, 28);
            label7.Name = "label7";
            label7.Size = new Size(120, 15);
            label7.TabIndex = 45;
            label7.Text = "Advanced Simulation";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(globalStatView);
            groupBox4.Location = new Point(6, 142);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(412, 255);
            groupBox4.TabIndex = 44;
            groupBox4.TabStop = false;
            groupBox4.Text = "Global Statistics";
            // 
            // globalStatView
            // 
            globalStatView.Columns.AddRange(new ColumnHeader[] { columnHeader36, columnHeader37, columnHeader33, columnHeader38, columnHeader39, columnHeader40 });
            globalStatView.Location = new Point(6, 19);
            globalStatView.Name = "globalStatView";
            globalStatView.Size = new Size(400, 227);
            globalStatView.TabIndex = 31;
            globalStatView.UseCompatibleStateImageBehavior = false;
            globalStatView.View = View.Details;
            // 
            // columnHeader36
            // 
            columnHeader36.Text = "Description";
            columnHeader36.Width = 210;
            // 
            // columnHeader37
            // 
            columnHeader37.Text = "Value";
            columnHeader37.Width = 80;
            // 
            // columnHeader33
            // 
            columnHeader33.Text = "Unit";
            // 
            // columnHeader38
            // 
            columnHeader38.Text = "CI";
            columnHeader38.Width = 50;
            // 
            // columnHeader39
            // 
            columnHeader39.Text = "Upper CI";
            columnHeader39.Width = 80;
            // 
            // columnHeader40
            // 
            columnHeader40.Text = "Lower CI";
            columnHeader40.Width = 80;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(localStatView);
            groupBox3.Location = new Point(424, 143);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(357, 255);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            groupBox3.Text = "Local Statistics";
            // 
            // localStatView
            // 
            localStatView.Columns.AddRange(new ColumnHeader[] { columnHeader31, columnHeader32, Unit });
            localStatView.Location = new Point(6, 19);
            localStatView.Name = "localStatView";
            localStatView.Size = new Size(345, 227);
            localStatView.TabIndex = 31;
            localStatView.UseCompatibleStateImageBehavior = false;
            localStatView.View = View.Details;
            // 
            // columnHeader31
            // 
            columnHeader31.Text = "Description";
            columnHeader31.Width = 210;
            // 
            // columnHeader32
            // 
            columnHeader32.Text = "Value";
            columnHeader32.Width = 70;
            // 
            // Unit
            // 
            Unit.Text = "Unit";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(6, 120);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(42, 15);
            statusLabel.TabIndex = 42;
            statusLabel.Text = "Status:";
            // 
            // workers2AllBox
            // 
            workers2AllBox.Location = new Point(236, 64);
            workers2AllBox.Name = "workers2AllBox";
            workers2AllBox.Size = new Size(84, 23);
            workers2AllBox.TabIndex = 41;
            workers2AllBox.Text = "1";
            // 
            // workers1Box
            // 
            workers1Box.Location = new Point(236, 35);
            workers1Box.Name = "workers1Box";
            workers1Box.Size = new Size(84, 23);
            workers1Box.TabIndex = 40;
            workers1Box.Text = "5";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(99, 68);
            label12.Name = "label12";
            label12.Size = new Size(118, 15);
            label12.TabIndex = 39;
            label12.Text = "Workers2,AllVehicles:";
            // 
            // slowModeGroup
            // 
            slowModeGroup.Controls.Add(label20);
            slowModeGroup.Controls.Add(label19);
            slowModeGroup.Controls.Add(label18);
            slowModeGroup.Controls.Add(label10);
            slowModeGroup.Controls.Add(label14);
            slowModeGroup.Controls.Add(label13);
            slowModeGroup.Controls.Add(occuranceTimeBar);
            slowModeGroup.Controls.Add(sleepTimeBar);
            slowModeGroup.Location = new Point(597, 9);
            slowModeGroup.Name = "slowModeGroup";
            slowModeGroup.Size = new Size(347, 129);
            slowModeGroup.TabIndex = 38;
            slowModeGroup.TabStop = false;
            slowModeGroup.Text = "Slow Mode Attributes";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.WhiteSmoke;
            label20.Location = new Point(298, 103);
            label20.Name = "label20";
            label20.Size = new Size(31, 15);
            label20.TabIndex = 52;
            label20.Text = "1000";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.WhiteSmoke;
            label19.Location = new Point(88, 103);
            label19.Name = "label19";
            label19.Size = new Size(13, 15);
            label19.TabIndex = 51;
            label19.Text = "1";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.WhiteSmoke;
            label18.Location = new Point(306, 52);
            label18.Name = "label18";
            label18.Size = new Size(19, 15);
            label18.TabIndex = 50;
            label18.Text = "10";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.WhiteSmoke;
            label10.Location = new Point(88, 52);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 49;
            label10.Text = "0";
            // 
            // label14
            // 
            label14.Location = new Point(6, 73);
            label14.Name = "label14";
            label14.Size = new Size(67, 36);
            label14.TabIndex = 43;
            label14.Text = "Occurance Time[s]:";
            // 
            // label13
            // 
            label13.Location = new Point(8, 22);
            label13.Name = "label13";
            label13.Size = new Size(55, 36);
            label13.TabIndex = 42;
            label13.Text = "Sleep Time[s]:";
            // 
            // occuranceTimeBar
            // 
            occuranceTimeBar.Location = new Point(81, 73);
            occuranceTimeBar.Maximum = 1000;
            occuranceTimeBar.Minimum = 1;
            occuranceTimeBar.Name = "occuranceTimeBar";
            occuranceTimeBar.Size = new Size(248, 45);
            occuranceTimeBar.TabIndex = 1;
            occuranceTimeBar.Value = 1000;
            occuranceTimeBar.Scroll += occuranceTimeBar_Scroll;
            // 
            // sleepTimeBar
            // 
            sleepTimeBar.Location = new Point(81, 22);
            sleepTimeBar.Name = "sleepTimeBar";
            sleepTimeBar.Size = new Size(248, 45);
            sleepTimeBar.TabIndex = 0;
            sleepTimeBar.Value = 1;
            sleepTimeBar.Scroll += sleepTimeBar_Scroll;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(99, 39);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 37;
            label11.Text = "Workers1:";
            // 
            // replicationBox
            // 
            replicationBox.Location = new Point(236, 6);
            replicationBox.Name = "replicationBox";
            replicationBox.Size = new Size(84, 23);
            replicationBox.TabIndex = 36;
            replicationBox.Text = "1000";
            // 
            // fastModeCheck
            // 
            fastModeCheck.AutoSize = true;
            fastModeCheck.Location = new Point(533, 11);
            fastModeCheck.Name = "fastModeCheck";
            fastModeCheck.Size = new Size(15, 14);
            fastModeCheck.TabIndex = 35;
            fastModeCheck.UseVisualStyleBackColor = true;
            fastModeCheck.CheckStateChanged += fastModeCheck_CheckStateChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(99, 11);
            label9.Name = "label9";
            label9.Size = new Size(74, 15);
            label9.TabIndex = 34;
            label9.Text = "Replications:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(346, 9);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 33;
            label3.Text = "Fast Mode";
            // 
            // stopBut
            // 
            stopBut.Location = new Point(6, 64);
            stopBut.Name = "stopBut";
            stopBut.Size = new Size(87, 23);
            stopBut.TabIndex = 32;
            stopBut.Text = "Stop";
            stopBut.UseVisualStyleBackColor = true;
            stopBut.Click += stopBut_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(takenVehiclesView);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(parkingVehiclesView);
            groupBox2.Controls.Add(payingVehiclesLabel);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(payingView);
            groupBox2.Controls.Add(arrivedVehiclesView);
            groupBox2.Controls.Add(parkingVehiclesLabel);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(controlledVehiclesView);
            groupBox2.Controls.Add(paymentQueueView);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(6, 403);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1455, 290);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Slow Mode Simulation Run";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(workers2View);
            groupBox1.Controls.Add(workers1View);
            groupBox1.Controls.Add(workers2Label);
            groupBox1.Controls.Add(workers1Label);
            groupBox1.Location = new Point(787, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(674, 255);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Workers Information";
            // 
            // workers2View
            // 
            workers2View.Columns.AddRange(new ColumnHeader[] { columnHeader26, columnHeader42, columnHeader27, columnHeader28, columnHeader34, columnHeader35 });
            workers2View.Location = new Point(269, 37);
            workers2View.Name = "workers2View";
            workers2View.Size = new Size(400, 209);
            workers2View.TabIndex = 31;
            workers2View.UseCompatibleStateImageBehavior = false;
            workers2View.View = View.Details;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "No.";
            columnHeader26.Width = 35;
            // 
            // columnHeader42
            // 
            columnHeader42.Text = "Break Done At";
            columnHeader42.Width = 80;
            // 
            // columnHeader27
            // 
            columnHeader27.Text = "JobType";
            columnHeader27.Width = 80;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "VehicleId";
            // 
            // columnHeader34
            // 
            columnHeader34.Text = "Type";
            columnHeader34.Width = 50;
            // 
            // columnHeader35
            // 
            columnHeader35.Text = "Certificate";
            columnHeader35.Width = 90;
            // 
            // workers1View
            // 
            workers1View.Columns.AddRange(new ColumnHeader[] { columnHeader25, columnHeader41, columnHeader29, columnHeader30 });
            workers1View.Location = new Point(3, 38);
            workers1View.Name = "workers1View";
            workers1View.Size = new Size(260, 209);
            workers1View.TabIndex = 30;
            workers1View.UseCompatibleStateImageBehavior = false;
            workers1View.View = View.Details;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "No.";
            columnHeader25.Width = 35;
            // 
            // columnHeader41
            // 
            columnHeader41.Text = "Break Done At";
            columnHeader41.Width = 80;
            // 
            // columnHeader29
            // 
            columnHeader29.Text = "JobType";
            columnHeader29.Width = 80;
            // 
            // columnHeader30
            // 
            columnHeader30.Text = "VehicleId";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(strongerCurrentCH1);
            tabPage4.Controls.Add(label23);
            tabPage4.Controls.Add(workers2CarVanCH1);
            tabPage4.Controls.Add(statusLabelCH1);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(stopButtonCH1);
            tabPage4.Controls.Add(workers2AllCH1);
            tabPage4.Controls.Add(replicationsCH1);
            tabPage4.Controls.Add(label22);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(startButtonCH1);
            tabPage4.Controls.Add(chartViewCH1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1467, 697);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Chart1";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // strongerCurrentCH1
            // 
            strongerCurrentCH1.AutoSize = true;
            strongerCurrentCH1.Location = new Point(261, 39);
            strongerCurrentCH1.Name = "strongerCurrentCH1";
            strongerCurrentCH1.Size = new Size(15, 14);
            strongerCurrentCH1.TabIndex = 54;
            strongerCurrentCH1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(99, 38);
            label23.Name = "label23";
            label23.Size = new Size(156, 15);
            label23.TabIndex = 53;
            label23.Text = "Stronger Current Of Vehicles";
            // 
            // workers2CarVanCH1
            // 
            workers2CarVanCH1.Location = new Point(588, 8);
            workers2CarVanCH1.Name = "workers2CarVanCH1";
            workers2CarVanCH1.Size = new Size(84, 23);
            workers2CarVanCH1.TabIndex = 52;
            workers2CarVanCH1.Text = "1";
            // 
            // statusLabelCH1
            // 
            statusLabelCH1.AutoSize = true;
            statusLabelCH1.Location = new Point(6, 60);
            statusLabelCH1.Name = "statusLabelCH1";
            statusLabelCH1.Size = new Size(42, 15);
            statusLabelCH1.TabIndex = 45;
            statusLabelCH1.Text = "Status:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(483, 12);
            label15.Name = "label15";
            label15.Size = new Size(99, 15);
            label15.TabIndex = 51;
            label15.Text = "Workers2,CarVan:";
            // 
            // stopButtonCH1
            // 
            stopButtonCH1.Location = new Point(6, 34);
            stopButtonCH1.Name = "stopButtonCH1";
            stopButtonCH1.Size = new Size(87, 23);
            stopButtonCH1.TabIndex = 44;
            stopButtonCH1.Text = "Stop";
            stopButtonCH1.UseVisualStyleBackColor = true;
            stopButtonCH1.Click += stopButtonCH1_Click;
            // 
            // workers2AllCH1
            // 
            workers2AllCH1.Location = new Point(393, 8);
            workers2AllCH1.Name = "workers2AllCH1";
            workers2AllCH1.Size = new Size(84, 23);
            workers2AllCH1.TabIndex = 50;
            workers2AllCH1.Text = "1";
            // 
            // replicationsCH1
            // 
            replicationsCH1.Location = new Point(179, 7);
            replicationsCH1.Name = "replicationsCH1";
            replicationsCH1.Size = new Size(84, 23);
            replicationsCH1.TabIndex = 39;
            replicationsCH1.Text = "500";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(269, 11);
            label22.Name = "label22";
            label22.Size = new Size(118, 15);
            label22.TabIndex = 49;
            label22.Text = "Workers2,AllVehicles:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(99, 11);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 38;
            label6.Text = "Replications:";
            // 
            // startButtonCH1
            // 
            startButtonCH1.Location = new Point(6, 6);
            startButtonCH1.Name = "startButtonCH1";
            startButtonCH1.Size = new Size(87, 23);
            startButtonCH1.TabIndex = 37;
            startButtonCH1.Text = "Start";
            startButtonCH1.UseVisualStyleBackColor = true;
            startButtonCH1.Click += startButtonCH1_Click;
            // 
            // chartViewCH1
            // 
            chartViewCH1.Location = new Point(6, 78);
            chartViewCH1.Name = "chartViewCH1";
            chartViewCH1.Size = new Size(1455, 613);
            chartViewCH1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(strongerCurrentCH2);
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(statusLabelCH2);
            tabPage3.Controls.Add(stopButtonCH2);
            tabPage3.Controls.Add(workers1CH2);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(replicationsCH2);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(startButtonCH2);
            tabPage3.Controls.Add(chartViewCH2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1467, 697);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Chart2";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // strongerCurrentCH2
            // 
            strongerCurrentCH2.AutoSize = true;
            strongerCurrentCH2.Location = new Point(261, 39);
            strongerCurrentCH2.Name = "strongerCurrentCH2";
            strongerCurrentCH2.Size = new Size(15, 14);
            strongerCurrentCH2.TabIndex = 56;
            strongerCurrentCH2.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(99, 38);
            label24.Name = "label24";
            label24.Size = new Size(156, 15);
            label24.TabIndex = 55;
            label24.Text = "Stronger Current Of Vehicles";
            // 
            // statusLabelCH2
            // 
            statusLabelCH2.AutoSize = true;
            statusLabelCH2.Location = new Point(6, 59);
            statusLabelCH2.Name = "statusLabelCH2";
            statusLabelCH2.Size = new Size(42, 15);
            statusLabelCH2.TabIndex = 52;
            statusLabelCH2.Text = "Status:";
            // 
            // stopButtonCH2
            // 
            stopButtonCH2.Location = new Point(6, 34);
            stopButtonCH2.Name = "stopButtonCH2";
            stopButtonCH2.Size = new Size(87, 23);
            stopButtonCH2.TabIndex = 51;
            stopButtonCH2.Text = "Stop";
            stopButtonCH2.UseVisualStyleBackColor = true;
            stopButtonCH2.Click += stopButtonCH2_Click;
            // 
            // workers1CH2
            // 
            workers1CH2.Location = new Point(349, 5);
            workers1CH2.Name = "workers1CH2";
            workers1CH2.Size = new Size(84, 23);
            workers1CH2.TabIndex = 50;
            workers1CH2.Text = "20";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(269, 9);
            label16.Name = "label16";
            label16.Size = new Size(59, 15);
            label16.TabIndex = 49;
            label16.Text = "Workers1:";
            // 
            // replicationsCH2
            // 
            replicationsCH2.Location = new Point(179, 6);
            replicationsCH2.Name = "replicationsCH2";
            replicationsCH2.Size = new Size(84, 23);
            replicationsCH2.TabIndex = 48;
            replicationsCH2.Text = "500";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(99, 11);
            label17.Name = "label17";
            label17.Size = new Size(74, 15);
            label17.TabIndex = 47;
            label17.Text = "Replications:";
            // 
            // startButtonCH2
            // 
            startButtonCH2.Location = new Point(6, 6);
            startButtonCH2.Name = "startButtonCH2";
            startButtonCH2.Size = new Size(87, 23);
            startButtonCH2.TabIndex = 46;
            startButtonCH2.Text = "Start";
            startButtonCH2.UseVisualStyleBackColor = true;
            startButtonCH2.Click += startButtonCH2_Click;
            // 
            // chartViewCH2
            // 
            chartViewCH2.Location = new Point(6, 77);
            chartViewCH2.Name = "chartViewCH2";
            chartViewCH2.Size = new Size(1455, 614);
            chartViewCH2.TabIndex = 45;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(1500, 743);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form";
            Text = "PPSimulator";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            slowModeGroup.ResumeLayout(false);
            slowModeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)occuranceTimeBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepTimeBar).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button startBut;
        private Label workers1Label;
        private Label workers2Label;
        private Label label1;
        private Label label2;
        private ListView arrivedVehiclesView;
        private Label parkingVehiclesLabel;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label4;
        private Label label5;
        private Label statusLabelCH1;
        private Button pauseButton;
        private ListView parkingVehiclesView;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ListView takenVehiclesView;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ListView controlledVehiclesView;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ListView paymentQueueView;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private Label label10;
        private Label payedCustomersLabel;
        private ListView payingView;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private Label payingVehiclesLabel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage4;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ListView workers2View;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private ListView workers1View;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private TextBox workers2AllBox;
        private TextBox workers1Box;
        private Label label12;
        private GroupBox slowModeGroup;
        private Label label14;
        private Label label13;
        private TrackBar occuranceTimeBar;
        private TrackBar sleepTimeBar;
        private Label label11;
        private TextBox replicationBox;
        private CheckBox fastModeCheck;
        private Label label9;
        private Label label3;
        private Button stopBut;
        private Label statusLabel;
        private GroupBox groupBox3;
        private ListView localStatView;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private GroupBox groupBox4;
        private ListView globalStatView;
        private ColumnHeader columnHeader36;
        private ColumnHeader columnHeader37;
        private ColumnHeader columnHeader38;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private ColumnHeader columnHeader33;
        private ColumnHeader Unit;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartViewCH1;
        private Button stopButtonCH2;
        private TextBox workers1CH2;
        private Label label16;
        private TextBox replicationsCH2;
        private Label label17;
        private Button startButtonCH2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartViewCH2;
        private Label statusLabelCH2;
        private Label workers2CarVanLabel;
        private CheckBox advancedSimulationCheck;
        private Label label7;
        private TextBox workers2CarVanBox;
        private Label label20;
        private Label label19;
        private Label label18;
        private GroupBox groupBox5;
        private Label salaryTotallabel;
        private Label salaryWorker2CarVanlabel;
        private Label label8;
        private Label salaryWorker2Alllabel;
        private Label salaryWorker1label;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader34;
        private CheckBox strongerCurrentOfVehiclesCheck;
        private Label strongerCurrentOfVehiclesLabel;
        private Label label21;
        private Button stopButtonCH1;
        private TextBox worker2BoxCH1;
        private TextBox replicationsCH1;
        private Label label6;
        private Button startButtonCH1;
        private ColumnHeader columnHeader42;
        private ColumnHeader columnHeader41;
        private TextBox workers2CarVanCH1;
        private Label label15;
        private TextBox workers2AllCH1;
        private Label label22;
        private CheckBox strongerCurrentCH1;
        private Label label23;
        private CheckBox strongerCurrentCH2;
        private Label label24;
    }
}