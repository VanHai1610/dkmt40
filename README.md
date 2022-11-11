# ĐIỀU KHIỂM MÁY TÍNH - Đề tài 40%



Thu thập dữ liệu từ biến tần thông qua Modbus-RTU, dùng OPC-UA để tạo cấu trúc cho dữ liệu đã thu thập được.
- Phiên bản .NET 6.
- WPF
- Thư viện OPC-UA: [UA-.NETStandard](https://github.com/OPCFoundation/UA-.NETStandard "UA-.NETStandard").
- Thư viện Modbus: [NMmodbus4](https://github.com/NModbus4/NModbus4 "NMmodbus4").


## Thông tin.

- File gốc [MainWindow.xaml.cs][1]
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/MainWindow.xaml.cs "MainWindow.xaml.cs"
- Cấu trúc của OPC-UA server [ModelDesign.xml][1] 
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/ModelDesign.xml "ModelDesign.xml"
- Cấu trúc của server bằng C# [TripleH.Classes.cs][1]
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/TripleH.Classes.cs "1"
- Thông tin về server [Server.Config.xml][1]
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/Server.Config.xml "1"
- Thông tin về các node của server [TripleH.NodeSet2.xml][1]
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/TripleH.NodeSet2.xml "1"
- Chương trình tạo và quản lý node [TripleHNodeManager.cs][1]
[1]:
https://github.com/codeflac/dkmt40/blob/main/conveyorOpcUaServerWPF/TripleHNodeManager.cs "1"

## Phần mềm
- Visual studio 2022
- Prosys Opc Ua Browser
- Prosys OPC UA Simulation Server
- UA-ModelCompiler
- Modus poll, Modbus slave
