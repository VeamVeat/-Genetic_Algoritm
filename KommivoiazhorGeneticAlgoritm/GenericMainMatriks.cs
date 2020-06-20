using System;
using System.Diagnostics;
using System.IO;

namespace KommivoiazhorGeneticAlgoritm
{
	public class GenericMainMatriks
	{
		public int A;
		public int B;
		public int Index;
		public int MINZnathMatriksMoney;
		public int[,] MatriksCity;
		public int[,] MatriksMoney;
		public int[] ArrrayTwoMainVektor;
		public int[] ArrayOneMainVektor;
		public int[] MatriksMoneyOfOneCitiInTwoCity;
		public Random random;
		

		public GenericMainMatriks( int a, int b )
		{
			A = a;
			B = b;
			MINZnathMatriksMoney = 0;
			MatriksCity = new int[A, B];
			MatriksMoney = new int[B + 1, B + 1];
			MatriksMoneyOfOneCitiInTwoCity = new int[A];
			ArrrayTwoMainVektor = new int[30];
			ArrayOneMainVektor = new int[30];
			random = new Random();
			
		}

		//Запись городов в файл
		public void WriteCityInFile()
		{
			int Number;
			StreamWriter streamWriter = new StreamWriter(@"MatriksSity.txt");
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					Number = random.Next(0, 31);
					while (MatchesCity(i, Number) == false)
						Number = random.Next(0, 31);

					MatriksCity[i, j] = Number;
					 
					streamWriter.Write(Number.ToString() + " ");
				}
				streamWriter.WriteLine();
			}
			streamWriter.Close();
			Process.Start(@"MatriksSity.txt");
		}

		// Запись стоимости в файл
		public void WriteMoneyInFile()
		{
			int Number;
			StreamWriter streamWriter = new StreamWriter(@"MatriksManey.txt");
			for (int i = 1; i < B + 1; i++)
			{
				for (int j = 1; j < B + 1; j++)
				{
					Number = random.Next(0, 40);
					while (MatchesMoney(i, Number) == false)
						Number = random.Next(0, 40);
					MatriksMoney[i, j] = Number;
					if (i == j)
					{
						Number = 40;
						MatriksMoney[i, j] = Number;
					}
					streamWriter.Write(Number.ToString() + " ");
				}
				streamWriter.WriteLine();
			}
			streamWriter.Close();
			Process.Start(@"MatriksManey.txt");
		}

		// Проверка на наличие того повторяется ли элемент в строке(матрица городов)
		public bool MatchesCity( int OneString, int Number )
		{
			bool h = false;
			for (int i = 0; i < B; i++)
			{
				if (MatriksCity[OneString, i] == Number)
				{
					h = false;
					break;
				}
				else
					h = true;

			}
			return h;
		}
		// проверка на наличие того поторяется ли элемент в строке(матрица стоимости) ?
		public bool MatchesMoney( int OneString, int Number )
		{
			bool h = false;
			for (int i = 0; i < B; i++)
			{
				if (MatriksMoney[OneString, i] == Number)
				{
					h = false;
					break;
				}
				else
					h = true;

			}
			return h;
		}

		// Считывем матрицу городов и матрицу стоимости
		public void GenerationMatriksCityAndMoney()
		{
			// матрица городов
			StreamReader streamReaderCity = new StreamReader(@"MatriksSity.txt");
			for (int i = 0; i < A; i++)
			{
				string[] Numbers = streamReaderCity.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < Numbers.Length; j++)
					MatriksCity[i, j] = Convert.ToInt32(Numbers[j]);
			}
			streamReaderCity.Close();

			// матрица стоимости
			StreamReader streamReaderMoney = new StreamReader(@"MatriksManey.txt");
			for (int i = 0; i < B; i++)
			{
				string[] Numbers = streamReaderMoney.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < Numbers.Length; j++)
					MatriksMoney[i, j] = Convert.ToInt32(Numbers[j]);
			}
			streamReaderMoney.Close();
		}

		// Считаем стоимость из одного города в другой
		public void MoneyOneCituInTwoCityOfMatriksCity()
		{
			int SumMoney = 0;
			for(int k = 0; k < A; k++)
			{
				for (int i = 0; i < B - 1; i++)
					SumMoney += MatriksMoney[MatriksCity[k, i], MatriksCity[k, i + 1]];
				MatriksMoneyOfOneCitiInTwoCity[k] = SumMoney;
				SumMoney = 0;
			}
			
		}

		// Выбираем Min элемент из 30 элементов стоимости и записываем в OneMainVektor и определяем второй вектов TwoMain
		public void MinElementOfMatriksMoney()
		{
			MoneyOneCituInTwoCityOfMatriksCity();
			int MIN = MatriksMoneyOfOneCitiInTwoCity[0];
			
			for(int i = 1; i < MatriksMoneyOfOneCitiInTwoCity.Length; i++)
			{
				if (MatriksMoneyOfOneCitiInTwoCity[i] < MIN)
				{
					MIN = MatriksMoneyOfOneCitiInTwoCity[i];
					Index = i;
				}
			}
			MINZnathMatriksMoney = MIN;

			////Сохраняем вектор OneMain
			for (int i = 0; i < B; i++)
				ArrayOneMainVektor[i] = MatriksCity[Index, i];

			//// Вычисляем второй вектор TwoMain
			int IndexForTwomainVektor = RandomElementOfMatriksMoney(Index);

			////Сохраняем вектор TwoMain
			for (int i = 0; i < B; i++)
				ArrrayTwoMainVektor[i] = MatriksCity[IndexForTwomainVektor, i];

			//Записываем в файл вектор OneMain
			WriteOneMainVektor();
			//Записываем в файл вектор TwoMain
			WriteTwoMainVektor();

		}



		// Выбираем рандомный элемент из 30 элемнтов стоимоти исключаю Min элемент(OneMainVektor) и записываем в TwoMainVektor
		public int  RandomElementOfMatriksMoney(int Index)
		{
			int Rezult = random.Next(0, 80);
			while(Rezult == Index)
				Rezult = random.Next(0, 80);
			return Rezult;
		}

		//запись в файл вектора OneMain
		public void WriteOneMainVektor()
		{
			StreamWriter streamWriter = new StreamWriter(@"VectorOneMain.txt");
			for (int i = 0; i < B; i++)
				streamWriter.Write(ArrayOneMainVektor[i].ToString() + " ");
			streamWriter.Close();

		}

		//запись в файл вектора TwoMain
		public void WriteTwoMainVektor()
		{
			StreamWriter streamWriter = new StreamWriter(@"VectorTwoMain.txt");
			for (int i = 0; i < B; i++)
				streamWriter.Write(ArrrayTwoMainVektor[i].ToString() + " ");
			streamWriter.Close();

		}

	}
}
