using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
     public static void Main(string[] args)
     {
        string filePathValue = args[0];
        string filePathTests = args[1];
        string filePathReport = args[2];

        ResultValues? values = JsonSerializer.Deserialize<ResultValues>(File.ReadAllText(filePathValue));
        ResultTests? tests = JsonSerializer.Deserialize<ResultTests>(File.ReadAllText(filePathTests));       
        
        Dictionary<int, ItemT> map = new Dictionary<int, ItemT>();
        FillMap(tests.Tests, map);

        
        foreach (var value in values.Values)
        {
            if (map.ContainsKey(value.Id))
            {
                map[value.Id].Value = value.Value;
            }
        }
        string json = JsonSerializer.Serialize(tests);
        File.WriteAllText(filePathReport, json);
     }

    public static void FillMap(ItemT[] items, Dictionary<int, ItemT> map) 
    {
        if (items == null) return;
        foreach (var item in items)
        {
            map.Add(item.Id, item);
            FillMap(item.Values, map);
        }
    }
}

 
public class ResultValues
{
    [JsonPropertyName("values")]
    public ItemV[] Values { get; set; }
}

public class ItemV
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class ResultTests
{
    [JsonPropertyName("tests")]
    public ItemT[] Tests { get; set; }
}


public class ItemT
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
   
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("value")]
    public string Value { get; set; }
    
    [JsonPropertyName("values")]
    public ItemT[] Values { get; set; }
}
