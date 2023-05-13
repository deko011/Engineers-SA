using System.Security.Cryptography;
using System.Text;

namespace PruebaDiego.Utils
{
    public static class SecurityHelper
    {
        //Algoritmo compatible con SQL SERVER para SHA256 CON ESTO SE DEBEN CIFRAR TODAS LAS LLAVES
        public static string SHA256Encrypt(string text)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(text));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return "0x" + sb.ToString().ToUpper();
        }
    }
}