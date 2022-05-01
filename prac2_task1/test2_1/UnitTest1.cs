using NUnit.Framework;
using opd;

namespace test2_1
{
    public class UnitTestMatrixSort
    {
      
        [Test]
        public void TestMinElementFromMin()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(true);
            m1.SetStrategy(new MinElementRow());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 15, 1, 11 }, { 6, 9, 15 }, { 11, 18, 19 }, { 18, 14, 17 }};
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
        [Test]
        public void TestMinElementFromMax()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(false);
            m1.SetStrategy(new MinElementRow());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 18, 14, 17 }, { 11, 18, 19 }, { 6, 9, 15 }, { 15, 1, 11 } };
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
        [Test]
        public void TestMaxElementFromMin()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(true);
            m1.SetStrategy(new MaxElementRow());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 6, 9, 15 }, { 15, 1, 11 }, { 18, 14, 17 }, { 11, 18, 19 }};
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
        [Test]
        public void TestMaxElementFromMax()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(false);
            m1.SetStrategy(new MaxElementRow());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 11, 18, 19 }, { 18, 14, 17 }, { 6, 9, 15 }, { 15, 1, 11 } };
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
        [Test]
        public void TestSumElementFromMin()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(true);
            m1.SetStrategy(new SumElementsRows());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 6, 9, 15 }, { 15, 1, 11 },  { 11, 18, 19 } , { 18, 14, 17 }};
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
        [Test]
        public void TestSumElementFromMax()
        {
            bubSort m1 = new bubSort(4, 3);
            m1.matrix = new int[,] { { 6, 9, 15 }, { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 } };
            m1.SetOrder(false);
            m1.SetStrategy(new SumElementsRows());
            m1.SortSomeArray();
            int[,] m2 = new int[,] { { 18, 14, 17 }, { 11, 18, 19 }, { 15, 1, 11 }, { 6, 9, 15 },  };
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    Assert.AreEqual(m1[i, j], m2[i, j]);
                }
            }
        }
    }
}