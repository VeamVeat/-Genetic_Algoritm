using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace KommivoiazhorGeneticAlgoritm
{

	public partial class Form1 : Form
	{
		public const int N = 30;
		public int Index = 0;
		public List<int> OneBlocksArray;
		GenericMainMatriks genericMainMatriks;
		GeneticAlgoritm geneticAlgoritm;
		Random Random;
		public Form1()
		{
			InitializeComponent();
			Random = new Random();
			OneBlocksArray = new List<int>();
			genericMainMatriks = new GenericMainMatriks(80, N);
			// 1) считываем матрицу городов и матрицу стоимости
			genericMainMatriks.WriteCityInFile();
			genericMainMatriks.WriteMoneyInFile();
			// 2) находим 2 вектора: OneMain и TwoMain
			genericMainMatriks.MinElementOfMatriksMoney();
			//Определяем 2 вектора: OneMain и TwoMain
			geneticAlgoritm = new GeneticAlgoritm(genericMainMatriks.ArrayOneMainVektor,
		    genericMainMatriks.ArrrayTwoMainVektor, genericMainMatriks.MINZnathMatriksMoney);

		}

		
		private void BStartAlgoritm_Click( object sender, EventArgs e )
		{
			Thread thread = new Thread(ThreadShag);
			thread.Start();
		}

		// делаем 3000 шагов и выводим 2 вектора: OneMain and LastOneMain
		public void ThreadShag()
		{
			RecordInFileOneMatriks();
			for (int i = 0; i < 30000; i++)
			{
				//Создаём 2 блока и заполняем матрицу 4 на 30
				geneticAlgoritm.CreateBlockMatricx();
				//Определяем минимальное значение в BlockMatrix и делаем замену векторов
				MinZnathInBlockMatrix();
				this.Invoke(new Action(() =>{ShasTextBoks.Text = (i + 1).ToString();}));
			}
			RecordInFileLastOneMatriks();

		}

		public void MinZnathInBlockMatrix()
		{
			int SumMoney = 0;
			for (int k = 0; k < 4; k++)
			{
				for (int i = 0; i < N - 1; i++)
					SumMoney += genericMainMatriks.MatriksMoney[geneticAlgoritm.BlockMatrix[k, i],
						geneticAlgoritm.BlockMatrix[k, i + 1]];
				OneBlocksArray.Add(SumMoney);
				SumMoney = 0;
			}

			int MIN = OneBlocksArray[0];

			for (int j = 1; j < OneBlocksArray.Count; j++)
			{
				if (OneBlocksArray[j] < MIN)
				{
					MIN = OneBlocksArray[j];
					Index = j;
				}
			}
			OneBlocksArray.Clear();

		
			// Замена векторов
			if (MIN < geneticAlgoritm.MInOneZnah)
			{
				this.Invoke(new Action(() =>
				{
					TwoMain.Text += MIN.ToString();
					TwoMain.Text += Environment.NewLine;

				}));
				geneticAlgoritm.MInOneZnah = MIN;
				for (int i = 0; i < N; i++)
					geneticAlgoritm.OneMainVektor[i] = geneticAlgoritm.BlockMatrix[Index, i];
			}
			else
			{
				for (int i = 0; i < N; i++)
					geneticAlgoritm.TwoMainVektor[i] = geneticAlgoritm.BlockMatrix[Index, i];
			}

		}

		public void RecordInFileOneMatriks()
		{
			for (int i = 0; i < N; i++)
				this.Invoke(new Action(() => { OneMain.Text += ((geneticAlgoritm.OneMainVektor[i]).ToString()) + " ";}));
		}

		public void RecordInFileLastOneMatriks()
		{
			for (int i = 0; i < N; i++)
				this.Invoke(new Action(() => { TwoMain.Text += ((geneticAlgoritm.OneMainVektor[i]).ToString()) + " ";}));
		}
	}

}
