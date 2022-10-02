using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Entertainment_App.Models
{
    public class Video : Media
    {
        private string _fileName;
        private List<Video> Videos = new();
        public string Format { get; set; }

        public int Length { get; set; }
        public  List<int>Regions { get; set; }

//Default Constructor
        public Video() { }


        public void PrintRegions()
        {
                

            for (int i =  0; i <    Regions.Count() ; i++) {
                Console.Write(Regions[i] + " ");
            
            }

            
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("videoId              title   format    length    regions");

            foreach (var vid in Videos)
            {
                Console.Write(vid.Id + " ");
                Console.Write(vid.Title + " ");
                Console.Write(vid.Format + " ");
                Console.Write(vid.Length + " ");
                vid.PrintRegions();
                Console.WriteLine();

            }
        }

            
            public override void Read()
        {
                
            _fileName = $"{Environment.CurrentDirectory}/Files/Videos.csv";

            if (!File.Exists(_fileName))
            {
                Console.WriteLine($"File does not exist {_fileName}");
            }

            try
            {   
                var sr = new StreamReader(_fileName);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {

                    var  Vid = new Video();
                    //Console.WriteLine("Debugging: Made it to video declaration)");
                    var line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    var idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in Video title
                        // Video  details are separated with comma(,)

                        //String strDetails; 
                        var VideoDetails = line.Split(',');
                        //strDetails  = (String) VideoDetails;
                        //Console.WriteLine(strDetails);

                        // 1st array element contains Video  .id
                        Vid.Id = int.Parse(VideoDetails[0]);
                        // 2nd array element contains Videoe title
                        Vid.Title = VideoDetails[1];
                        // 3rd array element contains Video  Format (s)

                        Vid.Format = VideoDetails[2].Replace("|", ", ");

                        // 4th array element contains Video Length()                   Vid.Id = int.Parse(VideoDetails[0]);
                        Vid.Length = int.Parse(VideoDetails[3]);

                        // replace "|" with ", "
                        var strNumbers  =     VideoDetails[4].Split("|");
                        Vid.Regions =  strNumbers.Select(int.Parse).ToList();     
                    
                    }
                    else
                    {
                        // quote = comma in Video title
                        // extract the 
                        Vid.Id = int.Parse(line.Substring(0, idx - 1));
                        // remove Video eId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the e
                        Vid.Title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        //var strNumbers2 = VideoDetails[4].Split("|");
//                        Vid.Regions = strNumbers2.Select(int.Parse).ToList();
                    }
                    Videos.Add(Vid);

                }

                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
            }

            //Console.WriteLine("Made it to the end of read");
        }
    }
}
