using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Collections
{
    public class Knapsack
    {
        internal List<Element> _elements;
        internal List<List<Element>> _listMax;
        public string StringRappresentation { get; }

        private Knapsack() { }
        public Knapsack(List<Element> elements) : this()
        {
            _elements = elements;
        }
        public Knapsack(string str) 
        {
            StringRappresentation = str;
            _elements = AddString(str);
        }

        public Element TheHighest(int number, int maxWeight)
        {
            _listMax = new List<List<Element>>();
            List<Element> itemNotOverMaxWeight = new List<Element>();

            foreach (var item in _elements)
            {
                _listMax.Add(new List<Element>() { item });
                SetAll(new List<Element>() { item }, number, _listMax.Count - 1);
            }

            //FilterDouble(); <-- per controllare tra i doppioni:inutile

            foreach (var list in _listMax)
            {
                Element element = new Element();

                foreach (var item in list)
                {
                    element += item;
                }

                if (element._weight <= maxWeight)
                {
                    itemNotOverMaxWeight.Add(element);
                }
            }

            if(itemNotOverMaxWeight.Count<1)
            {
                return new Element("lista non trovata", 0, 0);
            }

            itemNotOverMaxWeight.Sort((x, y) => x._value.CompareTo(y._value));

            return itemNotOverMaxWeight[itemNotOverMaxWeight.Count - 1];
        }

        private void SetAll(List<Element> locked, int number, int index)
        {
            var copyListMax = CopyFrom(_listMax[index]);
            int copyIndex = index;
            int countList = _listMax[index].Count;

            foreach (var item in _elements)
            {
                if (countList < number && !locked.Contains(item))
                {
                    List<Element> copyLocked = CopyFrom(locked);
                    if (copyIndex != index)
                    {
                        _listMax.Add(new List<Element>(copyListMax));
                        copyIndex = _listMax.Count - 1;
                    }

                    _listMax[copyIndex].Add(item);
                    copyLocked.Add(item);
                    SetAll(copyLocked, number, copyIndex);
                    index++;
                }
            }
        }
        private T CopyFrom<T>(T list) where T : class, IEnumerable, ICollection, IList, new()
        {
            T result = new T();
            foreach (var n in list)
            {
                result.Add(n);
            }
            return result;
        }

        private List<Element> AddString(string str)
        {
            char excluded1 = '(';
            char excluded2 = ')';
            char excluded3 = ',';
            List<List<string>> all = new List<List<string>>();
            List<Element> finalAll = new List<Element>();

            str.Trim();


            for (int index = 0; index < str.Count(); index++)
            {
                List<string> temp = new List<string>();

                //if (str[index] == excluded1)                
                string name = "";
                for (; index < str.Count(); index++)
                {
                    if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
                    {
                        name += str[index];
                    }

                    if (str[index] == excluded3)
                    {
                        temp.Add(name);
                        name = "";
                    }

                    if (str[index] == excluded2)
                    {
                        temp.Add(name);
                        break;
                    }
                }

                all.Add(temp);
            }

            foreach (var item in all)
            {
                int value = Convert.ToInt32(item[1]);
                int weight = Convert.ToInt32(item[2]);
                finalAll.Add(new Element(item[0], value, weight));
            }
            return finalAll;
        }
    }

    public struct Element
    {
        internal string _name;
        internal int _value;
        internal int _weight;

        public Element(string name, int value, int weight)
        {
            this._name = name;
            this._value = value;
            this._weight = weight;
        }

        #region override
        public override bool Equals(object obj1)
        {
            var obj = (Element)obj1;
            return this._name.Equals(obj._name);
        }
        public override string ToString()
        {
            return $"[nomi={_name}, valore={_value}, peso={_weight}]";
        }
        #endregion

        #region operatori 
        public static bool operator ==(Element ele1, Element ele2)
        {
            return false;
        }
        public static bool operator !=(Element ele1, Element ele2)
        {
            return false;
        }

        public static Element operator +(Element item1, Element item2)
        {
            return new Element(item1._name + "+" + item2._name, item1._value + item2._value, item2._weight + item1._weight);
        }
        public static Element operator -(Element item1, Element item2)
        {
            return new Element("(" + item1._name + "-" + item2._name + ")", item1._value - item2._value, item2._weight - item1._weight);
        } //inutile
        #endregion
    }
}

