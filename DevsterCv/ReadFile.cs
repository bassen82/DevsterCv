using DevsterCv.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

public class ReadFile
{
    public String Name { get; set; }
    public String AssignmentDesc { get; set; }
    public String Tech { get; set; }
    public String Contact { get; set; }
    public String Expertis { get; set; }
    public String Training { get; set; }
    public String Bransch { get; set; }
    public String Intrest { get; set; }

    public string read()
    {

        string data = File.ReadAllText(@"C:\CvAppen\Devster\Abid Hussain\beskrivning\data.json");



        return data;
    }

}