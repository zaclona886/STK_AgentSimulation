using LiveChartsCore.Defaults;
using SimulatorLib.Simulations;
using SimulatorLib.Simulations.EventSimulation.Implementation.STK.Others;
using SimulatorLib.Simulations.EventSimulation.Implementation.STK.Simulation;
using WinFormSP1.Models;

namespace WinFormSP2
{
    public partial class Form : System.Windows.Forms.Form
    {
        public ViewModel _viewModelCH1 = new ViewModel();
        private SimulationCore chart1Simulation;

        public ViewModel _viewModelCH2 = new ViewModel();
        private SimulationCore chart2Simulation;

        private SimulationCore _simulation;
        private bool simultionIsRunning;
        private bool simulationIsPaused;
        private bool slowModeOn;

        private int sleepTime = 10;
        public Form()
        {
            InitializeComponent();
            simultionIsRunning = false;
            simulationIsPaused = false;

            slowModeOn = false;
            slowModeGroup.Visible = false;
            slowModeGroup.Enabled = false;

            sleepTimeBar.Value = 1;
            sleepTimeBox.Text = "1";
            occuranceTimeBar.Value = 1;
            occuranceTimeBox.Text = "1";

            chartViewCH1.Series = _viewModelCH1.Series;
            chartViewCH1.XAxes = _viewModelCH1.xAxes;
            chartViewCH1.YAxes = _viewModelCH1.yAxes;
            _viewModelCH1.SetYAxisName("Average Count of Vehicles in Queue");
            _viewModelCH1.SetXAxisName("Count of Worker1");

            chartViewCH2.Series = _viewModelCH2.Series;
            chartViewCH2.XAxes = _viewModelCH2.xAxes;
            chartViewCH2.YAxes = _viewModelCH2.yAxes;
            _viewModelCH2.SetYAxisName("Average Time of Vehicles in System");
            _viewModelCH2.SetXAxisName("Count of Worker2");
        }

        private void startBut_Click(object sender, EventArgs e)
        {
            var numberOfReplications = 0;
            if (!int.TryParse(replicationBox.Text, out numberOfReplications))
            {
                statusLabel.Text = "Status: Replications have to be Number!";
                return;
            }
            if (numberOfReplications <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Replications";
                return;
            }

            var numberOfWorkers1 = 0;
            if (!int.TryParse(workers1Box.Text, out numberOfWorkers1))
            {
                statusLabel.Text = "Status: Workers1 have to be Number!";
                return;
            }
            if (numberOfWorkers1 <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Worker1";
                return;
            }

            var numberOfWorkers2 = 0;
            if (!int.TryParse(workers2Box.Text, out numberOfWorkers2))
            {
                statusLabel.Text = "Status: Workers1 have to be Number!";
                return;
            }
            if (numberOfWorkers2 <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Worker1";
                return;
            }

            _simulation = new STKSimulation(numberOfReplications, 0,
                slowModeOn, sleepTimeBar.Value, occuranceTimeBar.Value, numberOfWorkers1, numberOfWorkers2);

            _simulation.Simulated += (sender, e) =>
            {

                var sim = (STKSimulation)e;
                if (!sim.replicationFinished && slowModeOn)
                {
                    this.Invoke((Action)(() =>
                    {

                        // Workers1
                        var countTrue = 0;
                        foreach (var item in sim.listWorkers1)
                        {
                            if (item.isBusy)
                            {
                                countTrue++;
                            }
                        }
                        workers1Label.Text = new string("Workers1, Busy: " + countTrue + " / " + sim.numberOfWorkers1);

                        workers1View.Items.Clear();
                        var i = 0;
                        foreach (var data in sim.listWorkers1)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.jobType?.ToString());
                            item.SubItems.Add(data.vehicle?.id.ToString());
                            workers1View.Items.Add(item);
                            i++;
                        }

                        // Workers2 
                        countTrue = 0;
                        foreach (var item in sim.listWorkers2)
                        {
                            if (item.isBusy)
                            {
                                countTrue++;
                            }
                        }
                        workers2Label.Text = new string("Workers2, Busy: " + countTrue + " / " + sim.numberOfWorkers2);
                        parkingVehiclesLabel.Text = new string("Parking Vehicles Queue, Max: " + sim.maxVehicleParkingInFrontOfControl);

                        workers2View.Items.Clear();
                        i = 0;
                        foreach (var data in sim.listWorkers2)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.jobType?.ToString());
                            item.SubItems.Add(data.vehicle?.id.ToString());
                            workers2View.Items.Add(item);
                            i++;
                        }

                        // arived
                        arrivedVehiclesView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.vehicleArrivalQueue)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.id.ToString());
                            item.SubItems.Add(data.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.arrivalTime);
                            item.SubItems.Add(simTime2.ToString("hh:mm:ss"));
                            arrivedVehiclesView.Items.Add(item);
                            i++;
                        }

                        // taken
                        takenVehiclesView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.takenVehicles)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.Value.id.ToString());
                            item.SubItems.Add(data.Value.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.Value.arrivalTime);
                            item.SubItems.Add(simTime2.ToString("hh:mm:ss"));
                            takenVehiclesView.Items.Add(item);
                            i++;
                        }

                        // parking
                        parkingVehiclesView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.vehicleParkingInFrontOfControlQueue)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.id.ToString());
                            item.SubItems.Add(data.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.arrivalTime);
                            item.SubItems.Add(simTime2.ToString("hh:mm:ss"));
                            parkingVehiclesView.Items.Add(item);
                            i++;
                        }

                        //controlled
                        controlledVehiclesView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.controlledVehicles)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.Value.id.ToString());
                            item.SubItems.Add(data.Value.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.Value.arrivalTime);
                            item.SubItems.Add(simTime2.ToString("hh:mm:ss"));
                            controlledVehiclesView.Items.Add(item);
                            i++;
                        }

                        //payment queue
                        paymentQueueView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.vehiclePaymentQueue)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.id.ToString());
                            item.SubItems.Add(data.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.arrivalTime);
                            item.SubItems.Add(simTime2.ToString("hh:mm:ss"));
                            paymentQueueView.Items.Add(item);
                            i++;
                        }

                        //paying vehicles
                        payingView.Items.Clear();
                        i = 0;
                        foreach (var data in sim.payingVehicles)
                        {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.SubItems.Add(data.Value.id.ToString());
                            item.SubItems.Add(data.Value.vehicleType.ToString());
                            var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                            simTime2 = simTime2.AddSeconds(data.Value.arrivalTime);
                            payingView.Items.Add(item);
                            i++;
                        }

                        //Local Statistics
                        localStatView.Items.Clear();
                        //finished replications
                        ListViewItem itemLocStat = new ListViewItem("Finished Replications");
                        itemLocStat.SubItems.Add(sim.finishedReplications.ToString());
                        localStatView.Items.Add(itemLocStat);

                        //Simulation Time
                        itemLocStat = new ListViewItem("Simulation Time");
                        var simTime = new DateTime(1, 1, 1, 9, 0, 0);
                        simTime = simTime.AddSeconds(sim.currentTime);
                        itemLocStat.SubItems.Add(simTime.ToString("hh:mm:ss"));
                        localStatView.Items.Add(itemLocStat);

                        // Count of Finished Vehicles
                        itemLocStat = new ListViewItem("Count of Finished Vehicles");
                        itemLocStat.SubItems.Add(sim.finishedVehicles.ToString());
                        itemLocStat.SubItems.Add("Vehicle");
                        localStatView.Items.Add(itemLocStat);

                        // Average count of Vehicles in the End xxxxx Not Displaying
                        itemLocStat = new ListViewItem();
                        localStatView.Items.Add(itemLocStat);

                        // Average Count of Vehicles in System
                        itemLocStat = new ListViewItem("Average Count of Vehicles in System");
                        itemLocStat.SubItems.Add(sim.averageCountOfVehiclesInSystem.GetResult().ToString("F5"));
                        itemLocStat.SubItems.Add("Vehicle");
                        localStatView.Items.Add(itemLocStat);

                        // Average Time of Vehicles in System
                        itemLocStat = new ListViewItem("Average Time of Vehicles in System");
                        itemLocStat.SubItems.Add((sim.averageTimeOfVehiclesInSystem.GetResult() / 60.0).ToString("F5"));
                        itemLocStat.SubItems.Add("Minute");
                        localStatView.Items.Add(itemLocStat);

                        //Average Count of Vehicle in Queue
                        itemLocStat = new ListViewItem("Average Count of Vehicles in Queue");
                        itemLocStat.SubItems.Add(sim.averageCountOfVehiclesInQueue.GetResult().ToString("F5"));
                        itemLocStat.SubItems.Add("Vehicle");
                        localStatView.Items.Add(itemLocStat);

                        //Average Time of Vehicle in Queue
                        itemLocStat = new ListViewItem("Average Time of Vehicles in Queue");
                        itemLocStat.SubItems.Add((sim.averageTimeOfVehiclesInQueue.GetResult() / 60.0).ToString("F5"));
                        itemLocStat.SubItems.Add("Minute");
                        localStatView.Items.Add(itemLocStat);

                        //Average Count of Free Workers1
                        itemLocStat = new ListViewItem("Average Count of Free Workers1");
                        itemLocStat.SubItems.Add((sim.averageCountOfFreeWorkers1.GetResult()).ToString("F5"));
                        itemLocStat.SubItems.Add("Worker1");
                        localStatView.Items.Add(itemLocStat);

                        //Average Count of Free Workers2
                        itemLocStat = new ListViewItem("Average Count of Free Workers2");
                        itemLocStat.SubItems.Add((sim.averageCountOfFreeWorkers2.GetResult()).ToString("F5"));
                        itemLocStat.SubItems.Add("Worker2");
                        localStatView.Items.Add(itemLocStat);
                    }));
                }
                if (sim.replicationFinished || sim.simulationFinished)
                {

                    if (numberOfReplications <= 1000)
                    {
                        Thread.Sleep(100);
                    }

                    this.Invoke((Action)(() =>
                    {
                        // Update Global Statistics
                        globalStatView.Items.Clear();
                        //finished replications
                        ListViewItem itemLocStat = new ListViewItem("Finished Replications");
                        itemLocStat.SubItems.Add(sim.finishedReplications.ToString());
                        globalStatView.Items.Add(itemLocStat);

                        //Simulation Time xxx Not Displaying
                        itemLocStat = new ListViewItem();
                        globalStatView.Items.Add(itemLocStat);

                        // Count of Finished Vehicles
                        itemLocStat = new ListViewItem("Average Count of Finished Vehicles");
                        itemLocStat.SubItems.Add(sim.globalAverageFinishedVehicles.GetResult().ToString("F5"));
                        itemLocStat.SubItems.Add("Vehicle");
                        globalStatView.Items.Add(itemLocStat);

                        // Average count of Vehicles in the End
                        itemLocStat = new ListViewItem("Average Count of Vehicles in the End");
                        itemLocStat.SubItems.Add(sim.globalAverageLeftVehiclesInSystem.GetResult().ToString());
                        itemLocStat.SubItems.Add("Vehicle");
                        globalStatView.Items.Add(itemLocStat);

                        // Average Count of Vehicles System
                        itemLocStat = new ListViewItem("Average Count of Vehicles in System");
                        itemLocStat.SubItems.Add(sim.globalAverageCountOfVehiclesInSystem.GetResult().ToString("F5"));
                        itemLocStat.SubItems.Add("Vehicle");
                        var listCI = sim.globalAverageCountOfVehiclesInSystem.getConfidenceInterval(95);
                        itemLocStat.SubItems.Add("95%");
                        itemLocStat.SubItems.Add("< " + (listCI[0]).ToString("F5"));
                        itemLocStat.SubItems.Add((listCI[1]).ToString("F5") + " >");

                        globalStatView.Items.Add(itemLocStat);

                        // Average Time of Vehicles in System
                        itemLocStat = new ListViewItem("Average Time of Vehicles in System");
                        itemLocStat.SubItems.Add((sim.globalAverageTimeOfVehiclesInSystem.GetResult() / 60.0).ToString("F5"));
                        itemLocStat.SubItems.Add("Minute");
                        listCI = sim.globalAverageTimeOfVehiclesInSystem.getConfidenceInterval(90);
                        itemLocStat.SubItems.Add("90%");
                        itemLocStat.SubItems.Add("< " + (listCI[0] / 60.0).ToString("F5"));
                        itemLocStat.SubItems.Add((listCI[1] / 60.0).ToString("F5") + " >");

                        globalStatView.Items.Add(itemLocStat);

                        //Average Count of Vehicle in Queue
                        itemLocStat = new ListViewItem("Average Count of Vehicles in Queue");
                        itemLocStat.SubItems.Add(sim.globalAverageCountOfVehiclesInQueue.GetResult().ToString("F5"));
                        itemLocStat.SubItems.Add("Vehicle");
                        globalStatView.Items.Add(itemLocStat);

                        //Average Time of Vehicle in Queue
                        itemLocStat = new ListViewItem("Average Time of Vehicles in Queue");
                        itemLocStat.SubItems.Add((sim.globalAverageTimeOfVehiclesInQueue.GetResult() / 60.0).ToString("F5"));
                        itemLocStat.SubItems.Add("Minute");
                        globalStatView.Items.Add(itemLocStat);

                        //Average Count of Free Workers1
                        itemLocStat = new ListViewItem("Average Count of Free Workers1");
                        itemLocStat.SubItems.Add((sim.globalAverageCountOfFreeWorkers1.GetResult()).ToString("F5"));
                        itemLocStat.SubItems.Add("Worker1");
                        globalStatView.Items.Add(itemLocStat);

                        //Average Count of Free Workers2
                        itemLocStat = new ListViewItem("Average Count of Free Workers2");
                        itemLocStat.SubItems.Add((sim.globalAverageCountOfFreeWorkers2.GetResult()).ToString("F5"));
                        itemLocStat.SubItems.Add("Worker2");
                        globalStatView.Items.Add(itemLocStat);

                    }));
                }
                this.Invoke((Action)(() =>
                {
                    statusLabel.Text = new string("Status: Simulation is Running");
                }));
            };

            // Run the calculate function in a separate thread
            Thread calculateThread = new Thread(() =>
            {
                _simulation.Simulate();
                this.Invoke((Action)(() =>
                {
                    statusLabel.Text = "Status: Simulation Finished";
                    replicationBox.ReadOnly = false;
                    workers1Box.ReadOnly = false;
                    workers2Box.ReadOnly = false;
                    _simulation = null;
                }));

            });

            // Simulation run Start
            calculateThread.Start();
            statusLabel.Text = "Status: Simulation is Running";
            replicationBox.ReadOnly = true;
            workers1Box.ReadOnly = true;
            workers2Box.ReadOnly = true;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_simulation != null)
            {
                var sim = (STKSimulation)_simulation;
                sim.PausePlayReplicationRun();
                simulationIsPaused = !simulationIsPaused;
                if (simulationIsPaused)
                {
                    statusLabel.Text = "Status: Simulation is Paused";
                }
                else
                {
                    statusLabel.Text = "Status: Simulation is Running";
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_simulation != null)
            {
                var sim = (STKSimulation)_simulation;
                sim.SlowModeTurnOnOff();
            }

            slowModeOn = slowModeCheck.Checked;
            if (slowModeOn)
            {
                slowModeGroup.Visible = true;
                slowModeGroup.Enabled = true;
            }
            else
            {
                slowModeGroup.Visible = false;
                slowModeGroup.Enabled = false;
            }
        }

        private void stopBut_Click(object sender, EventArgs e)
        {
            if (_simulation != null)
            {
                var sim = (STKSimulation)_simulation;
                sim.StopSimulationRun();
            }
        }

        private void sleepTimeBar_Scroll(object sender, EventArgs e)
        {
            sleepTimeBox.Text = sleepTimeBar.Value.ToString();
            if (_simulation != null)
            {
                var sim = (STKSimulation)_simulation;
                sim.SetSleepOccurranceTime(sleepTimeBar.Value, occuranceTimeBar.Value);
            }
        }

        private void occuranceTimeBar_Scroll(object sender, EventArgs e)
        {
            occuranceTimeBox.Text = occuranceTimeBar.Value.ToString();
            if (_simulation != null)
            {
                var sim = (STKSimulation)_simulation;
                sim.SetSleepOccurranceTime(sleepTimeBar.Value, occuranceTimeBar.Value);
            }
        }

        private async void startButtonCH1_Click(object sender, EventArgs e)
        {
            long numberOfReplications = 0;
            if (!long.TryParse(repBoxCH1.Text, out numberOfReplications))
            {
                statusLabelCH1.Text = "Replications have to be Number!";
                return;
            }

            int numberOfWorkers2 = 0;
            if (!int.TryParse(worker2BoxCH1.Text, out numberOfWorkers2))
            {
                statusLabelCH1.Text = "Workers2 have to be Number!";
                return;
            }

            _viewModelCH1.Reset();
            startButtonCH1.Enabled = false;
            repBoxCH1.Enabled = false;
            worker2BoxCH1.Enabled = false;

            for (int i = 1; i < 16; i++)
            {
                chart1Simulation = new STKSimulation(numberOfReplications, 0,
                false, 0, 0, i, numberOfWorkers2);
                await Task.Run(() =>
                {
                    chart1Simulation.Simulate();
                });
                if (chart1Simulation.simulationStoped)
                {
                    chart1Simulation = null;
                    return;
                }
                var sim = (STKSimulation)chart1Simulation;
                ObservablePoint new_point = new ObservablePoint(i, sim.globalAverageCountOfVehiclesInQueue.GetResult());
                _viewModelCH1.AddPoint(new_point);
            }
            startButtonCH1.Enabled = true;
            repBoxCH1.Enabled = true;
            worker2BoxCH1.Enabled = true;
        }

        private void stopButtonCH1_Click(object sender, EventArgs e)
        {
            if (chart1Simulation != null)
            {
                chart1Simulation.StopSimulationRun();
                startButtonCH1.Enabled = true;
                repBoxCH1.Enabled = true;
                worker2BoxCH1.Enabled = true;
            }
        }

        private async void startButtonCH2_Click(object sender, EventArgs e)
        {
            long numberOfReplications = 0;
            if (!long.TryParse(repBoxCH2.Text, out numberOfReplications))
            {
                statusLabelCH2.Text = "Replications have to be Number!";
                return;
            }

            int numberOfWorkers1 = 0;
            if (!int.TryParse(worker1BoxCH2.Text, out numberOfWorkers1))
            {
                statusLabelCH2.Text = "Workers2 have to be Number!";
                return;
            }

            _viewModelCH2.Reset();
            startButtonCH2.Enabled = false;
            repBoxCH2.Enabled = false;
            worker1BoxCH2.Enabled = false;

            for (int i = 10; i < 26; i++)
            {
                chart2Simulation = new STKSimulation(numberOfReplications, 0,
                false, 0, 0, numberOfWorkers1, i);
                await Task.Run(() =>
                {
                    chart2Simulation.Simulate();
                });
                if (chart2Simulation.simulationStoped)
                {
                    chart2Simulation = null;
                    return;
                }
                var sim = (STKSimulation)chart2Simulation;
                ObservablePoint new_point = new ObservablePoint(i, sim.globalAverageTimeOfVehiclesInSystem.GetResult() / 60.0);
                _viewModelCH2.AddPoint(new_point);
            }

            startButtonCH2.Enabled = true;
            repBoxCH2.Enabled = true;
            worker1BoxCH2.Enabled = true;
        }

        private void stopButtonCH2_Click(object sender, EventArgs e)
        {
            if (chart2Simulation != null)
            {
                chart2Simulation.StopSimulationRun();
                startButtonCH2.Enabled = true;
                repBoxCH2.Enabled = true;
                worker1BoxCH2.Enabled = true;
            }
        }
    }
}