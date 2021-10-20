using System;
using System.Numerics;
using System.Windows.Forms;

namespace TI
{
    public partial class Lab_2 : Form
    {
        create keys = new create();
        ulong[] Cipher;
        public Lab_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keys.CreatingKey();
            OpenKey.Text = keys.OpenKey[0].ToString() + ", " + keys.OpenKey[1].ToString();
            PrivateKey.Text = keys.PrivateKey[0].ToString() + ", " + keys.PrivateKey[1].ToString();
        }

        static ulong Power(ulong Number, ulong Pow, ulong Mod)
        {
            ulong Result = 1;
            ulong Bit = Number % Mod;

            while (Pow > 0)
            {
                if ((Pow & 1) == 1)
                {
                    Result *= Bit;
                    Result %= Mod;
                }
                Bit *= Bit;
                Bit %= Mod;
                Pow >>= 1;
            }
            return Result;
        }

        static ulong[] Algorithm(ulong[] Source, long[] Key)
        {
            ulong[] Result = new ulong[Source.Length];
            for (int i = 0; i < Source.Length; i++)
            {
                Result[i] = Power(Source[i], (ulong)Key[0], (ulong)Key[1]);
            }
            return Result;
        }

        //шифрование
        private void button2_Click(object sender, EventArgs e)
        {
            string Inptext = text.Text;
            ulong[] Source = new ulong[Inptext.Length];

            for (int i = 0; i < Inptext.Length; i++)
            {
                Source[i] = Inptext[i];
            }
            Cipher = Algorithm(Source, keys.OpenKey);
            encrypt.Text = "";

            for (int i = 0; i < Inptext.Length; i++)
            {
                encrypt.Text += Cipher[i] + " ";
            }
        }

        //дешифрование
        private void button3_Click(object sender, EventArgs e)
        {
            ulong[] Text;

            Text = Algorithm(Cipher, keys.PrivateKey);

            decrypt.Text = "";

            for (int i = 0; i < Text.Length; i++)
            {
                decrypt.Text += (char)Text[i];
            }
        }
    }
}
