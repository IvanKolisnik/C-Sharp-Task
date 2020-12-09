using System;

namespace ClassContainerArray
{
    public static class GlobalMembersArray
    {
        public static void Main(string[] args)
        {
            var test = new Array<int>();

            Console.Write("метод \"GetSize\":\n");
            Console.Write(test.GetSize());
            Console.Write("\n");
            Console.Write("\n");

            test.Add(1);
            test.Add(2);
            test.Add(3);
            Console.Write("метод \"Add\":\n");
            test.Show();

            Console.Write("метод \"GetUpperBound\":\n");
            Console.Write(test.GetUpperBound());
            Console.Write("\n");
            Console.Write("\n");

            Console.Write("метод \"IsEmpty\":\n");
            Console.Write(test.isEmpty());
            Console.Write("\n");
            Console.Write("\n");

            Console.Write("метод \"GetSize\" (показываем количество элементов массива, под которые выделена память):\n");
            Console.Write(test.GetSize());
            Console.Write("\n");
            Console.Write("\n");

            test.SetSize(5);
            Console.Write("метод \"SetSize\" (устанавилваем размер равнывй 5):\n");
            Console.Write(test.GetSize());
            Console.Write("\n");
            Console.Write("\n");

            test.SetAt(3, 4);
            test.SetAt(4, 5);
            Console.Write("метод \"SetAt\" (устанавилваем значение 4 и 5):\n");
            test.Show();

            Console.Write("метод \"FreeExtra\" (устанавливаем размер 10, используем фри экстра):\n");
            test.SetSize(10);
            test.FreeExtra();
            Console.Write(test.GetSize());
            Console.Write("\n");
            Console.Write("\n");

            Console.Write("метод \"GetAt\" (Получаем значение 3-го элемента):\n");
            Console.Write(test.GetAt(2));
            Console.Write("\n");
            Console.Write("\n");

            Console.Write("метод \"operator[]\" (Получаем значение 3-го элемента):\n");
            Console.Write(test[2]);
            Console.Write("\n");
            Console.Write("\n");

            Array<int> test2 = new Array<int>();
            //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
            //ORIGINAL LINE: test2 = test;
            test2.CopyFrom(test);
            Console.Write("метод \"operator=\" (создали второй массив и приравняли первому.)\n");
            test2.Show();

            // Console.Write("метод \"GetData\" (Получаем адрес массива):\n");
            // Console.Write(test.GetData());
            // Console.Write("\n");
            // Console.Write("\n");

            // Console.Write("метод \"Append\" (Прибавили к первому массиву второй):\n");
            // test.Append(test2);
            // test.Show();

            Console.Write("метод \"InsertAt\" (Вставили во вторую позицию цифру 256):\n");
            test.InsertAt(2, 256);
            test.Show();

            Console.Write("метод \"RemoveAt\" (Убрали со второй позиции цифру 256):\n");
            test.RemoveAt(2);
            test.Show();
        }
    }

    //ORIGINAL LINE: template <typename T>
    public class Array<T>
    {
        private T[] mData;
        private int mCounter;
        private int mSize;
        private int mGrow;

        public Array()
        {
            mCounter = 0;
            mSize = 0;
            mGrow = 1;
            mData = new T[0];
        }

        public int GetSize()
        {
            return mSize;
        }

        public void SetSize(int size, int grow = 1)
        {
            mGrow = grow;

            if (size == mSize)
            {
                return;
            }

            mSize = size;

            if (mSize > 0)
            {
                if (mSize % mGrow != 0)
                {
                    Array.Resize(ref mData, mSize + (grow - mSize % grow));
                }
                else if (mSize % mGrow == 0)
                {
                    Array.Resize(ref mData, mSize);
                }
            }

            if (mCounter > mSize)
            {
                mCounter = mSize;
            }
        }

        public int GetUpperBound()
        {
            return mCounter - 1;
        }

        public bool isEmpty()
        {
            if (mCounter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FreeExtra()
        {
            if (mSize % mGrow != 0)
            {
                Array.Resize(ref mData, mCounter + (mGrow - mCounter % mGrow));
                mSize = mCounter + (mGrow - mCounter % mGrow);
            }
            else if (mSize % mGrow == 0)
            {
                Array.Resize(ref mData, mCounter);
                mSize = mCounter;
            }
        }

        public void removeAll()
        {
            mData = new T[0]; ;
            mCounter = 0;
            mSize = 0;
        }

        public T GetAt(int index)
        {
            if (index >= 0 && index < mCounter)
            {
                return mData[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void SetAt(int index, T data)
        {
            if (index >= 0 && index < mSize)
            {
                mData[index] = data;
                mCounter = index + 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public T this[int index] => this.GetAt(index);

        public void Add(T data)
        {
            if (mCounter < mSize)
            {
                mData[mCounter++] = data;
            }
            else if (mCounter >= mSize)
            {
                SetSize(mSize + 1);
                mData[mSize - 1] = data;
                mCounter++;
            }
        }

        public void Append(Array<T> obj)
        {
            // C# не позволяет сложить два обьекта произвольного типа.

            // int maxCounter = this.GetUpperBound() > obj.GetUpperBound() ? this.GetUpperBound() + 1 : obj.GetUpperBound() + 1;
            // int minCounter = this.GetUpperBound() < obj.GetUpperBound() ? this.GetUpperBound() + 1 : obj.GetUpperBound() + 1;
            // this.SetSize(maxCounter, mGrow);
            //
            // for (int i = 0; i < minCounter; i++)
            // {
            //     mData[i] = mData[i] + obj[i];
            // }
        }

        //ORIGINAL LINE: Array<T> & operator = (const Array &obj)
        public void CopyFrom(Array<T> obj)
        {
            if (this == obj)
            {
                return;
            }

            mGrow = obj.mGrow;
            mCounter = obj.mCounter;
            mSize = obj.mSize;
            Array.Resize(ref mData, (mSize + (mGrow - mSize % mGrow)));

            for (int i = 0; i < mCounter; i++)
            {
                mData[i] = obj.mData[i];
            }
        }

        // За исключением очень редких случаев к которым данная задача не относится, в c# не используют адреса обьектов
        // public IntPtr GetData()
        // {
        //     throw new NotSupportedException();
        // }

        public void InsertAt(int position, T data)
        {
            if (position < 0 || position >= mCounter)
            {
                return;
            }

            if (mCounter >= mSize)
            {
                SetSize(mSize + 1);
            }

            for (int i = mCounter; i >= position; i--)
            {
                mData[i] = mData[i - 1];
            }

            mData[position] = data;
            mCounter++;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= mCounter)
            {
                return;
            }

            for (int i = position; i < mCounter - 1; i++)
            {
                mData[i] = mData[i + 1];
            }

            mCounter--;
        }

        public void Show()
        {
            for (int i = 0; i < mCounter; i++)
            {
                Console.Write(mData[i]);
                Console.Write(" ");
            }

            Console.Write("\n");
            Console.Write("\n");
        }
    }
}