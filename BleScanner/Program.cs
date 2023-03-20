using System.Text;
using Windows.Devices.Bluetooth.Advertisement;

var watcher = new BluetoothLEAdvertisementWatcher
{
    ScanningMode = BluetoothLEScanningMode.Active
};
watcher.Received += (sender, args) =>
{
    var line = new StringBuilder();
    line.Append(args.Timestamp.ToString("HH:mm:ss.ffff"));
    line.Append("  ");
    line.Append(args.BluetoothAddress.ToString("x12"));
    line.Append("  ");
    line.Append(args.Advertisement.LocalName);
    Console.WriteLine(line.ToString());
};
watcher.Start();
await Task.Delay(30000);
watcher.Stop();
