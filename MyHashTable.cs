using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10Lab;
namespace Лабораторная_работа_12_2
{
    internal class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>?[] table;
        public int Capacity => table.Length;

        //constructor
        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];
        }
        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        //public MyHashTable(int size)
        //{
        //    if (size <= 0) throw new Exception("size less zero");
        //    beg = MakeRandomData();
        //    end = beg;
        //    for (int i = 1; i < size; i++)
        //    {
        //        T newItem = MakeRandomItem();
        //        AddToEnd(newItem);
        //    }
        //    count = size;
        //}
        int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
       
        public void PrintTable()
        {
            for(int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] != null) //не пустая ссылка
                {
                    Console.WriteLine(table[i].Data);//вывели информацию
                    if (table[i].Next != null)//не пустая цепочка
                    {
                        Point<T>? current = table[i].Next;//идем по цепочке
                        while(current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }

        public void AddPoint(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null) //пустая позиция
            {
                table[index] = new Point<T>(data);
                table[index].Data = data;
            } 
            else //есть цепочка
            {
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
            }
        }

        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table == null)
                throw new Exception("empty table");
            if (table[index] == null)//цепочка пустая, элемента нет
                return false;
            if (table[index].Data.Equals(data))//попали на нужный элемент
                return true;
            else
            {
                Point<T>? current = table[index];//идем по цепочке
                while(current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }

        public bool RemoveData(T data)
        {
            Point<T>? current;
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null) //один элемент в цепочке
                    table[index] = null;
                else
                { 
                    table[index] = table[index].Next;
                    table[index] = null;
                }
                return true;
            }
            else
            {
                current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data)) //нашли и удаляем
                    {
                        Point<T>? pred = current.Pred;
                        Point<T>? next = current.Next;
                        pred.Next = next;
                        current.Pred = null;
                        if (next != null)
                            next.Pred = pred;
                        return true;
                    }
                    current = current.Next;
                }

            }
            return false;
        }


    }
}
