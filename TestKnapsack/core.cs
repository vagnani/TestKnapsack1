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

        private Knapsack() { }
        public Knapsack(List<Element> elements)
        {
            _elements = elements;
        }

        public Element TheHighest(int number, int maxWeight)
        {
            _listMax = new List<List<Element>>();
            List<Element> itemNotOverMaxWeight = new List<Element>();

            foreach (var item in _elements)
            {
                _listMax.Add(new List<Element>() { item });
                SetAll(new List<Element>() { item }, number, _listMax.Count-1);
            }

            FilterDouble();

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

            itemNotOverMaxWeight.Sort((x, y) => x._value.CompareTo(y._value));

            return itemNotOverMaxWeight[itemNotOverMaxWeight.Count - 1];
        }

        private void FilterDouble()
        {
            //throw new NotImplementedException();
        }

        //private void SetAll(Coordinate _first, List<Coordinate> locked, int index)
        private void SetAll(List<Element> locked, int number, int index)
        {
            var copyListMax = CopyFrom(_listMax[index]);
            int copyIndex = index;

            foreach (var item in _elements)
            {
                if (_listMax[copyIndex].Count < number && !locked.Contains(item))
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

        #region add string

        //public void AddString(string str)
        //{
        //    str.Trim();

        //    char excluded1 = '(';
        //    char excluded2 = ')';
        //    char excluded3 = ',';

        //    List<List<string>> all = new List<List<string>>();

        //    for (int index = 0; index < str.Count(); index++)
        //    {
        //        List<string> temp = new List<string>();

        //        //if (str[index] == excluded1)                
        //        string name = "";
        //        for (; index <= str.Count(); index++)
        //        {
        //            if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
        //            {
        //                name += str[index];
        //            }

        //            if (str[index] == excluded3)
        //            {
        //                temp.Add(name);
        //                name = "";
        //            }

        //            if (str[index] == excluded2)
        //            {
        //                temp.Add(name);
        //                break;
        //            }
        //        }

        //        all.Add(temp);
        //    }

        //    List<string> mustContain = new List<string>() { _first.name };
        //    int countDone = 0;
        //    //int indexMust = 0;


        //    //to see again the function of islock, i mean when i must lock the iterazione
        //    for (int indexMust = 0; countDone < all.Count; indexMust++)
        //    {
        //        List<List<string>> rightToAdd = new List<List<string>>();

        //        foreach (var list in all)
        //        {
        //            if (list[0] == mustContain[indexMust])
        //            {
        //                rightToAdd.Add(list);
        //            }
        //        }

        //        if (rightToAdd.Count > 0)
        //        {
        //            foreach (var list in rightToAdd)
        //            {
        //                SetAllNodeString();

        //                //if(_allNodeString.Contains(list[0]))
        //                int indexFather = _allNodeString.FindIndex(x => x == list[0]);

        //                if (_allNodeString.Contains(list[1]))
        //                {
        //                    int indexSon = _allNodeString.FindIndex(x => x == list[1]);
        //                    AddAfter(_allNode[indexFather], _allNode[indexSon]);
        //                    _allNode[indexFather].value.Add(list[1], Convert.ToInt32(list[2]));
        //                    mustContain.Add(list[1]);
        //                    countDone++;
        //                }
        //                else
        //                {
        //                    var node = new MyLinkedListNode(list[1], new Dictionary<string, int>());
        //                    //check if it is added to _allNode
        //                    AddAfter(_allNode[indexFather], node);
        //                    _allNode[indexFather].value.Add(list[1], Convert.ToInt32(list[2]));
        //                    mustContain.Add(list[1]);
        //                    countDone++;
        //                }
        //            }
        //        }
        //    }
        //}           
        #endregion
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

        public override bool Equals(object obj1)
        {
            var obj = (Element)obj1;
            return this._name.Equals(obj._name);
        }
        public override string ToString()
        {
            return $"[nomi={_name}, valore={_value}, peso={_weight}]";
        }

        #region operatori (da definire)
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
        }
        #endregion
    }
}

