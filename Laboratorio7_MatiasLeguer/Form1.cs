using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio7_MatiasLeguer
{
    public partial class Form1 : Form
    {
        private string ans = null;
        private string operation = null;
        private int indexOp;
        private int number1;
        private int number2;
        private double numberDouble1;
        private double numberDouble2;


        public string Ans { get => ans; set => ans = value; }
        public string Operation { get => operation; set => operation = value; }
        public int IndexOp { get => indexOp; set => indexOp = value; }
       
        public Form1()
        {
            InitializeComponent();
        }

        //Main
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Exit program
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Text
        //-------------------------------------------------------------------------------------
        private void text_TextChanged(object sender, EventArgs e)
        {

        }
        //-------------------------------------------------------------------------------------

        //OPERATIONS
        //-------------------------------------------------------------------------------------
        private void Add_Click(object sender, EventArgs e)
        {
            if (text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();

            if (operation == null)
            {
                text.Text += "+";
                Operation = "+";
            }
        }
        private void Substract_Click(object sender, EventArgs e)
        {
            if (text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();

            if (operation == null)
            {
                text.Text += "-";
                Operation = "-";
            }
        }
        private void Multiply_Click(object sender, EventArgs e)
        {
            if (text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();

            if (operation == null)
            {
                text.Text += "*";
                Operation = "*";
            }

        }
        private void Divide_Click(object sender, EventArgs e)
        {
            if (text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();

            if (operation == null)
            {
                text.Text += "/";
                Operation = "/";
            }
        }
        //-------------------------------------------------------------------------------------



        //Answer, equal and delete
        //-------------------------------------------------------------------------------------
        private void Answer_Click(object sender, EventArgs e)
        {
            if (text.Text == Ans || text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();
            if (Ans == null)
            {
                text.Text += "0";
                Ans = text.Text;
            }
            else
                text.Text += Ans;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            string result;
            switch (Operation)
            {
                
                case "+":
                    
                    IndexOp = text.Text.IndexOf("+");
                    result = GetNumber(operation, IndexOp);

                    if (result == "MATH ERROR" || result == "SYNTAX ERROR")
                        text.Text = result;
                    else
                    {
                        Ans = result;
                        text.Text = Ans;
                    }

                    Operation = null;

                    break;
                case "-":
                    IndexOp = text.Text.IndexOf("-");
                    result = GetNumber(operation, IndexOp);

                    if (result == "MATH ERROR" || result == "SYNTAX ERROR")
                        text.Text = result;
                    else
                    {
                        Ans = result;
                        text.Text = Ans;
                    }

                    Operation = null;
                    break;

                case "*":
                    IndexOp = text.Text.IndexOf("*");
                    result = GetNumber(operation, IndexOp);

                    if (result == "MATH ERROR" || result == "SYNTAX ERROR")
                        text.Text = result;
                    else
                    {
                        Ans = result;
                        text.Text = Ans;
                    }

                    Operation = null;
                    break;

                case "/":
                    IndexOp = text.Text.IndexOf("/");
                    result = GetNumber(operation, IndexOp);

                    if (result == "MATH ERROR" || result == "SYNTAX ERROR")
                        text.Text = result;
                    else
                    {
                        Ans = result;
                        text.Text = Ans;
                    }

                    Operation = null;
                    break;
                default:
                    Ans = text.Text;
                    text.Text = Ans;
                    Operation = null;
                    break;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            text.Text = "";
        }

        private void DeleteRecent_Click(object sender, EventArgs e)
        {
            string deleteRecent = text.Text;
            if (deleteRecent == "")
                return;
            if (deleteRecent[deleteRecent.Length - 1] == '+' || deleteRecent[deleteRecent.Length - 1] == '-' || deleteRecent[deleteRecent.Length - 1] == '*' || deleteRecent[deleteRecent.Length - 1] == '/')
                operation = null;

            deleteRecent = deleteRecent.Remove(deleteRecent.Length - 1, 1);
            text.Text = deleteRecent;
        }
        //-------------------------------------------------------------------------------------

        //NUMBER
        //-------------------------------------------------------------------------------------
        private void Number_Click(object sender, EventArgs e)
        {
            if (text.Text == Ans || text.Text == "MATH ERROR" || text.Text == "SYNTAX ERROR")
                text.Clear();
            Button button = (Button)sender;
            text.Text += button.Text;
        }
        //-------------------------------------------------------------------------------------


        //MÉTODO PARA CONSEGUIR EL NUMERO
        //-------------------------------------------------------------------------------------
        private string GetNumber(string opc, int IndexOp)
        {
            string number1S = "";
            string number2S = "";
            int contadorPuntos1 = 0;
            int contadorPuntos2 = 0;
            string error = null;


            for (int i = 0; i < 2; i++)
            {
                
                if (i == 0)
                {
                    for (int j = 0; j < IndexOp; j++)
                    {
                        if(text.Text[j] == ',')
                        {
                            contadorPuntos1++;
                        }
                        number1S += text.Text[j];
                    }




                    if (IndexOp == 0)
                        error = "SYNTAX ERROR";

                    if (contadorPuntos1 == 0 && error == null)
                        number1 = int.Parse(number1S);

                    else if (contadorPuntos1 == 1)
                        numberDouble1 = Convert.ToDouble(number1S);
                    else
                        error = "SYNTAX ERROR";
                }

                else
                {
                    for (int j = (IndexOp + 1); j < text.Text.Length; j++)
                    {
                        if (text.Text[j] == ',')
                        {
                            contadorPuntos2++;
                        }
                        number2S += text.Text[j];
                    }

                    if (number2S == "0")
                        error = "MATH ERROR";

                    else if (IndexOp == text.Text.Length - 1)
                        error = "SYNTAX ERROR";


                    if (contadorPuntos2 == 0 && error == null)
                        number2 = int.Parse(number2S);
                    else if (contadorPuntos2 == 1)
                        numberDouble2 = Convert.ToDouble(number2S);
                    else if(contadorPuntos2 > 1)
                        error = "SYNTAX ERROR";
                }
            }

            if (error != null)
                return error;

            if(opc == "+")
            {
                if (contadorPuntos1 == 0 && contadorPuntos2 == 0)
                    Ans = (number1 + number2).ToString();
                else if (contadorPuntos1 == 1 && contadorPuntos2 == 0)
                    Ans = (numberDouble1 + number2).ToString();
                else if(contadorPuntos1 == 0 && contadorPuntos2 == 1)
                    Ans = (number1 + numberDouble2).ToString();
                else
                    Ans = (numberDouble1 + numberDouble2).ToString();
            }
            else if (opc == "-")
            {
                if (contadorPuntos1 == 0 && contadorPuntos2 == 0)
                    Ans = (number1 - number2).ToString();
                else if (contadorPuntos1 == 1 && contadorPuntos2 == 0)
                    Ans = (numberDouble1 - number2).ToString();
                else if (contadorPuntos1 == 0 && contadorPuntos2 == 1)
                    Ans = (number1 - numberDouble2).ToString();
                else
                    Ans = (numberDouble1 - numberDouble2).ToString();
            }
            else if (opc == "*")
            {
                if (contadorPuntos1 == 0 && contadorPuntos2 == 0)
                    Ans = (number1 * number2).ToString();
                else if (contadorPuntos1 == 1 && contadorPuntos2 == 0)
                    Ans = (numberDouble1 * number2).ToString();
                else if (contadorPuntos1 == 0 && contadorPuntos2 == 1)
                    Ans = (number1 * numberDouble2).ToString();
                else
                    Ans = (numberDouble1 * numberDouble2).ToString();
            }
            else
            {
                if (contadorPuntos1 == 0 && contadorPuntos2 == 0)
                    Ans = (number1 / number2).ToString();
                else if (contadorPuntos1 == 1 && contadorPuntos2 == 0)
                    Ans = (numberDouble1 / number2).ToString();
                else if (contadorPuntos1 == 0 && contadorPuntos2 == 1)
                    Ans = (number1 / numberDouble2).ToString();
                else
                    Ans = (numberDouble1 / numberDouble2).ToString();
            }


            return Ans;

        }



        //-------------------------------------------------------------------------------------

    }
}
