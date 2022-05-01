namespace opd
{
    public class bubSort
    {
        public int[,] matrix;
        private IStrategy _strategy;
        private bool _order;
        public bubSort(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)//установить стратегию поведения
        {
            this._strategy = strategy;

        }

        public void SetOrder(bool order)//если true то по возрастанию
        {
            this._order = order;
        }

        public void SortSomeArray()
        {
            Console.WriteLine("Результат сортировки матрицы:");

            int[,] result = (int[,])this._strategy.DoneAlgorithm(matrix, _order);

            for (int i = 0; i < result.GetLength(0); i++)//вывод матрицы
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
            matrix = result;
        }

        public bubSort()
        {
            matrix = new int[3, 4];
        }
        public bubSort(int[,] im)
        {
            matrix = im;
        }
        
        public bubSort(int r, int c)
        {
            matrix = new int[r,c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public bubSort(int r, int[] c)
        {
            matrix = new int[r , c.Count()];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c.Count(); j++)
                {
                    matrix[i, j] = c[j];
                }
        }

        public int Rows
        {
            get { return matrix.GetLength(0); }

        }

        public int Columns
        {
            get { return matrix.GetLength(1); }

        }
        public int this[int i, int j]
        {
            get { return matrix[i ,j]; }
            set { matrix[i, j] = value; }
        }

        public int[,] giveMatrix
        {
            get
            {
                return matrix;    // возвращаем значение свойства
            }
            set
            {
                matrix = value;
            }
        }
    }
    public delegate int CheckAlg(int temp, int mtrx);//делегат для обработки каждой стратегии

    public interface IStrategy
    {
        public  object DoneAlgorithm(object data, bool order);//итоговый вариант сортировки, изменяемый в стратегиях

        public static object DoAlgorithm(object data, bool order, CheckAlg checkAlg)//универсальная стратегия сортировки
        {
            int[,] matrix = data as int[,];
            int[] tempSum = new int[matrix.GetLength(0)];
            int[] tempId = new int[matrix.GetLength(0)];
            int tt;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                tempSum[i] = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tempSum[i] = checkAlg(tempSum[i], matrix[i, j]);
                }
                tempId[i] = i;
            }
            for (int i = 0; i + 1 < matrix.GetLength(0); i++)
            {
                for (int j = 0; j + 1 < matrix.GetLength(0) - i; j++)
                {
                    if (((tempSum[j + 1] < tempSum[j]) && order) || ((tempSum[j + 1] > tempSum[j]) && !order))
                    {
                        tt = tempSum[j];
                        tempSum[j] = tempSum[j + 1];
                        tempSum[j + 1] = tt;
                        tt = tempId[j];
                        tempId[j] = tempId[j + 1];
                        tempId[j + 1] = tt;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (tempId[i] != i)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        tt = matrix[tempId[i], j];
                        matrix[tempId[i], j] = matrix[tempId[tempId[i]], j];
                        matrix[tempId[tempId[i]], j] = tt;
                    }
                    tt = tempId[i];
                    tempId[i] = tempId[tt];
                    tempId[tt] = tt;
                    i--;
                }
            }
            return matrix;
        }
    }
    public class SumElementsRows : IStrategy 
    {
        public object DoneAlgorithm(object data, bool order)
        {
            return IStrategy.DoAlgorithm(data, order, tempAction);
        }

        public static int tempAction(int temp, int mtrx)
        {
            return temp += mtrx;
        }
    }

    public class MaxElementRow : IStrategy
    {
        public object DoneAlgorithm(object data, bool order)
        {
            return IStrategy.DoAlgorithm(data, order, tempAction);
        }

        public static int tempAction(int temp, int mtrx)
        {
            if (temp < mtrx)
            {
                return  mtrx;
            }
           return temp;
        }
    }

    public class MinElementRow : IStrategy
    {
        public object DoneAlgorithm(object data, bool order)
        {
            return IStrategy.DoAlgorithm(data, order, tempAction);
        }

        public static int tempAction(int temp, int mtrx)
        {
            if (temp > mtrx)
            {
                return mtrx;
            }
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();

            bubSort mtrx = new bubSort(4,3);
            for (int i = 0; i < mtrx.Rows; i++)
            {
                for (int j = 0; j < mtrx.Columns; j++)
                {
                    mtrx[i, j] = rnd.Next(20);
                }
            }
            Console.WriteLine("Входная матрица");
            for (int i = 0; i < mtrx.Rows; i++)
            {
                for (int j = 0; j < mtrx.Columns; j++)
                {
                    Console.Write(mtrx[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Выберите способ сортировки:");
            Console.WriteLine("1 - В порядке возрастания сумм элементов строк матрицы\n2 - В порядке убывания сумм элементов строк матрицы\n3 - По возрастанию максимального элемента в строке матрицы\n4 - По убыванию максимального элемента в строке матрицы\n5 - В порядке возрастания  минимального элемента в строке матрицы\n6 - В порядке убывания минимального элемента в строке матрицы");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    mtrx.SetStrategy(new SumElementsRows());
                    mtrx.SetOrder(true);
                    mtrx.SortSomeArray();
                    break;
                case ConsoleKey.D2:
                    mtrx.SetStrategy(new SumElementsRows());
                    mtrx.SetOrder(false);
                    mtrx.SortSomeArray();
                    break;
                case ConsoleKey.D3:
                    mtrx.SetStrategy(new MaxElementRow());
                    mtrx.SetOrder(true);
                    mtrx.SortSomeArray();
                    break;
                case ConsoleKey.D4:
                    mtrx.SetStrategy(new MaxElementRow());
                    mtrx.SetOrder(false);
                    mtrx.SortSomeArray();
                    break;
                case ConsoleKey.D5:
                    mtrx.SetStrategy(new MinElementRow());
                    mtrx.SetOrder(true);
                    mtrx.SortSomeArray();
                    break;
                case ConsoleKey.D6:
                    mtrx.SetStrategy(new MinElementRow());
                    mtrx.SetOrder(false);
                    mtrx.SortSomeArray();
                    break;
                default:
                    Console.WriteLine("ошибка ввода");
                    break;
            }
        }
    }
}