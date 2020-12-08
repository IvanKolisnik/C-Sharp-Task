using System;

namespace dinarray
{
    class DinArray
    {
        private int[] arr;

        public int Length { get => arr.Length; }

        public DinArray()
        {
            arr = new int[0];
        }

        public void Add(int n)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = n;
        }

        public void Insert(int n, int place)
        {
            if (place >= Length)
            {
                throw new ArgumentOutOfRangeException("Индекс находится за пределами массива");
            }
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 2; i >= place; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[place] = n;
        }

        public void Remove(int place)
        {
            if (place >= Length)
            {
                throw new ArgumentOutOfRangeException("Индекс находится за пределами массива");
            }
            for (int i = place + 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }

            Array.Resize(ref arr, arr.Length - 1);
        }

        // оператор []
        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }

        public static DinArray operator +(DinArray b, DinArray c)
        {
            DinArray box = new DinArray();
            var z = new int[b.Length + c.Length];
            b.arr.CopyTo(z, 0);
            c.arr.CopyTo(z, b.arr.Length);
            box.arr = z;
            return box;
        }

        public static DinArray operator -(DinArray b, DinArray c)
        {
            DinArray box = new DinArray();
            int min = b.Length < c.Length ? b.Length : c.Length;
            int max = b.Length > c.Length ? b.Length : c.Length;
            int set = b.Length > c.Length ? 0 : 1;
            var z = new int[max];
            for (int i = 0; i < z.Length; i++)
            {
                if (i < min)
                {
                    z[i] = b.arr[i] - c.arr[i];
                }
                else
                {
                    if (set == 1)
                        z[i] = c.arr[i];
                    else
                        z[i] = b.arr[i];
                }
            }
            box.arr = z;
            return box;
        }

        public static DinArray operator ++(DinArray a)
        {
            Array.Resize(ref a.arr, a.arr.Length + 1);
            return a;
        }

        public static DinArray operator --(DinArray a)
        {
            Array.Resize(ref a.arr, a.arr.Length - 1);
            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var din = new DinArray();
            din.Add(1);
            din.Add(2);
            din.Add(3);
            din.Add(4);
            din.Add(5);
            for (int i = 0; i < din.Length; i++)
            {
                Console.WriteLine(din[i]);
            }

            Console.WriteLine("");

            din.Insert(15, 3);
            for (int i = 0; i < din.Length; i++)
            {
                Console.WriteLine(din[i]);
            }

            Console.WriteLine("");

            din.Remove(3);
            for (int i = 0; i < din.Length; i++)
            {
                Console.WriteLine(din[i]);
            }

            Console.WriteLine("");

            din++;
            for (int i = 0; i < din.Length; i++)
            {
                Console.WriteLine(din[i]);
            }

            Console.WriteLine("");

            din--;
            for (int i = 0; i < din.Length; i++)
            {
                Console.WriteLine(din[i]);
            }
        }
    }
}