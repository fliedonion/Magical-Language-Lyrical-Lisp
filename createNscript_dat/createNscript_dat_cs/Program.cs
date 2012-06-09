using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace createNscript_dat_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var wfs = new FileStream("nscript.dat", FileMode.Create ,FileAccess.Write))
            {
                using (var bw = new BinaryWriter(wfs,Encoding.ASCII))
                {
                    var sjis = Encoding.GetEncoding(932);

                    foreach (var f in Directory.GetFiles(".", "*.txt"))
                    {
                        using (var sr = new StreamReader(f, sjis))
                        {
                            string line;
                            while( (line = sr.ReadLine()) != null){
                                foreach (var b in sjis.GetBytes(line))
                                {
                                    bw.Write((byte)(b ^ 0x84));
                                }
                                bw.Write((byte)(0x0A ^ 0x84));
                            }
                        }
                    }
                }
            }
            

        }


    }
}
