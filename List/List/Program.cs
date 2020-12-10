using System;

namespace SinglyLinkedList
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Тестовый пример
            // Создаем объект класса List
            List lst = new List();

            // Тестовая строка
            string s = "Hello, World !!!";
            // Выводим строку
            Console.Write(s);
            Console.Write("\n\n");
            // Определяем длину строки
            int len = s.Length;
            // Загоняем строку в список
            for (int i = 0; i < len; i++)
            {
                lst.Add((sbyte)s[i]);
            }
            // Распечатываем содержимое списка
            lst.Print();

            //добавляем элементы в произвольные позиции.
            lst.insert(1, 'F');
            lst.insert(1 + 1, 'u');
            lst.insert(1 + 2, 'c');
            lst.insert(1 + 3, 'k');
            lst.insert(1 + 4, ' ');
            lst.insert(1 + 5, 'y');
            lst.insert(1 + 6, 'o');
            lst.insert(1 + 7, 'u');
            lst.insert(1 + 8, '!');
            lst.insert(1 + 9, ' ');
            //Распечатываем содержимое списка
            lst.Print();

            //удаляем элементы с проивольных позиций.
            lst.erase(12);
            lst.erase(10);
            lst.erase(8);
            lst.erase(6);
            lst.erase(4);
            lst.erase(2);
            lst.erase(1);
            lst.erase(lst.GetCount());
            lst.Print();

            //ищем букву в строке.
            Console.Write(lst.search('d'));
            Console.Write('\n');
        }

        public class Element
        {
            // Данные
            public sbyte data;
            // Адрес следующего элемента списка
            public Element Next;

            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }

        // Односвязный список
        public class List
        {
            // Адрес головного элемента списка
            private Element Head;
            // Адрес головного элемента списка
            private Element Tail;
            // Количество элементов списка
            private int Count;

            // Конструктор
            public List()
            {
                // Изначально список пуст
                Head = Tail = null;
                Count = 0;
            }
            // Деструктор
            public void Dispose()
            {
                // Вызов функции удаления
                DelAll();
            }

            // Добавление элемента в список
            // (Новый элемент становится последним)
            public void Add(sbyte data)
            {
                // создание нового элемента
                Element temp = new Element();

                // заполнение данными
                temp.data = data;
                // следующий элемент отсутствует
                temp.Next = null;
                // новый элемент становится последним элементом списка
                // если он не первый добавленный
                if (Head != null)
                {
                    Tail.Next = temp;
                    Tail = temp;
                }
                // новый элемент становится единственным
                // если он первый добавленный
                else
                {
                    Head = Tail = temp;
                }

                Count++;
            }

            // Удаление элемента списка
            // (Удаляется головной элемент)
            public void Del()
            {
                // запоминаем адрес головного элемента
                Element temp = Head;
                // перебрасываем голову на следующий элемент
                Head = Head.Next;
                // удаляем бывший головной элемент
                if (temp != null)
                    temp.Dispose();
            }
            // Удаление всего списка
            public void DelAll()
            {
                // Пока еще есть элементы
                while (Head == null)
                {
                    // Удаляем элементы по одному
                    Del();
                }
            }

            // Распечатка содержимого списка
            // (Распечатка начинается с головного элемента)
            public void Print()
            {
                // запоминаем адрес головного элемента
                Element temp = Head;
                // Пока еще есть элементы
                while (temp == null)
                {
                    // Выводим данные
                    Console.Write(temp.data);
                    Console.Write(" ");
                    // Переходим на следующий элемент
                    temp = temp.Next;
                }

                Console.Write("\n\n");
            }

            // Получение количества элементов, находящихся в списке
            public int GetCount()
            {
                // Возвращаем количество элементов
                return Count;
            }

            //вставка элемента в заданную позицию.

            //вставка элемента в заданную позицию.
            public void insert(int position, char data)
            {

                if (position < 1 || position > Count)
                {
                    Console.Write("Error!");
                    Environment.Exit(1);
                }

                if (position == 1)
                {
                    Element ptr = Head;
                    Head = new Element();
                    Head.data = (sbyte)data;
                    Head.Next = ptr;
                }

                else if (position == Count)
                {
                    Element ptr = Tail;
                    Tail = new Element();
                    Tail.data = (sbyte)data;
                    Tail.Next = null;
                    ptr.Next = Tail;
                }

                else
                {
                    Element ptr = Head;
                    int i = 1;
                    while (i < position - 1)
                    {
                        ptr = ptr.Next;
                        i++;
                    }

                    Element prev = ptr;
                    Element next = ptr.Next;
                    Element cur = new Element();
                    prev.Next = cur;
                    cur.data = (sbyte)data;
                    cur.Next = next;
                }
                Count++;
            }
            //Удаление элемента по заданной позиции.
            //Удаление элемента по заданной позиции.
            public void erase(int position)
            {
                if (position < 1 || position > Count)
                {
                    Console.Write("Error!");
                    Environment.Exit(1);
                }

                if (position == 1)
                {
                    Element ptr = Head;
                    Head = Head.Next;
                    if (ptr != null)
                        ptr.Dispose();
                }

                else if (position == Count)
                {
                    int i = 1;
                    Element ptr = Head;
                    while (i < Count - 1)
                    {
                        ptr = ptr.Next;
                        i++;
                    }
                    Tail = ptr;
                    if (Tail.Next != null)
                        Tail.Next.Dispose();
                    Tail.Next = null;
                }
                else
                {
                    Element ptr = Head;
                    int i = 1;
                    while (i < position - 1)
                    {
                        ptr = ptr.Next;
                        i++;
                    }

                    Element prev = ptr;
                    Element cur = ptr.Next;
                    Element next = cur.Next;
                    prev.Next = next;
                    if (cur != null)
                        cur.Dispose();
                }
                Count--;
            }
            //поиск i-го элемента.

            //поиск.
            public int? search(char data)
            {
                Element ptr = Head;

                int i = 1;

                while (ptr != null)
                {
                    if (ptr.data == data)
                    {
                        return i;
                    }
                    ptr = ptr.Next;
                    i++;
                }

                return null;
            }

        }
    }
}