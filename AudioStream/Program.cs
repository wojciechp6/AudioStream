using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioStream
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Server.LocalIPAddress() == null)
            {
                MessageBox.Show("You are not connected to network :(. I need network. Bye.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static IEnumerable<byte> ParseByte(this string[] enumeration)
        {
            foreach (string item in enumeration)
            {
                if (byte.TryParse(item, out byte t))
                    yield return t;
            }
        }

        public static void Print<T>(this IEnumerable<T> enumeration)
        {
            foreach (T item in enumeration)
            {
                Console.Write(item);
            }
        }


        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}
