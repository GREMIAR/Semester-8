namespace Lab7
{
    class Program
    {
        static string x1 = "10010010111";
        static string x2 = "10010010111";
        static string y = "00010000111";

        static int n = 11;

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1: " + Task1());
            Console.WriteLine("Задание 2: " + Task2());
        }

        static string Task1()
        {
            string result = "";

            byte currentElement, e, g, h;

            byte[] Ae = new byte[n];
            byte[] Ah = new byte[n];
            byte[] Ag = new byte[n];

            for (int i = 0; i < n; i++)
            {
                Ae[i] = byte.Parse(x1[i].ToString());
                Ah[i] = byte.Parse(x1[i].ToString());
                Ag[i] = byte.Parse(x1[i].ToString());
            }


            for (int i = 0; i < n; i++)
            {
                byte[] array = Ae;
                e = (byte)(Ae[0] ^ Ae[2] ^ Ae[6] ^ Ae[8] ^ Ae[9]);
                for (int j = n - 1; j > 1; j--)
                    Ae[j] = array[j - 1];
                Ae[0] = e;

                array = Ah;
                h = (byte)(Ah[0] ^ Ah[2] ^ Ah[5] ^ Ah[8]);
                for (int j = 0; j < n - 2; j++)
                    Ah[j + 1] = array[j];
                Ah[n - 1] = h;

                array = Ag;
                g = (byte)(Ag[0] ^ Ag[5] ^ Ag[6] ^ Ag[8] ^ Ag[9]);
                for (int j = 0; j < n - 2; j++)
                    Ag[j + 1] = array[j];
                Ag[n - 1] = g;

                currentElement = (byte)(Ae[n - 1] ^ Ah[0] ^ Ag[0]);
                result += currentElement;
            }
            return result;
        }

        static string Task2()
        {
            string result = "";

            byte currentElement, e, h;

            byte[] Ae = new byte[n];
            byte[] Ah = new byte[n];

            for (int i = 0; i < n; i++)
            {
                Ae[i] = byte.Parse(x2[i].ToString());
                Ah[i] = byte.Parse(y[i].ToString());
            }

            for (int i = 0; i < n; i++)
            {
                byte[] array = Ae;
                e = (byte)(Ae[8] ^ 1);
                for (int j = n - 1; j > 1; j--)
                    Ae[j] = array[j - 1];
                Ae[0] = e;

                array = Ah;
                h = (byte)(Ah[8] ^ 1);
                for (int j = n - 1; j > 1; j--)
                    Ah[j] = array[j - 1];
                Ah[0] = h;

                currentElement = (byte)(Ae[n - 1] ^ Ah[n - 1]);
                result += currentElement;
            }
            return result;
        }
    }
}
