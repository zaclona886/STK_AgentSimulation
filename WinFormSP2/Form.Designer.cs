﻿namespace WinFormSP2
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
            workers2Box = new TextBox();
            workers1Box = new TextBox();
            label12 = new Label();
            slowModeGroup = new GroupBox();
            occuranceTimeBox = new TextBox();
            sleepTimeBox = new TextBox();
            label14 = new Label();
            label13 = new Label();
            occuranceTimeBar = new TrackBar();
            sleepTimeBar = new TrackBar();
            label11 = new Label();
            replicationBox = new TextBox();
            slowModeCheck = new CheckBox();
            label9 = new Label();
            label3 = new Label();
            stopBut = new Button();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            workers2View = new ListView();
            columnHeader26 = new ColumnHeader();
            columnHeader27 = new ColumnHeader();
            columnHeader28 = new ColumnHeader();
            workers1View = new ListView();
            columnHeader25 = new ColumnHeader();
            columnHeader29 = new ColumnHeader();
            columnHeader30 = new ColumnHeader();
            tabPage4 = new TabPage();
            statusLabelCH1 = new Label();
            stopButtonCH1 = new Button();
            worker2BoxCH1 = new TextBox();
            label15 = new Label();
            repBoxCH1 = new TextBox();
            label6 = new Label();
            startButtonCH1 = new Button();
            chartViewCH1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPage3 = new TabPage();
            statusLabelCH2 = new Label();
            stopButtonCH2 = new Button();
            worker1BoxCH2 = new TextBox();
            label16 = new Label();
            repBoxCH2 = new TextBox();
            label17 = new Label();
            startButtonCH2 = new Button();
            chartViewCH2 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
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
            workers1Label.Location = new Point(9, 19);
            workers1Label.Name = "workers1Label";
            workers1Label.Size = new Size(110, 15);
            workers1Label.TabIndex = 1;
            workers1Label.Text = "Workers1, Busy: 0/0";
            // 
            // workers2Label
            // 
            workers2Label.AutoSize = true;
            workers2Label.Location = new Point(230, 19);
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
            parkingVehiclesLabel.Size = new Size(179, 15);
            parkingVehiclesLabel.TabIndex = 10;
            parkingVehiclesLabel.Text = "Parking Vehicles Queue, Max 0/0";
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
            pauseButton.Location = new Point(6, 64);
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
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(statusLabel);
            tabPage1.Controls.Add(workers2Box);
            tabPage1.Controls.Add(workers1Box);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(slowModeGroup);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(replicationBox);
            tabPage1.Controls.Add(slowModeCheck);
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
            // groupBox4
            // 
            groupBox4.Controls.Add(globalStatView);
            groupBox4.Location = new Point(6, 142);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(599, 255);
            groupBox4.TabIndex = 44;
            groupBox4.TabStop = false;
            groupBox4.Text = "Global Statistics";
            // 
            // globalStatView
            // 
            globalStatView.Columns.AddRange(new ColumnHeader[] { columnHeader36, columnHeader37, columnHeader33, columnHeader38, columnHeader39, columnHeader40 });
            globalStatView.Location = new Point(6, 19);
            globalStatView.Name = "globalStatView";
            globalStatView.Size = new Size(587, 227);
            globalStatView.TabIndex = 31;
            globalStatView.UseCompatibleStateImageBehavior = false;
            globalStatView.View = View.Details;
            // 
            // columnHeader36
            // 
            columnHeader36.Text = "Description";
            columnHeader36.Width = 230;
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
            groupBox3.Location = new Point(615, 142);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(381, 255);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            groupBox3.Text = "Local Statistics";
            // 
            // localStatView
            // 
            localStatView.Columns.AddRange(new ColumnHeader[] { columnHeader31, columnHeader32, Unit });
            localStatView.Location = new Point(6, 19);
            localStatView.Name = "localStatView";
            localStatView.Size = new Size(369, 227);
            localStatView.TabIndex = 31;
            localStatView.UseCompatibleStateImageBehavior = false;
            localStatView.View = View.Details;
            // 
            // columnHeader31
            // 
            columnHeader31.Text = "Description";
            columnHeader31.Width = 230;
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
            statusLabel.Location = new Point(6, 100);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(42, 15);
            statusLabel.TabIndex = 42;
            statusLabel.Text = "Status:";
            // 
            // workers2Box
            // 
            workers2Box.Location = new Point(179, 64);
            workers2Box.Name = "workers2Box";
            workers2Box.Size = new Size(84, 23);
            workers2Box.TabIndex = 41;
            workers2Box.Text = "1";
            // 
            // workers1Box
            // 
            workers1Box.Location = new Point(179, 35);
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
            label12.Size = new Size(59, 15);
            label12.TabIndex = 39;
            label12.Text = "Workers2:";
            // 
            // slowModeGroup
            // 
            slowModeGroup.Controls.Add(occuranceTimeBox);
            slowModeGroup.Controls.Add(sleepTimeBox);
            slowModeGroup.Controls.Add(label14);
            slowModeGroup.Controls.Add(label13);
            slowModeGroup.Controls.Add(occuranceTimeBar);
            slowModeGroup.Controls.Add(sleepTimeBar);
            slowModeGroup.Location = new Point(385, 6);
            slowModeGroup.Name = "slowModeGroup";
            slowModeGroup.Size = new Size(347, 129);
            slowModeGroup.TabIndex = 38;
            slowModeGroup.TabStop = false;
            slowModeGroup.Text = "Slow Mode Attributes";
            // 
            // occuranceTimeBox
            // 
            occuranceTimeBox.Location = new Point(266, 86);
            occuranceTimeBox.Name = "occuranceTimeBox";
            occuranceTimeBox.ReadOnly = true;
            occuranceTimeBox.Size = new Size(23, 23);
            occuranceTimeBox.TabIndex = 44;
            occuranceTimeBox.Text = "10";
            // 
            // sleepTimeBox
            // 
            sleepTimeBox.Location = new Point(266, 33);
            sleepTimeBox.Name = "sleepTimeBox";
            sleepTimeBox.ReadOnly = true;
            sleepTimeBox.Size = new Size(23, 23);
            sleepTimeBox.TabIndex = 43;
            sleepTimeBox.Text = "10";
            // 
            // label14
            // 
            label14.Location = new Point(6, 73);
            label14.Name = "label14";
            label14.Size = new Size(67, 36);
            label14.TabIndex = 43;
            label14.Text = "Occurance Time[min]:";
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
            occuranceTimeBar.Maximum = 20;
            occuranceTimeBar.Minimum = 1;
            occuranceTimeBar.Name = "occuranceTimeBar";
            occuranceTimeBar.Size = new Size(179, 45);
            occuranceTimeBar.TabIndex = 1;
            occuranceTimeBar.Value = 1;
            occuranceTimeBar.Scroll += occuranceTimeBar_Scroll;
            // 
            // sleepTimeBar
            // 
            sleepTimeBar.Location = new Point(81, 22);
            sleepTimeBar.Minimum = 1;
            sleepTimeBar.Name = "sleepTimeBar";
            sleepTimeBar.Size = new Size(179, 45);
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
            replicationBox.Location = new Point(179, 6);
            replicationBox.Name = "replicationBox";
            replicationBox.Size = new Size(84, 23);
            replicationBox.TabIndex = 36;
            replicationBox.Text = "10000";
            // 
            // slowModeCheck
            // 
            slowModeCheck.AutoSize = true;
            slowModeCheck.Location = new Point(364, 9);
            slowModeCheck.Name = "slowModeCheck";
            slowModeCheck.Size = new Size(15, 14);
            slowModeCheck.TabIndex = 35;
            slowModeCheck.UseVisualStyleBackColor = true;
            slowModeCheck.CheckedChanged += checkBox1_CheckedChanged;
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
            label3.Location = new Point(289, 9);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 33;
            label3.Text = "Slow Mode:";
            // 
            // stopBut
            // 
            stopBut.Location = new Point(6, 35);
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
            groupBox1.Controls.Add(workers1Label);
            groupBox1.Controls.Add(workers2Label);
            groupBox1.Location = new Point(1006, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 255);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Workers Information";
            // 
            // workers2View
            // 
            workers2View.Columns.AddRange(new ColumnHeader[] { columnHeader26, columnHeader27, columnHeader28 });
            workers2View.Location = new Point(230, 37);
            workers2View.Name = "workers2View";
            workers2View.Size = new Size(215, 209);
            workers2View.TabIndex = 31;
            workers2View.UseCompatibleStateImageBehavior = false;
            workers2View.View = View.Details;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "No.";
            columnHeader26.Width = 40;
            // 
            // columnHeader27
            // 
            columnHeader27.Text = "JobType";
            columnHeader27.Width = 90;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "VehicleId";
            columnHeader28.Width = 80;
            // 
            // workers1View
            // 
            workers1View.Columns.AddRange(new ColumnHeader[] { columnHeader25, columnHeader29, columnHeader30 });
            workers1View.Location = new Point(9, 37);
            workers1View.Name = "workers1View";
            workers1View.Size = new Size(215, 209);
            workers1View.TabIndex = 30;
            workers1View.UseCompatibleStateImageBehavior = false;
            workers1View.View = View.Details;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "No.";
            columnHeader25.Width = 40;
            // 
            // columnHeader29
            // 
            columnHeader29.Text = "JobType";
            columnHeader29.Width = 90;
            // 
            // columnHeader30
            // 
            columnHeader30.Text = "VehicleId";
            columnHeader30.Width = 80;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(statusLabelCH1);
            tabPage4.Controls.Add(stopButtonCH1);
            tabPage4.Controls.Add(worker2BoxCH1);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(repBoxCH1);
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
            // statusLabelCH1
            // 
            statusLabelCH1.AutoSize = true;
            statusLabelCH1.Location = new Point(6, 59);
            statusLabelCH1.Name = "statusLabelCH1";
            statusLabelCH1.Size = new Size(42, 15);
            statusLabelCH1.TabIndex = 45;
            statusLabelCH1.Text = "Status:";
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
            // worker2BoxCH1
            // 
            worker2BoxCH1.Location = new Point(179, 35);
            worker2BoxCH1.Name = "worker2BoxCH1";
            worker2BoxCH1.Size = new Size(84, 23);
            worker2BoxCH1.TabIndex = 43;
            worker2BoxCH1.Text = "20";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(99, 39);
            label15.Name = "label15";
            label15.Size = new Size(59, 15);
            label15.TabIndex = 42;
            label15.Text = "Workers2:";
            // 
            // repBoxCH1
            // 
            repBoxCH1.Location = new Point(179, 6);
            repBoxCH1.Name = "repBoxCH1";
            repBoxCH1.Size = new Size(84, 23);
            repBoxCH1.TabIndex = 39;
            repBoxCH1.Text = "1000";
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
            chartViewCH1.Location = new Point(6, 77);
            chartViewCH1.Name = "chartViewCH1";
            chartViewCH1.Size = new Size(1455, 614);
            chartViewCH1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(statusLabelCH2);
            tabPage3.Controls.Add(stopButtonCH2);
            tabPage3.Controls.Add(worker1BoxCH2);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(repBoxCH2);
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
            // worker1BoxCH2
            // 
            worker1BoxCH2.Location = new Point(179, 35);
            worker1BoxCH2.Name = "worker1BoxCH2";
            worker1BoxCH2.Size = new Size(84, 23);
            worker1BoxCH2.TabIndex = 50;
            worker1BoxCH2.Text = "20";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(99, 39);
            label16.Name = "label16";
            label16.Size = new Size(59, 15);
            label16.TabIndex = 49;
            label16.Text = "Workers1:";
            // 
            // repBoxCH2
            // 
            repBoxCH2.Location = new Point(179, 6);
            repBoxCH2.Name = "repBoxCH2";
            repBoxCH2.Size = new Size(84, 23);
            repBoxCH2.TabIndex = 48;
            repBoxCH2.Text = "1000";
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
        private TextBox workers2Box;
        private TextBox workers1Box;
        private Label label12;
        private GroupBox slowModeGroup;
        private Label label14;
        private Label label13;
        private TrackBar occuranceTimeBar;
        private TrackBar sleepTimeBar;
        private Label label11;
        private TextBox replicationBox;
        private CheckBox slowModeCheck;
        private Label label9;
        private Label label3;
        private Button stopBut;
        private Label statusLabel;
        private TextBox occuranceTimeBox;
        private TextBox sleepTimeBox;
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
        private Button stopButtonCH1;
        private TextBox worker2BoxCH1;
        private Label label15;
        private TextBox repBoxCH1;
        private Label label6;
        private Button startButtonCH1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartViewCH1;
        private Button stopButtonCH2;
        private TextBox worker1BoxCH2;
        private Label label16;
        private TextBox repBoxCH2;
        private Label label17;
        private Button startButtonCH2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartViewCH2;
        private Label statusLabelCH2;
    }
}