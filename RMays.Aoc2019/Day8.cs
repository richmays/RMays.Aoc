using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    // start: 4:10 AM
    // stop: 4:34:37 and 4:46:13 (24m and 35m)
    public class Day8 : IDay<long>
    {
        public long SolveA(string input)
        {
            // everything's in one list.
            var pixelImage = new PixelImage { Width = 25, Height = 6, ImageString = input };
            pixelImage.Read();

            Dictionary<int, int> layerCountsOf0 = new Dictionary<int, int>();
            int bestLayer = -1;
            int lowest0DigitsFound = int.MaxValue;
            for (var currLayer = 0; currLayer < pixelImage.dict.Keys.Count(); currLayer++)
            {
                int count = 0;
                foreach (var r in pixelImage.dict[currLayer].Rows)
                {
                    foreach (char c in r)
                    {
                        if (c == '0')
                        {
                            count++;
                        }
                    }
                }
                if (count < lowest0DigitsFound)
                {
                    lowest0DigitsFound = count;
                    bestLayer = currLayer;
                }
            }

            // We have the best layer.
            int total1s = 0;
            int total2s = 0;
            foreach (var r in pixelImage.dict[bestLayer].Rows)
            {
                foreach (char c in r)
                {
                    switch(c)
                    {
                        case '1':
                            total1s++;
                            break;
                        case '2':
                            total2s++;
                            break;
                    }
                }
            }

            return total1s * total2s;
        }

        public long SolveB(string input)
        {
            // everything's in one list.
            var pixelImage = new PixelImage { Width = 25, Height = 6, ImageString = input };
            pixelImage.Read();

            Console.WriteLine(pixelImage.Decode());

            return -1;
        }
    }

    public class PixelImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImageString { get; set; }

        public Dictionary<int, Layer> dict;

        public void Read()
        {
            dict = new Dictionary<int, Layer>();
            int ptr = 0;
            int currLayerId = 0;
            while (ptr < ImageString.Length)
            {
                var currLayer = new Layer();
                for(var rowId = 0; rowId < Height; rowId++)
                {
                    var currRow = "";
                    for(var colId = 0; colId < Width; colId++)
                    {
                        currRow += ImageString[ptr];
                        ptr++;
                    }
                    currLayer.Rows.Add(currRow);
                }
                dict.Add(currLayerId, currLayer);
                currLayerId++;
            }
        }

        public string Decode()
        {
            var image = new int[Height, Width];
            for(int r = 0; r < this.Height; r++)
            {
                for(int c = 0; c < this.Width; c++)
                {
                    image[r, c] = 2; // transparent
                }
            }

            for (var currLayer = 0; currLayer < dict.Keys.Count(); currLayer++)
            {
                for(int r = 0; r < this.Height; r++)
                {
                    var currRow = dict[currLayer].Rows[r];
                    for (int c = 0; c < this.Width; c++)
                    {
                        if (image[r, c] != 2) continue;
                        image[r, c] = (currRow[c] - '0');
                    }
                }
            }

            // Now turn the image into a string.
            var toReturn = "";
            for (int r = 0; r < this.Height; r++)
            {
                for (int c = 0; c < this.Width; c++)
                {
                    toReturn += image[r, c];
                }
                toReturn += Environment.NewLine;
            }

            return toReturn;
        }
    }

    public class Layer
    {
        public List<string> Rows { get; set; }

        public Layer()
        {
            Rows = new List<string>();
        }
    }

}
