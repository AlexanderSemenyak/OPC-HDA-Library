# OPC-HDA-Library
Free .Net OPC Historical Data Access Library

OPC Core components:
https://opcfoundation.org/developer-tools/samples-and-tools-classic/core-components/


## Sample code
```csharp
var client = new HdaClient("localhost", "Matrikon.OPC.Simulation.1");
System.Console.WriteLine($"{client.HdaServer.Host}");
System.Console.WriteLine($"{client.HdaServer.ServerName}");
System.Console.WriteLine($"Server connected: {client.HdaServer.Connected}");

System.Console.WriteLine();
var node = client.Browse();
System.Console.WriteLine("Browse: ");
System.Console.WriteLine(node + Environment.NewLine);
System.Console.WriteLine("Available servers: ");
foreach (var availableServer in HdaUtils.GetAvailableServers("localhost"))
{
    System.Console.WriteLine(availableServer.ServerName);
}

System.Console.WriteLine();
var tag = "AliasTest.testNew";
System.Console.WriteLine($"Rading tag {tag} from {client.HdaServer.Url}:");
var dt = DateTime.Now;
var readRes = client.ReadRaw(tag, dt - TimeSpan.FromSeconds(20), dt);
foreach (var keyValuePair in readRes)
{
    System.Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
}
```

## Output
```
localhost
Matrikon.OPC.Simulation.1
Server connected: True

Browse:
Name: Root, Address: , IsItem: False
   Name: Simulation Items, Address: Simulation Items¥, IsItem: False
      Name: Bucket Brigade, Address: Bucket Brigade, IsItem: False
         Name: ArrayOfReal8, Address: Bucket Brigade.ArrayOfReal8, IsItem: True
         Name: ArrayOfString, Address: Bucket Brigade.ArrayOfString, IsItem: True
         Name: Boolean, Address: Bucket Brigade.Boolean, IsItem: True
         Name: Int1, Address: Bucket Brigade.Int1, IsItem: True
         Name: Int2, Address: Bucket Brigade.Int2, IsItem: True
         Name: Int4, Address: Bucket Brigade.Int4, IsItem: True
         Name: Money, Address: Bucket Brigade.Money, IsItem: True
         Name: Real4, Address: Bucket Brigade.Real4, IsItem: True
         Name: Real8, Address: Bucket Brigade.Real8, IsItem: True
         Name: String, Address: Bucket Brigade.String, IsItem: True
         Name: Time, Address: Bucket Brigade.Time, IsItem: True
         Name: UInt1, Address: Bucket Brigade.UInt1, IsItem: True
         Name: UInt2, Address: Bucket Brigade.UInt2, IsItem: True
         Name: UInt4, Address: Bucket Brigade.UInt4, IsItem: True
      Name: Random, Address: Random, IsItem: False
         Name: ArrayOfReal8, Address: Random.ArrayOfReal8, IsItem: True
         Name: ArrayOfString, Address: Random.ArrayOfString, IsItem: True
         Name: Boolean, Address: Random.Boolean, IsItem: True
         Name: Int1, Address: Random.Int1, IsItem: True
         Name: Int2, Address: Random.Int2, IsItem: True
         Name: Int4, Address: Random.Int4, IsItem: True
         Name: Money, Address: Random.Money, IsItem: True
         Name: Qualities, Address: Random.Qualities, IsItem: True
         Name: Real4, Address: Random.Real4, IsItem: True
         Name: Real8, Address: Random.Real8, IsItem: True
         Name: String, Address: Random.String, IsItem: True
         Name: Time, Address: Random.Time, IsItem: True
         Name: UInt1, Address: Random.UInt1, IsItem: True
         Name: UInt2, Address: Random.UInt2, IsItem: True
         Name: UInt4, Address: Random.UInt4, IsItem: True
      Name: Read Error, Address: Read Error, IsItem: False
         Name: ArrayOfReal8, Address: Read Error.ArrayOfReal8, IsItem: True
         Name: ArrayOfString, Address: Read Error.ArrayOfString, IsItem: True
         Name: Boolean, Address: Read Error.Boolean, IsItem: True
         Name: Int1, Address: Read Error.Int1, IsItem: True
         Name: Int2, Address: Read Error.Int2, IsItem: True
         Name: Int4, Address: Read Error.Int4, IsItem: True
         Name: Money, Address: Read Error.Money, IsItem: True
         Name: Real4, Address: Read Error.Real4, IsItem: True
         Name: Real8, Address: Read Error.Real8, IsItem: True
         Name: String, Address: Read Error.String, IsItem: True
         Name: Time, Address: Read Error.Time, IsItem: True
         Name: UInt1, Address: Read Error.UInt1, IsItem: True
         Name: UInt2, Address: Read Error.UInt2, IsItem: True
         Name: UInt4, Address: Read Error.UInt4, IsItem: True
      Name: Saw-toothed Waves, Address: Saw-toothed Waves, IsItem: False
         Name: Int1, Address: Saw-toothed Waves.Int1, IsItem: True
         Name: Int2, Address: Saw-toothed Waves.Int2, IsItem: True
         Name: Int4, Address: Saw-toothed Waves.Int4, IsItem: True
         Name: Money, Address: Saw-toothed Waves.Money, IsItem: True
         Name: Real4, Address: Saw-toothed Waves.Real4, IsItem: True
         Name: Real8, Address: Saw-toothed Waves.Real8, IsItem: True
         Name: UInt1, Address: Saw-toothed Waves.UInt1, IsItem: True
         Name: UInt2, Address: Saw-toothed Waves.UInt2, IsItem: True
         Name: UInt4, Address: Saw-toothed Waves.UInt4, IsItem: True
      Name: Square Waves, Address: Square Waves, IsItem: False
         Name: Boolean, Address: Square Waves.Boolean, IsItem: True
         Name: Int1, Address: Square Waves.Int1, IsItem: True
         Name: Int2, Address: Square Waves.Int2, IsItem: True
         Name: Int4, Address: Square Waves.Int4, IsItem: True
         Name: Real4, Address: Square Waves.Real4, IsItem: True
         Name: Real8, Address: Square Waves.Real8, IsItem: True
         Name: UInt1, Address: Square Waves.UInt1, IsItem: True
         Name: UInt2, Address: Square Waves.UInt2, IsItem: True
         Name: UInt4, Address: Square Waves.UInt4, IsItem: True
      Name: Triangle Waves, Address: Triangle Waves, IsItem: False
         Name: Int1, Address: Triangle Waves.Int1, IsItem: True
         Name: Int2, Address: Triangle Waves.Int2, IsItem: True
         Name: Int4, Address: Triangle Waves.Int4, IsItem: True
         Name: Money, Address: Triangle Waves.Money, IsItem: True
         Name: Real4, Address: Triangle Waves.Real4, IsItem: True
         Name: Real8, Address: Triangle Waves.Real8, IsItem: True
         Name: UInt1, Address: Triangle Waves.UInt1, IsItem: True
         Name: UInt2, Address: Triangle Waves.UInt2, IsItem: True
         Name: UInt4, Address: Triangle Waves.UInt4, IsItem: True
      Name: Write Error, Address: Write Error, IsItem: False
         Name: ArrayOfReal8, Address: Write Error.ArrayOfReal8, IsItem: True
         Name: ArrayOfString, Address: Write Error.ArrayOfString, IsItem: True
         Name: Boolean, Address: Write Error.Boolean, IsItem: True
         Name: Int1, Address: Write Error.Int1, IsItem: True
         Name: Int2, Address: Write Error.Int2, IsItem: True
         Name: Int4, Address: Write Error.Int4, IsItem: True
         Name: Money, Address: Write Error.Money, IsItem: True
         Name: Real4, Address: Write Error.Real4, IsItem: True
         Name: Real8, Address: Write Error.Real8, IsItem: True
         Name: String, Address: Write Error.String, IsItem: True
         Name: Time, Address: Write Error.Time, IsItem: True
         Name: UInt1, Address: Write Error.UInt1, IsItem: True
         Name: UInt2, Address: Write Error.UInt2, IsItem: True
         Name: UInt4, Address: Write Error.UInt4, IsItem: True
      Name: Write Only, Address: Write Only, IsItem: False
         Name: ArrayOfReal8, Address: Write Only.ArrayOfReal8, IsItem: True
         Name: ArrayOfString, Address: Write Only.ArrayOfString, IsItem: True
         Name: Boolean, Address: Write Only.Boolean, IsItem: True
         Name: Int1, Address: Write Only.Int1, IsItem: True
         Name: Int2, Address: Write Only.Int2, IsItem: True
         Name: Int4, Address: Write Only.Int4, IsItem: True
         Name: Money, Address: Write Only.Money, IsItem: True
         Name: Real4, Address: Write Only.Real4, IsItem: True
         Name: Real8, Address: Write Only.Real8, IsItem: True
         Name: String, Address: Write Only.String, IsItem: True
         Name: Time, Address: Write Only.Time, IsItem: True
         Name: UInt1, Address: Write Only.UInt1, IsItem: True
         Name: UInt2, Address: Write Only.UInt2, IsItem: True
         Name: UInt4, Address: Write Only.UInt4, IsItem: True
   Name: Configured Aliases, Address: Configured Aliases¥, IsItem: False
      Name: AliasTest, Address: Configured Aliases.AliasTest, IsItem: False
         Name: testNew, Address: AliasTest.testNew, IsItem: True
      Name: HomeTagTest, Address: Configured Aliases.HomeTagTest, IsItem: False
         Name: ChildHomeAlias, Address: Configured Aliases.HomeTagTest.ChildHomeAlias, IsItem: False
            Name: GrandchildAlias, Address: Configured Aliases.HomeTagTest.ChildHomeAlias.GrandchildAlias, IsItem: False
               Name: testg, Address: HomeTagTest.ChildHomeAlias.GrandchildAlias.testg, IsItem: True
         Name: TestItem, Address: HomeTagTest.TestItem, IsItem: True
      Name: JarekSrv, Address: .JarekSrv, IsItem: True
      Name: jjjj, Address: .jjjj, IsItem: True
   Name: #MonitorACLFile, Address: #MonitorACLFile, IsItem: True
   Name: @ClientCount, Address: @ClientCount, IsItem: True
   Name: @Clients, Address: @Clients, IsItem: True


Available servers:
Advosol.HDA.Net4.Test.6
Matrikon.OPC.Simulation

Rading tag AliasTest.testNew from opchda://localhost/Matrikon.OPC.Simulation.1:
Key: 03.03.2019 22:51:30, Value: 80000000
Key: 03.03.2019 22:51:31, Value: 81250000
Key: 03.03.2019 22:51:32, Value: 82500000
Key: 03.03.2019 22:51:33, Value: 83750000
Key: 03.03.2019 22:51:34, Value: 85000000
Key: 03.03.2019 22:51:35, Value: 86250000
Key: 03.03.2019 22:51:36, Value: 87500000
Key: 03.03.2019 22:51:37, Value: 88750000
Key: 03.03.2019 22:51:38, Value: 90000000
Key: 03.03.2019 22:51:39, Value: 91250000
Key: 03.03.2019 22:51:40, Value: 92500000
Key: 03.03.2019 22:51:41, Value: 93750000
Key: 03.03.2019 22:51:42, Value: 95000000
Key: 03.03.2019 22:51:43, Value: 96250000
Key: 03.03.2019 22:51:44, Value: 97500000
Key: 03.03.2019 22:51:45, Value: 98750000
Key: 03.03.2019 22:51:46, Value: 100000000
Key: 03.03.2019 22:51:48, Value: 101250000
Key: 03.03.2019 22:51:49, Value: 102500000

```
