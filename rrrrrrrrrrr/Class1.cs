using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rrrrrrrrrrr
{
    public  class Class1
    {
        public struct menu
        {
            public string name;
            public double price;

            public menu(string _name, double _price)
            {
                name = _name;
                price = _price;

            }
        }

        public List<menu> menus = new List<menu>();

       
        public  struct check
        {
            public string name;
            public double price;

            public check(string _name, double _price)
            {
                name = _name;
                price = _price;

            }
        }
        public List<check> _check = new List<check>();

        public struct pass
        {
            public string name;
            public double price;

            public pass(string _name, double _price)
            {
                name = _name;
                price = _price;

            }
        }
        public List<pass> _pass = new List<pass>();

        public void pass_add(string _name, double _price)
        {
            _pass.Add(new pass(_name, _price));

        }

        public void pass_dell()
        {
           for(int i = 0; i<_pass.Count; i++)
            {
                _pass.RemoveAt(i);
            }

        }
        public struct _class
        {
            public string suname;
            public string name;
            
            public int age;

            public _class(string _suname, string _name, int _age)
            {
                suname = _suname;
                name = _name;
                age = _age;

            }
        }
        public List<_class> _classs = new List<_class>();

        public void class_add(string _suname, string _name, int _age)
        {
            _classs.Add(new _class(_suname, _name, _age));
         
        }
        public void class_dell(int index)
        {
            _classs.RemoveAt(index);
        }


        public void _add(string _name, double _price)
        {
            menus.Add(new menu(_name, _price));
           
        }
        public void _dell(int index)
        {
            menus.RemoveAt(index);
        }
        public void _Add(string _name, double _price)
        {
            _check.Add(new check(_name, _price));
            Console.WriteLine(_name + _price);
        }
        public void _Dell(int index)
        {
            _check.RemoveAt(index);
        }
    }
}
