using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTArduino.Models
{
    public class BTDevice
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BluetoothDeviceInfo DeviceInfo { get; set; }
    }
}
