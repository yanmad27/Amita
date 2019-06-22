using System;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Diagnostics;
using LowLevelHooks.Keyboard;
using WindowsInput;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Configuration;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Linq;

namespace AutoBuff
{
    public partial class Form1 : Form
    {
        bool authentication;
        const int time = 50;    //milisecond
        WindowsInput.Native.VirtualKeyCode key_canhan, key_doi, key_huy, key_call, key_5;
        Keys huy_key, call_key, scan_key;
        bool stop = true, stopScan = true, isScaning = false, isRunning = false, enable = true;
        string pause;
        List<Point> listLocation = new List<Point>();
        bool bw1Wait = false;
        private LowLevelHooks.Keyboard.KeyboardHook kHook;
        private InputSimulator inputSimulator = new InputSimulator();

        BackgroundWorker backgroundWorker1, bwCall, scanWorker;
        int positionPartner;
        bool call = false;

        public Form1()
        {
            InitializeComponent();

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

            scanWorker = new BackgroundWorker();
            scanWorker.WorkerSupportsCancellation = true;

            scanWorker.DoWork += ScanWorker_DoWork;


            //bwCall = new BackgroundWorker();
            //bwCall.WorkerSupportsCancellation = true;

            // bwCall.DoWork += BwCall_DoWork;
            //bwCall.RunWorkerCompleted += BwCall_RunWorkerCompleted;

        }

        private void ScanWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
              
                inputSimulator.Keyboard.KeyDown(key_5);
                Thread.Sleep(time);
                inputSimulator.Keyboard.KeyUp(key_5);
                Thread.Sleep(3050);
            }
            while (stopScan ==false);
        }



        private void BwCall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isRunning)
            if (!backgroundWorker1.IsBusy)
            {
                    backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BwCall_DoWork(object sender, DoWorkEventArgs e)
        {
            AutoCall(positionPartner);
            bw1Wait = false;
        }

        bool Authenticate()
        {
            var mac = GetDefaultMacAddress();
            var pcname = System.Environment.MachineName;

            using (var db = new AMITA_DATABASEEntities())
            {
                var select = (from t in db.ALLOWs where t.MacAddress == mac && pcname == t.PCName select t).SingleOrDefault();
                if (select == null)
                {
                    XAIKEMADEOXINPHEP tmp = new XAIKEMADEOXINPHEP() { MacAddress = mac, PCName = pcname };
                    var select1 = (from t in db.XAIKEMADEOXINPHEPs where t.MacAddress == mac && pcname == t.PCName select t).SingleOrDefault();
                    if (select1 == null)
                    {
                        db.XAIKEMADEOXINPHEPs.Add(tmp);
                        db.SaveChanges();
                    }
                    return false;
                }
            }

            return true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " - Ver ";
            this.Text += new FileInfo(Application.ExecutablePath).LastWriteTime.ToString("yyMMdd");
            if (!Authenticate())
            {
                MessageBox.Show("Error!");
                Close();
            }

            try
            {


                cbbCaNhan.SelectedIndex = Properties.Settings.Default.CaNhan;
                cbbDoi.SelectedIndex = Properties.Settings.Default.Doi;
                cbbHuy.SelectedIndex = Properties.Settings.Default.Huy;
                cbbCall.SelectedIndex = Properties.Settings.Default.Call;
                cbbScan.SelectedIndex = Properties.Settings.Default.Scan;


                kHook = new LowLevelHooks.Keyboard.KeyboardHook();
                kHook.KeyDown += KHook_KeyDown;
                kHook.Hook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void KHook_KeyDown(object sender, KeyboardHookEventArgs e)
        {
            //if (bwCall.IsBusy)
            //return;
            if (enable == true)
            {
                if ((e.Key == Keys.Q) && isRunning == false)
                {
                    isRunning = true;
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    return;
                }
                else if ((e.Key == Keys.Q) && isRunning == true)
                {
                    isRunning = false;
                    if (backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.CancelAsync();
                    }
                }

                if (e.Key == Keys.E)
                {
                    stop = !stop;
                }
                if (isRunning)
                {
                    if (e.Key == huy_key)
                    {
                        pause = "Huy";
                    //    //if (backgroundWorker1.IsBusy)
                    //    //{
                    //    //    backgroundWorker1.CancelAsync();
                    //    //}
                    //    //////Press '~'
                    //    //inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.OEM_3);
                    //    //Thread.Sleep(time);
                    //    //inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.OEM_3);

                    //    //Thread.Sleep(1000);
                    //    //if (!backgroundWorker1.IsBusy)
                    //    //{
                    //    //    backgroundWorker1.RunWorkerAsync();
                    //    //}
                    //    //return;
                    }
                    else if (e.Key == call_key)
                    {
                        pause = "Call";

                    //    //if (backgroundWorker1.IsBusy)
                    //    //{
                    //    //    backgroundWorker1.CancelAsync();
                    //    //}
                    //    //////Press '~'
                    //    //inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.OEM_3);
                    //    //Thread.Sleep(time);
                    //    //inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.OEM_3);

                    //    //Thread.Sleep(1000);
                    //    //if (!backgroundWorker1.IsBusy)
                    //    //{
                    //    //    backgroundWorker1.RunWorkerAsync();
                    //    //}
                    //    //return;
                    }
                }

                //if (e.Key == Keys.G)
                //{
                //    if (scanWorker.IsBusy)
                //    {
                //        stopScan = true;
                //    }
                //    else
                //    {
                //        scanWorker.RunWorkerAsync();
                //        stopScan = false;
                //    }
                //}

            }

            if (e.Key == Keys.RControlKey)
            {
                enable = !enable;
                if (isRunning == true)
                {
                    if (backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.CancelAsync();
                    }
                    isRunning = false;
                    stop = true;
                }
                if (isScaning == true)
                {
                    stopScan = false;
                }
            }
            //if (isSetLocation && e.Key == Keys.P)
            //{
            //    if (listLocation.Count <5)
            //    {
            //        Point tmp = new Point(Cursor.Position.X, Cursor.Position.Y);
            //        listLocation.Add(tmp);
            //    }
            //    if (listLocation.Count ==5)
            //    {
            //        btnSetPartnerLocation.Enabled = true;
            //        btnSetPartnerLocation.Text = "Set Call";
            //        isSetLocation = false;
            //    }
                        
            //}
            //if (e.Key == Keys.NumPad1 || e.Key == Keys.NumPad2 || e.Key == Keys.NumPad3 || e.Key == Keys.NumPad4 || e.Key == Keys.NumPad5)
            //{
            //    switch (e.Key)
            //    {
            //        case Keys.NumPad1:
            //            positionPartner = 1;
            //            break;
            //        case Keys.NumPad2:
            //            positionPartner = 2;
            //            break;
            //        case Keys.NumPad3:
            //            positionPartner = 3;
            //            break;
            //        case Keys.NumPad4:
            //            positionPartner = 4;
            //            break;
            //        case Keys.NumPad5:
            //            positionPartner = 5;
            //            break;
            //    }
            //    backgroundWorker1.CancelAsync();
            //    if (!bwCall.IsBusy)
            //    {
            //        bwCall.RunWorkerAsync();
            //    }                                                  2`3
            //}                             `2`
        }


        //chạy auto buff
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                if (pause == "Huy" )
                {
                    Press_1(key_huy);
                    Press_1(key_huy);
                    Press_1(key_huy);
                    Thread.Sleep(1500);
                    pause = "";
                }
                else if (pause == "Call")
                {
                    Press_1(key_call);
                    Press_1(key_call);
                    Press_1(key_call);
                    Thread.Sleep(1500);
                    pause = "";
                }
                Press_1(key_canhan);
                Thread.Sleep(350);
                Press_2(key_doi);
                Thread.Sleep(800);
            }
            while (stop == false);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.CaNhan = cbbCaNhan.SelectedIndex;
            Properties.Settings.Default.Doi = cbbDoi.SelectedIndex;
            Properties.Settings.Default.Huy = cbbHuy.SelectedIndex;
            Properties.Settings.Default.Scan = cbbScan.SelectedIndex;
            Properties.Settings.Default.Call = cbbCall.SelectedIndex;
            Properties.Settings.Default.Save();

        }






        //sau khi dừng auto buff
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isRunning = false;
        }

        private void Press_1(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                //Press '1'
                inputSimulator.Keyboard.KeyDown(key);
                Thread.Sleep(time);
                inputSimulator.Keyboard.KeyUp(key);

                ////Press '~'
                inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.OEM_3);
                Thread.Sleep(time);
                inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.OEM_3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbCaNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbCaNhan.SelectedIndex)
            {
                case 0:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_1;
                    return;
                case 1:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_2;
                    return;
                case 2:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_3;
                    return;
                case 3:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_4;
                    return;
                case 4:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_5;
                    return;
                case 5:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_6;
                    return;
                case 6:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_7;
                    return;
                case 7:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_8;
                    return;
                case 8:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_9;
                    return;
                case 9:
                    key_canhan = WindowsInput.Native.VirtualKeyCode.VK_0;
                    return;
            }
        }

        private void cbbDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbDoi.SelectedIndex)
            {
                case 0:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_1;
                    return;
                case 1:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_2;
                    return;
                case 2:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_3;
                    return;
                case 3:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_4;
                    return;
                case 4:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_5;
                    return;
                case 5:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_6;
                    return;
                case 6:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_7;
                    return;
                case 7:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_8;
                    return;
                case 8:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_9;
                    return;
                case 9:
                    key_doi = WindowsInput.Native.VirtualKeyCode.VK_0;
                    return;
            }
        }

        bool isSetLocation = false;
        private void btnSetPartnerLocation_Click(object sender, EventArgs e)
        {
            btnSetPartnerLocation.Enabled = false;
            isSetLocation = true;
            listLocation.Clear();
            btnSetPartnerLocation.Text = "Setting";
        }

        private void cbbHuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbHuy.SelectedIndex)
            {
                case 0:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_1;
                    huy_key = Keys.D1;
                    return;
                case 1:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_2;
                    huy_key = Keys.D2;
                    return;
                case 2:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_3;
                    huy_key = Keys.D3;
                    return;
                case 3:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_4;
                    huy_key = Keys.D4;
                    return;
                case 4:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_5;
                    huy_key = Keys.D5;
                    return;
                case 5:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_6;
                    huy_key = Keys.D6;
                    return;
                case 6:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_7;
                    huy_key = Keys.D7;
                    return;
                case 7:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_8;
                    huy_key = Keys.D8;
                    return;
                case 8:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_9;
                    huy_key = Keys.D9;
                    return;
                case 9:
                    key_huy = WindowsInput.Native.VirtualKeyCode.VK_0;
                    huy_key = Keys.D0;
                    return;
            }
        }

        private void cbbCall_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbCall.SelectedIndex)
            {
                case 0:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_1;
                    call_key = Keys.D1;
                    return;
                case 1:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_2;
                    call_key = Keys.D2;
                    return;
                case 2:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_3;
                    call_key = Keys.D3;
                    return;
                case 3:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_4;
                    call_key = Keys.D4;
                    return;
                case 4:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_5;
                    call_key = Keys.D5;
                    return;
                case 5:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_6;
                    call_key = Keys.D6;
                    return;
                case 6:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_7;
                    call_key = Keys.D7;
                    return;
                case 7:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_8;
                    call_key = Keys.D8;
                    return;
                case 8:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_9;
                    call_key = Keys.D9;
                    return;
                case 9:
                    key_call = WindowsInput.Native.VirtualKeyCode.VK_0;
                    call_key = Keys.D0;
                    return;
            }
        }

        private void cbbScan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbScan.SelectedIndex)
            {
                case 0:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_1;
                    scan_key = Keys.D1;
                    return;
                case 1:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_2;
                    scan_key = Keys.D2;
                    return;
                case 2:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_3;
                    scan_key = Keys.D3;
                    return;
                case 3:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_4;
                    scan_key = Keys.D4;
                    return;
                case 4:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_5;
                    scan_key = Keys.D5;
                    return;
                case 5:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_6;
                    scan_key = Keys.D6;
                    return;
                case 6:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_7;
                    scan_key = Keys.D7;
                    return;
                case 7:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_8;
                    scan_key = Keys.D8;
                    return;
                case 8:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_9;
                    scan_key = Keys.D9;
                    return;
                case 9:
                    key_5 = WindowsInput.Native.VirtualKeyCode.VK_0;
                    scan_key = Keys.D0;
                    return;
            }
        }

        private void Press_2(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                ////Press '2'
                inputSimulator.Keyboard.KeyDown(key);
                Thread.Sleep(time);
                inputSimulator.Keyboard.KeyUp(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        void AutoCall(int positionPartner)
        {
            if (listLocation.Count != 5)
                return;
            Point currentCursor = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point locationParner = listLocation[positionPartner-1];

            Press_2(key_call);
            Cursor.Position = locationParner;
            inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(15);
            Cursor.Position = currentCursor;

        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            //    cbbCaNhan.Enabled = false;
            //    cbbDoi.Enabled = false;
            //    SaveFlag = true;

            //    //key_canhan
            //    switch(cbbCaNhan.Text)
            //    {
            //        case "1":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_1;
            //            return;
            //        case "2":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_2;
            //            return;
            //        case "3":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_3;
            //            return;
            //        case "4":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_4;
            //            return;
            //        case "5":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_5;
            //            return;
            //        case "6":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_6;
            //            return;
            //        case "7":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_7;
            //            return;
            //        case "8":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_8;
            //            return;
            //        case "9":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_9;
            //            return;
            //        case "0":
            //            key_canhan = WindowsInput.Native.VirtualKeyCode.VK_0;
            //            return;
            //    }

            //    //key_doi
            //    switch (cbbDoi.Text)
            //    {
            //        case "1":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_1;
            //            return;
            //        case "2":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_2;
            //            return;
            //        case "3":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_3;
            //            return;
            //        case "4":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_4;
            //            return;
            //        case "5":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_5;
            //            return;
            //        case "6":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_6;
            //            return;
            //        case "7":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_7;
            //            return;
            //        case "8":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_8;
            //            return;
            //        case "9":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_9;
            //            return;
            //        case "0":
            //            key_doi = WindowsInput.Native.VirtualKeyCode.VK_0;
            //            return;
            //    }
        }

         string GetDefaultMacAddress()
        {
            Dictionary<string, long> macAddresses = new Dictionary<string, long>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                    macAddresses[nic.GetPhysicalAddress().ToString()] = nic.GetIPStatistics().BytesSent + nic.GetIPStatistics().BytesReceived;
            }
            long maxValue = 0;
            string mac = "";
            foreach (KeyValuePair<string, long> pair in macAddresses)
            {
                if (pair.Value > maxValue)
                {
                    mac = pair.Key;
                    maxValue = pair.Value;
                }
            }
            return mac;
        }


    }
}
