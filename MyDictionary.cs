using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
     class MyDictionary
    {
        static void Main(string[] args)
        {
           
            Dictionary<string, string> dict = new Dictionary<string, string>();

          
            dict.Add("txt" , "notepad.exe" );
            dict.Add("bmp" , "paint.exe" );
            dict.Add("dib" , "paint.exe" );
            dict.Add("rtf" , "wordpad.exe" );          
            foreach (string key in dict.Keys) 
                Console.WriteLine("Ключ=" + key + " , значення=" + dict[key]);                                                                             
            foreach (KeyValuePair<string, string> item in dict)
                Console.WriteLine("Ключ=" + item.Key + " , значення=" + item.Value);                  
            dict["eee"] = "office.exe";                   
            string value;
            if (dict.TryGetValue("ooo", out value))
                Console.WriteLine(value);          
            try
            {
                value = dict["vvv"];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message); 
            }       
            bool isFound = dict.ContainsKey("iii");           
            dict.Remove("rtf");
       
        }
    }
}
