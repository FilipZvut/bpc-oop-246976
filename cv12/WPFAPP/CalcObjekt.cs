using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAPP;

class CalcObjekt
{
    public CalcObjekt(decimal operand1, decimal operand2, string operation)
    {
        Operand1 = operand1;
        Operand2 = operand2;
        Operation = operation;
    }

    public decimal Operand1 { get; set; }
    public decimal Operand2 { get; set; }
    public string Operation { get; set; }

}
