using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicCalculator
{
    class ot
    {
        public const int POW = 0;
        public const int ADD = 1;
        public const int SUB = 2;
        public const int MUL = 3;
        public const int DIV = 4;
    }

    class ep
    {
        public const int EXP = 0;
        public const int VAL = 1;
        public const int VAR = 2;
    }

    class Expression
    {
        public int OpType;
        public int ExpType;
        public Expression Op1;
        public Expression Op2;
        public double Val;

        public Expression(int op_type, Expression op1, Expression op2)
        {
            OpType = op_type;
            ExpType = ep.EXP;
            Op1 = op1;
            Op2 = op2;
        }
        public Expression(double value)
        {
            ExpType = ep.VAL;
            Val = value;
        }
        public Expression()
        {
            ExpType = ep.VAR;
        }
    }

    class MathManager
    {
        private Expression main_exp;

        public void ParseExpression(String exp)
        {
            Expression aux = new Expression(0);
            Expression op = new Expression(0);

            int exp_type = -1;
            int state = 0;
            int i = 0;

            while(i<exp.Length)
            {
                char c = exp[i];

                switch(c)
                {
                    case 'x': aux = new Expression(); break;
                    case '^': exp_type = ot.POW; break;
                    case '+': exp_type = ot.ADD; break;
                    case '-': exp_type = ot.SUB; break;
                    case '*': exp_type = ot.MUL; break;
                    case '/': exp_type = ot.DIV; break;

                    default:
                        if (Char.IsDigit(c))
                        {
                            String number = "";
                            number = String.Concat(number, c.ToString());
                            int aux_i = 1;

                            while((i + aux_i < exp.Length) && (Char.IsDigit(exp[i + aux_i]) || exp[i + aux_i] == '.'))
                            {
                                number = String.Concat(number, exp[i + aux_i].ToString());
                                aux_i++;
                            }

                            i += aux_i - 1;

                            aux = new Expression(float.Parse(number));
                        }
                        break;
                }

                switch(state)
                {
                    case 0: op = aux; break;
                    case 2: op = new Expression(exp_type, op, aux); break;
                    default: break;
                }

                state++;
                if (state > 2)
                    state = 1;

                i++;
            }

            main_exp = op;

/*            x^2 + (x^3)/3 

            Expression exp1 = new Expression();
            Expression exp2 = new Expression(2);
            Expression exp3 = new Expression();
            Expression exp4 = new Expression(3);
            Expression exp5 = new Expression(3);

            Expression exp6 = new Expression(ot.POW, exp1, exp2);
            Expression exp7 = new Expression(ot.POW, exp3, exp4);
            Expression exp8 = new Expression(ot.DIV, exp7, exp5);
            Expression exp9 = new Expression(ot.ADD, exp6, exp8);

            main_exp = exp9;*/
        }

        public double EvaluateExpression(double var_value, Expression exp)
        {
            if (exp.ExpType == ep.VAL)
                return exp.Val;

            if (exp.ExpType == ep.VAR)
                return var_value;

            double res = 0;
            double op1 = EvaluateExpression(var_value, exp.Op1);
            double op2 = EvaluateExpression(var_value, exp.Op2);

            switch (exp.OpType)
            {
                case ot.POW:
                    res = Math.Pow(op1, op2);
                    break;

                case ot.ADD:
                    res = op1 + op2;
                    break;

                case ot.MUL:
                    res = op1 * op2;
                    break;

                case ot.SUB:
                    res = op1 - op2;
                    break;

                case ot.DIV:
                    res = op1 / op2;
                    break;
            }

            return res;
        }

        public double Evaluate(double var_value)
        {
            return EvaluateExpression(var_value, main_exp);
        }
    }
}
