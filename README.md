# OPC-HDA-Library
Free .Net OPC Historical Data Access Library

OPC Core components:
https://opcfoundation.org/developer-tools/samples-and-tools-classic/core-components/

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
