using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.MNISTDatabase
{
    class MNISTDecoder
    {
        public static int ToUnsignedByte(byte b) => b & 0xFF;

        public static List<Digit> LoadData(string labelPath, string imagePath)
        {
            List<Digit> digits = new List<Digit>();

            byte[] labels = File.ReadAllBytes(labelPath);
            byte[] images = File.ReadAllBytes(imagePath);
            byte[,] data = new byte[28, 28];

            int labelHead = 8;
            int imageHead = 16;

            while (imageHead < images.Length)
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        data[i, j] = images[imageHead++];
                    }
                }
                digits.Add(new Digit(ToUnsignedByte(labels[labelHead++]), data));
            }

            return digits;
        }
    }

    class Digit
    {
        public Digit(int label, byte[,] data)
        {
            Label = label;
            Data = data;
        }

        public int Label { get; private set; }

        public byte[,] Data { get; }
    }
}
