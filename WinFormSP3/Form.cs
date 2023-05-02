using LiveChartsCore.Defaults;
using OSPABA;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.simulation;
using WinFormSP1.Models;

namespace WinFormSP2
{
    public partial class Form : System.Windows.Forms.Form
    {
        public ViewModel _viewModelCH1 = new ViewModel();
        public ViewModel _viewModelCH2 = new ViewModel();

        //premenne pre nacitanie dat z GUI
        private int _numberOfReplications;
        private int _numberOfWorkers1;
        private int _numberOfWorkers2AllVehicles;
        private int _numberOfWorkers2CarVan;

        //Simulacia a jej stav pre synchronizaciu s GUI
        private MySimulation _sim;
        private bool _isRunning = false;
        private bool _isPaused = false;

        private bool _fastMode = false;
        private bool _advancedSimulation = false;
        private bool _strongerCurrentOfVehicles = false;
        public Form()
        {
            InitializeComponent();
            InitializeSim();
            InitializeGui();
            //xxx graphs
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

        private void InitializeSim()
        {
            _sim = new MySimulation();

            _sim = new MySimulation();
            _sim.OnRefreshUI(RefreshUI);
            _sim.OnSimulationWillStart(OnSimulationWillStart);
            _sim.OnReplicationWillStart(OnReplicationWillStart);
            _sim.OnReplicationDidFinish(OnReplicationDidFinish);
            _sim.OnSimulationDidFinish(OnSimulationDidFinish);
        }

        private void RefreshUI(Simulation obj)
        {
            Invoke((System.Action)(() =>
            {

                // Workers1
                var countTrue = 0;
                foreach (var item in _sim.AgentOffice.workers1)
                {
                    if (item.isBusy)
                    {
                        countTrue++;
                    }
                }
                workers1Label.Text = new string("Workers1, Busy: " + countTrue + " / " + _sim.AgentOffice.workers1.Count);

                workers1View.Items.Clear();
                var i = 0;
                foreach (var data in _sim.AgentOffice.workers1)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data.jobType?.ToString());
                    item.SubItems.Add(data.vehicle?.id.ToString());
                    workers1View.Items.Add(item);
                    i++;
                }

                // Workers2 
                countTrue = 0;
                foreach (var item in _sim.AgentGarage.workers2)
                {
                    if (item.isBusy)
                    {
                        countTrue++;
                    }
                }
                workers2Label.Text = new string("Workers2, Busy: " + countTrue + " / " + _sim.AgentGarage.workers2.Count);

                workers2View.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentGarage.workers2)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data.jobType?.ToString());
                    item.SubItems.Add(data.vehicle?.id.ToString());
                    item.SubItems.Add(data.vehicle?.vehicleType.ToString());
                    item.SubItems.Add(data.certificate.ToString());
                    workers2View.Items.Add(item);
                    i++;
                }

                // arived
                arrivedVehiclesView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentOffice.vehicleArrivalQueue)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data._vehicle.id.ToString());
                    item.SubItems.Add(data._vehicle.vehicleType.ToString());
                    var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                    simTime2 = simTime2.AddSeconds(data._vehicle.arrivalTime);
                    item.SubItems.Add(simTime2.ToString("HH:mm:ss"));
                    arrivedVehiclesView.Items.Add(item);
                    i++;
                }

                // taken
                takenVehiclesView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentOffice.takenVehicles)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data.Value.id.ToString());
                    item.SubItems.Add(data.Value.vehicleType.ToString());
                    var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                    simTime2 = simTime2.AddSeconds(data.Value.arrivalTime);
                    item.SubItems.Add(simTime2.ToString("HH:mm:ss"));
                    takenVehiclesView.Items.Add(item);
                    i++;
                }

                // parking
                parkingVehiclesView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentGarage.vehiclesParkingInFrontOfControlQueue)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data._vehicle.id.ToString());
                    item.SubItems.Add(data._vehicle.vehicleType.ToString());
                    var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                    simTime2 = simTime2.AddSeconds(data._vehicle.arrivalTime);
                    item.SubItems.Add(simTime2.ToString("HH:mm:ss"));
                    parkingVehiclesView.Items.Add(item);
                    i++;
                }

                //controlled
                controlledVehiclesView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentGarage.controllingVehicles)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data.Value.id.ToString());
                    item.SubItems.Add(data.Value.vehicleType.ToString());
                    var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                    simTime2 = simTime2.AddSeconds(data.Value.arrivalTime);
                    item.SubItems.Add(simTime2.ToString("HH:mm:ss"));
                    controlledVehiclesView.Items.Add(item);
                    i++;
                }

                //payment queue
                paymentQueueView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentOffice.vehiclePaymentQueue)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(data._vehicle.id.ToString());
                    item.SubItems.Add(data._vehicle.vehicleType.ToString());
                    var simTime2 = new DateTime(1, 1, 1, 9, 0, 0);
                    simTime2 = simTime2.AddSeconds(data._vehicle.arrivalTime);
                    item.SubItems.Add(simTime2.ToString("HH:mm:ss"));
                    paymentQueueView.Items.Add(item);
                    i++;
                }

                //paying vehicles
                payingView.Items.Clear();
                i = 0;
                foreach (var data in _sim.AgentOffice.payingVehicles)
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
                ListViewItem itemLocStat = new ListViewItem("Current Replication");
                itemLocStat.SubItems.Add((_sim.CurrentReplication + 1).ToString());
                localStatView.Items.Add(itemLocStat);

                //Simulation Time
                itemLocStat = new ListViewItem("Simulation Time");
                var simTime = new DateTime(1, 1, 1, 9, 0, 0);
                simTime = simTime.AddSeconds(_sim.CurrentTime);
                itemLocStat.SubItems.Add(simTime.ToString("HH:mm:ss"));
                localStatView.Items.Add(itemLocStat);

                // Count of Finished Vehicles
                itemLocStat = new ListViewItem("Count of Finished Vehicles");
                itemLocStat.SubItems.Add(_sim.AgentOffice.finishedVehicles.ToString());
                itemLocStat.SubItems.Add("Vehicle");
                localStatView.Items.Add(itemLocStat);

                // Average count of Vehicles in the End xxxxx Not Displaying
                itemLocStat = new ListViewItem();
                localStatView.Items.Add(itemLocStat);

                // Average Count of Vehicles in System
                itemLocStat = new ListViewItem("Average Count of Vehicles in System");
                itemLocStat.SubItems.Add(_sim.AgentOffice.averageCountOfVehiclesInSystem.GetResult().ToString("F5"));
                itemLocStat.SubItems.Add("Vehicle");
                localStatView.Items.Add(itemLocStat);

                // Average Time of Vehicles in System
                itemLocStat = new ListViewItem("Average Time of Vehicles in System");
                itemLocStat.SubItems.Add((_sim.AgentOffice.averageTimeOfVehiclesInSystem.GetResult() / 60.0).ToString("F5"));
                itemLocStat.SubItems.Add("Minute");
                localStatView.Items.Add(itemLocStat);

                //Average Count of Vehicle in Queue
                itemLocStat = new ListViewItem("Average Count of Vehicles in Queue");
                itemLocStat.SubItems.Add(_sim.AgentOffice.averageCountOfVehiclesInQueue.GetResult().ToString("F5"));
                itemLocStat.SubItems.Add("Vehicle");
                localStatView.Items.Add(itemLocStat);

                //Average Time of Vehicle in Queue
                itemLocStat = new ListViewItem("Average Time of Vehicles in Queue");
                itemLocStat.SubItems.Add((_sim.AgentOffice.averageTimeOfVehiclesInQueue.GetResult() / 60.0).ToString("F5"));
                itemLocStat.SubItems.Add("Minute");
                localStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers1
                itemLocStat = new ListViewItem("Average Count of Free Workers1");
                itemLocStat.SubItems.Add((_sim.AgentOffice.averageCountOfFreeWorkers1.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker1");
                localStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers2-AllVehicles
                itemLocStat = new ListViewItem("Average Count of Free Workers2-AllVehicles");
                itemLocStat.SubItems.Add((_sim.AgentGarage.averageCountOfFreeWorkers2AllVehicles.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker2");
                localStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers2-CarVans
                itemLocStat = new ListViewItem("Average Count of Free Workers2-CarVans");
                itemLocStat.SubItems.Add((_sim.AgentGarage.averageCountOfFreeWorkers2CarVans.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker2");
                localStatView.Items.Add(itemLocStat);
            }));
        }

        private void OnSimulationWillStart(Simulation obj)
        {
            _isRunning = true;
            _isPaused = false;

            Invoke((System.Action)(() =>
            {
                startBut.Text = "Running";
                startBut.Enabled = false;
                replicationBox.Enabled = false;
                workers1Box.Enabled = false;
                workers2AllBox.Enabled = false;
                workers2CarVanBox.Enabled = false;
                advancedSimulationCheck.Enabled = false;
                strongerCurrentOfVehiclesCheck.Enabled = false;

                salaryWorker1label.Text = "Worker 1 Salary: " + Config.salaryWorker1 +
                    ", " + Config.salaryWorker1 + "*" + Config.numberOfWorkers1 +
                    "= " + Config.salaryWorker1 * Config.numberOfWorkers1;

                salaryWorker2Alllabel.Text = "Worker 2, All Vehicles Certificate, Salary: " + Config.salaryWorker2AllVehicles +
                    ", " + Config.salaryWorker2AllVehicles + "*" + Config.numberOfWorkers2AllVehicles +
                    "= " + Config.salaryWorker2AllVehicles * Config.numberOfWorkers2AllVehicles;

                salaryWorker2CarVanlabel.Text = "Worker 2, Car & Van Certificate, Salary: " + Config.salaryWorker2VanCar +
                    ", " + Config.salaryWorker2VanCar + "*" + Config.numberOfWorkers2VanCar +
                    "= " + Config.salaryWorker2VanCar * Config.numberOfWorkers2VanCar;

                salaryTotallabel.Text = "Total Month Salary: " +
                    (Config.salaryWorker1 * Config.numberOfWorkers1 +
                    Config.salaryWorker2AllVehicles * Config.numberOfWorkers2AllVehicles +
                    Config.salaryWorker2VanCar * Config.numberOfWorkers2VanCar);
            }));
        }

        private void OnReplicationWillStart(Simulation obj)
        {
            SetSimSpeed();
        }

        private void SetSimSpeed()
        {
            int durationValue = -1;
            int intervalValue = -1;

            Invoke((System.Action)(() =>
            {
                durationValue = sleepTimeBar.Value;
            }));

            Invoke((System.Action)(() =>
            {
                intervalValue = occuranceTimeBar.Value;
            }));

            if (!_fastMode)
            {
                _sim.SetSimSpeed(intervalValue, durationValue);
            }
            else
            {
                _sim.SetMaxSimSpeed();
            }
        }

        private void OnReplicationDidFinish(Simulation obj)
        {
            // display local statistics
            UpdateGlobalStats();
        }
        private void UpdateGlobalStats()
        {
            Invoke((System.Action)(() =>
            {
                // Update Global Statistics
                globalStatView.Items.Clear();
                //finished replications
                ListViewItem itemLocStat = new ListViewItem("Finished Replications");
                itemLocStat.SubItems.Add((_sim.CurrentReplication + 1).ToString());
                globalStatView.Items.Add(itemLocStat);

                //Simulation Time xxx Not Displaying
                itemLocStat = new ListViewItem();
                globalStatView.Items.Add(itemLocStat);

                // Count of Finished Vehicles
                itemLocStat = new ListViewItem("Average Count of Finished Vehicles");
                itemLocStat.SubItems.Add(_sim.globalAverageFinishedVehicles.GetResult().ToString("F5"));
                itemLocStat.SubItems.Add("Vehicle");
                globalStatView.Items.Add(itemLocStat);

                // Average count of Vehicles in the End
                itemLocStat = new ListViewItem("Average Count of Vehicles in the End");
                itemLocStat.SubItems.Add(_sim.globalAverageLeftVehiclesInSystem.GetResult().ToString());
                itemLocStat.SubItems.Add("Vehicle");
                globalStatView.Items.Add(itemLocStat);

                // Average Count of Vehicles System
                itemLocStat = new ListViewItem("Average Count of Vehicles in System");
                itemLocStat.SubItems.Add(_sim.globalAverageCountOfVehiclesInSystem.GetResult().ToString("F5"));
                itemLocStat.SubItems.Add("Vehicle");
                var listCI = _sim.globalAverageCountOfVehiclesInSystem.getConfidenceInterval(95);
                itemLocStat.SubItems.Add("95%");
                itemLocStat.SubItems.Add("< " + (listCI[0]).ToString("F5"));
                itemLocStat.SubItems.Add((listCI[1]).ToString("F5") + " >");
                globalStatView.Items.Add(itemLocStat);

                // Average Time of Vehicles in System
                itemLocStat = new ListViewItem("Average Time of Vehicles in System");
                itemLocStat.SubItems.Add((_sim.globalAverageTimeOfVehiclesInSystem.GetResult() / 60.0).ToString("F5"));
                itemLocStat.SubItems.Add("Minute");
                listCI = _sim.globalAverageTimeOfVehiclesInSystem.getConfidenceInterval(90);
                itemLocStat.SubItems.Add("90%");
                itemLocStat.SubItems.Add("< " + (listCI[0] / 60.0).ToString("F5"));
                itemLocStat.SubItems.Add((listCI[1] / 60.0).ToString("F5") + " >");
                globalStatView.Items.Add(itemLocStat);

                //Average Count of Vehicle in Queue
                itemLocStat = new ListViewItem("Average Count of Vehicles in Queue");
                itemLocStat.SubItems.Add(_sim.globalAverageCountOfVehiclesInQueue.GetResult().ToString("F5"));
                itemLocStat.SubItems.Add("Vehicle");
                globalStatView.Items.Add(itemLocStat);

                //Average Time of Vehicle in Queue
                itemLocStat = new ListViewItem("Average Time of Vehicles in Queue");
                itemLocStat.SubItems.Add((_sim.globalAverageTimeOfVehiclesInQueue.GetResult() / 60.0).ToString("F5"));
                itemLocStat.SubItems.Add("Minute");
                globalStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers1
                itemLocStat = new ListViewItem("Average Count of Free Workers1");
                itemLocStat.SubItems.Add((_sim.globalAverageCountOfFreeWorkers1.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker1");
                globalStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers2-AllVehicles
                itemLocStat = new ListViewItem("Average Count of Free Workers2-AllVehicles");
                itemLocStat.SubItems.Add((_sim.globalAverageCountOfFreeWorkers2AllVehicles.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker2");
                globalStatView.Items.Add(itemLocStat);

                //Average Count of Free Workers2-CarVans
                itemLocStat = new ListViewItem("Average Count of Free Workers2-CarVans");
                itemLocStat.SubItems.Add((_sim.globalAverageCountOfFreeWorkers2CarVans.GetResult()).ToString("F5"));
                itemLocStat.SubItems.Add("Worker2");
                globalStatView.Items.Add(itemLocStat);

            }));
        }

        private void OnSimulationDidFinish(Simulation obj)
        {
            _isRunning = false;
            _isPaused = false;
            Invoke((System.Action)(() =>
            {
                startBut.Text = "Start";
                startBut.Enabled = true;
                replicationBox.Enabled = true;
                workers1Box.Enabled = true;
                workers2AllBox.Enabled = true;
                workers2CarVanBox.Enabled = true;
                advancedSimulationCheck.Enabled = true;
                strongerCurrentOfVehiclesCheck.Enabled = true;
            }));
        }


        private void fastModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            _fastMode = fastModeCheck.Checked;
            SetSimSpeed();
            slowModeGroup.Visible = !slowModeGroup.Visible;
        }

        private void InitializeGui()
        {
            workers2CarVanBox.Enabled = false;
            workers2CarVanBox.Visible = false;
            workers2CarVanLabel.Enabled = false;
            workers2CarVanLabel.Visible = false;

            salaryWorker1label.Text = "Worker 1 Salary: ";
            salaryWorker2Alllabel.Text = "Worker 2, All Vehicles Certificate, Salary: ";
            salaryWorker2CarVanlabel.Text = "Worker 2, Car & Van Certificate, Salary: ";
            salaryTotallabel.Text = "Total Month Salary: ";

            strongerCurrentOfVehiclesCheck.Enabled = false;
            strongerCurrentOfVehiclesCheck.Visible = false;

            strongerCurrentOfVehiclesLabel.Enabled = false;
            strongerCurrentOfVehiclesLabel.Visible = false;
        }

        private void startBut_Click(object sender, EventArgs e)
        {
            if (!_isRunning) // start
            {
                if (!ReadInputParameters()) return;
                Config.numberOfReplications = _numberOfReplications;
                Config.numberOfWorkers1 = _numberOfWorkers1;
                Config.numberOfWorkers2AllVehicles = _numberOfWorkers2AllVehicles;

                Config.advancedSimulation = _advancedSimulation;
                if (_advancedSimulation)
                {
                    if (!ReadAdvancedInputParameters()) return;
                    Config.numberOfWorkers2VanCar = _numberOfWorkers2CarVan;
                    Config.strongerCurrentOfVehicles = _strongerCurrentOfVehicles;
                }
                else
                {
                    Config.numberOfWorkers2VanCar = 0;
                    Config.strongerCurrentOfVehicles = false;
                }

                _isRunning = true;
                _sim.SimulateAsync(Config.numberOfReplications, Config.simulationTime);
            }
        }

        private bool ReadAdvancedInputParameters()
        {
            //Workers2CarVan
            if (!int.TryParse(workers2CarVanBox.Text, out _numberOfWorkers2CarVan))
            {
                statusLabel.Text = "Status: Workers1 have to be Number!";
                return false;
            }
            if (_numberOfWorkers2CarVan < 0)
            {
                statusLabel.Text = "Status: There have to be more than -1 Workers2CarVan";
                return false;
            }

            _strongerCurrentOfVehicles = strongerCurrentOfVehiclesCheck.Checked;
            return true;
        }

        private bool ReadInputParameters()
        {
            //Reps
            if (!int.TryParse(replicationBox.Text, out _numberOfReplications))
            {
                statusLabel.Text = "Status: Replications have to be Number!";
                return false;
            }
            if (_numberOfReplications <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Replications";
                return false;
            }

            //Workers1           
            if (!int.TryParse(workers1Box.Text, out _numberOfWorkers1))
            {
                statusLabel.Text = "Status: Workers1 have to be Number!";
                return false;
            }
            if (_numberOfWorkers1 <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Workers1";
                return false;
            }

            //Workers2All
            if (!int.TryParse(workers2AllBox.Text, out _numberOfWorkers2AllVehicles))
            {
                statusLabel.Text = "Status: Workers1 have to be Number!";
                return false;
            }
            if (_numberOfWorkers2AllVehicles <= 0)
            {
                statusLabel.Text = "Status: There have to be more than 0 Workers2AllVehicles";
                return false;
            }
            return true;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                if (!_isPaused) // pause
                {
                    _isPaused = true;
                    _sim.PauseSimulation();
                    pauseButton.Text = "Play";
                }
                else // resume
                {
                    _isPaused = false;
                    _sim.ResumeSimulation();
                    pauseButton.Text = "Pause";
                }
            }
        }

        private void stopBut_Click(object sender, EventArgs e)
        {
            if (_isRunning) // stop
            {
                _sim.StopSimulation();
            }
        }

        private void sleepTimeBar_Scroll(object sender, EventArgs e)
        {
            SetSimSpeed();
        }

        private void occuranceTimeBar_Scroll(object sender, EventArgs e)
        {
            SetSimSpeed();
        }

        private void advancedSimulationCheck_CheckedChanged(object sender, EventArgs e)
        {
            _advancedSimulation = advancedSimulationCheck.Checked;
            workers2CarVanBox.Enabled = advancedSimulationCheck.Checked;
            workers2CarVanBox.Visible = advancedSimulationCheck.Checked;
            workers2CarVanLabel.Enabled = advancedSimulationCheck.Checked;
            workers2CarVanLabel.Visible = advancedSimulationCheck.Checked;
            if (advancedSimulationCheck.Checked == false)
            {
                strongerCurrentOfVehiclesCheck.Checked = false;
                strongerCurrentOfVehiclesCheck.Enabled = false;
                strongerCurrentOfVehiclesCheck.Visible = false;

                strongerCurrentOfVehiclesLabel.Enabled = false;
                strongerCurrentOfVehiclesLabel.Visible = false;
            }
            else
            {
                strongerCurrentOfVehiclesCheck.Enabled = true;
                strongerCurrentOfVehiclesCheck.Visible = true;

                strongerCurrentOfVehiclesLabel.Enabled = true;
                strongerCurrentOfVehiclesLabel.Visible = true;
            }
        }

        private void fastModeCheck_CheckStateChanged(object sender, EventArgs e)
        {
            _fastMode = fastModeCheck.Checked;
            if (_sim != null)
            {
                SetSimSpeed();
            }
            slowModeGroup.Visible = !slowModeGroup.Visible;
        }

        // Charts Tabs Controll Buttons
        private async void startButtonCH1_Click(object sender, EventArgs e)
        {

        }

        private void stopButtonCH1_Click(object sender, EventArgs e)
        {

        }

        private async void startButtonCH2_Click(object sender, EventArgs e)
        {

        }

        private void stopButtonCH2_Click(object sender, EventArgs e)
        {

        }
    }
}