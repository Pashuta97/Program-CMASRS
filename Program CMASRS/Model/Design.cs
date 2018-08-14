using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_CMASRS.Model
{
    class Design
    {
        private string _name;
        private List<Item> _items = new List<Item>();
        private double _price = 0;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public double Price()
        {
            _price = 0;
            int _index = 0;
            foreach( Item _item in _items)
            {
                if (_item.Price() == 0) throw new Exception("Не вибрано кращий елемент в предметі №" + _index.ToString());
                _price += _item.Price();
                _index++;
            }
            
            return _price;
        }

        public Design(string _name, List<Item> _items)
        {
            this._name = _name;
            this._items = _items;
        }

        public Design(string _name)
        {
            this._name = _name;
        }

        public Design() { }

        public void FindRelevant()
        {
            foreach(Item _item in _items)
            {
                _item.FindRelevantElement();
            }

        }
    }
}
