using Godot;
using System;

public partial class Main : TextureRect
{
    public static Main Console;
    public enum Trit : sbyte
    {
        Neutral = 0,
        Negative = -1,
        Positive = 1,
    }
    public struct Tryte(Trit T0, Trit T1, Trit T2, Trit T3, Trit T4, Trit T5, Trit T6, Trit T7, Trit T8)
    {
        static public Tryte Zero()
        {
            return new(Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        static public Tryte One()
        {
            return new(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        static public Tryte NegativeOne()
        {
            return new(Trit.Negative, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }

        public Trit[] Trits = [T0, T1, T2, T3, T4, T5, T6, T7, T8];
        public static Tryte Flip(Tryte InputTryte)
        {
            Tryte OutputTryte = new();
            for (int T = 0; T < InputTryte.Trits.Length; T++)
            {
                if (InputTryte.Trits[T] == Trit.Positive)
                {
                    OutputTryte.Trits[T] = Trit.Negative;
                }
                else if (InputTryte.Trits[T] == Trit.Negative)
                {
                    OutputTryte.Trits[T] = Trit.Positive;
                }
            }
            return OutputTryte;
        }
        public Tryte Combine(Tryte InputTryte, bool Subtract, Tryte OverflowMultiplier)
        {
            Tryte OutputTryte = Zero();
            Trit Carry = 0;
            for (int T = 0; T < Trits.Length; T++)
            {
                int num;
                if (Subtract == false)
                {
                    num = (sbyte)Trits[T] + (sbyte)Carry + (sbyte)InputTryte.Trits[T];
                }
                else
                {
                    num = (sbyte)Trits[T] + (sbyte)Carry - (sbyte)InputTryte.Trits[T];
                }
                switch (num)
                {
                    case -3:
                        OutputTryte.Trits[T] = Trit.Neutral;
                        Carry = Trit.Negative;
                        break;
                    case -2:
                        OutputTryte.Trits[T] = Trit.Positive;
                        Carry = Trit.Negative;
                        break;
                    case -1:
                        OutputTryte.Trits[T] = Trit.Negative;
                        Carry = Trit.Neutral;

                        break;
                    case 0:
                        OutputTryte.Trits[T] = Trit.Neutral;
                        Carry = Trit.Neutral;

                        break;
                    case 1:
                        OutputTryte.Trits[T] = Trit.Positive;
                        Carry = Trit.Neutral;

                        break;
                    case 2:
                        OutputTryte.Trits[T] = Trit.Negative;
                        Carry = Trit.Positive;
                        break;
                    case 3:
                        OutputTryte.Trits[T] = Trit.Neutral;
                        Carry = Trit.Positive;
                        break;
                    default:
                        GD.Print("WTF");
                        break;
                }
            }
            if (Carry == Trit.Positive)
            {
                Main.Console.Overflows.Combine(new Tryte(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral).Multiply(OverflowMultiplier), false, Zero());
            }
            else if (Carry == Trit.Negative)
            {
                Main.Console.Underflows.Combine(new Tryte(Trit.Negative, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral).Multiply(OverflowMultiplier), false, Zero());
            }
            return OutputTryte;
        }

        public Tryte Multiply(Tryte InputTryte)
        {
            Tryte DoubleTryte = new() { Trits = new Trit[18] };
            Tryte StepOutput = Zero();
            Tryte StepOutputDoubleTryte = new() { Trits = new Trit[18] };
            for (int M = 0; M < InputTryte.Trits.Length; M++)
            {
                StepOutput = Zero();
                for (int T = 0; T < Trits.Length; T++)
                {
                    int num = (sbyte)Trits[T] * (sbyte)InputTryte.Trits[M];
                    switch (num)
                    {
                        case -1:
                            StepOutput.Trits[T] = Trit.Negative;

                            break;
                        case 0:
                            StepOutput.Trits[T] = Trit.Neutral;

                            break;
                        case 1:
                            StepOutput.Trits[T] = Trit.Positive;
                            break;
                        default:
                            GD.Print("WTF2");
                            break;
                    }
                }
                StepOutputDoubleTryte = new() { Trits = new Trit[18] };
                for (int T = 0; T < StepOutput.Trits.Length; T++)
                {
                    StepOutputDoubleTryte.Trits[T + M] = StepOutput.Trits[T];
                }
                DoubleTryte = DoubleTryte.Combine(StepOutputDoubleTryte, false, Zero());
            }
            Tryte OutputTryte = new(DoubleTryte.Trits[0], DoubleTryte.Trits[1], DoubleTryte.Trits[2], DoubleTryte.Trits[3], DoubleTryte.Trits[4], DoubleTryte.Trits[5], DoubleTryte.Trits[6], DoubleTryte.Trits[7], DoubleTryte.Trits[8]);
            Tryte OutputOverflow = new(DoubleTryte.Trits[9], DoubleTryte.Trits[10], DoubleTryte.Trits[11], DoubleTryte.Trits[12], DoubleTryte.Trits[13], DoubleTryte.Trits[14], DoubleTryte.Trits[15], DoubleTryte.Trits[16], DoubleTryte.Trits[17]);
            sbyte OverflowSign = 0;
            int OverflowCheckPoint = OutputOverflow.Trits.Length - 1;
            while (OverflowSign == 0 && OverflowCheckPoint >= 0)
            {
                OverflowSign = (sbyte)OutputOverflow.Trits[OverflowCheckPoint];
                OverflowCheckPoint -= 1;
            }
            if (OverflowSign == 1)
            {
                Main.Console.Overflows.Combine(OutputOverflow, false, Zero());
            }
            else if (OverflowSign == -1)
            {
                Main.Console.Underflows.Combine(OutputOverflow, false, Zero());
            }
            return OutputTryte;
        }

        public int IntValue()
        {
            int ToReturn = 0;
            int multiplier = 1;
            for (int T = 0; T < Trits.Length; T++)
            {
                ToReturn += multiplier * (sbyte)Trits[T];
                multiplier *= 3;
            }
            return ToReturn;
        }
    }
    public Tryte Input;
    public Tryte Overflows = Tryte.Zero();
    public Tryte Underflows = Tryte.Zero();
    public Tryte[,] Sprites = new Tryte[12, 243];
    public Tryte[,] GameObjects = new Tryte[0, 108];

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Console = this;
        base._Ready();
        var asdf = new Tryte(Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive);
        GD.Print(asdf.IntValue());
        asdf = asdf.Combine(new(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral), false, Tryte.One());
        GD.Print(asdf.IntValue());
        GD.Print(Overflows.IntValue());
        GD.Print(new Tryte(Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Negative).IntValue());
    }
}
