using BTArduino.Models;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Plugin.BLE;
using Plugin.BluetoothClassic.Abstractions;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace BTArduino
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public List<BTDevice> Devices { get; set; }

        private async void RequestPermissions()
        {
            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        public MainPage()
        {
            InitializeComponent();

            var devices = new List<BTDevice> {
                new BTDevice { Name = "1", Description = "d1"},
                new BTDevice { Name = "2", Description = "d2"},
                new BTDevice { Name = "3", Description = "d3"}
            };

            btDevices.ItemsSource = devices;
            btState.Text = "Undefined";
            //RequestPermissions();
            //BindingContext = this;

        }

        private async void ScanBLE()
        {
            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            var deviceList = new List<Plugin.BLE.Abstractions.Contracts.IDevice>();
            adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            PermissionStatus status = await Permissions.RequestAsync<Permissions.Bluetooth>();
            await adapter.StartScanningForDevicesAsync();

        }

        private async void OnScanButtonCliked(object sender, EventArgs e)
        {

            //PermissionStatus status = await Permissions.RequestAsync<Permissions.Bluetooth>();

            BluetoothClient client = new BluetoothClient();
            var devices = client.DiscoverDevices();
            var tmpDevices = new List<BTDevice>();

            foreach (var device in devices)
            {
                tmpDevices.Add(new BTDevice() { Name = device.DeviceName, Description = device.DeviceName, DeviceInfo = device });
            }

            btDevices.ItemsSource = tmpDevices;

            btState.Text = "";//ble.State.ToString();
        }

        private async void OnConnectButtonCliked(object sender, EventArgs e)
        {
            var selectedDevice = btDevices.SelectedItem as BTDevice;
            BluetoothClient client = new BluetoothClient();

            if (selectedDevice != null)
            {
                if (!selectedDevice.DeviceInfo.Authenticated)
                {
                    bool paired = BluetoothSecurity.PairRequest(selectedDevice.DeviceInfo.DeviceAddress, null);
                    await Task.Delay(1000);
                }
            }
        }


        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
