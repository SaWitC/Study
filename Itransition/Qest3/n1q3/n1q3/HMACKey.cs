using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace n1q3
{
    class HMACKey
    {
        public byte[] bytrkey { get; set; } = new byte[32];

        public string key { get; set; } = "";
        public string GenerateHMAC(byte[] b)
        {
            var bytes = new byte[32];
            var gen = RandomNumberGenerator.Create();
            gen.GetBytes(bytes);
            HMACSHA256 hMACSHA = new HMACSHA256(bytes);
            var hach = hMACSHA.ComputeHash(b);

            bytrkey = bytes;//savekey

            string fhach = "";
            foreach (var item in hach)
            {
                if (Convert.ToString(item, 16).Length < 2)
                    fhach += "0" + Convert.ToString(item, 16);
                else
                    fhach += Convert.ToString(item, 16);
            }
            foreach (var item in bytes)
            {
                if (Convert.ToString(item, 16).Length < 2)
                    key += "0" + Convert.ToString(item, 16);
                else
                    key += Convert.ToString(item, 16);
            }
            return fhach;
        }
        public string GenerateHMACByKey(byte[] b,byte[] bytes)
        {
            HMACSHA256 hMACSHA = new HMACSHA256(bytes);
            var hach = hMACSHA.ComputeHash(b);

            string fhach = "";
            foreach (var item in hach)
            {
                if (Convert.ToString(item, 16).Length < 2)
                    fhach += "0" + Convert.ToString(item, 16);
                else
                    fhach += Convert.ToString(item, 16);
            }
            return fhach;
        }
    }
}
