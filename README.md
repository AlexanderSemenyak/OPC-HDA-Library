# OPC-HDA-Library
Free .Net OPC Historical Data Access Library

To compile, please download OPC Core components, from OPCFoundation website:
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

```
