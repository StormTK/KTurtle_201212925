using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTurtle_201212925
{
    class AnalizadorLexico
    {
        private List<Tuple<int, String, int, int, int, String>> Tokens = new List<Tuple<int, String, int, int, int, String>>();
        private List<Tuple<int, int, int, String>> Errores = new List<Tuple<int, int, int, String>>();
        private List<Tuple<String, int>> Variables = new List<Tuple<String, int>>();

       
        private Char[] Letra; //Almacena cada uno de las letras del texto.
        private String NumeroAlmacenado = "";
        private String VariableAlmacenada = "";
        private String VariableAsignar = "";
        private String[] CadenaOperaciones = new String[100];
        private String[] LimpiarCadena = new String[100];
        private String Consola = "";

        private int NumeroOperaciones = 0;
        private int Intruccion = 0;
        private int ColorLienzo = 0;
        private int ColorPincel = 0;
        private int[][] Instrucciones;
        private int[] TamañoLienzo = new int[2];
        private int tamaño_TextoAnalizar = 0;
        private int posicion_InicialToken = 0;
        private int posicion_TextoAnalizado = 0;
        private int candidadTokens = 0;
        private int cantidadErrores = 0;
        private int NoFila = 1;
        private int NoColumna = 1;

        public void AnalizarTexto(String TextoAnalizar)
        {
            try
            {
                tamaño_TextoAnalizar = 0;
                posicion_InicialToken = 0;
                posicion_TextoAnalizado = 0;
                candidadTokens = 0;
                cantidadErrores = 0;
                NoFila = 1;
                NoColumna = 1;
                NumeroAlmacenado = "";
                VariableAlmacenada = "";
                Consola = "";
                Tokens.RemoveRange(0, Tokens.Count);
                Errores.RemoveRange(0, Errores.Count);
                Variables.RemoveRange(0, Variables.Count);
                TamañoLienzo[0] = 200; //Tamaño Lienzo por default X
                TamañoLienzo[1] = 200; //Tamaño Lienzo por default Y
                ColorLienzo = 0; //Blanco por Defecto
                ColorPincel = 0; //Negro por Defecto
                NumeroOperaciones = 0;
                Letra = TextoAnalizar.ToCharArray();
                tamaño_TextoAnalizar = Letra.Length;
                S0(Letra[posicion_TextoAnalizado]);
            }
            catch (Exception)
            {
            }
        }
        public Boolean AgregarTokens(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "Tama&ntilde;olienzo", posicion_InicialToken, NoColumna, opcion, "Reservada Tama&ntilde;o Lienzo"));
                        return true;
                    }
                case 2:
                    {
                        int TamañoLienzoX = Convert.ToInt32(NumeroAlmacenado);
                        TamañoLienzo[0] = TamañoLienzoX;
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, NumeroAlmacenado, posicion_InicialToken, NoColumna, opcion, "NUMERO Ancho del Lienzo"));
                        return true;
                    }
                case 3:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, ",", NoFila, NoColumna, opcion, "Signo Coma"));
                        return true;
                    }
                case 4:
                    {
                        int TamañoLienzoY = Convert.ToInt32(NumeroAlmacenado);
                        TamañoLienzo[1] = TamañoLienzoY;
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, NumeroAlmacenado, posicion_InicialToken, NoColumna, opcion, "NUMERO Alto del Lienzo"));
                        return true;
                    }
                case 5:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, ";", NoFila, NoColumna, opcion, "Signo Punto y Coma"));
                        return true;
                    }
                case 6:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "tl", posicion_InicialToken, NoColumna, opcion, "Reservada TL Tama&ntilde;o Lienzo"));
                        return true;
                    }
                case 7:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "Escribir", posicion_InicialToken, NoColumna, opcion, "Reservada Escribir"));
                        return true;
                    }
                case 8:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "(", NoFila, NoColumna, opcion, "Apertura de Parentesis"));
                        return true;
                    }
                case 9:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, NumeroAlmacenado, posicion_InicialToken, NoColumna, opcion, "Numero"));
                        return true;
                    }
                case 10:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, ")", NoFila, NoColumna, opcion, "Cierre de Parentesis"));
                        return true;
                    }
                case 11:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, VariableAlmacenada, posicion_InicialToken, NoColumna, opcion, "ID Variable"));
                        return true;
                    }
                case 12:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "=", NoFila, NoColumna, opcion, "Signo Igual"));
                        return true;
                    }
                case 13:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "+", NoFila, NoColumna, opcion, "Signo Suma"));
                        return true;
                    }
                case 14:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "-", NoFila, NoColumna, opcion, "Signo Resta"));
                        return true;
                    }
                case 15:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "*", NoFila, NoColumna, opcion, "Signo Multiplicacion"));
                        return true;
                    }
                case 16:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "^", NoFila, NoColumna, opcion, "Signo Potenciacion"));
                        return true;
                    }
                case 17:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "Asg", posicion_InicialToken, NoColumna, opcion, "Reservada Asignar Variable"));
                        return true;
                    }
                case 18:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "/", NoFila, NoColumna, opcion, "Signo Division"));
                        return true;
                    }
                case 19:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "avz", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada AVANZAR"));
                        return true;
                    }
                case 20:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "avanzar", posicion_InicialToken, NoColumna, opcion, "Reservada AVANZAR"));
                        return true;
                    }
                case 21:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "ret", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada RETROCEDER"));
                        return true;
                    }
                case 22:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "retroceder", posicion_InicialToken, NoColumna, opcion, "Reservada RETROCEDER"));
                        return true;
                    }
                case 23:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "girarIzq", posicion_InicialToken, NoColumna, opcion, "Reservada GIRAR IZQUIERDA"));
                        return true;
                    }
                case 24:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "girarDer", posicion_InicialToken, NoColumna, opcion, "Reservada GIRAR DERECHA"));
                        return true;
                    }
                case 25:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "der", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada GIRAR DERECHA"));
                        return true;
                    }
                case 26:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "iy", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada IRY"));
                        return true;
                    }
                case 27:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "ix", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada IRX"));
                        return true;
                    }
                case 28:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "izq", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada GIRAR IZQUIERDA"));
                        return true;
                    }
                case 29:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "irX", posicion_InicialToken, NoColumna, opcion, "Reservada IRX"));
                        return true;
                    }
                case 30:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "irY", posicion_InicialToken, NoColumna, opcion, "Reservada IRY"));
                        return true;
                    }
                case 31:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "ir", posicion_InicialToken, NoColumna, opcion, "Reservada IR"));
                        return true;
                    }
                case 32:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "subirPincel", posicion_InicialToken, NoColumna, opcion, "Reservada SUBIR PINCEL"));
                        return true;
                    }
                case 33:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "spl", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada SUBIR PINCEL"));
                        return true;
                    }
                case 34:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "bajarPincel", posicion_InicialToken, NoColumna, opcion, "Reservada BAJAR PINCEL"));
                        return true;
                    }
                case 35:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "bpl", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada BAJAR PINCEL"));
                        return true;
                    }
                case 36:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "cpl", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada COLOR LIENZO"));
                        return true;
                    }
                case 37:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "colorlienzo", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR LIENZO"));
                        return true;
                    }
                case 38:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "colorpincel", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR PINCEL"));
                        return true;
                    }
                case 39:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "cp", posicion_InicialToken, NoColumna, opcion, "Reservada Abreviada COLOR PINCEL"));
                        return true;
                    }
                case 40:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "blanco", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR BLANCO"));
                        return true;
                    }
                case 41:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "celeste", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR CELESTE"));
                        return true;
                    }
                case 42:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "amarillo", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR AMARILLO"));
                        return true;
                    }
                case 43:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "negro", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR NEGRO"));
                        return true;
                    }
                case 44:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "azul", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR AZUL"));
                        return true;
                    }
                case 45:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "rojo", posicion_InicialToken, NoColumna, opcion, "Reservada COLOR ROJO"));
                        return true;
                    }
                case 46:
                    {
                        Tokens.Add(new Tuple<int, String, int, int, int, String>(candidadTokens, "centrar", posicion_InicialToken, NoColumna, opcion, "Reservada CENTRAR"));
                        return true;
                    }
            }
            return false;
        }
        public int getCantidadErrores()
        {
            return cantidadErrores;
        }
        public List<Tuple<int, String, int, int, int, String>> getHTMLToken()
        {
            return Tokens;
        }
        public List<Tuple<int, int, int, String>> getHTMLError()
        {
            return Errores;
        }
        public int getColorLienzo()
        {
            return ColorLienzo;
        }
        public int[] getTamañoLienzo()
        {
            return TamañoLienzo;
        }
        public String getConsola()
        {
            return Consola;
        }
        public Boolean LeerEnterEspacioTab(char letraAnalizada)
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizada == 09)
                {
                    NoFila += 5;
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 10)
                {
                    NoColumna++;
                    NoFila = 1;
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 13)
                {
                    posicion_TextoAnalizado++;
                }
                else if (letraAnalizada == 32)
                {
                    NoFila++;
                    posicion_TextoAnalizado++;
                }
                else
                {
                    cantidadErrores++;
                    Errores.Add(new Tuple<int, int, int, string>(cantidadErrores, NoFila, NoColumna, letraAnalizada.ToString()));
                    posicion_TextoAnalizado++;
                    NoFila++;
                }
                return true;
            }
            else
            {
                return true;
            }

        }
        private void S0(char letraAnalizar)//T|E|A|R|G
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S1(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S17(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S28(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S41(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'g' || letraAnalizar == 'G')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S49(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S58(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'I' || letraAnalizar == 'i')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S60(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'b' || letraAnalizar == 'B')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S82(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S69(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S95(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S0(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S1(char letraAnalizar)//A|L
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S2(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S13(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S1(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S2(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S3(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S2(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S3(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S4(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S3(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S4(char letraAnalizar)//ñ
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'ñ' || letraAnalizar == 'Ñ')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S5(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S4(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S5(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S6(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S5(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S6(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S7(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S6(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S7(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S8(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S7(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S8(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S9(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S8(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S9(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S10(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S9(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S10(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S11(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S10(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S11(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(1);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S12(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S11(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S12(char letraAnalizar)//#
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    posicion_InicialToken = NoFila;
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S14(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S12(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S13(char letraAnalizar)//#
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    candidadTokens++;
                    AgregarTokens(6);
                    posicion_InicialToken = NoFila;
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S14(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S13(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S14(char letraAnalizar)//,
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ',')
                {
                    candidadTokens++;
                    AgregarTokens(2);
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S15(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S14(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S14(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S15(char letraAnalizar)//#
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    posicion_InicialToken = NoFila;
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S16(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S15(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S16(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(4);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S16(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S16(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S17(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S18(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S17(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S18(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S19(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S18(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S19(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S20(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S19(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S20(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S21(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S20(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S21(char letraAnalizar)//b
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'b' || letraAnalizar == 'B')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S22(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S21(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S22(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S23(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S22(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S23(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(7);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S24(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S23(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S24(char letraAnalizar)//(
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '(')
                {
                    candidadTokens++;
                    AgregarTokens(8);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S25(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S24(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S25(char letraAnalizar)//L
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165)
                {
                    posicion_InicialToken = NoFila;
                    VariableAlmacenada = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S26(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S25(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S26(char letraAnalizar)//)
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ')')
                {
                    candidadTokens++;
                    AgregarTokens(11);
                    candidadTokens++;
                    AgregarTokens(10);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S27(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165 || (letraAnalizar >= 48 && letraAnalizar <= 57) || letraAnalizar == '_')
                {
                    VariableAlmacenada += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S26(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S26(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S27(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    foreach (var busqueda in Variables)
                    {
                        if (VariableAlmacenada.Equals(busqueda.Item1))
                        {
                            Consola += "" + busqueda.Item1 + " = " + busqueda.Item2 + Convert.ToChar(10);
                        }
                    }
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S27(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S28(char letraAnalizar)//s|v
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S29(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'v' || letraAnalizar == 'V')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S36(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S28(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S29(char letraAnalizar)//g
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'g' || letraAnalizar == 'G')
                {
                    candidadTokens++;
                    AgregarTokens(17);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S30(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S29(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S30(char letraAnalizar)//L
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165)
                {
                    posicion_InicialToken = NoFila;
                    VariableAlmacenada = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S31(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S30(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S31(char letraAnalizar)//=
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '=')
                {
                    VariableAsignar = VariableAlmacenada;
                    candidadTokens++;
                    AgregarTokens(11);
                    candidadTokens++;
                    AgregarTokens(12);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S32(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165 || (letraAnalizar >= 48 && letraAnalizar <= 57) || letraAnalizar == '_')
                {
                    VariableAlmacenada += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S31(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S31(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S32(char letraAnalizar)//D|L
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 48 && letraAnalizar <= 57))
                {
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S33(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165)
                {
                    VariableAlmacenada = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S34(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S32(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S33(char letraAnalizar)//D|S|;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '+' || letraAnalizar == '-' || letraAnalizar == '*' || letraAnalizar == '/' || letraAnalizar == '^')
                {
                    CadenaOperaciones[NumeroOperaciones] = NumeroAlmacenado;
                    NumeroOperaciones++;
                    candidadTokens++;
                    AgregarTokens(9);
                    candidadTokens++;
                    if (letraAnalizar == '+')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "+";
                        NumeroOperaciones++;
                        AgregarTokens(13);
                    }
                    else if (letraAnalizar == '-')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "-";
                        NumeroOperaciones++;
                        AgregarTokens(14);
                    }
                    else if (letraAnalizar == '*')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "*";
                        NumeroOperaciones++;
                        AgregarTokens(15);
                    }
                    else if (letraAnalizar == '/')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "/";
                        NumeroOperaciones++;
                        AgregarTokens(18);
                    }
                    else if (letraAnalizar == '^')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "^";
                        NumeroOperaciones++;
                        AgregarTokens(16);
                    }
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S35(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 48 && letraAnalizar <= 57))
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S33(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == ';')
                {
                    CadenaOperaciones[NumeroOperaciones] = NumeroAlmacenado;
                    NumeroOperaciones++;
                    
                    if (NumeroOperaciones == 1)
                    {
                        Variables.Add(new Tuple<string, int>(VariableAsignar, Convert.ToInt32(CadenaOperaciones[0])));
                    }
                    else
                    {
                        Variables.Add(new Tuple<string, int>(VariableAsignar, CalcularNumero()));
                    }
                    candidadTokens++;
                    AgregarTokens(9);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S33(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S34(char letraAnalizar)//L|S|;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == '+' || letraAnalizar == '-' || letraAnalizar == '*' || letraAnalizar == '/' || letraAnalizar == '^')
                {
                    CadenaOperaciones[NumeroOperaciones] = VariableAlmacenada;
                    NumeroOperaciones++;
                    candidadTokens++;
                    AgregarTokens(11);
                    candidadTokens++;
                    if (letraAnalizar == '+')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "+";
                        NumeroOperaciones++;
                        AgregarTokens(13);
                    }
                    else if (letraAnalizar == '-')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "-";
                        NumeroOperaciones++;
                        AgregarTokens(14);
                    }
                    else if (letraAnalizar == '*')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "*";
                        NumeroOperaciones++;
                        AgregarTokens(15);
                    }
                    else if (letraAnalizar == '/')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "/";
                        NumeroOperaciones++;
                        AgregarTokens(18);
                    }
                    else if (letraAnalizar == '^')
                    {
                        CadenaOperaciones[NumeroOperaciones] = "^";
                        NumeroOperaciones++;
                        AgregarTokens(16);
                    }
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S35(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165 || (letraAnalizar >= 48 && letraAnalizar <= 57) || letraAnalizar == '_')
                {
                    VariableAlmacenada += letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S34(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(11);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S34(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S35(char letraAnalizar)//D|L
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 48 && letraAnalizar <= 57))
                {
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S33(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165)
                {
                    VariableAlmacenada = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S34(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S35(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S36(char letraAnalizar)//a|z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    candidadTokens++;
                    AgregarTokens(19);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S37(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S36(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S37(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S38(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S37(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S38(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S39(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S38(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S39(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S40(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S39(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S40(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(20);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S40(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S41(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S42(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S41(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S42(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    candidadTokens++;
                    AgregarTokens(21);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S42(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S43(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S44(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S43(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S44(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S45(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S44(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S45(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S46(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S45(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S46(char letraAnalizar)//d
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S47(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S46(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S47(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S48(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S47(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S48(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(22);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S48(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S49(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S50(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S49(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S50(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S51(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S50(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S51(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S52(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S51(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S52(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S53(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S52(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S53(char letraAnalizar)//I|D
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'I' || letraAnalizar == 'i')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S54(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'd' || letraAnalizar == 'D')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S56(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S53(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S54(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S55(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S54(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S55(char letraAnalizar)//q
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'q' || letraAnalizar == 'Q')
                {
                    candidadTokens++;
                    AgregarTokens(23);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S55(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S56(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S57(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S56(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S57(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(24);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S57(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S58(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S59(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S58(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S59(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(25);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S59(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S60(char letraAnalizar)//x|y|z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    candidadTokens++;
                    AgregarTokens(27);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'y' || letraAnalizar == 'Y')
                {
                    candidadTokens++;
                    AgregarTokens(26);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S61(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S62(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S60(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S61(char letraAnalizar)//q
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'q' || letraAnalizar == 'Q')
                {
                    candidadTokens++;
                    AgregarTokens(28);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S61(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S62(char letraAnalizar)//q
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'x' || letraAnalizar == 'X')
                {
                    candidadTokens++;
                    AgregarTokens(29);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'y' || letraAnalizar == 'Y')
                {
                    candidadTokens++;
                    AgregarTokens(30);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S63(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    posicion_InicialToken = NoFila;
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S66(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S62(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S63(char letraAnalizar)//D|L|R
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar == 'r' || letraAnalizar == 'R'))
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S43(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 48 && letraAnalizar <= 57))
                {
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S64(Letra[posicion_TextoAnalizado]);
                }
                else if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165)
                {
                    VariableAlmacenada = "" + letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S65(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S63(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S64(char letraAnalizar)//D|;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 48 && letraAnalizar <= 57))
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S64(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(9);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S64(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S65(char letraAnalizar)//L|D|_|;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if ((letraAnalizar >= 65 && letraAnalizar <= 90) || (letraAnalizar >= 97 && letraAnalizar <= 122) || letraAnalizar == 164 || letraAnalizar == 165 || (letraAnalizar >= 48 && letraAnalizar <= 57) || letraAnalizar == '_')
                {
                    VariableAlmacenada += letraAnalizar;
                    posicion_InicialToken = NoFila;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S65(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(11);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S65(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S66(char letraAnalizar)//,
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ',')
                {
                    candidadTokens++;
                    AgregarTokens(9);
                    candidadTokens++;
                    AgregarTokens(3);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S67(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S66(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S66(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S67(char letraAnalizar)//#
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    posicion_InicialToken = NoFila;
                    NumeroAlmacenado = "" + letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S68(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S67(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S68(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(9);
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar >= 48 && letraAnalizar <= 57)
                {
                    NumeroAlmacenado += letraAnalizar;
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S68(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S68(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S69(char letraAnalizar)//u|p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'u' || letraAnalizar == 'U')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S70(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S80(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S80(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S70(char letraAnalizar)//b
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'b' || letraAnalizar == 'B')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S71(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S70(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S71(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S72(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S71(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S72(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S73(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S72(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S73(char letraAnalizar)//P
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S74(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S73(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S74(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S75(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S74(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S75(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S76(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S75(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S76(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S77(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S76(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S77(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S78(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S77(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S78(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(32);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S79(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S78(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S79(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S79(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S80(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(33);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S81(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S80(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S81(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S81(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S82(char letraAnalizar)//a|p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S83(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S93(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S82(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S83(char letraAnalizar)//j
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'j' || letraAnalizar == 'j')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S84(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S83(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S84(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S85(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S84(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S85(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S86(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S85(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S86(char letraAnalizar)//P
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S87(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S86(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S87(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S88(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S87(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S88(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S89(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S88(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S89(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S90(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S89(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S90(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S91(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S90(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S91(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(34);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S92(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S91(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S92(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S92(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S93(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(35);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S94(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S93(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S94(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S94(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S95(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(36);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S96(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S97(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S1132(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S148(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S95(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S96(char letraAnalizar)//b|c|a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'b' || letraAnalizar == 'b')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S114(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S120(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S127(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S96(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S97(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S98(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S97(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S98(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S99(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S98(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S99(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S100(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S99(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S100(char letraAnalizar)//l|p
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S101(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'p' || letraAnalizar == 'P')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S107(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S100(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S101(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S102(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S101(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S102(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S103(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S102(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S103(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S104(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S103(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S104(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S105(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S104(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S105(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(37);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S106(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S105(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S106(char letraAnalizar)//b|c|a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'b' || letraAnalizar == 'b')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S114(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S120(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S127(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S106(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S107(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S108(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S107(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S108(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S109(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S108(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S109(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S110(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S109(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S110(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S111(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S110(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S111(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(38);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S112(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S111(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S112(char letraAnalizar)//r|a|n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S135(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S139(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S143(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S112(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S1132(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(36);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S113(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S1132(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S113(char letraAnalizar)//r|a|n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S135(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S139(Letra[posicion_TextoAnalizado]);
                }
                else if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S143(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S113(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S114(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S115(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S114(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S115(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S116(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S115(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S116(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S117(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S116(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S117(char letraAnalizar)//c
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'c' || letraAnalizar == 'C')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S118(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S117(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S118(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    ColorLienzo = 0;
                    candidadTokens++;
                    AgregarTokens(40);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S119(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S118(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S119(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S119(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S120(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S121(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S120(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S121(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S122(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S121(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S122(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S123(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S122(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S123(char letraAnalizar)//s
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 's' || letraAnalizar == 'S')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S124(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S123(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S124(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S125(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S124(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S125(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    ColorLienzo = 1;
                    candidadTokens++;
                    AgregarTokens(41);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S126(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S125(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S126(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S126(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S127(char letraAnalizar)//m
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'm' || letraAnalizar == 'M')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S128(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S127(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S128(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S129(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S128(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S129(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S130(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S129(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S130(char letraAnalizar)//i
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'i' || letraAnalizar == 'I')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S131(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S130(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S131(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S132(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S131(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S132(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S133(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S132(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S133(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    ColorLienzo = 2;
                    candidadTokens++;
                    AgregarTokens(42);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S134(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S133(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S134(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S134(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S135(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'O' || letraAnalizar == 'o')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S136(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S135(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S136(char letraAnalizar)//j
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'j' || letraAnalizar == 'J')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S137(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S136(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S137(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(45);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S138(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S137(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S138(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S138(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S139(char letraAnalizar)//z
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'z' || letraAnalizar == 'Z')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S140(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S139(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S140(char letraAnalizar)//u
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'u' || letraAnalizar == 'U')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S141(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S140(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S141(char letraAnalizar)//l
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'l' || letraAnalizar == 'L')
                {
                    candidadTokens++;
                    AgregarTokens(444);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S142(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S141(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S142(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S142(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S143(char letraAnalizar)//e
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'e' || letraAnalizar == 'E')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S144(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S143(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S144(char letraAnalizar)//g
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'g' || letraAnalizar == 'G')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S145(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S144(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S145(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S146(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S145(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S146(char letraAnalizar)//o
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'o' || letraAnalizar == 'O')
                {
                    candidadTokens++;
                    AgregarTokens(43);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S147(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S146(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S147(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S147(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S148(char letraAnalizar)//n
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'n' || letraAnalizar == 'N')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S149(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S148(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S149(char letraAnalizar)//t
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 't' || letraAnalizar == 'T')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S150(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S149(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S150(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S151(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S150(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S151(char letraAnalizar)//a
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'a' || letraAnalizar == 'A')
                {
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S152(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S151(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S152(char letraAnalizar)//r
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == 'r' || letraAnalizar == 'R')
                {
                    candidadTokens++;
                    AgregarTokens(46);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S153(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S152(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S153(char letraAnalizar)//;
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                if (letraAnalizar == ';')
                {
                    candidadTokens++;
                    AgregarTokens(5);
                    posicion_TextoAnalizado++;
                    NoFila++;
                    S154(Letra[posicion_TextoAnalizado]);
                }
                else
                {
                    LeerEnterEspacioTab(letraAnalizar);
                    S153(Letra[posicion_TextoAnalizado]);
                }
            }
        }
        private void S154(char letraAnalizar)//Finalizar
        {
            if (posicion_TextoAnalizado < tamaño_TextoAnalizar)
            {
                S0(Letra[posicion_TextoAnalizado]);
            }
        }
        private int CalcularNumero()
        {
            String[] temp = new String[100];
            int resultado = 0;
            int posicion = 0;
            int posicionTemp = 0;
            if(NumeroOperaciones > 2)
            {
                do
                {
                    if (CadenaOperaciones[posicion+1].Equals("^"))
                    {
                        resultado = Convert.ToInt32(Math.Pow(Convert.ToInt32(CadenaOperaciones[posicion]), Convert.ToInt32(CadenaOperaciones[posicion+2])));
                        temp[posicionTemp] = Convert.ToString(resultado);
                        NumeroOperaciones -= 2;
                        posicion += 3;
                        posicionTemp++;
                    }else
                    {
                        temp[posicionTemp] = CadenaOperaciones[posicion];
                        posicionTemp++;
                        posicion++;
                    }   
                } while (NumeroOperaciones > 2);
            }
            CadenaOperaciones = temp;
            temp = LimpiarCadena;
            return Convert.ToInt32(CadenaOperaciones[0]);
        }
        
    }
}
