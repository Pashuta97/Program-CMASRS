using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_CMASRS.Model
{
    class Item
    {
        private string _name;
        private List<Element> _elements = new List<Element>();
        private Element _criteria = new Element();
        private Element _importantCriteria = new Element();
        private List<string> _nameCriteria = new List<string>();
        private int _count = 1;

        private double _deviation = -1;
        private int _deviationItem = -1;
        private double _price = 0;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Element> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public Element Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        public Element ImportantCriteria
        {
            get { return _importantCriteria; }
            set { _importantCriteria = value; }
        }

        public List<string> NameCriteria
        {
            get { return _nameCriteria; }
            set { _nameCriteria = value; }
        }

        public double Deviation
        {
            get { return _deviation; }
        }

        public int DeviationItemIndex
        {
            get { return _deviationItem; }

        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }


        public int FindRelevantElement()
        {
            _deviation = -1;
            _deviationItem = -1;
            int _index = 0;
            foreach (Element _element in _elements)
            {
                double _tempDeviation = 0;
                int _tempDevItem = _index;

                if (_element.Characteristics.Count != _criteria.Characteristics.Count) throw new Exception("Не співпадає кількість характеристик елемента №" + _index.ToString() + "з кільістю критеріїв");

                for (int i = 0; i < _criteria.Characteristics.Count; i++)
                {
                    _tempDeviation += (Math.Abs(_element.Characteristics[i] - _criteria.Characteristics[i]) / _criteria.Characteristics[i]) * _importantCriteria.Characteristics[i];
                }

                _tempDeviation += (Math.Abs(_element.Price - _criteria.Price) / _criteria.Price) * _importantCriteria.Price;

                if (_deviationItem != -1)
                {
                    if (_deviation > _tempDeviation)
                    {
                        _deviation = _tempDeviation;
                        _deviationItem = _tempDevItem;
                    }
                }
                else
                {
                    _deviation = _tempDeviation;
                    _deviationItem = _tempDevItem;
                }
                _index++;
            }

            
            
            return _deviationItem;
        }

        public double Price()
        {
            _price = _elements[_deviationItem].Price * _count;
            return _price;
        }

        public Item() { }

        public Item(string _name, int _count, Element _criteria, Element _importantCriteria, List<string> _nameCriteria)
        {
            this._name = _name;
            this._count = _count;
            this._criteria = _criteria;
            this._importantCriteria = _importantCriteria;
            this._nameCriteria = _nameCriteria;
        }
    }
}
