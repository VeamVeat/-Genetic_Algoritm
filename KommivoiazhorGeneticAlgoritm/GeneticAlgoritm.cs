using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace KommivoiazhorGeneticAlgoritm
{
	public class GeneticAlgoritm
	{
		public const int N = 30;
		public int[] OneMainVektor; // первый главный вектор
		public int[] TwoMainVektor; // второй главный вектор
		public List<int> OneBlockArray; // массив индексов первый блок первая сторока
		public List<int> TwoBlockArray;	// массив индексов второй блок вторая строка
		public List<int> DopBlockArray;	// массив индексов второй блок вторая строка
		public int[,] BlockMatrix; //2 блока
		public int MInOneZnah;	// минимальное значение (значение 1 главного вектора)
		public int IndexInBlockMatrix;
		public Random random;

		public GeneticAlgoritm(int [] OneVektor , int [] TwoVektor , int MINznah)
		{
			OneMainVektor = OneVektor;
			TwoMainVektor = TwoVektor;
			MInOneZnah = MINznah;
			BlockMatrix = new int[4, N];
			OneBlockArray = new List<int>();
			TwoBlockArray = new List<int>(); 
			DopBlockArray = new List<int>(); 
			random = new Random();
		}													   

		public void CreateBlockMatricx()
		{
			int PointSection = random.Next(4,27); // Определили точку сечения

			//Создаём первый блок
			for (int j = 0; j < PointSection; j++)
			{
				BlockMatrix[0, j] = OneMainVektor[j];
				BlockMatrix[1, j] = TwoMainVektor[j];
			}

			for (int i = PointSection; i < N; i++)
			{
				BlockMatrix[0, i] = TwoMainVektor[i];
				BlockMatrix[1, i] = OneMainVektor[i];
			}

			//Создаём второй блок
			for (int j = 0; j < OneMainVektor.Length - PointSection; j++)
			{
				BlockMatrix[2, j] = OneMainVektor[PointSection + j];
				BlockMatrix[3, j] = TwoMainVektor[PointSection + j];
			}                            							
			for (int j = OneMainVektor.Length - PointSection; j < OneMainVektor.Length; j++)
			{									
				BlockMatrix[2, j] = TwoMainVektor[PointSection - (OneMainVektor.Length - j)];
				BlockMatrix[3, j] = OneMainVektor[PointSection - (OneMainVektor.Length - j)];
			}

			//делаем замену индексов в первом блоке(0 стр)
			for (int i = 0; i < PointSection; i++)
			{
				for(int j = PointSection; j < OneMainVektor.Length; j++)
				{
					if(BlockMatrix[0,i] == BlockMatrix[0, j])
					{
						OneBlockArray.Add(i);
						DopBlockArray.Add(j);
						break;
					}
				}
			}
			for (int i = 0; i < DopBlockArray.Count; i++)
				OneBlockArray.Add(DopBlockArray[i]);
			DopBlockArray.Clear();

			//делаем замену индексов в первом блоке(1стр)
			for (int i = 0; i < PointSection; i++)
			{
				for (int j = PointSection; j < OneMainVektor.Length; j++)
				{
					if (BlockMatrix[1, i] == BlockMatrix[1, j])
					{
						TwoBlockArray.Add(i);
						DopBlockArray.Add(j);
						break;
					}
				}
			}
			for (int i = 0; i < DopBlockArray.Count; i++)
				TwoBlockArray.Add(DopBlockArray[i]);
			DopBlockArray.Clear();

			int Count = OneBlockArray.Count;
																									   //	???
			if (Count > TwoBlockArray.Count)
				Count = TwoBlockArray.Count;
			
			for(int i = 0; i < Count; i++)
			{
				int Element = BlockMatrix[0, OneBlockArray[i]];
				BlockMatrix[0, OneBlockArray[i]] = BlockMatrix[1, TwoBlockArray[i]];
				BlockMatrix[1, TwoBlockArray[i]] = Element;
			}
			OneBlockArray.Clear();
			TwoBlockArray.Clear();

			//делаем замену индексов в первом блоке(2стр)
			for (int i = 0; i < OneMainVektor.Length - PointSection; i++)
			{
				for (int j = OneMainVektor.Length - PointSection; j < OneMainVektor.Length; j++)
				{
					if (BlockMatrix[2, i] == BlockMatrix[2, j])
					{
						OneBlockArray.Add(i);
						DopBlockArray.Add(j);
					}
				}
			}
			for (int i = 0; i < DopBlockArray.Count; i++)
				OneBlockArray.Add(DopBlockArray[i]);
			DopBlockArray.Clear();

			//делаем замену индексов в первом блоке(3стр)
			for (int i = 0; i < OneMainVektor.Length - PointSection; i++)
			{
				for (int j = OneMainVektor.Length - PointSection; j < OneMainVektor.Length; j++)
				{
					if (BlockMatrix[3, i] == BlockMatrix[3, j])
					{
						TwoBlockArray.Add(i);
						DopBlockArray.Add(j);
					}
				}
			}
			for (int i = 0; i < DopBlockArray.Count; i++)
				TwoBlockArray.Add(DopBlockArray[i]);
			DopBlockArray.Clear();

			 Count = OneBlockArray.Count;

			if (Count > TwoBlockArray.Count)
				Count = TwoBlockArray.Count;
			
			for (int i = 0; i < Count; i++)
			{
				int Element = BlockMatrix[2, OneBlockArray[i]];
				BlockMatrix[2, OneBlockArray[i]] = BlockMatrix[3, TwoBlockArray[i]];
				BlockMatrix[3, TwoBlockArray[i]] = Element;
			}
			OneBlockArray.Clear();
			TwoBlockArray.Clear();

		}

		// Helper
		public void ReadOneMatrix()
		{
			ReadMatrix("VectorOneMain", 1);
			ReadMatrix("VectorTwoMain", 2);
		}
		public void ReadMatrix(string Nume , int Number)
		{
			StreamReader streamReader = new StreamReader($"{Nume}.txt");

			string[] OneVector = streamReader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			streamReader.Close();
			if (Number == 1)
			{
				for (int i = 0; i < OneVector.Length; i++)
					OneMainVektor[i] = Convert.ToInt32(OneVector[i]);
			}
			else
			{
				for (int i = 0; i < OneVector.Length; i++)
					TwoMainVektor[i] = Convert.ToInt32(OneVector[i]);

			}
			
		}
	}
}
