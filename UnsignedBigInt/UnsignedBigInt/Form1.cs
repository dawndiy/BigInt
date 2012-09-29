using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UnsignedBigInt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class BigInt   //大整数类
        {
            
            
            public uint[] part; //分组,每组9位
            public bool sign;  //符号,非负为true,负为false
            public ushort count; //位数,0的位数为0

            
            
            public BigInt(ushort n)  //创建n位"空"的大数对象的构造函数
            {
                count = n;
                sign = true;
                if (n != 0)
                {
                    ushort m = (ushort)Math.Ceiling((double)n / 9.0); //m为组的个数
                    part = new uint[m];
                    part.Initialize(); //清0
                }
                else { part = null; }
            }

            public BigInt(string s) //用字符串初始化大数的构造函数
            {
                if (s == "0")  //是0
                {
                    sign = true;
                    count = 0;
                    part = null;
                }
                else  //非0
                {
                    if (s.StartsWith("+")) { sign = true; }
                    else { sign = false; }
                    s = s.Remove(0, 1);
                    count = (ushort)s.Length;
                    short m = (short)Math.Ceiling((double)count / 9.0);
                    part = new uint[m];
                    if (count % 9 != 0)
                    {
                        s = s.PadLeft(count + 9 - count % 9, '0');
                    }
                    for (short k = (short)(m - 1); k >= 0; k--)
                    {
                        part[k] = Convert.ToUInt32(s.Substring(0, 9));
                        s = s.Remove(0, 9);
                    }
                }
            }


            public static BigInt operator +(BigInt A, BigInt B) //重载加号"+"
            {
                if (B.count == 0)  //有0
                { return A; }
                if (A.count == 0)
                { return B; }

                BigInt C;
                if (!(A.sign ^ B.sign))  //同号
                {
                    C = (A.count >= B.count) ? add(A, B) : add(B, A);
                    C.sign = A.sign;
                    return C;
                }

                sbyte r = compare(A, B);  //异号
                if (r == 0)   //相等
                { return new BigInt(0); }
                C = (r == 1) ? minus(A, B) : minus(B, A);
                C.sign = (r == 1) ? A.sign : B.sign;
                return C;
            }

            public static BigInt operator -(BigInt A) //重载负号"-"
            {
                if (A.count == 0)
                { return new BigInt(0); }

                BigInt A0 = new BigInt(A.count);
                A.part.CopyTo(A0.part, 0);
                A0.sign = !A.sign;
                return A0;
            }

            public static BigInt operator -(BigInt A, BigInt B)  //重载减号"-"
            {
                return A + (-B);
            }

            public static BigInt operator *(BigInt A, BigInt B) //重载乘号"*"
            {
                BigInt C = (A.count >= B.count) ? multiply(A, B) : multiply(B, A);
                C.sign = !(A.sign ^ B.sign);
                return C;
            }

            public static BigInt operator /(BigInt A, BigInt B)  //重载除号"/"
            {
                BigInt C;
                return divmod(A, B, out C);
            }

            public static BigInt operator %(BigInt A, BigInt B) //重载取余号"%"
            {
                BigInt C;
                divmod(A, B, out C);
                return C;
            }
        }


        private static BigInt abs(BigInt A) //求大数A的绝对值
        {
            if (A.count == 0)
            {
                return new BigInt(0);
            }
            BigInt A0 = new BigInt(A.count);
            A.part.CopyTo(A0.part, 0);
            return A0;
        }

        /* 同时求出大数A除以大数B的商和余数M */
        private static BigInt divmod(BigInt A, BigInt B, out BigInt M)
        {
            if (A.count == 0)
            {
                M = new BigInt(0);
                return M;
            }

            sbyte q = compare(A, B);
            if (q == -1)
            {
                M = A;
                return new BigInt(0);
            }

            if (q == 0)
            {
                M = new BigInt(0);
                return (A.sign ^ B.sign) ? (new BigInt("-1")) : (new BigInt("+1"));
            }

            BigInt C;
            if (B.part.Length == 1)
            {
                uint c;
                C = divide(A, B.part[0], out c);
                C.sign = !(A.sign ^ B.sign);
                if (c != 0)
                {
                    string s = (A.sign ? "+" : "-") + c.ToString();
                    M = new BigInt(s);
                }
                else
                { M = new BigInt(0); }
                return C;
            }

            C = divide(A, B, out M);
            C.sign = !(A.sign ^ B.sign);
            if (M.count != 0)
            {
                M.sign = A.sign;
            }
            return C;
        }



        /* 绝对值相加,结果非负,要求A的位数不少于B的位数 */
        private static BigInt add(BigInt A, BigInt B)
        {
            if (B.count == 0)
            { return abs(A); }
            BigInt A0 = abs(A);
            byte c = 0;   // c为进位值
            byte a = (byte)A0.part[A0.part.Length - 1].ToString().Length;
            int temp;
            for (ushort i = 0; i < B.part.Length; i++)
            {
                A0.part[i] += B.part[i] + c;
                c = (byte)Math.DivRem((int)A0.part[i], 1000000000, out temp);
                A0.part[i] = (uint)temp;
            }
            if (c == 0)
            {
                if ((A0.part.Length == B.part.Length) && (A0.part[A0.part.Length - 1].ToString().Length > a))
                {
                    A0.count++;
                }
                return A0;
            }
            for (ushort i = (ushort)B.part.Length; i < A0.part.Length; i++)
            {
                A0.part[i] += c;
                c = (byte)Math.DivRem((int)A0.part[i], 1000000000, out temp);
                if (c == 0) { break; }
                A0.part[i] = (uint)temp;
            }
            if (c == 0)
            {
                if (A0.part[A0.part.Length - 1].ToString().Length > a)
                { A0.count++; }
                return A0;
            }
            A0.count = (ushort)(9 * A0.part.Length + 1);
            Array.Resize(ref A0.part, A0.part.Length + 1);
            A0.part[A0.part.Length - 1] = 1;
            return A0;
        }


        /* A的绝对值减去B的绝对值,结果非负,要求A的绝对值大于B的绝对值 */
        private static BigInt minus(BigInt A, BigInt B)
        {
            if (B.count == 0)
            { return abs(A); }
            BigInt A0 = abs(A);
            byte c = 0; //c为借位值
            for (ushort i = 0; i < B.part.Length; i++)
            {
                uint temp = B.part[i] + c;
                if (A0.part[i] >= temp)
                { A0.part[i] -= temp; c = 0; }
                else
                { A0.part[i] += 1000000000 - temp; c = 1; }
            }
            if (c != 0)
            {
                for (ushort i = (ushort)B.part.Length; i < A0.part.Length; i++)
                {
                    if (A0.part[i] != 0)
                    { A0.part[i]--; break; }
                    else
                    { A0.part[i] = 999999999; }
                }
            }
            if (A0.part[A0.part.Length - 1] != 0)
            {
                A0.count = (ushort)(A0.part[A0.part.Length - 1].ToString().Length +
                    9 * (A0.part.Length - 1));
                return A0;
            }
            short j;
            for (j = (short)(A0.part.Length - 2); j >= 0; j--)
            {
                if (A0.part[j] != 0) { break; }
            }
            if (j == -1) { return new BigInt(0); }
            A0.count = (ushort)(A0.part[j].ToString().Length + 9 * j);
            Array.Resize(ref A0.part, j + 1);
            return A0;
        }

        /* 绝对值比较:若A的绝对值大,则返回1;若B的绝对值大,则返回-1;若绝对值相等,则返回0 */
        private static sbyte compare(BigInt A, BigInt B)
        {
            if (A.count > B.count)
            { return 1; }
            if (A.count < B.count)
            { return -1; }
            if (A.count == 0 && B.count == 0)
            { return 0; }
            for (short i = (short)(A.part.Length - 1); i >= 0; i--)
            {
                if (A.part[i] > B.part[i]) { return 1; }
                if (A.part[i] < B.part[i]) { return -1; }
            }
            return 0;
        }

        /* 大数A与9位以内的数b相乘,结果取绝对值 */
        private static BigInt multiply(BigInt A, uint b)
        {
            if (b == 0 || A.count == 0) { return new BigInt(0); }
            if (b == 1)
            { return abs(A); }
            if (A.count == 1 && A.part[0] == 1)
            { return new BigInt("+" + b.ToString()); }

            BigInt B = new BigInt((ushort)(A.count + b.ToString().Length));
            uint c = 0;  //c为进位值
            for (ushort i = 0; i < A.part.Length; i++)
            {
                long t = Math.BigMul((int)b, (int)A.part[i]) + c;
                long temp;
                c = (uint)Math.DivRem(t, 1000000000L, out temp);
                B.part[i] = (uint)temp;
            }
            if (c != 0)
            {
                B.part[A.part.Length] = c;
                B.count = (ushort)(c.ToString().Length + 9 * (B.part.Length - 1));
                return B;
            }
            if (B.part[B.part.Length - 1] != 0)
            {
                B.count = (ushort)(B.part[B.part.Length - 1].ToString().Length +
                    9 * (B.part.Length - 1));
                return B;
            }
            B.count = (ushort)(B.part[B.part.Length - 2].ToString().Length +
                    9 * (B.part.Length - 2));
            Array.Resize(ref B.part, B.part.Length - 1);
            return B;
        }

        /* 大数绝对值相乘,结果非负,A的位数最好大于等于B的位数 */
        private static BigInt multiply(BigInt A, BigInt B)
        {
            if (B.count == 0 || A.count == 0)
            { return new BigInt(0); }
            if (B.count == 1 && B.part[0] == 1)
            { return abs(A); }
            if (A.count == 1 && A.part[0] == 1)
            { return abs(B); }
            BigInt C = multiply(A, B.part[0]);
            for (ushort i = 1; i < B.part.Length; i++)
            {
                if (B.part[i] != 0)
                {
                    C = add(multiply(A, B.part[i]), C, i);
                }
            }
            return C;
        }

        /* 错位相加,结果非负;错位方法:A左移9k位,要求(A的位数+9k)不少于B的位数 */
        private static BigInt add(BigInt A, BigInt B, ushort k) //这是计算大数乘大数的子程序
        {
            if (A.count == 0)
            { return abs(B); }
            if (k == 0)
            { return add(A, B); }
            BigInt A0 = new BigInt((ushort)(A.count + 9 * k));
            A.part.CopyTo(A0.part, k);
            if (B.count <= 9 * k)
            {
                if (B.count != 0)
                {
                    B.part.CopyTo(A0.part, 0);
                }
                return A0;
            }
            Array.Copy(B.part, 0, A0.part, 0, k);
            byte c = 0;   // c为进位值
            byte a = (byte)A0.part[A0.part.Length - 1].ToString().Length;
            int temp;
            for (ushort i = k; i < B.part.Length; i++)
            {
                A0.part[i] += B.part[i] + c;
                c = (byte)Math.DivRem((int)A0.part[i], 1000000000, out temp);
                A0.part[i] = (uint)temp;
            }
            if (c == 0)
            {
                if ((A0.part.Length == B.part.Length) && (A0.part[A0.part.Length - 1].ToString().Length > a))
                {
                    A0.count++;
                }
                return A0;
            }
            for (ushort i = (ushort)B.part.Length; i < A0.part.Length; i++)
            {
                A0.part[i] += c;
                c = (byte)Math.DivRem((int)A0.part[i], 1000000000, out temp);
                if (c == 0) { break; }
                A0.part[i] = (uint)temp;
            }
            if (c == 0)
            {
                if (A0.part[A0.part.Length - 1].ToString().Length > a)
                { A0.count++; }
                return A0;
            }
            A0.count = (ushort)(9 * A0.part.Length + 1);
            Array.Resize(ref A0.part, A0.part.Length + 1);
            A0.part[A0.part.Length - 1] = 1;
            return A0;
        }

        /* 大数A除以b,商和余数c均取绝对值 */
        private static BigInt divide(BigInt A, uint b, out uint c)
        {
            if (A.count == 0)
            {
                c = 0;
                return new BigInt(0);
            }
            if (b == 1)
            {
                c = 0;
                return abs(A);
            }
            if (A.part.Length == 1)
            {
                int c1;
                uint k = (uint)Math.DivRem((int)A.part[0], (int)b, out c1);
                c = (uint)c1;
                return (k != 0) ? (new BigInt("+" + Convert.ToString(k))) : (new BigInt(0));
            }
            long a;
            long c0;
            if (A.part.Length == 2)
            {
                a = Math.BigMul((int)A.part[1], 1000000000) + (long)A.part[0];
                long d0 = Math.DivRem(a, (long)b, out c0);
                c = (uint)c0;
                return new BigInt("+" + Convert.ToString(d0));
            }
            uint d;
            a = (long)A.part[A.part.Length - 1];
            byte t = 1;
            if (a < b)
            {
                a = Math.BigMul((int)a, 1000000000) + (long)A.part[A.part.Length - 2];
                t = 2;
            }
            d = (uint)Math.DivRem(a, (long)b, out c0);
            ushort n = (ushort)(d.ToString().Length + 9 * (A.part.Length - t));
            BigInt B = new BigInt(n);
            B.part[B.part.Length - 1] = d;
            for (short i = (short)(B.part.Length - 2); i >= 0; i--)
            {
                a = Math.BigMul((int)c0, 1000000000) + (long)A.part[i];
                B.part[i] = (uint)Math.DivRem(a, (long)b, out c0);
            }
            c = (uint)c0;
            return B;
        }

        /* 大数A除以大数B,商和余数C均取绝对值,要求A>B,B在9位以上 */
        private static BigInt divide(BigInt A, BigInt B, out BigInt C)
        {
            double b = (double)B.part[B.part.Length - 1] +
                (double)B.part[B.part.Length - 2] / 1000000000.0;
            if (B.part.Length > 2)
            {
                b += (double)B.part[B.part.Length - 3] / Math.Pow(10, 18);
            }
            byte p = 1;
            for (ushort i = 1; i <= B.part.Length; i++)
            {
                if (A.part[A.part.Length - i] < B.part[B.part.Length - i])
                { p = 0; break; }
                if (A.part[A.part.Length - i] > B.part[B.part.Length - i])
                { p = 1; break; }
            }
            C = new BigInt((ushort)(A.part[A.part.Length - 1].ToString().Length +
                    9 * (B.part.Length - p)));
            Array.Copy(A.part, A.part.Length - C.part.Length, C.part, 0, C.part.Length);
            double c;
            if (p == 1)
            {
                c = (double)A.part[A.part.Length - 1] +
                (double)A.part[A.part.Length - 2] / 1000000000.0;
                if (A.part.Length > 2)
                {
                    c += (double)A.part[A.part.Length - 3] / Math.Pow(10, 18);
                }
            }
            else
            {
                c = (double)A.part[A.part.Length - 1] * 1000000000.0 +
                    (double)A.part[A.part.Length - 2] +
                (double)A.part[A.part.Length - 3] / 1000000000.0;
            }
            uint d = (uint)(c / b); //试商
            BigInt B0 = abs(B);
            if (d > 999999999)
            {
                d = 999999999;
                C = minus(C, multiply(B0, d));
            }
            else
            {
                C -= multiply(B0, d);
                if (!C.sign)
                {
                    d--;
                    C += B0;
                }
                else
                {
                    if (compare(C, B0) >= 0)
                    {
                        d++;
                        C = minus(C, B0);
                    }
                }
            }
            BigInt D = new BigInt((ushort)(d.ToString().Length +
                9 * (A.part.Length - B0.part.Length + p - 1)));
            D.part[D.part.Length - 1] = d;
            for (short i = (short)(D.part.Length - 2); i >= 0; i--)
            {
                C = connect(C, A.part[i]);
                if (compare(C, B0) < 0)
                {
                    D.part[i] = 0;
                    continue;
                }
                if (C.part.Length == B0.part.Length)
                {
                    c = (double)C.part[C.part.Length - 1] +
                    (double)C.part[C.part.Length - 2] / 1000000000.0;
                    if (C.part.Length > 2)
                    {
                        c += (double)C.part[C.part.Length - 3] / Math.Pow(10, 18);
                    }
                }
                else
                {
                    c = (double)C.part[C.part.Length - 1] * 1000000000.0 +
                        (double)C.part[C.part.Length - 2] +
                    (double)C.part[C.part.Length - 3] / 1000000000.0;
                }
                d = (uint)(c / b);
                if (d > 999999999)
                {
                    d = 999999999;
                    C = minus(C, multiply(B0, d));
                }
                else
                {
                    C -= multiply(B0, d);
                    if (!C.sign)
                    {
                        d--;
                        C += B0;
                    }
                    else
                    {
                        if (compare(C, B0) >= 0)
                        {
                            d++;
                            C = minus(C, B0);
                        }
                    }
                }
                D.part[i] = d;
            }
            return D;
        }

        /* 计算正的大数T乘以10的9次幂再加上t */
        private static BigInt connect(BigInt T, uint t) //在计算大数除法中发挥作用
        {
            if (T.count == 0)
            {
                return (t == 0) ? (new BigInt(0)) : (new BigInt("+" + t.ToString()));
            }
            BigInt P = new BigInt((ushort)(T.count + 9));
            P.part[0] = t;
            T.part.CopyTo(P.part, 1);
            return P;
        }

        private string BigIntToString(BigInt H)  //大数转字符串
        {
            if (H.count == 0) { return "0"; }
            string str;
            if (H.sign) { str = "+"; }
            else { str = "-"; }
            str += Convert.ToString(H.part[H.part.Length - 1]);
            for (short i = (short)(H.part.Length - 2); i >= 0; i--)
            {
                str += String.Format("{0:D9}", H.part[i]);
            }
            return str;
        }

        //运算前的数据检查
        private bool check(ref string s)
        {
            s = s.Trim();
            if ((!s.StartsWith("+")) && (!s.StartsWith("-")))
            { s = "+" + s; } //正数一律带正号"+"
            if (s.Length <= 1)
            { s = "+0"; }
            int r = 1;
            for (int i = 1; i < s.Length; i++)//是否有非法字符
            {
                if (!Regex.IsMatch(s[i].ToString(),"^[0-9]$" ))
                {
                    r = 0;
                    break;
                }
            }
            if (r == 0) return false;
            else return true;
        }

        //清空
        private void btn_cl_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        //退出程序
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //关于按钮
        private void btn_about_Click(object sender, EventArgs e)
        {
             MessageBox.Show("程序：大整数计算器 v1.0\n说明：计算含符号的10进制大整数计算\n设计：程路","  关于");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //结果计算
        private void btn_res_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            string str1=textBox1.Text;
            string str2=textBox2.Text;
            //check(ref str1);
            //check(ref str2);
            if (!check(ref str1) || !check(ref str2))
            {
                textBox4.Text = "输入的数据含非法字符，请检查！";
            }
            else
            {
                BigInt A = new BigInt(str1);
                BigInt B = new BigInt(str2);
                textBox1.Text = str1;
                textBox2.Text = str2;
                //加法运算
                if (radioButton_add.Checked)
                {
                    textBox3.Text = BigIntToString(A + B);
                    return;                
                }
                //减法运算
                if (radioButton_sub.Checked)
                {
                    textBox3.Text = BigIntToString(A - B);
                    return;                
                }
                //乘法运算
                if (radioButton_mul.Checked)
                {
                    if (A.count + B.count >= 65535)
                    {
                        textBox3.Text = "错误！";
                        textBox4.Text = "结果太大，数据溢出！";
                        return;
                    }
                    textBox3.Text = BigIntToString(A * B);
                    return;
                }
                //除法运算
                if (radioButton_div.Checked)
                {
                    if (BigIntToString(B) == "+0")
                    {
                        textBox3.Text = "错误！";
                        textBox4.Text = "除数不能为0！";
                        return;
                    }
                    BigInt C;
                    textBox3.Text = BigIntToString(divmod(A, B, out C));
                    textBox4.Text = "余数：" + BigIntToString(C);
                    return;
                }
                textBox4.Text = "请选择运算符！";

            }

        }

        private void radioButton_add_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "加法运算";
        }

        private void radioButton_sub_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "减法运算";
        }

        private void radioButton_mul_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "乘法运算";
        }

        private void radioButton_div_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "除法运算";
        }
    }
}
