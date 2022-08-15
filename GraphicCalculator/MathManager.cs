using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicCalculator
{
    class Operation
    {
        public int Type;
        public double Arg;

        public Operation(int type, double arg)
        {
            Type = type;
            Arg = arg;
        }
    }

    class OpType
    {
        public const int POW = 0;
        public const int ADD = 1;
        public const int MUL = 2;
    }

    class MathManager
    {
        List<Operation> Operations;

        public MathManager()
        {
            Operations = new List<Operation>();
        }

        public void ParseExpression(String exp)
        {
            Operations.Clear();
            Operations.Add(new Operation(OpType.ADD, -1));
            Operations.Add(new Operation(OpType.POW, 3));
        }

        public double ApplyExpression(double x)
        {
            double y = x;
            Operation op;

            for (int i = 0; i < Operations.Count; i++){
                op = Operations[i];
                switch (op.Type)
                {
                    case OpType.POW:
                        y = Math.Pow(y, op.Arg);
                        break;

                    case OpType.ADD:
                        y = y + op.Arg;
                        break;

                    case OpType.MUL:
                        y = y * op.Arg;
                        break;
                }
            }

            return y;
        }
    }
}
