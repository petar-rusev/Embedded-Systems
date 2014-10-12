using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO.Ports;

    class ArduinoTalk:MonoBehaviour
    {
       
            private string portNumber;
            private int baudRate;
            private SerialPort sp;
            public ArduinoTalk(string PortNumber, int BaudRate)
            {
                this.PortNumber = PortNumber;
                this.BaudRate = BaudRate;
                this.Sp = new SerialPort(this.PortNumber, this.BaudRate);

            }
            public SerialPort Sp
            {
                get
                {
                    return this.sp;
                }
                set
                {
                    this.sp = value;
                }
                    
            }
            public string PortNumber
            {
                get
                {
                    return this.portNumber;
                }
                set
                {
                    string pat = @"COM+[0-9]+";
                    Regex reg = new Regex(pat);
                    Match mat = reg.Match(value);
                    if (mat.Success == false)
                    {
                        throw new ArgumentException("Invalid communication port number.");
                    }
                    else
                    {
                        this.portNumber = value;
                    }
                }

            }

            public int BaudRate
            {
                get
                {
                    return this.baudRate;
                }
                set
                {
                    if (value < 9600)
                    {
                        throw new ArgumentException("Invalid Baud Rate argument. The Baud Rate must be greater or equal to 9600.");
                    }
                    else
                    {
                        this.baudRate = value;
                    }
                }
            }
            public override string ToString()
            {
                return string.Format("{0}", this.PortNumber);
            }
            public void OpenPort(SerialPort sp, int ReadTimeOut)
            {
                sp.Open();
                if (ReadTimeOut <= 0)
                {
                    throw new ArgumentException("Invalid ReadTimeOut argument.");
                }
                else
                {
                    sp.ReadTimeout = ReadTimeOut;
                }
            }
            public void PrintPortValue(SerialPort sp)
            {
                if (sp.IsOpen)
                {
                    Console.WriteLine("Value: {0}", sp.ReadByte());
                }
            }
            public int ReadPortValue(SerialPort sp)
            {
                int i = 0;
                if (sp.IsOpen)
                {
                    try
                    {
                        i = sp.ReadByte();
                        print(sp.ReadByte());
                    }
                    catch (SystemException)
                    {

                    }
                   
                }
                return i;
            }
            public void ClosePort(SerialPort sp)
            {
                sp.Close();
            }
        }


