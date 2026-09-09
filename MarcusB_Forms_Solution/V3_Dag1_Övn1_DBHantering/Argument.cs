using System;
using System.Collections.Generic;
using System.Text;
using static V3_Dag1_Övn1_DBHantering.MainWindow;

namespace V3_Dag1_Övn1_DBHantering
{
    public class Argument
    {
        // Globala variabler
        public string Column { get; set; }
        public string OperatorType { get; set; }
        public string Value { get; set; }

        public Argument(string column, string operatorType, string value)
        {
            this.Column = column;
            this.OperatorType = operatorType;
            this.Value = value;
        }
        public override string ToString()
        {
            return $"{Column} {OperatorType} '{Value}'";
        }    
    }
}
