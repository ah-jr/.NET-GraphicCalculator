using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicCalculator
{
    class OperationType
    {
        public const int POW = 0;
        public const int ADD = 1;
        public const int MUL = 2;
    }

    class OperandType
    {
        public const int EXP = 0;
        public const int VAL = 1;
        public const int VAR = 2;
    }

    class Operand
    {
        public Expression Exp;
        public double Val;
        public int Type;

        public Operand(Expression exp)
        {
            Type = OperandType.EXP;
            Exp = exp;
        }
        public Operand(double value)
        {
            Type = OperandType.VAL;
            Val = value;
        }
        public Operand()
        {
            Type = OperandType.VAR;
        }
    }

    class Expression
    {
        public int Type;
        public Operand Op1;
        public Operand Op2;

        public Expression(int type, Operand op1, Operand op2)
        {
            Type = type;
            Op1 = op1;
            Op2 = op2;
        }
    }

    class MathManager
    {
        private Expression main_exp;

        public void ParseExpression(String exp)
        {
            Operand op1 = new Operand();
            Operand op2 = new Operand(2);
            Operand op3 = new Operand();
            Operand op4 = new Operand(3);
            Operand op5 = new Operand(1/3);

            Expression exp1 = new Expression(OperationType.POW, op1, op2);
            Expression exp2 = new Expression(OperationType.POW, op3, op4);
            Expression exp3 = new Expression(OperationType.MUL, new Operand(exp2), op5);
            Expression exp4 = new Expression(OperationType.ADD, new Operand(exp1), new Operand(exp3));

            main_exp = exp4;
        }

        public double ApplyExpression(double var_value, Expression exp)
        {
            double res = 0;
            double op1;
            double op2;

            op1 = EvaluateOperand(var_value, exp.Op1);
            op2 = EvaluateOperand(var_value, exp.Op2);

            switch (exp.Type)
            {
                case OperationType.POW:
                    res = Math.Pow(op1, op2);
                    break;

                case OperationType.ADD:
                    res = op1 + op2;
                    break;

                case OperationType.MUL:
                    res = op1 * op2;
                    break;
            }

            return res;
        }

        private double EvaluateOperand(double var_value, Operand op)
        {
            double res = 0;

            switch (op.Type)
            {
                case OperandType.EXP:
                    res = ApplyExpression(var_value, op.Exp);
                    break;

                case OperandType.VAL:
                    res = op.Val;
                    break;

                case OperandType.VAR:
                    res = var_value;
                    break;
            }

            return res;
        }

    public double Evaluate(double var_value)
        {
            return ApplyExpression(var_value, main_exp);
        }
    }
}
