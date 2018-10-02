using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHW
{
    public class Place
    {
        private int _place;
        private int _row;
        private bool Empt = true;
        public Place() { }
        public Place(int place, int row,bool empty)
        {
            _place = place;
            _row = row;
            Empt = empty;
        }

        
        public bool GetEmpty()
        {
            return Empt;
        }
        public int GetPlace()
        {
            return _place;
        }
        public int GetRow()
        {
            return _row;
        }
        public void SetPlace(int place)
        {
            _place = place;
        }
        public void SetRow(int row)
        {
            _row = row;
        }
        public void SetEmpty(bool Empty)
        {
            Empt = Empty;
        }
        public bool PlaceGetEmpty() {
            return Empt;
        }
        public void PlaceGetEmpty(bool empty)
        {
            Empt=empty;
        }
       
    }
}
