using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_CMASRS.Model
{
    class Element
    {
        private string _name;
        private double _price;
        private List<double> _characteristics = new List<double>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public List<double> Characteristics
        {
            get { return _characteristics; }
            set { _characteristics = value; }
        }

        public Element() { }

        public Element(string _name, double _price, List<double> _characteristics)
        {
            this._name = _name;
            this._price = _price;
            this._characteristics = _characteristics;
        }

        public Element( double _price, List<double> _characteristics)
        {
            this._price = _price;
            this._characteristics = _characteristics;
        }
    }
}
