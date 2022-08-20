using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicCalculator
{
    class ot
    {
        public const int ADD = 0;
        public const int SUB = 1;
        public const int MUL = 2;
        public const int DIV = 3;
        public const int POW = 4;

        public const int SIN = 100;
        public const int COS = 101;
        public const int TAN = 102;
        public const int CSC = 103;
        public const int SEC = 104;
        public const int COT = 105;
        public const int ASIN = 106;
        public const int ACOS = 107;
        public const int ATAN = 108;
        public const int ACSC = 109;
        public const int ASEC = 110;
        public const int ACOT = 111;
        public const int EXP = 112;
        public const int LOG = 113;
        public const int LN  = 114;

        public const int PAR_L = 200;
        public const int PAR_R = 201;

        public const int UNDEF = -1;

        public static int HigherPrecedence(int ot1, int ot2)
        {
            if (GetPrecedence(ot1) >= GetPrecedence(ot2)) 
                return ot1;

            return ot2;
        }

        public static bool IsFunction(int ot)
        {
            return (ot >= 100 && ot < 200);
        }

        private static int GetPrecedence(int ot)
        {
            switch (ot)
            {
                case SUB:
                case ADD:
                    return 0;
                case MUL:
                case DIV:
                    return 1;
                case POW:
                    return 2;
                case PAR_L:
                case PAR_R:
                    return int.MinValue;
                case UNDEF:
                    return int.MaxValue;
            }

            return -1;
        }
    }

    class ep
    {
        public const int EXP = 0;
        public const int VAL = 1;
        public const int VAR = 2;
        public const int FUN = 3;
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

        public Expression(int op_type, Expression exp)
        {
            ExpType = ep.FUN;
            OpType = op_type;
            Op1 = exp;
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
        FunctionTrie functions;
        private Expression main_exp;
        private char variable = 'x';

        public MathManager()
        {
            functions = new FunctionTrie();
            functions.Insert("sin(", ot.SIN);
            functions.Insert("cos(", ot.COS);
            functions.Insert("tan(", ot.TAN);
            functions.Insert("csc(", ot.CSC);
            functions.Insert("sec(", ot.SEC);
            functions.Insert("cot(", ot.COT);
            functions.Insert("asin(", ot.ASIN);
            functions.Insert("acos(", ot.ACOS);
            functions.Insert("atan(", ot.ATAN);
            functions.Insert("acsc(", ot.ACSC);
            functions.Insert("asec(", ot.ASEC);
            functions.Insert("acot(", ot.ACOT);

            functions.Insert("exp(", ot.EXP);
            functions.Insert("log(", ot.LOG);
            functions.Insert("ln(", ot.LN);
        }

        public void SetVariableChar(char var)
        {
            variable = var;
        }

        public bool ParseExpression(String exp)
        {
            Stack<int> operations = new Stack<int>();
            List<Expression> expressions = new List<Expression>();
            main_exp = new Expression(0);

            int i = 0;
            int first;
            int operation;
            int length = 0;
            char curr;

            try
            {
                // Shunting Yard algorithm
                while (i < exp.Length)
                {
                    curr = exp[i];
                    operation = ot.UNDEF;

                    switch (curr)
                    {
                        case '^': operation = ot.POW; break;
                        case '+': operation = ot.ADD; break;
                        case '-': operation = ot.SUB; break;
                        case '*': operation = ot.MUL; break;
                        case '/': operation = ot.DIV; break;
                        case '(': operation = ot.PAR_L; break;
                        case ')': operation = ot.PAR_R; break;

                        default:
                            if (Char.IsDigit(curr))
                            {
                                String number = "";
                                while ((i < exp.Length) && (Char.IsDigit(exp[i]) || exp[i] == '.'))
                                    number = String.Concat(number, exp[i++].ToString());

                                i--;
                                expressions.Add(new Expression(float.Parse(number)));
                            }
                            else if (functions.Search(exp.Substring(i), ref operation, ref length))
                            {
                                i += length - 1;
                            }
                            else if (curr == variable)
                            {
                                expressions.Add(new Expression());
                            }

                            break;
                    }

                    if (operations.Count > 0 && operation != ot.UNDEF) 
                    {
                        if (operation == ot.PAR_R)
                        {
                            operation = ot.UNDEF;
                            while (operations.Count > 0 && operations.Peek() != ot.PAR_L && !ot.IsFunction(operations.Peek()))
                                MergeLastTwoExpressions(expressions, operations.Pop());

                            if (operations.Count > 0)
                            {
                                if (operations.Peek() == ot.PAR_L)
                                    operations.Pop();
                                else if (ot.IsFunction(operations.Peek()))
                                    MergeLastExpression(expressions, operations.Pop());
                            }
                        }
                        else if (operation != ot.PAR_L && !ot.IsFunction(operation))
                        {
                            first = operations.Peek();
                            if (ot.HigherPrecedence(first, operation) == first)
                                MergeLastTwoExpressions(expressions, operations.Pop());
                        }
                    }

                    if (operation != ot.UNDEF)
                        operations.Push(operation);

                    i++;
                }

                while (operations.Count > 0)
                    if (!MergeLastTwoExpressions(expressions, operations.Pop()))
                        return false;

                if (expressions.Count != 1)                    
                    return false;

                 main_exp = expressions[0];
                 return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool MergeLastTwoExpressions(List<Expression> expressions, int op)
        {
            if (expressions.Count < 2)
                return false;

            Expression exp1 = expressions[expressions.Count - 2];
            Expression exp2 = expressions[expressions.Count - 1];
            expressions.RemoveAt(expressions.Count - 1);
            expressions.RemoveAt(expressions.Count - 1);
            expressions.Add(new Expression(op, exp1, exp2));
            return true;
        }

        private bool MergeLastExpression(List<Expression> expressions, int op)
        {
            if (expressions.Count < 1)
                return false;

            Expression exp = expressions[expressions.Count - 1];
            expressions.RemoveAt(expressions.Count - 1);
            expressions.Add(new Expression(op, exp));
            return true;
        }

        public double EvaluateExpression(double var_value, Expression exp)
        {
            if (exp.ExpType == ep.VAL)
                return exp.Val;

            if (exp.ExpType == ep.VAR)
                return var_value;

            if (exp.ExpType == ep.EXP)
            {
                double op1 = EvaluateExpression(var_value, exp.Op1);
                double op2 = EvaluateExpression(var_value, exp.Op2);

                switch (exp.OpType)
                {
                    case ot.POW: return Math.Pow(op1, op2);
                    case ot.ADD: return op1 + op2;
                    case ot.MUL: return op1 * op2;
                    case ot.SUB: return op1 - op2;
                    case ot.DIV: return op1 / op2;
                    default: return 0;
                }
            }

            if (exp.ExpType == ep.FUN)
            {
                double op = EvaluateExpression(var_value, exp.Op1);

                switch (exp.OpType)
                {
                    case ot.SIN: return Math.Sin(op);
                    case ot.COS: return Math.Cos(op);
                    case ot.TAN: return Math.Tan(op);
                    case ot.CSC: return 1/Math.Sin(op);
                    case ot.SEC: return 1/Math.Cos(op);
                    case ot.COT: return 1/Math.Tan(op);
                    case ot.ASIN: return Math.Asin(op);
                    case ot.ACOS: return Math.Acos(op);
                    case ot.ATAN: return Math.Atan(op);
                    case ot.ACSC: return Math.Asin(1/op);
                    case ot.ASEC: return Math.Acos(1/op);
                    case ot.ACOT: return Math.Atan(1/op);
                    case ot.EXP: return Math.Exp(op);
                    case ot.LOG: return Math.Log10(op);
                    case ot.LN: return Math.Log(op);
                    default: return 0;
                }
            }

            return 0;
        }

        public double Evaluate(double var_value)
        {
            return EvaluateExpression(var_value, main_exp);
        }
    }
}
