using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopper
{
    interface IDesk
    {
        void saveOrderInfo(Desk desk);
        int validateIntInput(string iInput);
        bool checkValid(int value);
        bool checkValidString(string sInput);
    }
}
