using Godot;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

public partial class Main : TextureRect
{
    public static Main Console;
    public enum Trit : sbyte
    {
        Neutral = 0,
        Negative = -1,
        Positive = 1,
    }
    public struct TriInt(Trit[] InputTrits)
    {
        public Trit[] Trits = InputTrits;
        static public TriInt SingleDigit(Trit T0)
        {
            return new([T0]);
        }
        static public TriInt Tryte(Trit T0, Trit T1, Trit T2, Trit T3, Trit T4, Trit T5, Trit T6, Trit T7, Trit T8)
        {
            return new([T0, T1, T2, T3, T4, T5, T6, T7, T8]);
        }

        static public TriInt TryteZero()
        {
            return Tryte(Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt TryteOne()
        {
            return Tryte(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt TryteNegativeOne()
        {
            return Tryte(Trit.Negative, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt Flip(TriInt InputTriInt)
        {
            Main.Console.WordRegisterA = new();
            for (int T = 0; T < InputTriInt.Trits.Length; T++)
            {
                if (InputTriInt.Trits[T] == Trit.Positive)
                {
                    Main.Console.WordRegisterA.Trits[T] = Trit.Negative;
                }
                else if (InputTriInt.Trits[T] == Trit.Negative)
                {
                    Main.Console.WordRegisterA.Trits[T] = Trit.Positive;
                }
            }
            return Main.Console.WordRegisterB;
        }
        public static TriInt Word(Trit T0, Trit T1, Trit T2, Trit T3, Trit T4, Trit T5, Trit T6, Trit T7, Trit T8, Trit T9, Trit T10, Trit T11, Trit T12, Trit T13, Trit T14, Trit T15, Trit T16, Trit T17, Trit T18, Trit T19, Trit T20, Trit T21, Trit T22, Trit T23, Trit T24, Trit T25, Trit T26, Trit T27, Trit T28, Trit T29, Trit T30, Trit T31, Trit T32, Trit T33, Trit T34, Trit T35)
        {
            return new([T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35]);
        }
        public static TriInt WordZero()
        {
            return Word(Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt WordOne()
        {
            return Word(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt WordMinusOne()
        {
            return Word(Trit.Negative, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt DoubleWord(Trit T0, Trit T1, Trit T2, Trit T3, Trit T4, Trit T5, Trit T6, Trit T7, Trit T8, Trit T9, Trit T10, Trit T11, Trit T12, Trit T13, Trit T14, Trit T15, Trit T16, Trit T17, Trit T18, Trit T19, Trit T20, Trit T21, Trit T22, Trit T23, Trit T24, Trit T25, Trit T26, Trit T27, Trit T28, Trit T29, Trit T30, Trit T31, Trit T32, Trit T33, Trit T34, Trit T35, Trit T36, Trit T37, Trit T38, Trit T39, Trit T40, Trit T41, Trit T42, Trit T43, Trit T44, Trit T45, Trit T46, Trit T47, Trit T48, Trit T49, Trit T50, Trit T51, Trit T52, Trit T53, Trit T54, Trit T55, Trit T56, Trit T57, Trit T58, Trit T59, Trit T60, Trit T61, Trit T62, Trit T63, Trit T64, Trit T65, Trit T66, Trit T67, Trit T68, Trit T69, Trit T70, Trit T71)
        {
            return new([T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71]);
        }
        public static TriInt DoubleWordZero()
        {
            return DoubleWord(Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt DoubleWordOne()
        {
            return DoubleWord(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public static TriInt DoubleWordMinusOne()
        {
            return DoubleWord(Trit.Negative, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral);
        }
        public TriInt Combine(TriInt InputTriInt, bool Subtract, TriInt OverflowMultiplier)
        {
            int OutputLength = Trits.Length;
            Main.Console.WordRegisterB = WordZero();
            Main.Console.WordRegisterB.Trits = new Trit[OutputLength];
            Trit Carry = 0;
            for (int T = 0; T < Trits.Length; T++)
            {
                int num;
                if (Subtract == false)
                {
                    num = (sbyte)Trits[T] + (sbyte)Carry + (sbyte)InputTriInt.Trits[T];
                }
                else
                {
                    num = (sbyte)Trits[T] + (sbyte)Carry - (sbyte)InputTriInt.Trits[T];
                }
                switch (num)
                {
                    case -3:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Neutral;
                        Carry = Trit.Negative;
                        break;
                    case -2:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Positive;
                        Carry = Trit.Negative;
                        break;
                    case -1:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Negative;
                        Carry = Trit.Neutral;

                        break;
                    case 0:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Neutral;
                        Carry = Trit.Neutral;

                        break;
                    case 1:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Positive;
                        Carry = Trit.Neutral;

                        break;
                    case 2:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Negative;
                        Carry = Trit.Positive;
                        break;
                    case 3:
                        Main.Console.WordRegisterB.Trits[T] = Trit.Neutral;
                        Carry = Trit.Positive;
                        break;
                    default:
                        GD.Print("WTF");
                        break;
                }
            }
            if (Carry == Trit.Positive)
            {
            }
            else if (Carry == Trit.Negative)
            {
                Main.Console.Overflows.Combine(Word(Trit.Positive, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral, Trit.Neutral).Multiply(OverflowMultiplier), false, WordZero());
            }
            return Main.Console.WordRegisterB;
        }

        public TriInt Multiply(TriInt InputTriInt)
        {
            for (int M = 0; M < InputTriInt.Trits.Length; M++)
            {
                Console.WordRegisterA = WordZero();
                for (int T = 0; T < Trits.Length; T++)
                {
                    int num = (sbyte)Trits[T] * (sbyte)InputTriInt.Trits[M];
                    switch (num)
                    {
                        case -1:
                            Console.WordRegisterA.Trits[T] = Trit.Negative;

                            break;
                        case 0:
                            Console.WordRegisterA.Trits[T] = Trit.Neutral;

                            break;
                        case 1:
                            Console.WordRegisterA.Trits[T] = Trit.Positive;
                            break;
                        default:
                            GD.Print("WTF2");
                            break;
                    }
                }
                Console.DoubleWordRegisterA = new() { Trits = new Trit[18] };
                for (int T = 0; T < Console.WordRegisterA.Trits.Length; T++)
                {
                    Console.DoubleWordRegisterA.Trits[T + M] = Console.WordRegisterA.Trits[T];
                }
                Console.DoubleWordRegisterB = Console.DoubleWordRegisterB.Combine(Console.WordRegisterA, false, WordZero());
            }
            Main.Console.WordRegisterB = Word(Console.DoubleWordRegisterB.Trits[0], Console.DoubleWordRegisterB.Trits[1], Console.DoubleWordRegisterB.Trits[2], Console.DoubleWordRegisterB.Trits[3], Console.DoubleWordRegisterB.Trits[4], Console.DoubleWordRegisterB.Trits[5], Console.DoubleWordRegisterB.Trits[6], Console.DoubleWordRegisterB.Trits[7], Console.DoubleWordRegisterB.Trits[8], Console.DoubleWordRegisterB.Trits[9], Console.DoubleWordRegisterB.Trits[10], Console.DoubleWordRegisterB.Trits[11], Console.DoubleWordRegisterB.Trits[12], Console.DoubleWordRegisterB.Trits[13], Console.DoubleWordRegisterB.Trits[14], Console.DoubleWordRegisterB.Trits[15], Console.DoubleWordRegisterB.Trits[16], Console.DoubleWordRegisterB.Trits[17], Console.DoubleWordRegisterB.Trits[18], Console.DoubleWordRegisterB.Trits[19], Console.DoubleWordRegisterB.Trits[20], Console.DoubleWordRegisterB.Trits[21], Console.DoubleWordRegisterB.Trits[22], Console.DoubleWordRegisterB.Trits[23], Console.DoubleWordRegisterB.Trits[24], Console.DoubleWordRegisterB.Trits[25], Console.DoubleWordRegisterB.Trits[26], Console.DoubleWordRegisterB.Trits[27], Console.DoubleWordRegisterB.Trits[28], Console.DoubleWordRegisterB.Trits[29], Console.DoubleWordRegisterB.Trits[30], Console.DoubleWordRegisterB.Trits[31], Console.DoubleWordRegisterB.Trits[32], Console.DoubleWordRegisterB.Trits[33], Console.DoubleWordRegisterB.Trits[34], Console.DoubleWordRegisterB.Trits[35]);
            Main.Console.WordRegisterC = Word(Console.DoubleWordRegisterB.Trits[36], Console.DoubleWordRegisterB.Trits[37], Console.DoubleWordRegisterB.Trits[38], Console.DoubleWordRegisterB.Trits[39], Console.DoubleWordRegisterB.Trits[40], Console.DoubleWordRegisterB.Trits[41], Console.DoubleWordRegisterB.Trits[42], Console.DoubleWordRegisterB.Trits[43], Console.DoubleWordRegisterB.Trits[44], Console.DoubleWordRegisterB.Trits[45], Console.DoubleWordRegisterB.Trits[46], Console.DoubleWordRegisterB.Trits[47], Console.DoubleWordRegisterB.Trits[48], Console.DoubleWordRegisterB.Trits[49], Console.DoubleWordRegisterB.Trits[50], Console.DoubleWordRegisterB.Trits[51], Console.DoubleWordRegisterB.Trits[52], Console.DoubleWordRegisterB.Trits[53], Console.DoubleWordRegisterB.Trits[54], Console.DoubleWordRegisterB.Trits[55], Console.DoubleWordRegisterB.Trits[56], Console.DoubleWordRegisterB.Trits[57], Console.DoubleWordRegisterB.Trits[58], Console.DoubleWordRegisterB.Trits[59], Console.DoubleWordRegisterB.Trits[60], Console.DoubleWordRegisterB.Trits[61], Console.DoubleWordRegisterB.Trits[62], Console.DoubleWordRegisterB.Trits[63], Console.DoubleWordRegisterB.Trits[64], Console.DoubleWordRegisterB.Trits[65], Console.DoubleWordRegisterB.Trits[66], Console.DoubleWordRegisterB.Trits[67], Console.DoubleWordRegisterB.Trits[68], Console.DoubleWordRegisterB.Trits[69], Console.DoubleWordRegisterB.Trits[70], Console.DoubleWordRegisterB.Trits[71]);
            Main.Console.TritRegisterA = SingleDigit(Trit.Neutral);
            int OverflowCheckPoint = Main.Console.WordRegisterC.Trits.Length - 1;
            //while (Main.Console.TritRegisterA == Trit.Neutral && OverflowCheckPoint >= 0)
            //{
            ///aaa
            //    Main.Console.TritRegisterA = Main.Console.WordRegisterB.Trits[OverflowCheckPoint];
            //    OverflowCheckPoint -= 1;
            //}
            GD.Print(Console.DoubleWordRegisterB.IntValue());
            GD.Print(Console.WordRegisterB.IntValue());
            GD.Print(Console.WordRegisterC.IntValue());
            if (Main.Console.TritRegisterA.IntValue() == SingleDigit(Trit.Positive).IntValue())
            {
                Main.Console.Overflows.Combine(Console.WordRegisterC, false, TryteZero());
            }
            else if (Main.Console.TritRegisterA.IntValue() == SingleDigit(Trit.Negative).IntValue())
            {
                Main.Console.Underflows.Combine(Console.WordRegisterC, false, TryteZero());
            }
            return Console.WordRegisterB;
        }

        public BigInteger IntValue()
        {
            BigInteger ToReturn = 0;
            BigInteger multiplier = 1;
            for (int T = 0; T < Trits.Length; T++)
            {
                ToReturn += multiplier * (sbyte)Trits[T];
                multiplier *= 3;
            }
            return ToReturn;
        }
        public static TriInt FromInt(BigInteger Value)
        {
            sbyte Carry = 0;
            List<Trit> Lmao = new();
            while (Value != 0 || Carry != 0)
            {
                sbyte asdf = (sbyte)(Value % 3);
                asdf += Carry;
                Value /= 3;
                switch (asdf)
                {
                    case -03:
                        Lmao.Add(Trit.Neutral);
                        GD.Print("=");
                        Carry = -1;
                        break;
                    case -2:
                        Lmao.Add(Trit.Positive);
                        GD.Print("-");
                        Carry = -1;
                        break;
                    case -1:
                        Lmao.Add(Trit.Negative);
                        GD.Print("-");
                        Carry = 0;
                        break;
                    case 0:
                        Lmao.Add(Trit.Neutral);
                        GD.Print("=");
                        Carry = 0;
                        break;
                    case 1:
                        Lmao.Add(Trit.Positive);
                        GD.Print("+");
                        Carry = 0;
                        break;
                    case 2:
                        Lmao.Add(Trit.Negative);
                        GD.Print("-");
                        Carry = 1;
                        break;
                    case 3:
                        Lmao.Add(Trit.Neutral);
                        GD.Print("=");
                        Carry = 1;
                        break;
                    default:
                        GD.Print("WTF3");
                        break;
                }
            }
            return new TriInt(Lmao.ToArray());
        }
    }
    public TriInt Overflows = TriInt.WordZero();
    public TriInt Underflows = TriInt.WordZero();
    public TriInt CompareRegisterA = TriInt.WordZero();
    public TriInt CompareRegisterB = TriInt.WordZero();
    public TriInt WordRegisterA = TriInt.WordZero();
    public TriInt WordRegisterB = TriInt.WordZero();
    public TriInt WordRegisterC = TriInt.WordZero();
    public TriInt DoubleWordRegisterA = TriInt.DoubleWordZero();
    public TriInt DoubleWordRegisterB = TriInt.DoubleWordZero();
    public TriInt TritRegisterA = TriInt.SingleDigit(Trit.Neutral);
    public TriInt TryteRegisterA = TriInt.TryteZero();

    public TriInt[] Ram = new TriInt[387420489];
    public List<TriInt> MemSplits;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Console = this;
        base._Ready();
        //var asdf = TriInt.Tryte(Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive);
        //GD.Print(asdf.IntValue());
        //asdf = asdf.Multiply(TriInt.Tryte(Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive, Trit.Positive));
        //GD.Print(asdf.IntValue());
        //GD.Print(Overflows.IntValue());
    }
}
