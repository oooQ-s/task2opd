using NUnit.Framework;
using lab2_2;
namespace test2_2
{
    public class Tests
    {

        [Test]
        public void ChangeDelay()
        {
            int delay = 5;
            Subscriber1 sb = new Subscriber1(delay);
            Assert.AreEqual(5, sb._delay);
        }
        [Test]

        public void UpdateCountSub1()
        {
            int count = 1;
            Subscriber1 sb = new Subscriber1(2);
            CountDown cd = new CountDown();
            cd.Attach(sb);
            cd.CountDownEvent();
            Assert.AreEqual(count, sb._count);
            
        }
        [Test]

        public void UpdateCountSub3()
        {
            int count = 3;
            Subscriber3 sb = new Subscriber3(1);
            CountDown cd = new CountDown();
            cd.Attach(sb);
            cd.CountDownEvent();
            Assert.AreEqual(count, sb._count);
        }
        [Test]
        public void UpdateSub1()
        {
            int delay = 1;
            Subscriber1 sb = new Subscriber1(delay);
            CountDown cd = new CountDown();
            sb.Update(cd, delay+4, 1);
            Assert.AreEqual(sb._delay, delay);
        }
        [Test]
        public void AttachDetachCountDown()
        {
            Subscriber1 sb = new Subscriber1(1);
            CountDown cd = new CountDown();
            cd.Attach(sb);
            cd.Detach(sb);
            Assert.Pass();
        }
    }
}